namespace Paessler.Billingtool
{
    partial class GeneralOptions
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txb_OutputFolder = new System.Windows.Forms.TextBox();
            this.Lbl_OutputFolder = new System.Windows.Forms.Label();
            this.Btn_BrowseOutput = new System.Windows.Forms.Button();
            this.Lbl_BillingLogo = new System.Windows.Forms.Label();
            this.Btn_BrowseLogo = new System.Windows.Forms.Button();
            this.Txb_CompanyLogo = new System.Windows.Forms.TextBox();
            this.Lbl_BillingFooter = new System.Windows.Forms.Label();
            this.Txb_BillingFooter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Txb_OutputFolder
            // 
            this.Txb_OutputFolder.Location = new System.Drawing.Point(7, 69);
            this.Txb_OutputFolder.Name = "Txb_OutputFolder";
            this.Txb_OutputFolder.Size = new System.Drawing.Size(282, 20);
            this.Txb_OutputFolder.TabIndex = 0;
            // 
            // Lbl_OutputFolder
            // 
            this.Lbl_OutputFolder.AutoSize = true;
            this.Lbl_OutputFolder.Location = new System.Drawing.Point(4, 53);
            this.Lbl_OutputFolder.Name = "Lbl_OutputFolder";
            this.Lbl_OutputFolder.Size = new System.Drawing.Size(104, 13);
            this.Lbl_OutputFolder.TabIndex = 1;
            this.Lbl_OutputFolder.Text = "Report output folder:";
            // 
            // Btn_BrowseOutput
            // 
            this.Btn_BrowseOutput.Location = new System.Drawing.Point(295, 67);
            this.Btn_BrowseOutput.Name = "Btn_BrowseOutput";
            this.Btn_BrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.Btn_BrowseOutput.TabIndex = 2;
            this.Btn_BrowseOutput.Text = "Browse";
            this.Btn_BrowseOutput.UseVisualStyleBackColor = true;
            this.Btn_BrowseOutput.Click += new System.EventHandler(this.Btn_BrowseOutput_Click);
            // 
            // Lbl_BillingLogo
            // 
            this.Lbl_BillingLogo.AutoSize = true;
            this.Lbl_BillingLogo.Location = new System.Drawing.Point(4, 9);
            this.Lbl_BillingLogo.Name = "Lbl_BillingLogo";
            this.Lbl_BillingLogo.Size = new System.Drawing.Size(77, 13);
            this.Lbl_BillingLogo.TabIndex = 3;
            this.Lbl_BillingLogo.Text = "Company logo:";
            // 
            // Btn_BrowseLogo
            // 
            this.Btn_BrowseLogo.Location = new System.Drawing.Point(295, 23);
            this.Btn_BrowseLogo.Name = "Btn_BrowseLogo";
            this.Btn_BrowseLogo.Size = new System.Drawing.Size(75, 23);
            this.Btn_BrowseLogo.TabIndex = 5;
            this.Btn_BrowseLogo.Text = "Browse";
            this.Btn_BrowseLogo.UseVisualStyleBackColor = true;
            this.Btn_BrowseLogo.Click += new System.EventHandler(this.Btn_BrowseLogo_Click);
            // 
            // Txb_CompanyLogo
            // 
            this.Txb_CompanyLogo.Location = new System.Drawing.Point(7, 25);
            this.Txb_CompanyLogo.Name = "Txb_CompanyLogo";
            this.Txb_CompanyLogo.Size = new System.Drawing.Size(282, 20);
            this.Txb_CompanyLogo.TabIndex = 4;
            // 
            // Lbl_BillingFooter
            // 
            this.Lbl_BillingFooter.AutoSize = true;
            this.Lbl_BillingFooter.Location = new System.Drawing.Point(4, 112);
            this.Lbl_BillingFooter.Name = "Lbl_BillingFooter";
            this.Lbl_BillingFooter.Size = new System.Drawing.Size(67, 13);
            this.Lbl_BillingFooter.TabIndex = 6;
            this.Lbl_BillingFooter.Text = "Billing footer:";
            // 
            // Txb_BillingFooter
            // 
            this.Txb_BillingFooter.Location = new System.Drawing.Point(7, 128);
            this.Txb_BillingFooter.Multiline = true;
            this.Txb_BillingFooter.Name = "Txb_BillingFooter";
            this.Txb_BillingFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_BillingFooter.Size = new System.Drawing.Size(365, 71);
            this.Txb_BillingFooter.TabIndex = 7;
            // 
            // GeneralOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Txb_OutputFolder);
            this.Controls.Add(this.Txb_BillingFooter);
            this.Controls.Add(this.Lbl_BillingFooter);
            this.Controls.Add(this.Btn_BrowseLogo);
            this.Controls.Add(this.Txb_CompanyLogo);
            this.Controls.Add(this.Lbl_BillingLogo);
            this.Controls.Add(this.Btn_BrowseOutput);
            this.Controls.Add(this.Lbl_OutputFolder);
            this.Name = "GeneralOptions";
            this.Size = new System.Drawing.Size(388, 233);
            this.Load += new System.EventHandler(this.FolderOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txb_OutputFolder;
        private System.Windows.Forms.Label Lbl_OutputFolder;
        private System.Windows.Forms.Button Btn_BrowseOutput;
        private System.Windows.Forms.Label Lbl_BillingLogo;
        private System.Windows.Forms.Button Btn_BrowseLogo;
        private System.Windows.Forms.TextBox Txb_CompanyLogo;
        private System.Windows.Forms.Label Lbl_BillingFooter;
        private System.Windows.Forms.TextBox Txb_BillingFooter;
    }
}
