/*
 * Copyright (c) 2011, Paessler AG
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 * 
 *     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
 *       the documentation and/or other materials provided with the distribution.
 *     * Neither the name of the Paessler AG nor the names of its contributors may be used to endorse or promote products derived from this
 *       software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
 * HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Windows.Forms;

namespace Paessler.Billingtool
{
    public partial class ServerDialog : Form
    {
        public bool IsInEditMode;
        public int EditId;
        private bool IsFirstServer;
        private ErrorProvider errProv;

        public ServerDialog(bool firstServer = false)
        {
            InitializeComponent();
            IsInEditMode = false;
            IsFirstServer = firstServer;
            if (firstServer)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            errProv = new ErrorProvider(this);
        }

        public ServerDialog(int editId)
        {
            InitializeComponent();
            IsInEditMode = true;
            EditId = editId;
            errProv = new ErrorProvider(this);
        }

        private void ServerDialog_Load(object sender, EventArgs e)
        {
            if (IsInEditMode)
            {
                ServerSettings server = Properties.prtg_server.Default.ServerList.Server[EditId];
                Txb_ServerIp.Text = server.Address;
                if (server.UseSsl)
                {
                    Cbox_UseSsl.Checked = true;
                    Nud_port.Enabled = false;
                    Nud_port.Visible = false;
                    Lbl_SslPort.Visible = true;
                }
                Nud_port.Value = (decimal)server.Port;
                Txb_Username.Text = server.Username;
                Mtxb_password.Text = server.Password;
                Txb_DisplayName.Text = server.DisplayName;
                Btn_Cancel.Enabled = true;
            }
            else if (Settings.Instance.ServerSettings.Server.Count == 0)
            {
                Btn_Cancel.Enabled = false;
            }
            else
            {
                Btn_Cancel.Enabled = true;
            }
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (Txb_ServerIp.Text == string.Empty)
            {
                MessageBox.Show("Please insert a server address!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Txb_Username.Text == string.Empty)
            {
                MessageBox.Show("Please insert a username!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Mtxb_password.Text == string.Empty)
            {
                MessageBox.Show("Please insert a password hash!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (GetVersionAndHashDialog getHashDialog = new GetVersionAndHashDialog(Txb_ServerIp.Text, Convert.ToUInt32(Nud_port.Value), Cbox_UseSsl.Checked, Txb_Username.Text, Mtxb_password.Text, true, true))
            {
                DialogResult hashDialogResult = getHashDialog.ShowDialog();
                if (hashDialogResult == DialogResult.OK)
                {
                    if (!IsInEditMode)
                    {
                        ServerSettings server = new ServerSettings();
                        server.Address = Txb_ServerIp.Text;
                        server.Port = Cbox_UseSsl.Checked ? 443 : (uint)Nud_port.Value;
                        server.UseSsl = Cbox_UseSsl.Checked;
                        server.Username = Txb_Username.Text;
                        server.Password = Mtxb_password.Text;
                        server.DisplayName = Txb_DisplayName.Text;

                        ReportGroup newGroup = new ReportGroup();
                        newGroup.GroupName = "My Group";
                    
                        Settings.Instance.ServerSettings.Server.Add(server);
                        Settings.Instance.ServerSettings.Server[Settings.Instance.ServerSettings.Server.Count-1].Groups.Add(newGroup);
                    }
                    else
                    {
                        ServerSettings server = Settings.Instance.ServerSettings.Server[EditId];
                        server.Address = Txb_ServerIp.Text;
                        server.Port = Cbox_UseSsl.Checked ? 443 : (uint)Nud_port.Value;
                        server.UseSsl = Cbox_UseSsl.Checked;
                        server.Username = Txb_Username.Text;
                        server.Password = Mtxb_password.Text;
                        server.DisplayName = Txb_DisplayName.Text;
                    }
                    Settings.Instance.SaveSettings();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void Cbox_UseSsl_CheckedChanged(object sender, EventArgs e)
        {
            if (Cbox_UseSsl.Checked)
            {
                Nud_port.Enabled = false;
                Nud_port.Visible = false;
                Lbl_SslPort.Visible = true;
            }
            else
            {
                Nud_port.Enabled = true;
                Nud_port.Visible = true;
                Lbl_SslPort.Visible = false;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Btn_GetHash_Click(object sender, EventArgs e)
        {
            if (Txb_ServerIp.Text == string.Empty)
            {
                MessageBox.Show("Please insert a server address!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Txb_Username.Text == string.Empty)
            {
                MessageBox.Show("Please insert a username!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (InputTextDialog inputTextDialog = new InputTextDialog("Get Passwordhash", "Password:", true))
            {
                DialogResult inputTextDialogResult = inputTextDialog.ShowDialog();
                if (inputTextDialogResult == DialogResult.OK)
                {
                    string password = inputTextDialog.UserText;
                    inputTextDialog.Dispose();

                    using (GetVersionAndHashDialog getHashDialog = new GetVersionAndHashDialog(Txb_ServerIp.Text, Convert.ToUInt32(Nud_port.Value), Cbox_UseSsl.Checked, Txb_Username.Text, password))
                    {
                        DialogResult hashDialogResult = getHashDialog.ShowDialog();
                        if (hashDialogResult == DialogResult.OK)
                        {
                            Mtxb_password.Text = getHashDialog.Hash;
                            ValidateMtxb(Mtxb_password);
                        }
                    }
                }
            }
        }

        private void ValidateTxb(object txb, string message = "Please fill in a value!")
        {
            if (string.IsNullOrEmpty(((TextBox)txb).Text))
            {
                errProv.SetError(((TextBox)txb), message);
                errProv.SetIconAlignment(((TextBox)txb), ErrorIconAlignment.TopLeft);
            }
            else
            {
                errProv.SetError(((TextBox)txb), "");
            }
        }

        private void ValidateMtxb(object txb, string message = "Please fill in a value!")
        {
            if (string.IsNullOrEmpty(((MaskedTextBox)txb).Text))
            {
                errProv.SetError(((MaskedTextBox)txb), message);
                errProv.SetIconAlignment(((MaskedTextBox)txb), ErrorIconAlignment.TopLeft);
            }
            else
            {
                errProv.SetError(((MaskedTextBox)txb), "");
            }
        }

        private void Txb_ServerIp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTxb(sender);
        }

        private void Txb_Username_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTxb(sender);
        }

        private void Mtxb_password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateMtxb(sender);
        }

    }
}
