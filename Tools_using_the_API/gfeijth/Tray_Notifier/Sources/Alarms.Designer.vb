<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alarms
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Alarms))
        Me.dgAlarms = New System.Windows.Forms.DataGridView
        Me.colGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colObjId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDevice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSensor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsAlarms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSensorPage = New System.Windows.Forms.ToolStripMenuItem
        Me.miPauseDevice = New System.Windows.Forms.ToolStripMenuItem
        Me.miScanNow = New System.Windows.Forms.ToolStripMenuItem
        Me.lblSettings = New System.Windows.Forms.LinkLabel
        Me.lblHomepage = New System.Windows.Forms.LinkLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbHelp = New System.Windows.Forms.PictureBox
        Me.rbWarnings = New System.Windows.Forms.RadioButton
        Me.rbPaused = New System.Windows.Forms.RadioButton
        Me.rbAlarms = New System.Windows.Forms.RadioButton
        Me.lblClose = New System.Windows.Forms.LinkLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.cmsStatus = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miRefreshNow = New System.Windows.Forms.ToolStripMenuItem
        Me.tslVersion = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslLastcheck = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblRegister = New System.Windows.Forms.LinkLabel
        Me.tmrLastCheck = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgAlarms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlarms.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.cmsStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgAlarms
        '
        Me.dgAlarms.AllowUserToAddRows = False
        Me.dgAlarms.AllowUserToDeleteRows = False
        Me.dgAlarms.AllowUserToOrderColumns = True
        Me.dgAlarms.AllowUserToResizeRows = False
        Me.dgAlarms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAlarms.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgAlarms.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgAlarms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colGroup, Me.colObjId, Me.colDevice, Me.colSensor, Me.colStatus})
        Me.dgAlarms.ContextMenuStrip = Me.cmsAlarms
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAlarms.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgAlarms.Location = New System.Drawing.Point(3, 33)
        Me.dgAlarms.MultiSelect = False
        Me.dgAlarms.Name = "dgAlarms"
        Me.dgAlarms.ReadOnly = True
        Me.dgAlarms.RowHeadersVisible = False
        Me.dgAlarms.RowHeadersWidth = 25
        Me.dgAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAlarms.Size = New System.Drawing.Size(404, 191)
        Me.dgAlarms.TabIndex = 0
        '
        'colGroup
        '
        Me.colGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colGroup.DataPropertyName = "Group"
        Me.colGroup.HeaderText = "Group"
        Me.colGroup.Name = "colGroup"
        Me.colGroup.ReadOnly = True
        '
        'colObjId
        '
        Me.colObjId.DataPropertyName = "ObjId"
        Me.colObjId.HeaderText = "ObjId"
        Me.colObjId.Name = "colObjId"
        Me.colObjId.ReadOnly = True
        Me.colObjId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colObjId.Visible = False
        '
        'colDevice
        '
        Me.colDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDevice.DataPropertyName = "Device"
        Me.colDevice.HeaderText = "Device"
        Me.colDevice.Name = "colDevice"
        Me.colDevice.ReadOnly = True
        '
        'colSensor
        '
        Me.colSensor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSensor.DataPropertyName = "Sensor"
        Me.colSensor.HeaderText = "Sensor"
        Me.colSensor.Name = "colSensor"
        Me.colSensor.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStatus.DataPropertyName = "Status"
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'cmsAlarms
        '
        Me.cmsAlarms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSensorPage, Me.miPauseDevice, Me.miScanNow})
        Me.cmsAlarms.Name = "ContextMenuStrip"
        Me.cmsAlarms.Size = New System.Drawing.Size(143, 70)
        '
        'miSensorPage
        '
        Me.miSensorPage.Name = "miSensorPage"
        Me.miSensorPage.Size = New System.Drawing.Size(142, 22)
        Me.miSensorPage.Text = "Sensor page"
        '
        'miPauseDevice
        '
        Me.miPauseDevice.Name = "miPauseDevice"
        Me.miPauseDevice.Size = New System.Drawing.Size(142, 22)
        Me.miPauseDevice.Text = "Pause sensor"
        '
        'miScanNow
        '
        Me.miScanNow.Name = "miScanNow"
        Me.miScanNow.Size = New System.Drawing.Size(142, 22)
        Me.miScanNow.Text = "Scan now"
        '
        'lblSettings
        '
        Me.lblSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSettings.AutoSize = True
        Me.lblSettings.ForeColor = System.Drawing.Color.Blue
        Me.lblSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSettings.ImageKey = "(none)"
        Me.lblSettings.LinkArea = New System.Windows.Forms.LinkArea(0, 15)
        Me.lblSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblSettings.Location = New System.Drawing.Point(13, 235)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(63, 17)
        Me.lblSettings.TabIndex = 0
        Me.lblSettings.TabStop = True
        Me.lblSettings.Text = "      Settings"
        Me.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblSettings, "TrayNotifier settings.")
        Me.lblSettings.UseCompatibleTextRendering = True
        Me.lblSettings.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'lblHomepage
        '
        Me.lblHomepage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHomepage.AutoSize = True
        Me.lblHomepage.ForeColor = System.Drawing.Color.Blue
        Me.lblHomepage.Image = Global.Notifier.My.Resources.Resources.home
        Me.lblHomepage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHomepage.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblHomepage.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblHomepage.Location = New System.Drawing.Point(87, 235)
        Me.lblHomepage.Name = "lblHomepage"
        Me.lblHomepage.Size = New System.Drawing.Size(81, 17)
        Me.lblHomepage.TabIndex = 1
        Me.lblHomepage.TabStop = True
        Me.lblHomepage.Text = "       Homepage"
        Me.lblHomepage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblHomepage, "Open your PRTG Network Monitor homepage.")
        Me.lblHomepage.UseCompatibleTextRendering = True
        Me.lblHomepage.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pbHelp)
        Me.GroupBox1.Controls.Add(Me.rbWarnings)
        Me.GroupBox1.Controls.Add(Me.rbPaused)
        Me.GroupBox1.Controls.Add(Me.rbAlarms)
        Me.GroupBox1.Controls.Add(Me.dgAlarms)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 230)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'pbHelp
        '
        Me.pbHelp.Image = Global.Notifier.My.Resources.Resources.button_info
        Me.pbHelp.Location = New System.Drawing.Point(209, 11)
        Me.pbHelp.Name = "pbHelp"
        Me.pbHelp.Size = New System.Drawing.Size(16, 16)
        Me.pbHelp.TabIndex = 2
        Me.pbHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbHelp, "Click for info.")
        '
        'rbWarnings
        '
        Me.rbWarnings.AutoSize = True
        Me.rbWarnings.Location = New System.Drawing.Point(66, 11)
        Me.rbWarnings.Name = "rbWarnings"
        Me.rbWarnings.Size = New System.Drawing.Size(70, 17)
        Me.rbWarnings.TabIndex = 1
        Me.rbWarnings.Text = "Warnings"
        Me.ToolTip1.SetToolTip(Me.rbWarnings, "Show warning sensors")
        Me.rbWarnings.UseVisualStyleBackColor = True
        '
        'rbPaused
        '
        Me.rbPaused.AutoSize = True
        Me.rbPaused.Location = New System.Drawing.Point(142, 11)
        Me.rbPaused.Name = "rbPaused"
        Me.rbPaused.Size = New System.Drawing.Size(61, 17)
        Me.rbPaused.TabIndex = 1
        Me.rbPaused.Text = "Paused"
        Me.ToolTip1.SetToolTip(Me.rbPaused, "Show paused sensors.")
        Me.rbPaused.UseVisualStyleBackColor = True
        '
        'rbAlarms
        '
        Me.rbAlarms.AutoSize = True
        Me.rbAlarms.Checked = True
        Me.rbAlarms.Location = New System.Drawing.Point(8, 11)
        Me.rbAlarms.Name = "rbAlarms"
        Me.rbAlarms.Size = New System.Drawing.Size(56, 17)
        Me.rbAlarms.TabIndex = 1
        Me.rbAlarms.TabStop = True
        Me.rbAlarms.Text = "Alarms"
        Me.ToolTip1.SetToolTip(Me.rbAlarms, "Show alarm sensors.")
        Me.rbAlarms.UseVisualStyleBackColor = True
        '
        'lblClose
        '
        Me.lblClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClose.AutoSize = True
        Me.lblClose.ForeColor = System.Drawing.Color.Blue
        Me.lblClose.Image = Global.Notifier.My.Resources.Resources.delete
        Me.lblClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClose.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblClose.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblClose.Location = New System.Drawing.Point(353, 235)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(54, 17)
        Me.lblClose.TabIndex = 2
        Me.lblClose.TabStop = True
        Me.lblClose.Text = "       Close"
        Me.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblClose, "Close the sensors window.")
        Me.lblClose.UseCompatibleTextRendering = True
        Me.lblClose.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ContextMenuStrip = Me.cmsStatus
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslVersion, Me.tslLastcheck})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 256)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(419, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cmsStatus
        '
        Me.cmsStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miRefreshNow})
        Me.cmsStatus.Name = "cmsStatus"
        Me.cmsStatus.Size = New System.Drawing.Size(140, 26)
        '
        'miRefreshNow
        '
        Me.miRefreshNow.Name = "miRefreshNow"
        Me.miRefreshNow.Size = New System.Drawing.Size(139, 22)
        Me.miRefreshNow.Text = "Refresh now"
        '
        'tslVersion
        '
        Me.tslVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tslVersion.ForeColor = System.Drawing.Color.Blue
        Me.tslVersion.Name = "tslVersion"
        Me.tslVersion.Size = New System.Drawing.Size(160, 19)
        Me.tslVersion.Text = "Network Monitor version {0}"
        '
        'tslLastcheck
        '
        Me.tslLastcheck.ForeColor = System.Drawing.Color.Blue
        Me.tslLastcheck.Name = "tslLastcheck"
        Me.tslLastcheck.Size = New System.Drawing.Size(149, 19)
        Me.tslLastcheck.Text = "Last update 0 seconds ago."
        '
        'lblRegister
        '
        Me.lblRegister.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRegister.AutoSize = True
        Me.lblRegister.ForeColor = System.Drawing.Color.Blue
        Me.lblRegister.Image = Global.Notifier.My.Resources.Resources.favorites
        Me.lblRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRegister.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblRegister.Location = New System.Drawing.Point(174, 235)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(67, 17)
        Me.lblRegister.TabIndex = 1
        Me.lblRegister.TabStop = True
        Me.lblRegister.Text = "       Register"
        Me.lblRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblRegister, "Register the application.")
        Me.lblRegister.UseCompatibleTextRendering = True
        Me.lblRegister.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'tmrLastCheck
        '
        Me.tmrLastCheck.Enabled = True
        Me.tmrLastCheck.Interval = 1000
        '
        'Alarms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 280)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblHomepage)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.lblRegister)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Alarms"
        Me.ShowInTaskbar = False
        Me.Text = "Sensors"
        Me.TopMost = True
        CType(Me.dgAlarms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlarms.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.cmsStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgAlarms As System.Windows.Forms.DataGridView
    Friend WithEvents lblSettings As System.Windows.Forms.LinkLabel
    Friend WithEvents lblHomepage As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblClose As System.Windows.Forms.LinkLabel
    Friend WithEvents cmsAlarms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSensorPage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPauseDevice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rbPaused As System.Windows.Forms.RadioButton
    Friend WithEvents rbAlarms As System.Windows.Forms.RadioButton
    Friend WithEvents pbHelp As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents miScanNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tslLastcheck As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrLastCheck As System.Windows.Forms.Timer
    Friend WithEvents cmsStatus As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miRefreshNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObjId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDevice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSensor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbWarnings As System.Windows.Forms.RadioButton
    Friend WithEvents lblRegister As System.Windows.Forms.LinkLabel
End Class
