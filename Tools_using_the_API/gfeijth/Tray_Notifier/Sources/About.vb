Public Class About
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Initialize()
    End Sub

    Private Sub Initialize()
        With My.Application.Info
            lblProduct.Text = .Title
            lblVersion.Text = String.Format("Version: {0}", .Version)
            lblCompany.Text = .Copyright.Replace("&", "&&")
        End With

        If Globals.Registered Then
            lblRegistrated.TextAlign = ContentAlignment.TopLeft
            lblRegistrated.Text = String.Format("Registered to{0}Company: {1}{0}User: {2}{0}", Environment.NewLine, Globals.RegisteredCompany, Globals.RegisteredUser)
        End If
    End Sub

    Private Sub lblClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblClose.LinkClicked
        Close()
    End Sub
End Class