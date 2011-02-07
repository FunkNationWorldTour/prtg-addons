<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Sensors
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
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sensors))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.miRefresh = New System.Windows.Forms.MenuItem
        Me.miMenu = New System.Windows.Forms.MenuItem
        Me.miAbout = New System.Windows.Forms.MenuItem
        Me.miSettings = New System.Windows.Forms.MenuItem
        Me.lvSensors = New System.Windows.Forms.ListView
        Me.colID = New System.Windows.Forms.ColumnHeader
        Me.colStatus_RAW = New System.Windows.Forms.ColumnHeader
        Me.colGroup = New System.Windows.Forms.ColumnHeader
        Me.colDevice = New System.Windows.Forms.ColumnHeader
        Me.colSensor = New System.Windows.Forms.ColumnHeader
        Me.colStatus = New System.Windows.Forms.ColumnHeader
        Me.cmSensors = New System.Windows.Forms.ContextMenu
        Me.miSensorStatus = New System.Windows.Forms.MenuItem
        Me.tmrLastRefresh = New System.Windows.Forms.Timer
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblError = New System.Windows.Forms.Label
        Me.lblNoData = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.miRefresh)
        Me.mainMenu1.MenuItems.Add(Me.miMenu)
        '
        'miRefresh
        '
        Me.miRefresh.Enabled = False
        Me.miRefresh.Text = "Refresh"
        '
        'miMenu
        '
        Me.miMenu.MenuItems.Add(Me.miAbout)
        Me.miMenu.MenuItems.Add(Me.miSettings)
        Me.miMenu.Text = "Menu"
        '
        'miAbout
        '
        Me.miAbout.Text = "About"
        '
        'miSettings
        '
        Me.miSettings.Text = "Settings"
        '
        'lvSensors
        '
        Me.lvSensors.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvSensors.Columns.Add(Me.colID)
        Me.lvSensors.Columns.Add(Me.colStatus_RAW)
        Me.lvSensors.Columns.Add(Me.colGroup)
        Me.lvSensors.Columns.Add(Me.colDevice)
        Me.lvSensors.Columns.Add(Me.colSensor)
        Me.lvSensors.Columns.Add(Me.colStatus)
        Me.lvSensors.ContextMenu = Me.cmSensors
        Me.lvSensors.Dock = System.Windows.Forms.DockStyle.Top
        Me.lvSensors.FullRowSelect = True
        Me.lvSensors.Location = New System.Drawing.Point(0, 0)
        Me.lvSensors.Name = "lvSensors"
        Me.lvSensors.Size = New System.Drawing.Size(240, 243)
        Me.lvSensors.TabIndex = 0
        Me.lvSensors.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = ""
        Me.colID.Width = 0
        '
        'colStatus_RAW
        '
        Me.colStatus_RAW.Text = ""
        Me.colStatus_RAW.Width = 0
        '
        'colGroup
        '
        Me.colGroup.Text = "Group"
        Me.colGroup.Width = 60
        '
        'colDevice
        '
        Me.colDevice.Text = "Device"
        Me.colDevice.Width = 60
        '
        'colSensor
        '
        Me.colSensor.Text = "Sensor"
        Me.colSensor.Width = 60
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        Me.colStatus.Width = 60
        '
        'cmSensors
        '
        Me.cmSensors.MenuItems.Add(Me.miSensorStatus)
        '
        'miSensorStatus
        '
        Me.miSensorStatus.Text = "Sensor status"
        '
        'tmrLastRefresh
        '
        Me.tmrLastRefresh.Interval = 1000
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(0, 246)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(240, 20)
        Me.lblStatus.Text = "Collecting data..."
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(1, 43)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(237, 165)
        Me.lblError.Text = "Error"
        Me.lblError.Visible = False
        '
        'lblNoData
        '
        Me.lblNoData.Location = New System.Drawing.Point(1, 114)
        Me.lblNoData.Name = "lblNoData"
        Me.lblNoData.Size = New System.Drawing.Size(236, 20)
        Me.lblNoData.Text = "No sensors with error status found."
        Me.lblNoData.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblNoData.Visible = False
        '
        'Sensors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblNoData)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lvSensors)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "Sensors"
        Me.Text = "Network Monitor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents miRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents lvSensors As System.Windows.Forms.ListView
    Friend WithEvents colGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDevice As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSensor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents miMenu As System.Windows.Forms.MenuItem
    Friend WithEvents tmrLastRefresh As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents cmSensors As System.Windows.Forms.ContextMenu
    Friend WithEvents miSensorStatus As System.Windows.Forms.MenuItem
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus_RAW As System.Windows.Forms.ColumnHeader
    Friend WithEvents miSettings As System.Windows.Forms.MenuItem
    Friend WithEvents miAbout As System.Windows.Forms.MenuItem
    Friend WithEvents lblNoData As System.Windows.Forms.Label

End Class
