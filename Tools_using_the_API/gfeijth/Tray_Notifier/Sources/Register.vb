Imports System.IO
Imports System.Net.NetworkInformation


Public Class Register
#Region " Membervars "
    Private Const emailAddress As String = "TrayNotifier registration <registration@krijco.nl>;"
    Private Const saltReq As String = "Salting request"
#End Region

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
        txtUser.Text = GetUserName()
        txtCompany.Text = GetDomainName()
    End Sub

    Declare Function GetUserName Lib "advapi32.dll" Alias _
       "GetUserNameA" (ByVal lpBuffer As String, _
       ByRef nSize As Integer) As Integer

    Private Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Convert.ToChar(0)))
    End Function

    Private Function GetDomainName() As String
        Dim ipproperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim s As String = ipproperties.DomainName
        If s.IndexOf(".") > 0 Then
            s = s.Substring(0, s.IndexOf("."))
        End If
        Return s
    End Function

#End Region

#Region " Event handlers "
    Private Sub lblCancel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCancel.LinkClicked
        Close()
    End Sub

    Private Sub lblRequestKey_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRequestKey.LinkClicked
        Dim subject As String = "Registration form"
        Dim hash As String = Globals.Encrypt(String.Format("{0},{1},{2},{3},{4},{0}", saltReq, My.Application.Info.ProductName, Application.ProductVersion, txtCompany.Text, txtUser.Text), "Geheim01")
        Dim body As String = String.Format("Product:{0}{1} {2}{0}{0}Registration code:{0}{3}", "%%0A", My.Application.Info.ProductName, Application.ProductVersion, hash)
        Dim s As String = String.Format("mailto:{3}{0}?subject={1}&body={2}{3}", emailAddress, subject, body, Convert.ToChar(34))

        s = s.Replace(" ", "%%20")
        Dim f As String = String.Format("{0}\register.bat", My.Computer.FileSystem.SpecialDirectories.Temp)

        Try
            File.WriteAllText(f, String.Format("@ECHO OFF{0}START {1}", Environment.NewLine, s))
            If MessageBox.Show("Your default e-mail client will now start.", "Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                Dim p As New Process
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.FileName = f
                p.Start()
                Threading.Thread.Sleep(5000)
            End If
            File.Delete(f)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Close()
    End Sub

    Private Sub txtCompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCompany.KeyPress, txtUser.KeyPress
        If e.KeyChar = "," Then
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub txtRegKey_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegKey.TextChanged
        txtCompany.Enabled = txtRegKey.Text.Length = 0
        txtUser.Enabled = txtRegKey.Text.Length = 0
        lblRequestKey.Enabled = txtRegKey.Text.Length = 0
        lblActivateKey.Enabled = txtRegKey.Text.Length > 0
        Dim s As String() = Globals.DecodeKey(txtRegKey.Text)
        If Not s Is Nothing Then
            txtCompany.Text = s(0)
            txtUser.Text = s(1)
        End If
    End Sub

    Private Sub txtCompany_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompany.TextChanged, txtUser.TextChanged
        lblRegKey.Enabled = txtCompany.Text.Length > 0 AndAlso txtUser.Text.Length > 0
    End Sub

    Private Sub lblActivateKey_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblActivateKey.LinkClicked
        If Globals.TryDecode(txtRegKey.Text, True) Then
            txtCompany.Text = Globals.RegisteredCompany
            txtUser.Text = Globals.RegisteredUser
            Close()
        End If
    End Sub
#End Region

End Class