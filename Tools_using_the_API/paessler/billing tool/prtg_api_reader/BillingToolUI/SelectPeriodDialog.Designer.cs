namespace Paessler.Billingtool
{
    partial class SelectPeriodDialog
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
            this.Dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.Dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_StartDate = new System.Windows.Forms.Label();
            this.Lbl_EndDate = new System.Windows.Forms.Label();
            this.Btn_Select = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Lbl_Caption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Dtp_StartDate
            // 
            this.Dtp_StartDate.CustomFormat = "";
            this.Dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_StartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Dtp_StartDate.Location = new System.Drawing.Point(47, 38);
            this.Dtp_StartDate.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.Dtp_StartDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.Dtp_StartDate.Name = "Dtp_StartDate";
            this.Dtp_StartDate.Size = new System.Drawing.Size(119, 20);
            this.Dtp_StartDate.TabIndex = 2;
            this.Dtp_StartDate.Value = new System.DateTime(2010, 11, 23, 17, 57, 37, 0);
            // 
            // Dtp_EndDate
            // 
            this.Dtp_EndDate.CustomFormat = "";
            this.Dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_EndDate.Location = new System.Drawing.Point(47, 64);
            this.Dtp_EndDate.Name = "Dtp_EndDate";
            this.Dtp_EndDate.Size = new System.Drawing.Size(119, 20);
            this.Dtp_EndDate.TabIndex = 4;
            // 
            // Lbl_StartDate
            // 
            this.Lbl_StartDate.AutoSize = true;
            this.Lbl_StartDate.Location = new System.Drawing.Point(12, 44);
            this.Lbl_StartDate.Name = "Lbl_StartDate";
            this.Lbl_StartDate.Size = new System.Drawing.Size(32, 13);
            this.Lbl_StartDate.TabIndex = 1;
            this.Lbl_StartDate.Text = "Start:";
            // 
            // Lbl_EndDate
            // 
            this.Lbl_EndDate.AutoSize = true;
            this.Lbl_EndDate.Location = new System.Drawing.Point(12, 70);
            this.Lbl_EndDate.Name = "Lbl_EndDate";
            this.Lbl_EndDate.Size = new System.Drawing.Size(29, 13);
            this.Lbl_EndDate.TabIndex = 3;
            this.Lbl_EndDate.Text = "End:";
            // 
            // Btn_Select
            // 
            this.Btn_Select.Location = new System.Drawing.Point(15, 90);
            this.Btn_Select.Name = "Btn_Select";
            this.Btn_Select.Size = new System.Drawing.Size(60, 23);
            this.Btn_Select.TabIndex = 5;
            this.Btn_Select.Text = "Run";
            this.Btn_Select.UseVisualStyleBackColor = true;
            this.Btn_Select.Click += new System.EventHandler(this.Btn_Select_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(106, 90);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(60, 23);
            this.Btn_Cancel.TabIndex = 6;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Lbl_Caption
            // 
            this.Lbl_Caption.AutoSize = true;
            this.Lbl_Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Caption.Location = new System.Drawing.Point(12, 9);
            this.Lbl_Caption.Name = "Lbl_Caption";
            this.Lbl_Caption.Size = new System.Drawing.Size(82, 13);
            this.Lbl_Caption.TabIndex = 0;
            this.Lbl_Caption.Text = "Select period";
            // 
            // SelectPeriodDialog
            // 
            this.AcceptButton = this.Btn_Select;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Cancel;
            this.ClientSize = new System.Drawing.Size(180, 126);
            this.Controls.Add(this.Lbl_Caption);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Select);
            this.Controls.Add(this.Lbl_EndDate);
            this.Controls.Add(this.Lbl_StartDate);
            this.Controls.Add(this.Dtp_EndDate);
            this.Controls.Add(this.Dtp_StartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPeriodDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Period";
            this.Load += new System.EventHandler(this.SelectPeriodDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Dtp_StartDate;
        private System.Windows.Forms.DateTimePicker Dtp_EndDate;
        private System.Windows.Forms.Label Lbl_StartDate;
        private System.Windows.Forms.Label Lbl_EndDate;
        private System.Windows.Forms.Button Btn_Select;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label Lbl_Caption;
    }
}