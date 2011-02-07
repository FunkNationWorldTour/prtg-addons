namespace Paessler.Billingtool
{
    partial class ReportDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDialog));
            this.Txb_ReportName = new System.Windows.Forms.TextBox();
            this.Txb_SensorId = new System.Windows.Forms.TextBox();
            this.Lbl_ReportDialogCaption = new System.Windows.Forms.Label();
            this.Lbl_ReportName = new System.Windows.Forms.Label();
            this.Lbl_SensorId = new System.Windows.Forms.Label();
            this.Lbl_ClientAddress = new System.Windows.Forms.Label();
            this.Lbl_ScriptPath = new System.Windows.Forms.Label();
            this.Txb_ClientAddress = new System.Windows.Forms.TextBox();
            this.Lbl_TemapltePath = new System.Windows.Forms.Label();
            this.Txb_ClientInfo = new System.Windows.Forms.TextBox();
            this.Lbl_ClientInfo = new System.Windows.Forms.Label();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Cb_ScriptNames = new System.Windows.Forms.ComboBox();
            this.Cb_TemplteNames = new System.Windows.Forms.ComboBox();
            this.Cb_Average = new System.Windows.Forms.ComboBox();
            this.Lbl_Average = new System.Windows.Forms.Label();
            this.Tv_SensorTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_DropDownTreeView = new System.Windows.Forms.Button();
            this.Lbl_BillingHeader = new System.Windows.Forms.Label();
            this.Txb_BillingHeader = new System.Windows.Forms.TextBox();
            this.Txb_BillingFooter = new System.Windows.Forms.TextBox();
            this.Lbl_BillingFooter = new System.Windows.Forms.Label();
            this.Gb_Percentile = new System.Windows.Forms.GroupBox();
            this.Cb_UsePercentile = new System.Windows.Forms.CheckBox();
            this.Lbl_MinIntervall = new System.Windows.Forms.Label();
            this.Rb_PercentileDiscrete = new System.Windows.Forms.RadioButton();
            this.Rb_PercentileContinuous = new System.Windows.Forms.RadioButton();
            this.Nud_PercentileAvg = new System.Windows.Forms.NumericUpDown();
            this.Nud_PercentilePercent = new System.Windows.Forms.NumericUpDown();
            this.Lbl_PercentileBasedOn = new System.Windows.Forms.Label();
            this.Lbl_PercentilePercent = new System.Windows.Forms.Label();
            this.Gb_Percentile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_PercentileAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_PercentilePercent)).BeginInit();
            this.SuspendLayout();
            // 
            // Txb_ReportName
            // 
            this.Txb_ReportName.Location = new System.Drawing.Point(94, 43);
            this.Txb_ReportName.Name = "Txb_ReportName";
            this.Txb_ReportName.Size = new System.Drawing.Size(238, 20);
            this.Txb_ReportName.TabIndex = 2;
            this.Txb_ReportName.Validating += new System.ComponentModel.CancelEventHandler(this.Txb_ReportName_Validating);
            // 
            // Txb_SensorId
            // 
            this.Txb_SensorId.Location = new System.Drawing.Point(94, 69);
            this.Txb_SensorId.Name = "Txb_SensorId";
            this.Txb_SensorId.Size = new System.Drawing.Size(205, 20);
            this.Txb_SensorId.TabIndex = 4;
            this.Txb_SensorId.Validating += new System.ComponentModel.CancelEventHandler(this.Txb_SensorId_Validating);
            // 
            // Lbl_ReportDialogCaption
            // 
            this.Lbl_ReportDialogCaption.AutoSize = true;
            this.Lbl_ReportDialogCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ReportDialogCaption.Location = new System.Drawing.Point(12, 9);
            this.Lbl_ReportDialogCaption.Name = "Lbl_ReportDialogCaption";
            this.Lbl_ReportDialogCaption.Size = new System.Drawing.Size(156, 13);
            this.Lbl_ReportDialogCaption.TabIndex = 0;
            this.Lbl_ReportDialogCaption.Text = "Billing report configuartion";
            // 
            // Lbl_ReportName
            // 
            this.Lbl_ReportName.AutoSize = true;
            this.Lbl_ReportName.Location = new System.Drawing.Point(13, 46);
            this.Lbl_ReportName.Name = "Lbl_ReportName";
            this.Lbl_ReportName.Size = new System.Drawing.Size(38, 13);
            this.Lbl_ReportName.TabIndex = 1;
            this.Lbl_ReportName.Text = "Name:";
            // 
            // Lbl_SensorId
            // 
            this.Lbl_SensorId.AutoSize = true;
            this.Lbl_SensorId.Location = new System.Drawing.Point(12, 72);
            this.Lbl_SensorId.Name = "Lbl_SensorId";
            this.Lbl_SensorId.Size = new System.Drawing.Size(54, 13);
            this.Lbl_SensorId.TabIndex = 3;
            this.Lbl_SensorId.Text = "Sensor ID:";
            // 
            // Lbl_ClientAddress
            // 
            this.Lbl_ClientAddress.AutoSize = true;
            this.Lbl_ClientAddress.Location = new System.Drawing.Point(13, 183);
            this.Lbl_ClientAddress.Name = "Lbl_ClientAddress";
            this.Lbl_ClientAddress.Size = new System.Drawing.Size(76, 13);
            this.Lbl_ClientAddress.TabIndex = 11;
            this.Lbl_ClientAddress.Text = "Client address:";
            // 
            // Lbl_ScriptPath
            // 
            this.Lbl_ScriptPath.AutoSize = true;
            this.Lbl_ScriptPath.Location = new System.Drawing.Point(12, 98);
            this.Lbl_ScriptPath.Name = "Lbl_ScriptPath";
            this.Lbl_ScriptPath.Size = new System.Drawing.Size(37, 13);
            this.Lbl_ScriptPath.TabIndex = 5;
            this.Lbl_ScriptPath.Text = "Script:";
            // 
            // Txb_ClientAddress
            // 
            this.Txb_ClientAddress.Location = new System.Drawing.Point(94, 180);
            this.Txb_ClientAddress.Multiline = true;
            this.Txb_ClientAddress.Name = "Txb_ClientAddress";
            this.Txb_ClientAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_ClientAddress.Size = new System.Drawing.Size(238, 98);
            this.Txb_ClientAddress.TabIndex = 12;
            // 
            // Lbl_TemapltePath
            // 
            this.Lbl_TemapltePath.AutoSize = true;
            this.Lbl_TemapltePath.Location = new System.Drawing.Point(12, 124);
            this.Lbl_TemapltePath.Name = "Lbl_TemapltePath";
            this.Lbl_TemapltePath.Size = new System.Drawing.Size(54, 13);
            this.Lbl_TemapltePath.TabIndex = 7;
            this.Lbl_TemapltePath.Text = "Template:";
            // 
            // Txb_ClientInfo
            // 
            this.Txb_ClientInfo.Location = new System.Drawing.Point(94, 284);
            this.Txb_ClientInfo.Multiline = true;
            this.Txb_ClientInfo.Name = "Txb_ClientInfo";
            this.Txb_ClientInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_ClientInfo.Size = new System.Drawing.Size(238, 98);
            this.Txb_ClientInfo.TabIndex = 14;
            // 
            // Lbl_ClientInfo
            // 
            this.Lbl_ClientInfo.AutoSize = true;
            this.Lbl_ClientInfo.Location = new System.Drawing.Point(13, 287);
            this.Lbl_ClientInfo.Name = "Lbl_ClientInfo";
            this.Lbl_ClientInfo.Size = new System.Drawing.Size(56, 13);
            this.Lbl_ClientInfo.TabIndex = 13;
            this.Lbl_ClientInfo.Text = "Client info:";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(635, 400);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(84, 22);
            this.Btn_Cancel.TabIndex = 16;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(545, 400);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(84, 22);
            this.Btn_Ok.TabIndex = 15;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Cb_ScriptNames
            // 
            this.Cb_ScriptNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_ScriptNames.FormattingEnabled = true;
            this.Cb_ScriptNames.Location = new System.Drawing.Point(94, 95);
            this.Cb_ScriptNames.Name = "Cb_ScriptNames";
            this.Cb_ScriptNames.Size = new System.Drawing.Size(238, 21);
            this.Cb_ScriptNames.TabIndex = 18;
            // 
            // Cb_TemplteNames
            // 
            this.Cb_TemplteNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_TemplteNames.FormattingEnabled = true;
            this.Cb_TemplteNames.Location = new System.Drawing.Point(94, 121);
            this.Cb_TemplteNames.Name = "Cb_TemplteNames";
            this.Cb_TemplteNames.Size = new System.Drawing.Size(238, 21);
            this.Cb_TemplteNames.TabIndex = 19;
            // 
            // Cb_Average
            // 
            this.Cb_Average.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Average.FormattingEnabled = true;
            this.Cb_Average.Location = new System.Drawing.Point(94, 148);
            this.Cb_Average.Name = "Cb_Average";
            this.Cb_Average.Size = new System.Drawing.Size(238, 21);
            this.Cb_Average.TabIndex = 20;
            // 
            // Lbl_Average
            // 
            this.Lbl_Average.AutoSize = true;
            this.Lbl_Average.Location = new System.Drawing.Point(13, 151);
            this.Lbl_Average.Name = "Lbl_Average";
            this.Lbl_Average.Size = new System.Drawing.Size(50, 13);
            this.Lbl_Average.TabIndex = 21;
            this.Lbl_Average.Text = "Average:";
            // 
            // Tv_SensorTree
            // 
            this.Tv_SensorTree.ImageIndex = 0;
            this.Tv_SensorTree.ImageList = this.imageList1;
            this.Tv_SensorTree.Location = new System.Drawing.Point(200, 9);
            this.Tv_SensorTree.Name = "Tv_SensorTree";
            this.Tv_SensorTree.SelectedImageIndex = 0;
            this.Tv_SensorTree.Size = new System.Drawing.Size(165, 17);
            this.Tv_SensorTree.TabIndex = 22;
            this.Tv_SensorTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.Tv_SensorTree_BeforeSelect);
            this.Tv_SensorTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tv_SensorTree_AfterSelect);
            this.Tv_SensorTree.DoubleClick += new System.EventHandler(this.Tv_SensorTree_DoubleClick);
            this.Tv_SensorTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tv_SensorTree_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "device");
            this.imageList1.Images.SetKeyName(1, "group");
            this.imageList1.Images.SetKeyName(2, "plus");
            this.imageList1.Images.SetKeyName(3, "probe");
            // 
            // btn_DropDownTreeView
            // 
            this.btn_DropDownTreeView.Location = new System.Drawing.Point(305, 69);
            this.btn_DropDownTreeView.Name = "btn_DropDownTreeView";
            this.btn_DropDownTreeView.Size = new System.Drawing.Size(27, 21);
            this.btn_DropDownTreeView.TabIndex = 23;
            this.btn_DropDownTreeView.Text = "6";
            this.btn_DropDownTreeView.UseVisualStyleBackColor = true;
            this.btn_DropDownTreeView.Click += new System.EventHandler(this.btn_DropDownTreeView_Click);
            // 
            // Lbl_BillingHeader
            // 
            this.Lbl_BillingHeader.AutoSize = true;
            this.Lbl_BillingHeader.Location = new System.Drawing.Point(351, 43);
            this.Lbl_BillingHeader.Name = "Lbl_BillingHeader";
            this.Lbl_BillingHeader.Size = new System.Drawing.Size(73, 13);
            this.Lbl_BillingHeader.TabIndex = 24;
            this.Lbl_BillingHeader.Text = "Billing header:";
            // 
            // Txb_BillingHeader
            // 
            this.Txb_BillingHeader.Location = new System.Drawing.Point(354, 59);
            this.Txb_BillingHeader.Multiline = true;
            this.Txb_BillingHeader.Name = "Txb_BillingHeader";
            this.Txb_BillingHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_BillingHeader.Size = new System.Drawing.Size(365, 71);
            this.Txb_BillingHeader.TabIndex = 25;
            // 
            // Txb_BillingFooter
            // 
            this.Txb_BillingFooter.Location = new System.Drawing.Point(354, 151);
            this.Txb_BillingFooter.Multiline = true;
            this.Txb_BillingFooter.Name = "Txb_BillingFooter";
            this.Txb_BillingFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_BillingFooter.Size = new System.Drawing.Size(365, 71);
            this.Txb_BillingFooter.TabIndex = 27;
            // 
            // Lbl_BillingFooter
            // 
            this.Lbl_BillingFooter.AutoSize = true;
            this.Lbl_BillingFooter.Location = new System.Drawing.Point(351, 135);
            this.Lbl_BillingFooter.Name = "Lbl_BillingFooter";
            this.Lbl_BillingFooter.Size = new System.Drawing.Size(67, 13);
            this.Lbl_BillingFooter.TabIndex = 26;
            this.Lbl_BillingFooter.Text = "Billing footer:";
            // 
            // Gb_Percentile
            // 
            this.Gb_Percentile.Controls.Add(this.Cb_UsePercentile);
            this.Gb_Percentile.Controls.Add(this.Lbl_MinIntervall);
            this.Gb_Percentile.Controls.Add(this.Rb_PercentileDiscrete);
            this.Gb_Percentile.Controls.Add(this.Rb_PercentileContinuous);
            this.Gb_Percentile.Controls.Add(this.Nud_PercentileAvg);
            this.Gb_Percentile.Controls.Add(this.Nud_PercentilePercent);
            this.Gb_Percentile.Controls.Add(this.Lbl_PercentileBasedOn);
            this.Gb_Percentile.Controls.Add(this.Lbl_PercentilePercent);
            this.Gb_Percentile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gb_Percentile.Location = new System.Drawing.Point(354, 228);
            this.Gb_Percentile.Name = "Gb_Percentile";
            this.Gb_Percentile.Size = new System.Drawing.Size(365, 154);
            this.Gb_Percentile.TabIndex = 28;
            this.Gb_Percentile.TabStop = false;
            this.Gb_Percentile.Text = "Percentile";
            // 
            // Cb_UsePercentile
            // 
            this.Cb_UsePercentile.AutoSize = true;
            this.Cb_UsePercentile.Location = new System.Drawing.Point(9, 26);
            this.Cb_UsePercentile.Name = "Cb_UsePercentile";
            this.Cb_UsePercentile.Size = new System.Drawing.Size(94, 17);
            this.Cb_UsePercentile.TabIndex = 29;
            this.Cb_UsePercentile.Text = "Use percentile";
            this.Cb_UsePercentile.UseVisualStyleBackColor = true;
            this.Cb_UsePercentile.CheckedChanged += new System.EventHandler(this.Cb_UsePercentile_CheckedChanged);
            // 
            // Lbl_MinIntervall
            // 
            this.Lbl_MinIntervall.AutoSize = true;
            this.Lbl_MinIntervall.Location = new System.Drawing.Point(220, 82);
            this.Lbl_MinIntervall.Name = "Lbl_MinIntervall";
            this.Lbl_MinIntervall.Size = new System.Drawing.Size(65, 13);
            this.Lbl_MinIntervall.TabIndex = 8;
            this.Lbl_MinIntervall.Text = "min. intervals";
            // 
            // Rb_PercentileDiscrete
            // 
            this.Rb_PercentileDiscrete.AutoSize = true;
            this.Rb_PercentileDiscrete.Location = new System.Drawing.Point(9, 129);
            this.Rb_PercentileDiscrete.Name = "Rb_PercentileDiscrete";
            this.Rb_PercentileDiscrete.Size = new System.Drawing.Size(325, 17);
            this.Rb_PercentileDiscrete.TabIndex = 7;
            this.Rb_PercentileDiscrete.Text = "Use Discrete Percentile (choose the next smaller discrete value)";
            this.Rb_PercentileDiscrete.UseVisualStyleBackColor = true;
            // 
            // Rb_PercentileContinuous
            // 
            this.Rb_PercentileContinuous.AutoSize = true;
            this.Rb_PercentileContinuous.Checked = true;
            this.Rb_PercentileContinuous.Location = new System.Drawing.Point(9, 106);
            this.Rb_PercentileContinuous.Name = "Rb_PercentileContinuous";
            this.Rb_PercentileContinuous.Size = new System.Drawing.Size(326, 17);
            this.Rb_PercentileContinuous.TabIndex = 6;
            this.Rb_PercentileContinuous.TabStop = true;
            this.Rb_PercentileContinuous.Text = "Use Continuous Percentile (interpolate between discrete values)";
            this.Rb_PercentileContinuous.UseVisualStyleBackColor = true;
            // 
            // Nud_PercentileAvg
            // 
            this.Nud_PercentileAvg.Location = new System.Drawing.Point(111, 80);
            this.Nud_PercentileAvg.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Nud_PercentileAvg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_PercentileAvg.Name = "Nud_PercentileAvg";
            this.Nud_PercentileAvg.Size = new System.Drawing.Size(103, 20);
            this.Nud_PercentileAvg.TabIndex = 5;
            this.Nud_PercentileAvg.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // Nud_PercentilePercent
            // 
            this.Nud_PercentilePercent.Location = new System.Drawing.Point(111, 54);
            this.Nud_PercentilePercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_PercentilePercent.Name = "Nud_PercentilePercent";
            this.Nud_PercentilePercent.Size = new System.Drawing.Size(103, 20);
            this.Nud_PercentilePercent.TabIndex = 3;
            this.Nud_PercentilePercent.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // Lbl_PercentileBasedOn
            // 
            this.Lbl_PercentileBasedOn.AutoSize = true;
            this.Lbl_PercentileBasedOn.Location = new System.Drawing.Point(6, 82);
            this.Lbl_PercentileBasedOn.Name = "Lbl_PercentileBasedOn";
            this.Lbl_PercentileBasedOn.Size = new System.Drawing.Size(55, 13);
            this.Lbl_PercentileBasedOn.TabIndex = 1;
            this.Lbl_PercentileBasedOn.Text = "Based on:";
            // 
            // Lbl_PercentilePercent
            // 
            this.Lbl_PercentilePercent.AutoSize = true;
            this.Lbl_PercentilePercent.Location = new System.Drawing.Point(6, 56);
            this.Lbl_PercentilePercent.Name = "Lbl_PercentilePercent";
            this.Lbl_PercentilePercent.Size = new System.Drawing.Size(47, 13);
            this.Lbl_PercentilePercent.TabIndex = 0;
            this.Lbl_PercentilePercent.Text = "Percent:";
            // 
            // ReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 432);
            this.Controls.Add(this.Gb_Percentile);
            this.Controls.Add(this.Txb_BillingFooter);
            this.Controls.Add(this.Lbl_BillingFooter);
            this.Controls.Add(this.Txb_BillingHeader);
            this.Controls.Add(this.Lbl_BillingHeader);
            this.Controls.Add(this.Tv_SensorTree);
            this.Controls.Add(this.btn_DropDownTreeView);
            this.Controls.Add(this.Lbl_Average);
            this.Controls.Add(this.Cb_Average);
            this.Controls.Add(this.Cb_TemplteNames);
            this.Controls.Add(this.Cb_ScriptNames);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Txb_ClientInfo);
            this.Controls.Add(this.Lbl_ClientInfo);
            this.Controls.Add(this.Lbl_TemapltePath);
            this.Controls.Add(this.Txb_ClientAddress);
            this.Controls.Add(this.Lbl_ScriptPath);
            this.Controls.Add(this.Lbl_ClientAddress);
            this.Controls.Add(this.Lbl_SensorId);
            this.Controls.Add(this.Lbl_ReportName);
            this.Controls.Add(this.Lbl_ReportDialogCaption);
            this.Controls.Add(this.Txb_SensorId);
            this.Controls.Add(this.Txb_ReportName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportDialog_Load);
            this.Gb_Percentile.ResumeLayout(false);
            this.Gb_Percentile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_PercentileAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_PercentilePercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txb_ReportName;
        private System.Windows.Forms.TextBox Txb_SensorId;
        private System.Windows.Forms.Label Lbl_ReportDialogCaption;
        private System.Windows.Forms.Label Lbl_ReportName;
        private System.Windows.Forms.Label Lbl_SensorId;
        private System.Windows.Forms.Label Lbl_ClientAddress;
        private System.Windows.Forms.Label Lbl_ScriptPath;
        private System.Windows.Forms.TextBox Txb_ClientAddress;
        private System.Windows.Forms.Label Lbl_TemapltePath;
        private System.Windows.Forms.TextBox Txb_ClientInfo;
        private System.Windows.Forms.Label Lbl_ClientInfo;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.ComboBox Cb_ScriptNames;
        private System.Windows.Forms.ComboBox Cb_TemplteNames;
        private System.Windows.Forms.ComboBox Cb_Average;
        private System.Windows.Forms.Label Lbl_Average;
        private System.Windows.Forms.TreeView Tv_SensorTree;
        private System.Windows.Forms.Button btn_DropDownTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label Lbl_BillingHeader;
        private System.Windows.Forms.TextBox Txb_BillingHeader;
        private System.Windows.Forms.TextBox Txb_BillingFooter;
        private System.Windows.Forms.Label Lbl_BillingFooter;
        private System.Windows.Forms.GroupBox Gb_Percentile;
        private System.Windows.Forms.RadioButton Rb_PercentileDiscrete;
        private System.Windows.Forms.RadioButton Rb_PercentileContinuous;
        private System.Windows.Forms.NumericUpDown Nud_PercentilePercent;
        private System.Windows.Forms.Label Lbl_PercentileBasedOn;
        private System.Windows.Forms.Label Lbl_PercentilePercent;
        private System.Windows.Forms.Label Lbl_MinIntervall;
        private System.Windows.Forms.CheckBox Cb_UsePercentile;
        private System.Windows.Forms.NumericUpDown Nud_PercentileAvg;
    }
}