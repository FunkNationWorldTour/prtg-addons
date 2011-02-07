Imports System.Xml

Public Class Sensors
#Region " Membervars "
    Private _lastRefresh As DateTime = DateTime.Now
    Private _readXML As New ReadXML
    Private _requestState As RequestState = RequestState.Idle
    Private _newline As String = Convert.ToChar(13) & Convert.ToChar(10)
#End Region

#Region " Enums "
    Private Enum RequestState
        Idle
        urlAlarms
        urlPause
        urlResume
    End Enum

    Private Enum SensorStatus
        Up = 3
        Warning = 4
        Alarms = 5
        Paused_By_User = 7
        Paused_By_Dependency = 8
    End Enum
#End Region

#Region " Constructor "
    Private Sub Sensors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialize()
    End Sub
#End Region

#Region " Methods "
    Private Sub Initialize()
        AddHandler _readXML.WebResult, AddressOf xmlReceived
        Globals.LoadSettings()
        If Globals.Server = "" OrElse Globals.User = "" OrElse Globals.Password = "" Then
            Settings()
        End If
        GetData(RequestState.urlAlarms)
    End Sub

    Private Sub Status()
        Dim SensorID As String = lvSensors.Items(lvSensors.SelectedIndices(0)).SubItems(0).Text
        Dim Status_RAW As Integer = CInt(lvSensors.Items(lvSensors.SelectedIndices(0)).SubItems(1).Text)
        Dim s As String = ""
        For i As Integer = 2 To lvSensors.Items(lvSensors.SelectedIndices(0)).SubItems.Count - 1
            s &= lvSensors.Items(lvSensors.SelectedIndices(0)).SubItems(i).Text & _newline
        Next
        If Status_RAW = SensorStatus.Alarms Or Status_RAW = SensorStatus.Warning Then
            s &= _newline & "Pause sensor?"
        Else
            s &= _newline & "Resume sensor?"
        End If
        If MessageBox.Show(s, "Sensor info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Return
        End If

        If Status_RAW = SensorStatus.Alarms Then
            GetData(RequestState.urlPause, SensorID)
        Else
            GetData(RequestState.urlResume, SensorID)
        End If
    End Sub

    Private Sub Settings()
        Dim f As New Settings
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub About()
        Dim ss As String() = Reflection.Assembly.GetExecutingAssembly().FullName.Split(","c)
        Dim s As String = String.Format("{1}{0}{2}", _newline, ss(0), ss(1))
        MessageBox.Show(s, "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub GetData(ByVal state As RequestState, Optional ByVal SensorID As String = "")
        lblError.Text = ""
        lblError.Visible = False
        lblNoData.Visible = False
        miRefresh.Enabled = False
        miSensorStatus.Enabled = False
        _requestState = state
        Select Case state
            Case RequestState.urlAlarms
                _readXML.SendRequest(Globals.formatURL(Globals.urlAlarms))
            Case RequestState.urlPause
                _readXML.SendRequest(Globals.formatURL(Globals.urlPauseDevice, SensorID))
            Case RequestState.urlResume
                _readXML.SendRequest(Globals.formatURL(Globals.urlResumeDevice, SensorID))
        End Select
    End Sub

    Private Delegate Sub xmlReceivedDelegate(ByVal doc As XmlDocument, ByVal errorMessage As String)
    Private Sub xmlReceived(ByVal doc As Xml.XmlDocument, ByVal errorMessage As String)
        If InvokeRequired Then
            Invoke(New xmlReceivedDelegate(AddressOf xmlReceived), New Object() {doc, errorMessage})
            Return
        End If
        lblError.Visible = errorMessage IsNot Nothing
        If errorMessage Is Nothing Then
            Dim titel As String = ""
            Select Case _requestState
                Case RequestState.urlAlarms
                    Readalarms(doc)
                    tmrLastRefresh.Enabled = True
                Case RequestState.urlPause
                    titel = "Sensor is paused"
                Case RequestState.urlResume
                    titel = "Sensor is resumed"
            End Select
            If titel IsNot "" Then
                If MessageBox.Show("Refresh status?", titel, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    GetData(RequestState.urlAlarms)
                End If
            End If
        Else
            lvSensors.Items.Clear()
            lblError.Text = errorMessage
            lblError.Show()
        End If

        _requestState = RequestState.Idle
        miRefresh.Enabled = True
        miSensorStatus.Enabled = True
    End Sub

    Private Sub Readalarms(ByVal doc As Xml.XmlDocument)
        Dim lv As ListViewItem
        lvSensors.Items.Clear()

        lblNoData.Visible = doc.SelectNodes("//sensors/item").Count = 0
        If lblNoData.Visible Then
            lblNoData.Show()
        End If

        

        For Each node As XmlNode In doc.SelectNodes("//sensors/item")
            Dim value As String = ""
            Dim id As String = ""
            Dim group As String = ""
            Dim device As String = ""
            Dim sensor As String = ""
            Dim status As String = ""
            Dim message As String = ""
            Dim downfor As String = ""
            Dim status_Raw As Integer = 0

            '//GF read nodes
            For i As Integer = 0 To node.ChildNodes.Count - 1
                Try
                    value = Uri.UnescapeDataString(node.ChildNodes(i).InnerXml.Trim)
                Catch ex As Exception
                    value = node.ChildNodes(i).InnerXml.Trim
                End Try

                Select Case node.ChildNodes(i).Name
                    Case "id"
                        id = value
                    Case "group"
                        group = value
                    Case "device"
                        device = value
                    Case "sensor"
                        sensor = value
                    Case "message"
                        message = value
                    Case "downfor"
                        downfor = value
                    Case "status"
                        status = value
                    Case "status_RAW"
                        status_Raw = CInt(value)
                End Select
            Next

            '//GF add aditional info to status
            Select Case CInt(status_Raw)
                Case CInt(SensorStatus.Paused_By_User), CInt(SensorStatus.Paused_By_Dependency)
                    status = message
                Case CInt(SensorStatus.Warning)
                    status = message
                Case CInt(SensorStatus.Alarms)
                    status &= " " & downfor
            End Select


            '//GF populate new listview item
            lv = New ListViewItem(New String() { _
                  id _
                , CStr(status_Raw) _
                , group _
                , device _
                , sensor _
                , status})

            '//GF set backcolor
            Select Case status_Raw
                Case SensorStatus.Alarms
                    lv.BackColor = Color.Red
                Case SensorStatus.Paused_By_User, SensorStatus.Paused_By_Dependency
                    lv.BackColor = Color.BlueViolet
                Case SensorStatus.Warning
                    lv.BackColor = Color.Orange
            End Select

            '//GF add to listview
            lvSensors.Items.Add(lv)
        Next
        _lastRefresh = DateTime.Now
    End Sub
#End Region


#Region " Eventhandlers "
    Private Sub miSettings_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSettings.Click
        Settings()
    End Sub

    Private Sub miAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAbout.Click
        About()
    End Sub

    Private Sub miRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRefresh.Click
        GetData(RequestState.urlAlarms)
    End Sub

    Private Sub miSensorStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSensorStatus.Click
        Status()
    End Sub

    Private Sub tmrLastRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLastRefresh.Tick
        Dim t As TimeSpan = DateTime.Now.Subtract(_lastRefresh)
        lblStatus.Text = String.Format("Last refresh {0:00}:{1:00}:{2:00} ago.", t.Hours, t.Minutes, t.Seconds)
    End Sub
#End Region


End Class
