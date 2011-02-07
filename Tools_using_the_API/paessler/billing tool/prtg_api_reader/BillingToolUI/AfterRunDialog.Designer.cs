namespace Paessler.Billingtool
{
    partial class AfterRunDialog
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
            this.Btn_OpenOutputFolder = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Lbl_ReadyText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_OpenOutputFolder
            // 
            this.Btn_OpenOutputFolder.Location = new System.Drawing.Point(12, 37);
            this.Btn_OpenOutputFolder.Name = "Btn_OpenOutputFolder";
            this.Btn_OpenOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenOutputFolder.TabIndex = 0;
            this.Btn_OpenOutputFolder.Text = "Open folder";
            this.Btn_OpenOutputFolder.UseVisualStyleBackColor = true;
            this.Btn_OpenOutputFolder.Click += new System.EventHandler(this.Btn_OpenOutputFolder_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(93, 37);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(75, 23);
            this.Btn_Close.TabIndex = 1;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Lbl_ReadyText
            // 
            this.Lbl_ReadyText.AutoSize = true;
            this.Lbl_ReadyText.Location = new System.Drawing.Point(44, 9);
            this.Lbl_ReadyText.Name = "Lbl_ReadyText";
            this.Lbl_ReadyText.Size = new System.Drawing.Size(94, 13);
            this.Lbl_ReadyText.TabIndex = 2;
            this.Lbl_ReadyText.Text = "Reports are ready!";
            // 
            // AfterRunDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 72);
            this.ControlBox = false;
            this.Controls.Add(this.Lbl_ReadyText);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Btn_OpenOutputFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AfterRunDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Done";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_OpenOutputFolder;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Label Lbl_ReadyText;
    }
}