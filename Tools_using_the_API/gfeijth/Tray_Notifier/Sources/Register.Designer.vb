<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Me.lblRegister = New System.Windows.Forms.Label
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.lblCancel = New System.Windows.Forms.LinkLabel
        Me.lblRequestKey = New System.Windows.Forms.LinkLabel
        Me.lblCompany = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblRegKey = New System.Windows.Forms.Label
        Me.txtRegKey = New System.Windows.Forms.TextBox
        Me.lblActivateKey = New System.Windows.Forms.LinkLabel
        Me.lblInfo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.Location = New System.Drawing.Point(79, 50)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(186, 13)
        Me.lblRegister.TabIndex = 1
        Me.lblRegister.Text = "Register this version of TrayNotifier to:"
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(82, 77)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(267, 20)
        Me.txtCompany.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(82, 101)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(267, 20)
        Me.txtUser.TabIndex = 5
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancel.AutoSize = True
        Me.lblCancel.ForeColor = System.Drawing.Color.Blue
        Me.lblCancel.Image = Global.Notifier.My.Resources.Resources.delete
        Me.lblCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCancel.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblCancel.Location = New System.Drawing.Point(301, 156)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(61, 17)
        Me.lblCancel.TabIndex = 10
        Me.lblCancel.TabStop = True
        Me.lblCancel.Text = "       Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCancel.UseCompatibleTextRendering = True
        Me.lblCancel.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'lblRequestKey
        '
        Me.lblRequestKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRequestKey.AutoSize = True
        Me.lblRequestKey.ForeColor = System.Drawing.Color.Blue
        Me.lblRequestKey.Image = Global.Notifier.My.Resources.Resources.move_to
        Me.lblRequestKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRequestKey.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblRequestKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblRequestKey.Location = New System.Drawing.Point(11, 156)
        Me.lblRequestKey.Name = "lblRequestKey"
        Me.lblRequestKey.Size = New System.Drawing.Size(88, 17)
        Me.lblRequestKey.TabIndex = 8
        Me.lblRequestKey.TabStop = True
        Me.lblRequestKey.Text = "       Request key"
        Me.lblRequestKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblRequestKey.UseCompatibleTextRendering = True
        Me.lblRequestKey.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(12, 81)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(51, 13)
        Me.lblCompany.TabIndex = 2
        Me.lblCompany.Text = "Company"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(12, 105)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "User"
        '
        'lblRegKey
        '
        Me.lblRegKey.AutoSize = True
        Me.lblRegKey.Location = New System.Drawing.Point(12, 129)
        Me.lblRegKey.Name = "lblRegKey"
        Me.lblRegKey.Size = New System.Drawing.Size(51, 13)
        Me.lblRegKey.TabIndex = 6
        Me.lblRegKey.Text = "Reg. Key"
        '
        'txtRegKey
        '
        Me.txtRegKey.Location = New System.Drawing.Point(82, 125)
        Me.txtRegKey.Name = "txtRegKey"
        Me.txtRegKey.Size = New System.Drawing.Size(267, 20)
        Me.txtRegKey.TabIndex = 7
        '
        'lblActivateKey
        '
        Me.lblActivateKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivateKey.AutoSize = True
        Me.lblActivateKey.Enabled = False
        Me.lblActivateKey.ForeColor = System.Drawing.Color.Blue
        Me.lblActivateKey.Image = Global.Notifier.My.Resources.Resources.open
        Me.lblActivateKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblActivateKey.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblActivateKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblActivateKey.Location = New System.Drawing.Point(110, 156)
        Me.lblActivateKey.Name = "lblActivateKey"
        Me.lblActivateKey.Size = New System.Drawing.Size(86, 17)
        Me.lblActivateKey.TabIndex = 9
        Me.lblActivateKey.TabStop = True
        Me.lblActivateKey.Text = "       Activate key"
        Me.lblActivateKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblActivateKey.UseCompatibleTextRendering = True
        Me.lblActivateKey.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Blue
        Me.lblInfo.Location = New System.Drawing.Point(2, 4)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(360, 29)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Registration is free of charge and enables additional features."
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 179)
        Me.Controls.Add(Me.lblRegKey)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.lblActivateKey)
        Me.Controls.Add(Me.lblRequestKey)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.txtRegKey)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblRegister)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registration"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRegister As System.Windows.Forms.Label
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblCancel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRequestKey As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblRegKey As System.Windows.Forms.Label
    Friend WithEvents txtRegKey As System.Windows.Forms.TextBox
    Friend WithEvents lblActivateKey As System.Windows.Forms.LinkLabel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
End Class
