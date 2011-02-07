namespace Paessler.Billingtool
{
    partial class ServerDialog
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
            this.Lbl_ServerIp = new System.Windows.Forms.Label();
            this.Lbl_ServerPort = new System.Windows.Forms.Label();
            this.Lbl_Username = new System.Windows.Forms.Label();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Lbl_DisplayName = new System.Windows.Forms.Label();
            this.Txb_ServerIp = new System.Windows.Forms.TextBox();
            this.Txb_Username = new System.Windows.Forms.TextBox();
            this.Txb_DisplayName = new System.Windows.Forms.TextBox();
            this.Nud_port = new System.Windows.Forms.NumericUpDown();
            this.Mtxb_password = new System.Windows.Forms.MaskedTextBox();
            this.Cbox_UseSsl = new System.Windows.Forms.CheckBox();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Lbl_SslPort = new System.Windows.Forms.Label();
            this.Btn_GetHash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_port)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_ServerIp
            // 
            this.Lbl_ServerIp.AutoSize = true;
            this.Lbl_ServerIp.Location = new System.Drawing.Point(3, 9);
            this.Lbl_ServerIp.Name = "Lbl_ServerIp";
            this.Lbl_ServerIp.Size = new System.Drawing.Size(119, 13);
            this.Lbl_ServerIp.TabIndex = 9;
            this.Lbl_ServerIp.Text = "Server-IP / DNS-Name:";
            // 
            // Lbl_ServerPort
            // 
            this.Lbl_ServerPort.AutoSize = true;
            this.Lbl_ServerPort.Location = new System.Drawing.Point(3, 34);
            this.Lbl_ServerPort.Name = "Lbl_ServerPort";
            this.Lbl_ServerPort.Size = new System.Drawing.Size(29, 13);
            this.Lbl_ServerPort.TabIndex = 10;
            this.Lbl_ServerPort.Text = "Port:";
            // 
            // Lbl_Username
            // 
            this.Lbl_Username.AutoSize = true;
            this.Lbl_Username.Location = new System.Drawing.Point(3, 61);
            this.Lbl_Username.Name = "Lbl_Username";
            this.Lbl_Username.Size = new System.Drawing.Size(58, 13);
            this.Lbl_Username.TabIndex = 11;
            this.Lbl_Username.Text = "Username:";
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Location = new System.Drawing.Point(3, 87);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(79, 13);
            this.Lbl_Password.TabIndex = 12;
            this.Lbl_Password.Text = "Passwordhash:";
            // 
            // Lbl_DisplayName
            // 
            this.Lbl_DisplayName.AutoSize = true;
            this.Lbl_DisplayName.Location = new System.Drawing.Point(3, 113);
            this.Lbl_DisplayName.Name = "Lbl_DisplayName";
            this.Lbl_DisplayName.Size = new System.Drawing.Size(119, 13);
            this.Lbl_DisplayName.TabIndex = 13;
            this.Lbl_DisplayName.Text = "Display name (optional):";
            // 
            // Txb_ServerIp
            // 
            this.Txb_ServerIp.Location = new System.Drawing.Point(151, 6);
            this.Txb_ServerIp.Name = "Txb_ServerIp";
            this.Txb_ServerIp.Size = new System.Drawing.Size(260, 20);
            this.Txb_ServerIp.TabIndex = 0;
            this.Txb_ServerIp.Validating += new System.ComponentModel.CancelEventHandler(this.Txb_ServerIp_Validating);
            // 
            // Txb_Username
            // 
            this.Txb_Username.Location = new System.Drawing.Point(151, 58);
            this.Txb_Username.Name = "Txb_Username";
            this.Txb_Username.Size = new System.Drawing.Size(260, 20);
            this.Txb_Username.TabIndex = 3;
            this.Txb_Username.Validating += new System.ComponentModel.CancelEventHandler(this.Txb_Username_Validating);
            // 
            // Txb_DisplayName
            // 
            this.Txb_DisplayName.Location = new System.Drawing.Point(151, 110);
            this.Txb_DisplayName.Name = "Txb_DisplayName";
            this.Txb_DisplayName.Size = new System.Drawing.Size(260, 20);
            this.Txb_DisplayName.TabIndex = 6;
            // 
            // Nud_port
            // 
            this.Nud_port.Location = new System.Drawing.Point(151, 32);
            this.Nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Nud_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_port.Name = "Nud_port";
            this.Nud_port.Size = new System.Drawing.Size(90, 20);
            this.Nud_port.TabIndex = 1;
            this.Nud_port.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // Mtxb_password
            // 
            this.Mtxb_password.Location = new System.Drawing.Point(151, 84);
            this.Mtxb_password.Name = "Mtxb_password";
            this.Mtxb_password.Size = new System.Drawing.Size(182, 20);
            this.Mtxb_password.TabIndex = 4;
            this.Mtxb_password.UseSystemPasswordChar = true;
            this.Mtxb_password.Validating += new System.ComponentModel.CancelEventHandler(this.Mtxb_password_Validating);
            // 
            // Cbox_UseSsl
            // 
            this.Cbox_UseSsl.AutoSize = true;
            this.Cbox_UseSsl.Location = new System.Drawing.Point(265, 35);
            this.Cbox_UseSsl.Name = "Cbox_UseSsl";
            this.Cbox_UseSsl.Size = new System.Drawing.Size(68, 17);
            this.Cbox_UseSsl.TabIndex = 2;
            this.Cbox_UseSsl.Text = "Use SSL";
            this.Cbox_UseSsl.UseVisualStyleBackColor = true;
            this.Cbox_UseSsl.CheckedChanged += new System.EventHandler(this.Cbox_UseSsl_CheckedChanged);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(151, 154);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(125, 23);
            this.Btn_Ok.TabIndex = 7;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(286, 154);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(125, 23);
            this.Btn_Cancel.TabIndex = 8;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Lbl_SslPort
            // 
            this.Lbl_SslPort.AutoSize = true;
            this.Lbl_SslPort.Location = new System.Drawing.Point(148, 34);
            this.Lbl_SslPort.Name = "Lbl_SslPort";
            this.Lbl_SslPort.Size = new System.Drawing.Size(25, 13);
            this.Lbl_SslPort.TabIndex = 15;
            this.Lbl_SslPort.Text = "443";
            this.Lbl_SslPort.Visible = false;
            // 
            // Btn_GetHash
            // 
            this.Btn_GetHash.Location = new System.Drawing.Point(339, 82);
            this.Btn_GetHash.Name = "Btn_GetHash";
            this.Btn_GetHash.Size = new System.Drawing.Size(72, 23);
            this.Btn_GetHash.TabIndex = 5;
            this.Btn_GetHash.Text = "Get Hash";
            this.Btn_GetHash.UseVisualStyleBackColor = true;
            this.Btn_GetHash.Click += new System.EventHandler(this.Btn_GetHash_Click);
            // 
            // ServerDialog
            // 
            this.AcceptButton = this.Btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Cancel;
            this.ClientSize = new System.Drawing.Size(426, 188);
            this.Controls.Add(this.Btn_GetHash);
            this.Controls.Add(this.Lbl_SslPort);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Cbox_UseSsl);
            this.Controls.Add(this.Mtxb_password);
            this.Controls.Add(this.Nud_port);
            this.Controls.Add(this.Txb_DisplayName);
            this.Controls.Add(this.Txb_Username);
            this.Controls.Add(this.Txb_ServerIp);
            this.Controls.Add(this.Lbl_DisplayName);
            this.Controls.Add(this.Lbl_Password);
            this.Controls.Add(this.Lbl_Username);
            this.Controls.Add(this.Lbl_ServerPort);
            this.Controls.Add(this.Lbl_ServerIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PRTG Server Connection";
            this.Load += new System.EventHandler(this.ServerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_ServerIp;
        private System.Windows.Forms.Label Lbl_ServerPort;
        private System.Windows.Forms.Label Lbl_Username;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.Label Lbl_DisplayName;
        private System.Windows.Forms.TextBox Txb_ServerIp;
        private System.Windows.Forms.TextBox Txb_Username;
        private System.Windows.Forms.TextBox Txb_DisplayName;
        private System.Windows.Forms.NumericUpDown Nud_port;
        private System.Windows.Forms.MaskedTextBox Mtxb_password;
        private System.Windows.Forms.CheckBox Cbox_UseSsl;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label Lbl_SslPort;
        private System.Windows.Forms.Button Btn_GetHash;
    }
}