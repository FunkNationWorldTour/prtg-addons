namespace Paessler.Billingtool
{
    partial class ServerConfig
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
            this.Btn_DeleteServer = new System.Windows.Forms.Button();
            this.Btn_EditServer = new System.Windows.Forms.Button();
            this.Btn_AddServer = new System.Windows.Forms.Button();
            this.Lb_ServerList = new System.Windows.Forms.ListBox();
            this.Lbl_ServerConfig = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_DeleteServer
            // 
            this.Btn_DeleteServer.Location = new System.Drawing.Point(258, 156);
            this.Btn_DeleteServer.Name = "Btn_DeleteServer";
            this.Btn_DeleteServer.Size = new System.Drawing.Size(120, 23);
            this.Btn_DeleteServer.TabIndex = 8;
            this.Btn_DeleteServer.Text = "Delete";
            this.Btn_DeleteServer.UseVisualStyleBackColor = true;
            this.Btn_DeleteServer.Click += new System.EventHandler(this.Btn_DeleteServer_Click);
            // 
            // Btn_EditServer
            // 
            this.Btn_EditServer.Location = new System.Drawing.Point(132, 156);
            this.Btn_EditServer.Name = "Btn_EditServer";
            this.Btn_EditServer.Size = new System.Drawing.Size(120, 23);
            this.Btn_EditServer.TabIndex = 7;
            this.Btn_EditServer.Text = "Edit";
            this.Btn_EditServer.UseVisualStyleBackColor = true;
            this.Btn_EditServer.Click += new System.EventHandler(this.Btn_EditServer_Click);
            // 
            // Btn_AddServer
            // 
            this.Btn_AddServer.Location = new System.Drawing.Point(6, 156);
            this.Btn_AddServer.Name = "Btn_AddServer";
            this.Btn_AddServer.Size = new System.Drawing.Size(120, 23);
            this.Btn_AddServer.TabIndex = 6;
            this.Btn_AddServer.Text = "Add";
            this.Btn_AddServer.UseVisualStyleBackColor = true;
            this.Btn_AddServer.Click += new System.EventHandler(this.Btn_AddServer_Click);
            // 
            // Lb_ServerList
            // 
            this.Lb_ServerList.CausesValidation = false;
            this.Lb_ServerList.FormattingEnabled = true;
            this.Lb_ServerList.Location = new System.Drawing.Point(6, 29);
            this.Lb_ServerList.Name = "Lb_ServerList";
            this.Lb_ServerList.Size = new System.Drawing.Size(372, 121);
            this.Lb_ServerList.TabIndex = 5;
            this.Lb_ServerList.SelectedIndexChanged += new System.EventHandler(this.Lb_ServerList_SelectedIndexChanged);
            // 
            // Lbl_ServerConfig
            // 
            this.Lbl_ServerConfig.AutoSize = true;
            this.Lbl_ServerConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ServerConfig.Location = new System.Drawing.Point(3, 0);
            this.Lbl_ServerConfig.Name = "Lbl_ServerConfig";
            this.Lbl_ServerConfig.Size = new System.Drawing.Size(149, 13);
            this.Lbl_ServerConfig.TabIndex = 9;
            this.Lbl_ServerConfig.Text = "PRTG Server Connection";
            // 
            // ServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lbl_ServerConfig);
            this.Controls.Add(this.Btn_DeleteServer);
            this.Controls.Add(this.Btn_EditServer);
            this.Controls.Add(this.Btn_AddServer);
            this.Controls.Add(this.Lb_ServerList);
            this.Name = "ServerConfig";
            this.Size = new System.Drawing.Size(387, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

            this.Load += new System.EventHandler(this.ServerConfig_Load);

        }

        #endregion

        private System.Windows.Forms.Button Btn_DeleteServer;
        private System.Windows.Forms.Button Btn_EditServer;
        private System.Windows.Forms.Button Btn_AddServer;
        private System.Windows.Forms.ListBox Lb_ServerList;
        private System.Windows.Forms.Label Lbl_ServerConfig;
    }
}
