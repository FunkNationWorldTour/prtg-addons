namespace Paessler.Billingtool
{
    partial class TemplateOptions
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
            this.Lbl_TemplateOptions = new System.Windows.Forms.Label();
            this.Lbl_TemplateHeader = new System.Windows.Forms.Label();
            this.Txb_DefaultBillingHeader = new System.Windows.Forms.TextBox();
            this.Txb_DefaultBillingFooter = new System.Windows.Forms.TextBox();
            this.Lbl_BillingFooter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_TemplateOptions
            // 
            this.Lbl_TemplateOptions.AutoSize = true;
            this.Lbl_TemplateOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_TemplateOptions.Location = new System.Drawing.Point(3, 0);
            this.Lbl_TemplateOptions.Name = "Lbl_TemplateOptions";
            this.Lbl_TemplateOptions.Size = new System.Drawing.Size(104, 13);
            this.Lbl_TemplateOptions.TabIndex = 0;
            this.Lbl_TemplateOptions.Text = "Template Options";
            // 
            // Lbl_TemplateHeader
            // 
            this.Lbl_TemplateHeader.AutoSize = true;
            this.Lbl_TemplateHeader.Location = new System.Drawing.Point(3, 24);
            this.Lbl_TemplateHeader.Name = "Lbl_TemplateHeader";
            this.Lbl_TemplateHeader.Size = new System.Drawing.Size(123, 13);
            this.Lbl_TemplateHeader.TabIndex = 1;
            this.Lbl_TemplateHeader.Text = "Default billing header text:";
            // 
            // Txb_DefaultBillingHeader
            // 
            this.Txb_DefaultBillingHeader.Location = new System.Drawing.Point(6, 40);
            this.Txb_DefaultBillingHeader.Multiline = true;
            this.Txb_DefaultBillingHeader.Name = "Txb_DefaultBillingHeader";
            this.Txb_DefaultBillingHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_DefaultBillingHeader.Size = new System.Drawing.Size(365, 71);
            this.Txb_DefaultBillingHeader.TabIndex = 2;
            // 
            // Txb_DefaultBillingFooter
            // 
            this.Txb_DefaultBillingFooter.Location = new System.Drawing.Point(6, 137);
            this.Txb_DefaultBillingFooter.Multiline = true;
            this.Txb_DefaultBillingFooter.Name = "Txb_DefaultBillingFooter";
            this.Txb_DefaultBillingFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txb_DefaultBillingFooter.Size = new System.Drawing.Size(365, 71);
            this.Txb_DefaultBillingFooter.TabIndex = 4;
            // 
            // Lbl_BillingFooter
            // 
            this.Lbl_BillingFooter.AutoSize = true;
            this.Lbl_BillingFooter.Location = new System.Drawing.Point(3, 121);
            this.Lbl_BillingFooter.Name = "Lbl_BillingFooter";
            this.Lbl_BillingFooter.Size = new System.Drawing.Size(129, 13);
            this.Lbl_BillingFooter.TabIndex = 3;
            this.Lbl_BillingFooter.Text = "Default billing footer text:";
            // 
            // TemplateOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Txb_DefaultBillingFooter);
            this.Controls.Add(this.Lbl_BillingFooter);
            this.Controls.Add(this.Txb_DefaultBillingHeader);
            this.Controls.Add(this.Lbl_TemplateHeader);
            this.Controls.Add(this.Lbl_TemplateOptions);
            this.Name = "TemplateOptions";
            this.Size = new System.Drawing.Size(388, 233);
            this.Load += new System.EventHandler(this.TemplateOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_TemplateOptions;
        private System.Windows.Forms.Label Lbl_TemplateHeader;
        private System.Windows.Forms.TextBox Txb_DefaultBillingHeader;
        private System.Windows.Forms.TextBox Txb_DefaultBillingFooter;
        private System.Windows.Forms.Label Lbl_BillingFooter;
    }
}
