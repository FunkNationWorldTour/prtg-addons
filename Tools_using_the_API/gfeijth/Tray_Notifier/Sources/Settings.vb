Imports System.IO
Imports System.Reflection

Public Class Settings

#Region " Constructor "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Initialize()
    End Sub
#End Region

#Region " Methods "
    Private Sub Initialize()
        With My.Settings
            If Not .Password = String.Empty Then
                txtPassword.Text = Globals.Decrypt(.Password, "Geheim01")
            End If
            txtUsername.Text = .Username
            txtServer.Text = .Server
            If .RefreshTime < nudRefresh.Minimum Then
                .RefreshTime = CInt(nudRefresh.Minimum)
            End If
            nudRefresh.Value = .RefreshTime
            nudLatency.Value = .DownLatency
            cpAlarms.Color = .AlarmColor
            cpWarning.Color = .WarningColor
            cpPaused.Color = .PausedColor
            chkPlaySound.Checked = .PlaySound
            chkAutoPopup.Checked = .AutoPopup
            chkAutoHide.Checked = .AutoHide
            If .SoundFile = String.Empty Then
                txtSoundfile.Text = String.Format("{0}\sound\alert.wav", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            Else
                txtSoundfile.Text = .SoundFile
            End If



        End With
    End Sub

    Private Function Save() As Boolean
        Dim Validated As Boolean = True

        ep.SetError(txtUsername, "")
        If txtUsername.Text.Trim.Length = 0 Then
            ep.SetError(txtUsername, "Enter the user name")
            Validated = False
        End If

        ep.SetError(txtPassword, "")
        If txtPassword.Text.Trim.Length = 0 Then
            ep.SetError(txtPassword, "Enter the password")
            Validated = False
        End If

        ep.SetError(txtServer, "")
        If txtServer.Text.Trim.Length = 0 Then
            ep.SetError(txtServer, "Enter the server name")
            Validated = False
        End If

        ep.SetError(txtSoundfile, "")
        If chkPlaySound.Checked AndAlso (txtSoundfile.Text.Trim.Length = 0 Or Not File.Exists(txtSoundfile.Text)) Then
            ep.SetError(txtSoundfile, "Select an existing sound file")
            Validated = False
        End If

        If Validated Then
            With My.Settings
                If txtPassword.Text = String.Empty Then
                    .Password = String.Empty
                Else
                    .Password = Globals.Encrypt(txtPassword.Text, "Geheim01")
                End If
                .Username = txtUsername.Text
                .Server = txtServer.Text
                .RefreshTime = CInt(nudRefresh.Value)
                .DownLatency = CInt(nudLatency.Value)
                .AlarmColor = cpAlarms.Color
                .WarningColor = cpWarning.Color
                .PausedColor = cpPaused.Color
                .PlaySound = chkPlaySound.Checked
                .AutoPopup = chkAutoPopup.Checked
                .AutoHide = chkAutoHide.Checked
                .SoundFile = txtSoundfile.Text
                .Save()
            End With
        End If

        Return Validated
    End Function
#End Region

#Region " Eventhandlers "
    Private Sub bntSoundFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSoundFile.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .DefaultExt = ".wav"
            .Filter = "*.wav | *.wav"
            If txtSoundfile.Text.Trim.Length > 0 Then
                .FileName = txtSoundfile.Text
            Else
                .InitialDirectory = String.Format("{0}\sound", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            End If
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtSoundfile.Text = .FileName
            End If
        End With
    End Sub

    Private Sub lblCancel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCancel.LinkClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub lblOk_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblOk.LinkClicked
        If Save() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub
#End Region

End Class