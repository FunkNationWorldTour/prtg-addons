Imports System.Xml

Public Class Alarms

#Region " Fields "
    Private _alarms As New AlarmsData.CurrentAlarmsDataTable
    Private _lastUpdate As DateTime
    Private _orgFont As Font
    Private _boldFont As Font
    Private _dv As New DataView
    Private _Request As Request = Request.None
    Private _objId As Integer
    Private _readXML As New ReadXML
    Private _orgText As String = ""
    Private _manual As Boolean = False
#End Region

#Region " Events "
    Public Event StopRefreshStatus()
    Public Event StartRefreshStatus(ByVal change As Boolean, ByVal refreshTime As Integer)
#End Region

#Region " Enums "
    Private Enum Request
        None
        Pause
        [Resume]
        ScanNow
    End Enum
#End Region

#Region " Constructor "
    Public Sub New(ByVal Alarms As AlarmsData.CurrentAlarmsDataTable)
        If My.Settings.AlarmsHeight = 0 Then
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Initialize()
        ShowAlarms(Alarms)
    End Sub
#End Region

#Region " Methods "
    Public Property RefreshTime() As Boolean
        Get
            Return tmrLastCheck.Enabled
        End Get
        Set(ByVal value As Boolean)
            tmrLastCheck.Enabled = value
        End Set
    End Property

    Public Sub ShowForm(ByVal manual As Boolean)
        _manual = manual
        Me.Show()
    End Sub

    Private Sub Initialize()
        AddHandler _readXML.WebResult, AddressOf xmlReceived
        lblSettings.Image = My.Resources.properties

        If Not Globals.Registered Then
            _orgText = Me.Text
            Me.Text &= " (unregistered)"
        End If
        lblRegister.Visible = Not Globals.Registered

        _orgFont = New Font(rbAlarms.Font, FontStyle.Regular)
        _boldFont = New Font(_orgFont, FontStyle.Bold)

        _dv.Table = _alarms

        dgAlarms.AutoGenerateColumns = False
        dgAlarms.DataSource = _dv
        With My.Settings
            If .colDeviceWidth > 0 Then dgAlarms.Columns(colDevice.Name).Width = .colDeviceWidth
            If .colGroupWidth > 0 Then dgAlarms.Columns(colGroup.Name).Width = .colGroupWidth
            If .colSensorWidth > 0 Then dgAlarms.Columns(colSensor.Name).Width = .colSensorWidth
            If .colStatusWidth > 0 Then dgAlarms.Columns(colStatus.Name).Width = .colStatusWidth
        End With
    End Sub

    ''' <summary>
    ''' Callback from a http request
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Private Delegate Sub xmlReceivedDelegate(ByVal doc As XmlDocument, ByVal ex As Exception)
    Private Sub xmlReceived(ByVal doc As XmlDocument, ByVal ex As Exception)
        If InvokeRequired Then
            Invoke(New xmlReceivedDelegate(AddressOf xmlReceived), New Object() {doc, ex})
            Return
        End If
        Cursor = Cursors.Default
        If ex IsNot Nothing Then
            Select Case _Request
                Case Request.Pause
                    MessageBox.Show(ex.Message, "Error pausing sensor", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Request.Resume
                    MessageBox.Show(ex.Message, "Error resuming sensor", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Request.ScanNow
                    MessageBox.Show(ex.Message, "Error scanning sensor now", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
            miScanNow.Enabled = True
            miRefreshNow.Enabled = True
        Else
            Select Case _Request
                Case Request.Pause, Request.Resume
                    Dim deleteRows As New List(Of DataRow)

                    For Each row As DataRow In _alarms
                        If CInt(row.Item(_alarms.ObjIdColumn.ColumnName)) = _objId Then
                            deleteRows.Add(row)
                        End If
                    Next
                    RemoveRows(deleteRows)
                Case Request.Resume
                    '
            End Select
            RaiseEvent StartRefreshStatus(True, 3000)
        End If
        _Request = Request.None
    End Sub

    Private Delegate Sub RemoveRowsDelegate(ByVal rows As List(Of DataRow))
    Private Sub RemoveRows(ByVal rows As List(Of DataRow))
        If InvokeRequired Then
            Invoke(New RemoveRowsDelegate(AddressOf RemoveRows), New Object() {rows})
            Return
        End If
        For Each row As DataRow In rows
            _alarms.Rows.Remove(row)
        Next
        SetRadioButtons()
    End Sub


    ''' <summary>
    ''' Updates the grid with recent alarms
    ''' </summary>
    ''' <param name="Alarms"></param>
    ''' <remarks></remarks>
    Private Delegate Sub ShowAlarmsDelegate(ByVal Alarms As AlarmsData.CurrentAlarmsDataTable)
    Public Sub ShowAlarms(ByVal Alarms As AlarmsData.CurrentAlarmsDataTable)
        If InvokeRequired Then
            Me.Invoke(New ShowAlarmsDelegate(AddressOf ShowAlarms), New Object() {Alarms})
            Return
        End If

        Try
            _lastUpdate = DateTime.Now
            miScanNow.Enabled = True
            miRefreshNow.Enabled = True
            tslVersion.Text = String.Format("Network Monitor version: {0}", Globals.PRTGversion)

            '//GF remove binding from grid
            dgAlarms.SuspendLayout()
            _dv.Table.Clear()

            _alarms.Clear()
            For Each row As AlarmsData.CurrentAlarmsRow In Alarms
                _alarms.ImportRow(row)
            Next

            '//GF restore binding to grid
            _dv.Table = _alarms
            dgAlarms.ResumeLayout()

            rbPaused.Enabled = Globals.Registered
            rbWarnings.Enabled = Globals.Registered
            pbHelp.Visible = Not Globals.Registered

            Dim ObjId As Integer = 0
            If dgAlarms.SelectedRows.Count = 1 Then ObjId = GetSelectedId()

            miScanNow.Visible = Not rbPaused.Checked

            SetRadioButtons()

            SetFilter()

            For Each row As DataGridViewRow In dgAlarms.Rows
                If CInt(row.Cells(colObjId.Name).Value) = ObjId Then
                    row.Selected = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            ex = ex
        End Try
    End Sub

    Private Function GetSelectedId() As Integer
        _objId = CInt(dgAlarms.SelectedRows(0).Cells(colObjId.Name).Value)
        Return _objId
    End Function

    Private Function CheckRegistration() As Boolean
        If Not Globals.Registered Then
            MessageBox.Show("This feature is only available in the registered version.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' Sets the radiobuttons color and text
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRadioButtons()
        Dim aantAlarms As Integer = 0
        Dim aantWarning As Integer = 0
        Dim aantPaused As Integer = 0


        For Each row As Data.DataRow In _alarms
            Select Case CInt(row.Item(_alarms.StatusRawColumn.ColumnName))
                Case CInt(Globals.SensorStatus.Alarms)
                    aantAlarms += 1
                Case CInt(Globals.SensorStatus.Warning)
                    aantWarning += 1
                Case CInt(Globals.SensorStatus.Paused_By_Dependency), CInt(Globals.SensorStatus.Paused_By_User), _
                     CInt(Globals.SensorStatus.Paused_By_Licence), CInt(Globals.SensorStatus.Paused_By_Schedule), _
                     CInt(Globals.SensorStatus.Paused_Until)
                    aantPaused += 1
            End Select
        Next

        If My.Settings.AutoHide AndAlso Not _manual AndAlso Me.Visible AndAlso aantAlarms = 0 Then
            Close()
        End If

        With rbAlarms
            .Text = String.Format("Alarms ({0})", aantAlarms)
            If aantAlarms > 0 Then
                .ForeColor = My.Settings.AlarmColor
                .Font = _boldFont
            Else
                .ForeColor = Color.Black
                .Font = _orgFont
            End If
        End With

        With rbWarnings
            .Text = String.Format("Warnings ({0})", aantWarning)
            If aantWarning > 0 Then
                .ForeColor = My.Settings.WarningColor
                .Font = _boldFont
            Else
                .ForeColor = Color.Black
                .Font = _orgFont
            End If
            .Left = rbAlarms.Left + rbAlarms.Width + 10
        End With

        With rbPaused
            .Text = String.Format("Paused ({0})", aantPaused)
            If aantPaused > 0 Then
                .ForeColor = My.Settings.PausedColor
                .Font = _boldFont
            Else
                .ForeColor = Color.Black
                .Font = _orgFont
            End If
            .Left = rbWarnings.Left + rbWarnings.Width + 10
        End With

        pbHelp.Left = rbPaused.Left + rbPaused.Width + 10

        Select Case True
            Case aantAlarms > 0
                If Not rbAlarms.Checked Then rbAlarms.Checked = True
            Case aantWarning > 0
                If Not rbWarnings.Checked Then rbWarnings.Checked = True
            Case aantPaused > 0
                If Not rbPaused.Checked Then rbPaused.Checked = True
        End Select

    End Sub

    ''' <summary>
    ''' Sets datagrid filter and colors according to the user selection
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Delegate Sub SetFilterDelegate()
    Private Sub SetFilter()
        If InvokeRequired Then
            Me.Invoke(New SetFilterDelegate(AddressOf SetFilter))
            Return
        End If
        Dim dt As New AlarmsData.CurrentAlarmsDataTable

        With dgAlarms.DefaultCellStyle
            Select Case True
                Case rbAlarms.Checked
                    _dv.RowFilter = String.Format("{0} = {1}", dt.StatusRawColumn.ColumnName, CInt(Globals.SensorStatus.Alarms))
                    .ForeColor = My.Settings.AlarmColor
                    .SelectionBackColor = My.Settings.AlarmColor
                    miPauseDevice.Text = "Pause sensor"
                Case rbWarnings.Checked
                    _dv.RowFilter = String.Format("{0} = {1}", dt.StatusRawColumn.ColumnName, CInt(Globals.SensorStatus.Warning))
                    .ForeColor = My.Settings.WarningColor
                    .SelectionBackColor = My.Settings.WarningColor
                    miPauseDevice.Text = "Pause sensor"
                Case rbPaused.Checked
                    _dv.RowFilter = String.Format("{0} = {1} Or {0} = {2} Or {0} = {3} Or {0} = {4} Or {0} = {5}" _
                                                  , dt.StatusRawColumn.ColumnName, CInt(Globals.SensorStatus.Paused_By_User) _
                                                  , CInt(Globals.SensorStatus.Paused_By_Dependency) _
                                                  , CInt(Globals.SensorStatus.Paused_By_Licence) _
                                                  , CInt(Globals.SensorStatus.Paused_By_Schedule) _
                                                  , CInt(Globals.SensorStatus.Paused_Until))


                    miPauseDevice.Text = "Resume sensor"
                    .ForeColor = My.Settings.PausedColor
                    .SelectionBackColor = My.Settings.PausedColor
            End Select
        End With

    End Sub

    ''' <summary>
    ''' Starts the default browser and opens the sensor page
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Open()
        If dgAlarms.SelectedRows.Count = 1 Then
            Process.Start(Globals.urlDevicePage(CStr(GetSelectedId())))
        End If
    End Sub

    ''' <summary>
    ''' Pauses or resumes a sensor
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Pause()
        If Not CheckRegistration() Then Return

        If dgAlarms.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Select Case True
                Case rbAlarms.Checked
                    _Request = Alarms.Request.Pause
                    _readXML.SendRequest(Globals.urlPauseDevice(CStr(GetSelectedId())))
                Case rbWarnings.Checked
                    _Request = Alarms.Request.Pause
                    _readXML.SendRequest(Globals.urlPauseDevice(CStr(GetSelectedId())))
                Case rbPaused.Checked
                    _Request = Alarms.Request.Resume
                    _readXML.SendRequest(Globals.urlResumeDevice(CStr(GetSelectedId())))
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Performs a immediate scan on the sensor
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScanNow()
        If dgAlarms.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            miScanNow.Enabled = False

            _Request = Alarms.Request.ScanNow
            _readXML.SendRequest(Globals.urlScanNow(CStr(GetSelectedId())))
        End If
    End Sub

    ''' <summary>
    ''' Gets the last saved formposition
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFormPosition()
        Dim scr As Windows.Forms.Screen() = Screen.AllScreens
        Dim TotalWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim TotalHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        '//GF get total screen width and height
        For Each sc As Screen In scr
            If Not sc.Primary Then
                If sc.Bounds.X > 0 Then TotalWidth += sc.Bounds.Width
                If sc.Bounds.Y > 0 Then TotalHeight += sc.Bounds.Height
            End If
        Next

        With My.Settings
            If .AlarmsHeight > 10 Then
                Me.Height = .AlarmsHeight
            Else
                Me.Height = 10
            End If
            If .AlarmsWidth > 10 Then
                Me.Width = .AlarmsWidth
            Else
                Me.Width = 10
            End If

            '//Gf if working area has changed, ajust form position
            If .AlarmsTop < TotalHeight - Me.Height Then
                Me.Top = .AlarmsTop
            Else
                Me.Top = TotalHeight - Me.Height
            End If

            If .AlarmsLeft < TotalWidth - Me.Width Then
                Me.Left = .AlarmsLeft
            Else
                Me.Left = TotalWidth - Me.Width
            End If
        End With
    End Sub

    ''' <summary>
    ''' Saves the current formposition
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveFormPosition()
        With My.Settings
            .AlarmsTop = Me.Top
            .AlarmsLeft = Me.Left
            .AlarmsHeight = Me.Height
            .AlarmsWidth = Me.Width
            .colDeviceWidth = dgAlarms.Columns(colDevice.Name).Width
            .colGroupWidth = dgAlarms.Columns(colGroup.Name).Width
            .colSensorWidth = dgAlarms.Columns(colSensor.Name).Width
            .colStatusWidth = dgAlarms.Columns(colStatus.Name).Width
            .Save()
        End With
    End Sub

    ''' <summary>
    ''' Change the program settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Settings()
        Dim f As New Settings
        RaiseEvent StopRefreshStatus()
        tmrLastCheck.Enabled = False

        f.ShowDialog()
        If My.Settings.Server = String.Empty OrElse My.Settings.Username = String.Empty Then
            RaiseEvent StartRefreshStatus(False, 0)
        Else
            RaiseEvent StartRefreshStatus(True, 10)
        End If
        f.Dispose()

        tmrLastCheck.Enabled = True
    End Sub

    ''' <summary>
    ''' Show the registration form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Register()
        Dim f As New Register
        f.ShowDialog()
        f.Dispose()
        lblRegister.Visible = Not Globals.Registered
        If Globals.Registered Then
            ScanNow()
            Me.Text = _orgText
            Dim ff As New About
            ff.Text = "Registration successful"
            ff.ShowDialog()
            ff.Dispose()
        End If
    End Sub
#End Region

#Region " Eventhandlers "
    Private Sub lblSettings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSettings.LinkClicked
        Settings()
    End Sub

    Private Sub lblHomepage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblHomepage.LinkClicked
        Process.Start(Globals.urlHomePage)
    End Sub

    Private Sub lblClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblClose.LinkClicked
        MyBase.Close()
    End Sub

    Private Sub Alarms_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveFormPosition()
    End Sub

    Private Sub Alarms_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition()
    End Sub

    Private Sub ContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlarms.Opening
        e.Cancel = dgAlarms.SelectedRows.Count = 0
    End Sub

    Private Sub dgvAlarms_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgAlarms.DoubleClick, miSensorPage.Click
        Open()
    End Sub

    Private Sub miPauseDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPauseDevice.Click
        Pause()
    End Sub

    Private Sub miScanNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miScanNow.Click
        ScanNow()
    End Sub

    Private Sub rbAlarms_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAlarms.CheckedChanged, rbWarnings.CheckedChanged, rbPaused.CheckedChanged
        SetFilter()
    End Sub

    Private Sub pbHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbHelp.Click
        Dim s As String = "To view paused and warning sensors, please register the application."
        If DialogResult.OK = MessageBox.Show(s, "Paused and warning sensors", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) Then
            Register()
        End If
    End Sub

    Private Sub miRefreshNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRefreshNow.Click
        miRefreshNow.Enabled = False
        RaiseEvent StartRefreshStatus(True, 1000)
    End Sub

    Private Sub lblRegister_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        Register()
    End Sub

#Region " Timer "
    Private Sub tmrLastCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLastCheck.Tick
        Try
            Dim sec As Integer = CInt(DateTime.Now.Subtract(_lastUpdate).TotalSeconds)
            If sec > My.Settings.RefreshTime Then
                tslLastcheck.ForeColor = Color.Red
            Else
                tslLastcheck.ForeColor = Color.Blue
            End If
            If sec = 1 Then
                tslLastcheck.Text = String.Format("Last update {0:0} second ago.", sec)
            Else
                tslLastcheck.Text = String.Format("Last update {0:0} seconds ago.", sec)
            End If
        Catch
            '
        End Try
    End Sub
#End Region

#End Region

    
End Class