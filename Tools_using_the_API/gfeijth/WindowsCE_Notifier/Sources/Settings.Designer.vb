<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private miMain As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.miMain = New System.Windows.Forms.MainMenu
        Me.miCancel = New System.Windows.Forms.MenuItem
        Me.miSave = New System.Windows.Forms.MenuItem
        Me.lblServerIP = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'miMain
        '
        Me.miMain.MenuItems.Add(Me.miCancel)
        Me.miMain.MenuItems.Add(Me.miSave)
        '
        'miCancel
        '
        Me.miCancel.Text = "Cancel"
        '
        'miSave
        '
        Me.miSave.Text = "Save"
        '
        'lblServerIP
        '
        Me.lblServerIP.Location = New System.Drawing.Point(3, 3)
        Me.lblServerIP.Name = "lblServerIP"
        Me.lblServerIP.Size = New System.Drawing.Size(66, 20)
        Me.lblServerIP.Text = "Server"
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(3, 28)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(66, 20)
        Me.lblUser.Text = "User"
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(3, 53)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(66, 20)
        Me.lblPassword.Text = "Password"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(84, 3)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(153, 21)
        Me.txtServer.TabIndex = 0
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(84, 28)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(153, 21)
        Me.txtUser.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(84, 53)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(153, 21)
        Me.txtPassword.TabIndex = 2
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblServerIP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.miMain
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblServerIP As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents miCancel As System.Windows.Forms.MenuItem
    Friend WithEvents miSave As System.Windows.Forms.MenuItem
End Class
