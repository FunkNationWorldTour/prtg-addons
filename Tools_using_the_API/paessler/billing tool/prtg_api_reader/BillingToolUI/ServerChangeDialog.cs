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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paessler.Billingtool
{
    public partial class ServerChangeDialog : Form
    {
        private BackgroundWorker bw;
        private delegate void UICallerDelegate(string status);

        private int ServerId;

        public ServerChangeDialog(int serverId)
        {
            InitializeComponent();
            ServerId = serverId;

        }

        private void SetStatusText(string status)
        {
            if (this.InvokeRequired)
            {
                UICallerDelegate dlg = new UICallerDelegate(SetStatusText);
                BeginInvoke(dlg, status);
            }
            else
            {
                this.Lbl_CurrentState.Text = status;
            }
        }

        private void LoadTree()
        {
            try
            {
                string url = HttpClient.GetUrlFromIp(
                    Settings.Instance.ServerSettings.Server[ServerId].Address,
                    Settings.Instance.ServerSettings.Server[ServerId].Port,
                    Settings.Instance.ServerSettings.Server[ServerId].UseSsl);

                PrtgApiManager api = new PrtgApiManager(
                    url,
                    Settings.Instance.ServerSettings.Server[ServerId].Username,
                    Settings.Instance.ServerSettings.Server[ServerId].Password,
                    true);

                Settings.Instance.SelectedServerSensoorTree =
                    SensorDataXmlParser.ParseSensorTree(HttpClient.GetHttpStream(api.GetSensorTree(), "tree.xml"));
            }
            catch (Exception e)
            {
                ErrorHandler.HandleError(e);
                bw.CancelAsync();
            }
        }

        private void RunDialog_Shown(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;


            SetStatusText("Checking server version...");

                if (bw.WorkerReportsProgress) bw.ReportProgress(50);

                SetStatusText("Receiving sensor tree...");
                LoadTree();
                if (bw.WorkerReportsProgress) bw.ReportProgress(100);
                if (bw.CancellationPending) e.Cancel = true;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (e.Error != null)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                Settings.Instance.SelectedServer = ServerId;
                Settings.Instance.SaveSettings();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
