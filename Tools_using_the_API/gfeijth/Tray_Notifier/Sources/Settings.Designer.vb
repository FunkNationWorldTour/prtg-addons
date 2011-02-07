<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.nudRefresh = New System.Windows.Forms.NumericUpDown
        Me.lblSec1 = New System.Windows.Forms.Label
        Me.lblRefresh = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.lblServer = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbAuthentication = New System.Windows.Forms.GroupBox
        Me.gbLayout = New System.Windows.Forms.GroupBox
        Me.cpWarning = New Notifier.ColorPicker
        Me.cpPaused = New Notifier.ColorPicker
        Me.cpAlarms = New Notifier.ColorPicker
        Me.gbAction = New System.Windows.Forms.GroupBox
        Me.nudLatency = New System.Windows.Forms.NumericUpDown
        Me.bntSoundFile = New System.Windows.Forms.Button
        Me.chkAutoPopup = New System.Windows.Forms.CheckBox
        Me.chkAutoHide = New System.Windows.Forms.CheckBox
        Me.chkPlaySound = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSoundfile = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblLatency = New System.Windows.Forms.Label
        Me.lblSec2 = New System.Windows.Forms.Label
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblCancel = New System.Windows.Forms.LinkLabel
        Me.lblOk = New System.Windows.Forms.LinkLabel
        CType(Me.nudRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAuthentication.SuspendLayout()
        Me.gbLayout.SuspendLayout()
        Me.gbAction.SuspendLayout()
        CType(Me.nudLatency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudRefresh
        '
        Me.nudRefresh.Location = New System.Drawing.Point(120, 17)
        Me.nudRefresh.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudRefresh.Name = "nudRefresh"
        Me.nudRefresh.Size = New System.Drawing.Size(48, 20)
        Me.nudRefresh.TabIndex = 1
        Me.nudRefresh.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'lblSec1
        '
        Me.lblSec1.AutoSize = True
        Me.lblSec1.Location = New System.Drawing.Point(174, 20)
        Me.lblSec1.Name = "lblSec1"
        Me.lblSec1.Size = New System.Drawing.Size(47, 13)
        Me.lblSec1.TabIndex = 2
        Me.lblSec1.Text = "seconds"
        '
        'lblRefresh
        '
        Me.lblRefresh.AutoSize = True
        Me.lblRefresh.Location = New System.Drawing.Point(6, 20)
        Me.lblRefresh.Name = "lblRefresh"
        Me.lblRefresh.Size = New System.Drawing.Size(73, 13)
        Me.lblRefresh.TabIndex = 0
        Me.lblRefresh.Text = "Refresh every"
        '
        'txtPassword
        '
        Me.ep.SetIconAlignment(Me.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPassword.Location = New System.Drawing.Point(120, 59)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(6, 63)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 8
        Me.lblPassword.Text = "Password"
        '
        'txtUsername
        '
        Me.ep.SetIconAlignment(Me.txtUsername, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtUsername.Location = New System.Drawing.Point(120, 36)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(6, 40)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 7
        Me.lblUsername.Text = "Username"
        '
        'txtServer
        '
        Me.ep.SetIconAlignment(Me.txtServer, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtServer.Location = New System.Drawing.Point(120, 13)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(100, 20)
        Me.txtServer.TabIndex = 0
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(6, 17)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(108, 13)
        Me.lblServer.TabIndex = 6
        Me.lblServer.Text = "Server IP/DNS name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Alarms color"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Paused color"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Warning color"
        '
        'gbAuthentication
        '
        Me.gbAuthentication.Controls.Add(Me.lblServer)
        Me.gbAuthentication.Controls.Add(Me.txtServer)
        Me.gbAuthentication.Controls.Add(Me.lblUsername)
        Me.gbAuthentication.Controls.Add(Me.txtUsername)
        Me.gbAuthentication.Controls.Add(Me.lblPassword)
        Me.gbAuthentication.Controls.Add(Me.txtPassword)
        Me.gbAuthentication.Location = New System.Drawing.Point(3, 4)
        Me.gbAuthentication.Name = "gbAuthentication"
        Me.gbAuthentication.Size = New System.Drawing.Size(230, 88)
        Me.gbAuthentication.TabIndex = 0
        Me.gbAuthentication.TabStop = False
        Me.gbAuthentication.Text = "Authentication"
        '
        'gbLayout
        '
        Me.gbLayout.Controls.Add(Me.Label1)
        Me.gbLayout.Controls.Add(Me.Label2)
        Me.gbLayout.Controls.Add(Me.cpWarning)
        Me.gbLayout.Controls.Add(Me.Label3)
        Me.gbLayout.Controls.Add(Me.cpPaused)
        Me.gbLayout.Controls.Add(Me.cpAlarms)
        Me.gbLayout.Location = New System.Drawing.Point(239, 4)
        Me.gbLayout.Name = "gbLayout"
        Me.gbLayout.Size = New System.Drawing.Size(165, 88)
        Me.gbLayout.TabIndex = 1
        Me.gbLayout.TabStop = False
        Me.gbLayout.Text = "Layout"
        '
        'cpWarning
        '
        Me.cpWarning.Color = System.Drawing.Color.Orange
        Me.cpWarning.Location = New System.Drawing.Point(132, 35)
        Me.cpWarning.Name = "cpWarning"
        Me.cpWarning.Size = New System.Drawing.Size(23, 23)
        Me.cpWarning.TabIndex = 1
        Me.cpWarning.TextDisplayed = False
        '
        'cpPaused
        '
        Me.cpPaused.Color = System.Drawing.Color.BlueViolet
        Me.cpPaused.Location = New System.Drawing.Point(132, 58)
        Me.cpPaused.Name = "cpPaused"
        Me.cpPaused.Size = New System.Drawing.Size(23, 23)
        Me.cpPaused.TabIndex = 2
        Me.cpPaused.TextDisplayed = False
        '
        'cpAlarms
        '
        Me.cpAlarms.Color = System.Drawing.Color.Red
        Me.cpAlarms.Location = New System.Drawing.Point(132, 12)
        Me.cpAlarms.Name = "cpAlarms"
        Me.cpAlarms.Size = New System.Drawing.Size(23, 23)
        Me.cpAlarms.TabIndex = 0
        Me.cpAlarms.TextDisplayed = False
        '
        'gbAction
        '
        Me.gbAction.Controls.Add(Me.nudLatency)
        Me.gbAction.Controls.Add(Me.bntSoundFile)
        Me.gbAction.Controls.Add(Me.chkAutoPopup)
        Me.gbAction.Controls.Add(Me.chkAutoHide)
        Me.gbAction.Controls.Add(Me.chkPlaySound)
        Me.gbAction.Controls.Add(Me.nudRefresh)
        Me.gbAction.Controls.Add(Me.Label5)
        Me.gbAction.Controls.Add(Me.txtSoundfile)
        Me.gbAction.Controls.Add(Me.Label4)
        Me.gbAction.Controls.Add(Me.lblLatency)
        Me.gbAction.Controls.Add(Me.lblRefresh)
        Me.gbAction.Controls.Add(Me.lblSec2)
        Me.gbAction.Controls.Add(Me.lblSec1)
        Me.gbAction.Location = New System.Drawing.Point(3, 93)
        Me.gbAction.Name = "gbAction"
        Me.gbAction.Size = New System.Drawing.Size(401, 158)
        Me.gbAction.TabIndex = 2
        Me.gbAction.TabStop = False
        Me.gbAction.Text = "Action"
        '
        'nudLatency
        '
        Me.nudLatency.Location = New System.Drawing.Point(120, 39)
        Me.nudLatency.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudLatency.Name = "nudLatency"
        Me.nudLatency.Size = New System.Drawing.Size(48, 20)
        Me.nudLatency.TabIndex = 4
        Me.nudLatency.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'bntSoundFile
        '
        Me.bntSoundFile.Location = New System.Drawing.Point(365, 83)
        Me.bntSoundFile.Name = "bntSoundFile"
        Me.bntSoundFile.Size = New System.Drawing.Size(26, 23)
        Me.bntSoundFile.TabIndex = 10
        Me.bntSoundFile.Text = "..."
        Me.bntSoundFile.UseVisualStyleBackColor = True
        '
        'chkAutoPopup
        '
        Me.chkAutoPopup.AutoSize = True
        Me.chkAutoPopup.Location = New System.Drawing.Point(6, 110)
        Me.chkAutoPopup.Name = "chkAutoPopup"
        Me.chkAutoPopup.Size = New System.Drawing.Size(288, 17)
        Me.chkAutoPopup.TabIndex = 11
        Me.chkAutoPopup.Text = "Popup sensors window when an alarm condition occurs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkAutoPopup.UseVisualStyleBackColor = True
        '
        'chkAutoHide
        '
        Me.chkAutoHide.AutoSize = True
        Me.chkAutoHide.Location = New System.Drawing.Point(6, 133)
        Me.chkAutoHide.Name = "chkAutoHide"
        Me.chkAutoHide.Size = New System.Drawing.Size(314, 17)
        Me.chkAutoHide.TabIndex = 12
        Me.chkAutoHide.Text = "Hide sensors window when the last alarm condition is cleared"
        Me.chkAutoHide.UseVisualStyleBackColor = True
        '
        'chkPlaySound
        '
        Me.chkPlaySound.AutoSize = True
        Me.chkPlaySound.Location = New System.Drawing.Point(120, 64)
        Me.chkPlaySound.Name = "chkPlaySound"
        Me.chkPlaySound.Size = New System.Drawing.Size(15, 14)
        Me.chkPlaySound.TabIndex = 7
        Me.chkPlaySound.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sound file"
        '
        'txtSoundfile
        '
        Me.ep.SetIconAlignment(Me.txtSoundfile, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSoundfile.Location = New System.Drawing.Point(120, 84)
        Me.txtSoundfile.Name = "txtSoundfile"
        Me.txtSoundfile.Size = New System.Drawing.Size(232, 20)
        Me.txtSoundfile.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Play sound at alarm"
        '
        'lblLatency
        '
        Me.lblLatency.AutoSize = True
        Me.lblLatency.Location = New System.Drawing.Point(6, 43)
        Me.lblLatency.Name = "lblLatency"
        Me.lblLatency.Size = New System.Drawing.Size(75, 13)
        Me.lblLatency.TabIndex = 3
        Me.lblLatency.Text = "Alarms latency"
        '
        'lblSec2
        '
        Me.lblSec2.AutoSize = True
        Me.lblSec2.Location = New System.Drawing.Point(174, 43)
        Me.lblSec2.Name = "lblSec2"
        Me.lblSec2.Size = New System.Drawing.Size(47, 13)
        Me.lblSec2.TabIndex = 5
        Me.lblSec2.Text = "seconds"
        '
        'ep
        '
        Me.ep.ContainerControl = Me
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
        Me.lblCancel.Location = New System.Drawing.Point(343, 265)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(61, 17)
        Me.lblCancel.TabIndex = 1
        Me.lblCancel.TabStop = True
        Me.lblCancel.Text = "       Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCancel.UseCompatibleTextRendering = True
        Me.lblCancel.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'lblOk
        '
        Me.lblOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOk.AutoSize = True
        Me.lblOk.ForeColor = System.Drawing.Color.Blue
        Me.lblOk.Image = Global.Notifier.My.Resources.Resources.save
        Me.lblOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblOk.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblOk.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblOk.Location = New System.Drawing.Point(297, 265)
        Me.lblOk.Name = "lblOk"
        Me.lblOk.Size = New System.Drawing.Size(40, 17)
        Me.lblOk.TabIndex = 0
        Me.lblOk.TabStop = True
        Me.lblOk.Text = "       Ok"
        Me.lblOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOk.UseCompatibleTextRendering = True
        Me.lblOk.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 288)
        Me.Controls.Add(Me.lblOk)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.gbAction)
        Me.Controls.Add(Me.gbLayout)
        Me.Controls.Add(Me.gbAuthentication)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Traynotifier settings"
        Me.TopMost = True
        CType(Me.nudRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAuthentication.ResumeLayout(False)
        Me.gbAuthentication.PerformLayout()
        Me.gbLayout.ResumeLayout(False)
        Me.gbLayout.PerformLayout()
        Me.gbAction.ResumeLayout(False)
        Me.gbAction.PerformLayout()
        CType(Me.nudLatency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudRefresh As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents lblRefresh As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cpAlarms As Notifier.ColorPicker
    Friend WithEvents cpPaused As Notifier.ColorPicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cpWarning As Notifier.ColorPicker
    Friend WithEvents gbAuthentication As System.Windows.Forms.GroupBox
    Friend WithEvents gbLayout As System.Windows.Forms.GroupBox
    Friend WithEvents gbAction As System.Windows.Forms.GroupBox
    Friend WithEvents bntSoundFile As System.Windows.Forms.Button
    Friend WithEvents chkPlaySound As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSoundfile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCancel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblOk As System.Windows.Forms.LinkLabel
    Friend WithEvents nudLatency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLatency As System.Windows.Forms.Label
    Friend WithEvents lblSec2 As System.Windows.Forms.Label
    Friend WithEvents chkAutoPopup As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoHide As System.Windows.Forms.CheckBox
End Class
