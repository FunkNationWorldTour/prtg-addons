namespace Paessler.Billingtool
{
    partial class ErrorMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessage));
            this.Pb_ErrorIcon = new System.Windows.Forms.PictureBox();
            this.Lbl_ErrorText = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_ErrorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // Pb_ErrorIcon
            // 
            this.Pb_ErrorIcon.Location = new System.Drawing.Point(22, 24);
            this.Pb_ErrorIcon.Name = "Pb_ErrorIcon";
            this.Pb_ErrorIcon.Size = new System.Drawing.Size(46, 42);
            this.Pb_ErrorIcon.TabIndex = 0;
            this.Pb_ErrorIcon.TabStop = false;
            // 
            // Lbl_ErrorText
            // 
            this.Lbl_ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ErrorText.Location = new System.Drawing.Point(74, 24);
            this.Lbl_ErrorText.Name = "Lbl_ErrorText";
            this.Lbl_ErrorText.Size = new System.Drawing.Size(334, 55);
            this.Lbl_ErrorText.TabIndex = 1;
            this.Lbl_ErrorText.Text = "Lbl_ErrorText";
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(184, 83);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 2;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // ErrorMessage
            // 
            this.AcceptButton = this.Btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 111);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Lbl_ErrorText);
            this.Controls.Add(this.Pb_ErrorIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ErrorMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pb_ErrorIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Pb_ErrorIcon;
        private System.Windows.Forms.Label Lbl_ErrorText;
        private System.Windows.Forms.Button Btn_Ok;
    }
}