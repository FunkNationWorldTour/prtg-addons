Imports System.Reflection
Imports System.IO

Public Class Settings

#Region " Memebervars "

#End Region

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Globals.LoadSettings()
        txtServer.Text = Globals.Server
        txtUser.Text = Globals.User
        txtPassword.Text = Globals.Password
    End Sub

    Private Sub miCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCancel.Click
        Close()
    End Sub

    Private Sub miSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSave.Click
        Globals.Server = txtServer.Text
        Globals.User = txtUser.Text
        Globals.Password = txtPassword.Text

        Globals.SaveSettings()
        Close()
    End Sub

   

End Class