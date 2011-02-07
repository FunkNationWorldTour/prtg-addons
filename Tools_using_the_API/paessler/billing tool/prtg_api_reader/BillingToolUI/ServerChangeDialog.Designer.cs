namespace Paessler.Billingtool
{
    partial class ServerChangeDialog
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
            this.Pb_CurrentState = new System.Windows.Forms.ProgressBar();
            this.Lbl_CurrentState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Pb_CurrentState
            // 
            this.Pb_CurrentState.Location = new System.Drawing.Point(12, 33);
            this.Pb_CurrentState.Name = "Pb_CurrentState";
            this.Pb_CurrentState.Size = new System.Drawing.Size(325, 23);
            this.Pb_CurrentState.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Pb_CurrentState.TabIndex = 1;
            // 
            // Lbl_CurrentState
            // 
            this.Lbl_CurrentState.AutoSize = true;
            this.Lbl_CurrentState.Location = new System.Drawing.Point(12, 9);
            this.Lbl_CurrentState.Name = "Lbl_CurrentState";
            this.Lbl_CurrentState.Size = new System.Drawing.Size(35, 13);
            this.Lbl_CurrentState.TabIndex = 2;
            this.Lbl_CurrentState.Text = "label1";
            // 
            // ServerChangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 70);
            this.Controls.Add(this.Lbl_CurrentState);
            this.Controls.Add(this.Pb_CurrentState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerChangeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connecting...";
            this.Load += new System.EventHandler(this.RunDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Pb_CurrentState;
        private System.Windows.Forms.Label Lbl_CurrentState;
    }
}