namespace Paessler.Billingtool
{
    partial class GetVersionAndHashDialog
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
            this.Pb_Progress = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Tim_Progress = new System.Windows.Forms.Timer(this.components);
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Pb_Progress
            // 
            this.Pb_Progress.Location = new System.Drawing.Point(15, 34);
            this.Pb_Progress.Name = "Pb_Progress";
            this.Pb_Progress.Size = new System.Drawing.Size(371, 26);
            this.Pb_Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Pb_Progress.TabIndex = 4;
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.AutoSize = true;
            this.Lbl_Status.Location = new System.Drawing.Point(12, 9);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Status.TabIndex = 3;
            this.Lbl_Status.Text = "label1";
            // 
            // GetVersionAndHashDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 79);
            this.Controls.Add(this.Lbl_Status);
            this.Controls.Add(this.Pb_Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetVersionAndHashDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fetching data...";
            this.Load += new System.EventHandler(this.GetHashDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Pb_Progress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer Tim_Progress;
        private System.Windows.Forms.Label Lbl_Status;
    }
}