<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.lblProduct = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblCompany = New System.Windows.Forms.Label
        Me.lblRegistrated = New System.Windows.Forms.Label
        Me.lblClose = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.BackColor = System.Drawing.Color.Transparent
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(165, 25)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(54, 16)
        Me.lblProduct.TabIndex = 0
        Me.lblProduct.Text = "Product"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(165, 56)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(54, 16)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Version"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(165, 86)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(66, 16)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = "Company"
        '
        'lblRegistrated
        '
        Me.lblRegistrated.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistrated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrated.Location = New System.Drawing.Point(165, 116)
        Me.lblRegistrated.Name = "lblRegistrated"
        Me.lblRegistrated.Size = New System.Drawing.Size(299, 63)
        Me.lblRegistrated.TabIndex = 0
        Me.lblRegistrated.Text = "Unregistrated version"
        Me.lblRegistrated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClose
        '
        Me.lblClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClose.AutoSize = True
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.ForeColor = System.Drawing.Color.Blue
        Me.lblClose.Image = Global.Notifier.My.Resources.Resources.delete
        Me.lblClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClose.LinkArea = New System.Windows.Forms.LinkArea(0, 20)
        Me.lblClose.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblClose.Location = New System.Drawing.Point(417, 188)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(54, 17)
        Me.lblClose.TabIndex = 3
        Me.lblClose.TabStop = True
        Me.lblClose.Text = "       Close"
        Me.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblClose.UseCompatibleTextRendering = True
        Me.lblClose.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Notifier.My.Resources.Resources.welcome_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(476, 210)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblRegistrated)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblProduct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents lblRegistrated As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.LinkLabel
End Class
