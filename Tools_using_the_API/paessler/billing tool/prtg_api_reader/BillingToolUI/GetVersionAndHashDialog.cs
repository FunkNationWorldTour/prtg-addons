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
    public partial class GetVersionAndHashDialog : Form
    {
        private BackgroundWorker bw;
        private delegate void UICallerDelegate(string status);

        private string _server;
        private uint _port;
        private bool _useSsl;
        private string _username;
        private string _password;
        private string _hash;

        private bool _onlyVersionCheck;
        private bool _useHash;

        public string Hash { get { return _hash; } }


        public GetVersionAndHashDialog(string server, uint port, bool useSsl, string username, string password, bool useHash = false, bool onlyVersionCheck = false)
        {
            InitializeComponent();
            this._server = server;
            this._port = port;
            this._useSsl = useSsl;
            this._username = username;
            this._password = password;
            this._onlyVersionCheck = onlyVersionCheck;
            this._useHash = useHash;
        }

        private bool CheckVersion()
        {
            string result;
            if (_useHash)
            {
                result = PrtgApiManager.CheckVersion(_server, _port, _useSsl, _username, _password, _useHash);
            }
            else
            {
                result = PrtgApiManager.CheckVersion(_server, _port, _useSsl, _username, _password);
            }
            if (result == "ok")
            {
                return true;
            }
            ErrorMessage err = new ErrorMessage(result);
            err.ShowDialog();
            err.Dispose();
            return false;
        }

        private void FetchHashFromServer()
        {
            string url = HttpClient.GetUrlFromIp(_server, _port, _useSsl);
            string pwHash = PrtgApiManager.GetPasswordHash(url, _username, _password);
            if (pwHash != null)
            {
                _hash = pwHash;
            }
            else
            {
                bw.CancelAsync();
            }
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
                this.Lbl_Status.Text = status;
            }
        }

        private void GetHashDialog_Load(object sender, EventArgs e)
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
            SetStatusText("Check version...");
            if (CheckVersion())
            {
                if (!_onlyVersionCheck)
                {
                    SetStatusText("Receiving passwordhash from PRTG...");
                    FetchHashFromServer();
                    if (bw.CancellationPending) e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
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
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
