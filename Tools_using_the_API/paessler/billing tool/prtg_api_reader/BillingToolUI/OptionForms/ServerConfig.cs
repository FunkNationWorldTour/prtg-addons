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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paessler.Billingtool
{
    public partial class ServerConfig : UserControl
    {
        
        public ServerConfig()
        {
            InitializeComponent();
        }
        private void Btn_AddServer_Click(object sender, EventArgs e)
        {
            ServerDialog serverDialog = new ServerDialog();
            if (serverDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateList();
                CheckButtons();
                if (Settings.Instance.SelectedServer == -1)
                {
                    Settings.Instance.SelectedServer = 0;
                }
            }
            serverDialog.Dispose();
        }

        private void ServerConfig_Load(object sender, EventArgs e)
        {
            UpdateList();
            CheckButtons();
        }

        private void UpdateList()
        {
            Lb_ServerList.Items.Clear();

            foreach (ServerSettings setting in Settings.Instance.ServerSettings.Server)
            {
                Lb_ServerList.Items.Add(setting.ToString());
            }

        }

        private void Btn_EditServer_Click(object sender, EventArgs e)
        {
            if (Lb_ServerList.SelectedIndex >= 0)
            {
                ServerDialog serverDialog = new ServerDialog(Lb_ServerList.SelectedIndex);
                if (serverDialog.ShowDialog() == DialogResult.OK)
                {
                    UpdateList();
                    CheckButtons();
                }
                serverDialog.Dispose();
                
            }
        }

        private void Btn_DeleteServer_Click(object sender, EventArgs e)
        {
                DialogResult messageBoxResult = MessageBox.Show("Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.Yes)
                {
                    if (Settings.Instance.SelectedServer == Lb_ServerList.SelectedIndex)
                    {
                        Settings.Instance.SelectedServer = -1;
                    }
                    Settings.Instance.ServerSettings.Server.RemoveAt(Lb_ServerList.SelectedIndex);

                    UpdateList();
                    CheckButtons();
                    if (Lb_ServerList.Items.Count < 1)
                    {
                        Settings.Instance.SelectedServer = -1;
                    }
                }
        }

        private void CheckButtons()
        {
            if (Lb_ServerList.SelectedItems.Count < 1)
            {
                Btn_EditServer.Enabled = false;
                Btn_DeleteServer.Enabled = false;
            }
            else
            {
                Btn_DeleteServer.Enabled = true;
                Btn_EditServer.Enabled = true;
            }
        }

        private void Lb_ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckButtons();
        }

        private void Lb_ServerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ServerDialog serverDialog = new ServerDialog(Lb_ServerList.SelectedIndex);
            if (serverDialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateList();
                CheckButtons();
            }
            serverDialog.Dispose();
        }
    }
}
