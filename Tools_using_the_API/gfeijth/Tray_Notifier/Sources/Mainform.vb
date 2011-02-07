Option Strict On
Option Explicit On

Imports System.Xml

Public Class Mainform

#Region " Membervars "
    Private Const _balloonShowTime As Integer = 3
    Private _balloonLastTime As DateTime = DateTime.Now.AddSeconds(_balloonShowTime * -1)
    Private _errorIcon As Boolean = False
    Private _frmAlarms As Alarms
    Private _alarms As New AlarmsData.CurrentAlarmsDataTable
    Private _lastAlarms As New AlarmsData.CurrentAlarmsDataTable
    Private _ackAlarms As New AlarmsData.CurrentAlarmsDataTable
    Private _alarmCount As Integer = 0
    Private _pausedCount As Integer = 0
    Private _warningCount As Integer = 0
    Private _state As State = State.Idle
    Private _readXML As New ReadXML
    Private _lastError As Exception = Nothing
    Private _timeOutCount As Integer = 0
    Private _soundPlayed As Boolean
#End Region

#Region " Constructor "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Initialize()

    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If niStatus IsNot Nothing Then
                With niStatus
                    .Visible = False
                    .Dispose()
                    .Visible = Nothing
                End With
            End If
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

#End Region

#Region " Enums "
    Private Enum State
        Idle
        urlStatus
        urlAlarms
    End Enum
#End Region

