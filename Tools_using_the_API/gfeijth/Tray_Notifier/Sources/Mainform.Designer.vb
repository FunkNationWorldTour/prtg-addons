<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.tmrRefreshStatus = New System.Windows.Forms.Timer(Me.components)
        Me.niStatus = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsStatus = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.miSensors = New System.Windows.Forms.ToolStripMenuItem
        Me.miHomepage = New System.Windows.Forms.ToolStripMenuItem
        Me.miCheckNow = New System.Windows.Forms.ToolStripMenuItem
        Me.miAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.miRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miExit = New System.Windows.Forms.ToolStripMenuItem
        Me.tmrHideBalloon = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBlink = New System.Windows.Forms.Timer(Me.components)
        Me.cmsStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrRefreshStatus
        '
        Me.tmrRefreshStatus.Interval = 5000
        '
        'niStatus
        '
        Me.niStatus.BalloonTipTitle = "TrayNotifier"
        Me.niStatus.ContextMenuStrip = Me.cmsStatus
        Me.niStatus.Visible = True
        '
        'cmsStatus
        '
        Me.cmsStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSettings, Me.miSensors, Me.miHomepage, Me.miCheckNow, Me.miAbout, Me.miRegister, Me.ToolStripMenuItem1, Me.miExit})
        Me.cmsStatus.Name = "cmsStatus"
        Me.cmsStatus.Size = New System.Drawing.Size(134, 164)
        '
        'miSettings
        '
        Me.miSettings.Name = "miSettings"
        Me.miSettings.Size = New System.Drawing.Size(133, 22)
        Me.miSettings.Text = "Settings"
        '
        'miSensors
        '
        Me.miSensors.Name = "miSensors"
        Me.miSensors.Size = New System.Drawing.Size(133, 22)
        Me.miSensors.Text = "Sensors"
        '
        'miHomepage
        '
        Me.miHomepage.Name = "miHomepage"
        Me.miHomepage.Size = New System.Drawing.Size(133, 22)
        Me.miHomepage.Text = "Homepage"
        '
        'miCheckNow
        '
        Me.miCheckNow.Name = "miCheckNow"
        Me.miCheckNow.Size = New System.Drawing.Size(133, 22)
        Me.miCheckNow.Text = "Check now"
        '
        'miAbout
        '
        Me.miAbout.Name = "miAbout"
        Me.miAbout.Size = New System.Drawing.Size(133, 22)
        Me.miAbout.Text = "About"
        '
        'miRegister
        '
        Me.miRegister.Name = "miRegister"
        Me.miRegister.Size = New System.Drawing.Size(133, 22)
        Me.miRegister.Text = "Register"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(130, 6)
        '
        'miExit
        '
        Me.miExit.Name = "miExit"
        Me.miExit.Size = New System.Drawing.Size(133, 22)
        Me.miExit.Text = "Exit"
        '
        'tmrHideBalloon
        '
        Me.tmrHideBalloon.Interval = 1000
        '
        'tmrBlink
        '
        Me.tmrBlink.Interval = 1000
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(195, 74)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Mainform"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TrayNotifier"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.cmsStatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrRefreshStatus As System.Windows.Forms.Timer
    Friend WithEvents niStatus As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsStatus As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSensors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miHomepage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCheckNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrHideBalloon As System.Windows.Forms.Timer
    Friend WithEvents tmrBlink As System.Windows.Forms.Timer
    Friend WithEvents miRegister As System.Windows.Forms.ToolStripMenuItem

End Class