#Region " Methods "
    Private Sub Initialize()
        CheckSettingsUpgrade()

        AddHandler _readXML.WebResult, AddressOf xmlReceived

        niStatus.Icon = My.Resources.prtg
        Me.Hide()
        Me.ShowInTaskbar = False

        If My.Settings.Username = String.Empty OrElse My.Settings.Server = String.Empty Then
            UpdateStatus("Invalid settings")
            BlinkIcon(True)
            Settings()
        Else
            UpdateStatus("")
            StartRefreshAlarms(True)
        End If

        Globals.CheckRegistration()
    End Sub

    ''' <summary>
    ''' Upgrade my.settings is a new version of the application is launched
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckSettingsUpgrade()
        If My.Settings.CallUpgrade Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = False
            My.Settings.Save()
        End If
    End Sub


    ''' <summary>
    ''' Callback from a http request
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Private Delegate Sub xmlReceivedDelegate(ByVal doc As XmlDocument, ByVal ex As Exception)
    Private Sub xmlReceived(ByVal doc As Xml.XmlDocument, ByVal ex As Exception)
        If InvokeRequired Then
            Invoke(New xmlReceivedDelegate(AddressOf xmlReceived), New Object() {doc, ex})
            Return
        End If
        If ex IsNot Nothing Then
            '//GF test for timeout exception
            Try
                Throw ex
            Catch tex As TimeoutException
                _timeOutCount += 1
            Catch gex As Exception
                _timeOutCount = 0
            End Try
        Else
            _timeOutCount = 0
        End If

        Try
            If ex IsNot Nothing Then
                If ex IsNot _lastError AndAlso (_timeOutCount = 0 Or _timeOutCount > 1) Then
                    UpdateStatus(ex.Message)
                    ShowBalloonTip()
                    BlinkIcon(True)
                End If
                _state = State.Idle
            Else
                Select Case _state
                    Case State.urlStatus
                        ReadStatus(doc)
                    Case State.urlAlarms
                        Readalarms(doc)
                End Select

            End If
            _lastError = ex
        Catch
            _state = State.Idle
        End Try
    End Sub

    Private Sub ReadStatus(ByVal doc As XmlDocument)
        Dim node As XmlNode = doc.SelectSingleNode("//status/Version")
        If Not node Is Nothing Then Globals.PRTGversion = node.InnerText

        _state = State.urlAlarms
        _readXML.SendRequest(Globals.urlAlarms)
    End Sub


    Private Sub Readalarms(ByVal doc As Xml.XmlDocument)
        '//GF update the lastalarms dataset
        _lastAlarms.Clear()
        For Each row As AlarmsData.CurrentAlarmsRow In _alarms
            _lastAlarms.ImportRow(row)
        Next

        Dim HasAlarm As Boolean = False

        _alarms.Clear()
        For Each node As XmlNode In doc.SelectNodes("//sensors/item")
            Dim row As Data.DataRow = _alarms.NewRow
            Dim value As String = ""
            '//GF give downsec an initial value, as not every status has a "downfor_RAW" node
            Dim downSec As Integer = My.Settings.DownLatency

            '//GF read all nodes into the dataset
            For i As Integer = 0 To node.ChildNodes.Count - 1
                value = System.Web.HttpUtility.HtmlDecode(node.ChildNodes(i).InnerXml.Trim)
                Select Case node.ChildNodes(i).Name
                    Case "id"
                        row.Item(_alarms.ObjIdColumn.ColumnName) = value
                    Case "group"
                        row.Item(_alarms.GroupColumn.ColumnName) = value
                    Case "device"
                        row.Item(_alarms.DeviceColumn.ColumnName) = value
                    Case "sensor"
                        row.Item(_alarms.SensorColumn.ColumnName) = value
                    Case "status"
                        row.Item(_alarms.StatusColumn.ColumnName) = value
                    Case "message"
                        row.Item(_alarms.MessageColumn.ColumnName) = value
                    Case "status_RAW"
                        row.Item(_alarms.StatusRawColumn.ColumnName) = value
                    Case "downfor"
                        row.Item(_alarms.DownForColumn.ColumnName) = value
                    Case "downfor_RAW"
                        If Integer.TryParse(value, downSec) Then
                            downSec = CInt(value)
                        End If
                End Select
            Next
            If downSec >= My.Settings.DownLatency AndAlso (Globals.Registered Or CInt(row.Item(_alarms.StatusRawColumn.ColumnName)) = Globals.SensorStatus.Alarms) Then
                If CInt(row.Item(_alarms.StatusRawColumn.ColumnName)) = Globals.SensorStatus.Alarms Then
                    HasAlarm = True
                End If
                _alarms.Rows.Add(row)
            End If
        Next

        '//GF remove 'paused by dependency' if there is no alarm condition in the dataset, this can be caused by the DownLatency time.
        If Not HasAlarm Then
            RemovePausedByDependency()
        End If

        _alarmCount = 0
        _pausedCount = 0
        _warningCount = 0

        '//GF update paused status to 'paused by user' or 'paused by dependency' and update counters
        For Each row As DataRow In _alarms
            Select Case CInt(row.Item(_alarms.StatusRawColumn.ColumnName))
                Case CInt(Globals.SensorStatus.Paused_By_User), CInt(Globals.SensorStatus.Paused_By_Dependency), _
                     CInt(Globals.SensorStatus.Paused_By_Licence), CInt(Globals.SensorStatus.Paused_By_Schedule), _
                     CInt(Globals.SensorStatus.Paused_Until)
                    row.Item(_alarms.StatusColumn.ColumnName) = row.Item(_alarms.MessageColumn.ColumnName)
                    _pausedCount += 1
                Case CInt(Globals.SensorStatus.Warning)
                    row.Item(_alarms.StatusColumn.ColumnName) = row.Item(_alarms.MessageColumn.ColumnName)
                    _warningCount += 1
                Case CInt(Globals.SensorStatus.Alarms)
                    row.Item(_alarms.StatusColumn.ColumnName) = String.Format("{0} {1}", row.Item(_alarms.StatusColumn.ColumnName), row.Item(_alarms.DownForColumn.ColumnName))
                    _alarmCount += 1
            End Select
        Next

        NotifyUser()

        _state = State.Idle
    End Sub

    ''' <summary>
    ''' Make alarms visible to the user
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NotifyUser()
        '//GF update notification status
        Dim status As String = String.Format("Alarms: {0}", _alarmCount)
        If _pausedCount > 0 Then
            status = String.Format("{0}{1}Paused: {2}", status, Environment.NewLine, _pausedCount)
        End If
        If _warningCount > 0 Then
            status = String.Format("{0}{1}Warnings: {2}", status, Environment.NewLine, _warningCount)
        End If
        UpdateStatus(status)

        If _alarmCount = 0 AndAlso _pausedCount = 0 Then
            _ackAlarms.Clear()
        End If

        If _frmAlarms IsNot Nothing AndAlso Not _frmAlarms.IsDisposed Then
            _frmAlarms.ShowAlarms(_alarms)
        End If

        BlinkIcon(_alarmCount > 0 AndAlso Not AlarmCompare(_alarms, _ackAlarms))

        If My.Settings.AutoPopup Then
            If _alarmCount > 0 AndAlso Not AlarmCompare(_alarms, _lastAlarms) AndAlso (_frmAlarms Is Nothing OrElse _frmAlarms.IsDisposed) Then
                '//GF popup alarms window
                ShowAlarms(False)
            End If
        Else
            If (_frmAlarms Is Nothing OrElse _frmAlarms.IsDisposed) AndAlso _alarmCount > 0 AndAlso Not AlarmCompare(_alarms, _lastAlarms) Then
                ShowBalloonTip()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Removes all 'paused by dependency' rows from the _alarms dataset
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemovePausedByDependency()
        Dim deleteRows As New List(Of DataRow)

        For Each row As DataRow In _alarms
            If CInt(row.Item(_alarms.StatusRawColumn.ColumnName)) = Globals.SensorStatus.Paused_By_Dependency Then
                deleteRows.Add(row)
            End If
        Next
        For Each row As DataRow In deleteRows
            _alarms.Rows.Remove(row)
        Next
    End Sub

    ''' <summary>
    ''' Sets the text in the balloontip
    ''' </summary>
    ''' <param name="myText"></param>
    ''' <remarks></remarks>
    Private Sub UpdateStatus(ByVal myText As String)
        niStatus.BalloonTipText = String.Format("{0}{2}{0}{0}{1}", Environment.NewLine, "(Right click for menu)", myText)
    End Sub

    ''' <summary>
    ''' Starts or stops the icon blinking
    ''' </summary>
    ''' <param name="blink"></param>
    ''' <remarks></remarks>
    Private Sub BlinkIcon(ByVal blink As Boolean)
        tmrBlink.Enabled = blink
        playsound(blink)
        If Not blink Then niStatus.Icon = My.Resources.prtg
    End Sub

    ''' <summary>
    ''' Play's a sound
    ''' </summary>
    ''' <param name="play"></param>
    ''' <remarks></remarks>
    Private Sub playsound(ByVal play As Boolean)
        If play AndAlso Not _soundPlayed Then
            If My.Settings.PlaySound AndAlso System.IO.File.Exists(My.Settings.SoundFile) Then
                My.Computer.Audio.Play(My.Settings.SoundFile)
            End If
        End If
        _soundPlayed = play
    End Sub

    ''' <summary>
    ''' Shows the alarms form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowAlarms(ByVal manual As Boolean)
        If _frmAlarms Is Nothing OrElse _frmAlarms.IsDisposed Then
            _frmAlarms = New Alarms(_alarms)
            AddHandler _frmAlarms.FormClosed, AddressOf frmAlarmsClose
            AddHandler _frmAlarms.StopRefreshStatus, AddressOf StopRefreshAlarms
            AddHandler _frmAlarms.StartRefreshStatus, AddressOf StartRefreshAlarms
        End If
        _frmAlarms.ShowForm(manual)
    End Sub

    ''' <summary>
    ''' Shows the settings form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Settings()
        Dim f As New Settings

        If _frmAlarms IsNot Nothing AndAlso Not _frmAlarms.IsDisposed Then
            '//GF stop the refresh counter on the alarms form
            _frmAlarms.RefreshTime = False
            '//GF centralize form on frmAlarms
            f.StartPosition = FormStartPosition.Manual
            f.Left = _frmAlarms.Left + ((_frmAlarms.Width - f.Width) \ 2)
            f.Top = _frmAlarms.Top + ((_frmAlarms.Height - f.Height) \ 2)
        Else
            f.StartPosition = FormStartPosition.CenterScreen
        End If
        '//GF stop refreshing the alarms
        StopRefreshAlarms()

        f.ShowDialog()
        If My.Settings.Server = String.Empty OrElse My.Settings.Username = String.Empty Then
            StartRefreshAlarms(False)
        Else
            StartRefreshAlarms(True)
        End If
        f.Dispose()

        If _frmAlarms IsNot Nothing AndAlso Not _frmAlarms.IsDisposed Then
            '//GF start the refresh counter on the alarms form
            _frmAlarms.RefreshTime = True
        End If
    End Sub

    ''' <summary>
    ''' Alarms form closed, set all the alarms as acknowledged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmAlarmsClose(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        _ackAlarms.Clear()
        For Each row As AlarmsData.CurrentAlarmsRow In _alarms
            _ackAlarms.ImportRow(row)
        Next
        BlinkIcon(False)
    End Sub

    ''' <summary>
    ''' Stop getting alarms from the server
    ''' </summary>
    ''' <remarks></remarks>
    Private Delegate Sub StopRefreshAlarmsDelegate()
    Private Sub StopRefreshAlarms()
        If InvokeRequired Then
            Invoke(New StopRefreshAlarmsDelegate(AddressOf StopRefreshAlarms))
            Return
        End If
        tmrRefreshStatus.Enabled = False
    End Sub

    ''' <summary>
    ''' Start getting alarms from the server
    ''' </summary>
    ''' <param name="change"></param>
    ''' <param name="refreshTime"></param>
    ''' <remarks></remarks>
    Private Delegate Sub StartRefreshAlarmsDelegate(ByVal change As Boolean, ByVal refreshTime As Integer)
    Private Sub StartRefreshAlarms(ByVal change As Boolean, Optional ByVal refreshTime As Integer = 10)
        If InvokeRequired Then
            Invoke(New StartRefreshAlarmsDelegate(AddressOf StartRefreshAlarms), New Object() {change, refreshTime})
            Return
        End If
        If change Then
            tmrRefreshStatus.Interval = refreshTime
        End If
        tmrRefreshStatus.Enabled = True
    End Sub

    ''' <summary>
    ''' Show or hide the balloontip
    ''' </summary>
    ''' <param name="showSeconds"></param>
    ''' <remarks></remarks>
    Private Sub ShowBalloonTip(Optional ByVal showSeconds As Integer = _balloonShowTime)
        niStatus.BalloonTipTitle = "TrayNotifier"
        If Not Globals.Registered Then
            niStatus.BalloonTipTitle = "TrayNotifier (unregistered)"
        End If
        If showSeconds = 0 Then
            '//GF toggle visebility to force balloon to hide
            niStatus.Visible = False
            niStatus.Visible = True
        ElseIf _balloonLastTime < DateTime.Now.AddSeconds(showSeconds * -1) Then
            _balloonLastTime = DateTime.Now
            If Not niStatus.BalloonTipText = String.Empty Then
                niStatus.ShowBalloonTip(showSeconds * 1000)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Compares two alarm datatables
    ''' </summary>
    ''' <param name="dt1"></param>
    ''' <param name="dt2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AlarmCompare(ByVal dt1 As AlarmsData.CurrentAlarmsDataTable, ByVal dt2 As AlarmsData.CurrentAlarmsDataTable) As Boolean
        Dim blnFound As Boolean = False

        For i As Integer = 0 To dt1.Rows.Count - 1
            '//GF only compare alarm conditions
            If CInt(dt1.Rows(i).Item(dt1.StatusRawColumn.ColumnName)) = Globals.SensorStatus.Alarms Then
                blnFound = False
                For x As Integer = 0 To dt2.Rows.Count - 1
                    If CStr(dt1.Rows(i).Item(dt1.ObjIdColumn.ColumnName)) = CStr(dt2.Rows(x).Item(dt2.ObjIdColumn.ColumnName)) AndAlso _
                        CStr(dt1.Rows(i).Item(dt1.StatusRawColumn.ColumnName)) = CStr(dt2.Rows(x).Item(dt1.StatusRawColumn.ColumnName)) Then
                        blnFound = True
                        Exit For
                    End If
                Next
                If Not blnFound Then Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region " Event Handlers "
    Private Sub niStatus_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niStatus.MouseClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                ShowAlarms(True)
            Case Windows.Forms.MouseButtons.Right
                niStatus.BalloonTipText = ""
        End Select
    End Sub

    Private Sub niStatus_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niStatus.MouseMove
        ShowBalloonTip()
    End Sub

    Private Sub niStatus_BalloonTipClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles niStatus.BalloonTipClosed
        tmrHideBalloon.Enabled = False
        _balloonLastTime = DateTime.Now.AddSeconds(_balloonShowTime * -1)
    End Sub

    Private Sub niStatus_BalloonTipShown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles niStatus.BalloonTipShown
        tmrHideBalloon.Interval = (_balloonShowTime * 4) * 1000
        tmrHideBalloon.Enabled = True
    End Sub

    Private Sub cmsStatus_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsStatus.Opening
        miRegister.Visible = Not Globals.Registered
    End Sub

    Private Sub miSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSettings.Click
        Settings()
    End Sub

    Private Sub miAlarms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSensors.Click
        ShowAlarms(True)
    End Sub

    Private Sub miHomepage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miHomepage.Click
        Process.Start(Globals.urlHomePage)
    End Sub

    Private Sub miExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miExit.Click
        MyBase.Close()
    End Sub

    Private Sub miAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAbout.Click
        Dim f As New About
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub miRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRegister.Click
        Dim f As New Register
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub miCheckNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCheckNow.Click
        StartRefreshAlarms(True)
    End Sub


#Region " Timers "
    ''' <summary>
    ''' Gets the current alarms from the server
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrRefreshStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshStatus.Tick
        Try
            tmrRefreshStatus.Enabled = False
            If My.Settings.RefreshTime < 10 Then
                tmrRefreshStatus.Interval = 10000
            Else
                tmrRefreshStatus.Interval = My.Settings.RefreshTime * 1000
            End If

            If _state = State.Idle Then
                If Globals.PRTGversion = "" Then
                    _state = State.urlStatus
                    _readXML.SendRequest(Globals.urlStatus)
                Else
                    _state = State.urlAlarms
                    _readXML.SendRequest(Globals.urlAlarms)
                End If
            End If
        Finally
            tmrRefreshStatus.Enabled = True
        End Try
    End Sub

    ''' <summary>
    ''' Hides the balloontip
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrHideBalloon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHideBalloon.Tick
        tmrHideBalloon.Enabled = False
        ShowBalloonTip(0)
    End Sub

    ''' <summary>
    ''' Blinks the tray icon
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        _errorIcon = Not _errorIcon
        If _errorIcon Then
            niStatus.Icon = My.Resources.dot_red
        Else
            niStatus.Icon = My.Resources.prtg
        End If
    End Sub
#End Region

#End Region

End Class
