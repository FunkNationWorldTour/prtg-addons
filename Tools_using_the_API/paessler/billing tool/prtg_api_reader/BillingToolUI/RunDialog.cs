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
using System.Windows.Forms;

namespace Paessler.Billingtool
{
    public partial class RunDialog : Form
    {
        private int ServerId;
        private int GroupId;
        private DateTime StartDate;
        private DateTime EndDate;
        private List<int> ReportList;

        private BackgroundWorker bw;
        private delegate void UICallerDelegate(string status);

        private RunDialog() { }

        public RunDialog(int serverId, int groupId, DateTime sDate, DateTime eDate)
        {
            InitializeComponent();
            ServerId = serverId;
            GroupId = groupId;
            StartDate = sDate;
            EndDate = eDate;
            ReportList = new List<int>();
            for (int i = 0; i < Properties.prtg_server.Default.ServerList.Server[serverId].Groups[groupId].Reports.Count; i++)
            {
                ReportList.Add(i);
            }
        }

        public RunDialog(int serverId, int groupId, DateTime sDate, DateTime eDate, int reportId)
        {
            InitializeComponent();
            ServerId = serverId;
            GroupId = groupId;
            StartDate = sDate;
            EndDate = eDate;
            ReportList = new List<int>();
            ReportList.Add(reportId);
        }

        public RunDialog(int serverId, int groupId, DateTime sDate, DateTime eDate, int[] reportIds)
        {
            InitializeComponent();
            ServerId = serverId;
            GroupId = groupId;
            StartDate = sDate;
            EndDate = eDate;
            ReportList = new List<int>();
            for (int i = 0; i < reportIds.Length; i++)
            {
                ReportList.Add(reportIds[i]);
            }
        }

        private void run(int reportId)
        {
            string url = HttpClient.GetUrlFromIp(Settings.Instance.ServerSettings.Server[ServerId].Address, Settings.Instance.ServerSettings.Server[ServerId].Port, Settings.Instance.ServerSettings.Server[ServerId].UseSsl);
            PrtgApiManager api = new PrtgApiManager(url, Settings.Instance.ServerSettings.Server[ServerId].Username, Settings.Instance.ServerSettings.Server[ServerId].Password, true);
            SetStatusText("Receiving data from the PRTG server...");
            SensorReport report = Settings.Instance.ServerSettings.Server[ServerId].Groups[GroupId].Reports[reportId];
            string tmpChannelsFile = HttpClient.GetHttpStream(api.GetSensorChannelNames(report.SensorId), "api_channels.xml");
            string tmpDataFile = HttpClient.GetHttpStream(api.GetHistoricSensorData(report.SensorId, report.Average.ToString(), StartDate, EndDate));
            string chartPath = HttpClient.GetHttpStream(api.GetSensorGraph(report.SensorId, report.Average.ToString(), StartDate, EndDate, 850, 270), "chart.png");
            string percentileTmp = string.Empty;
            if (report.HasPercentile)
            {
                percentileTmp = HttpClient.GetHttpStream(api.GetPercentile(report.SensorId, StartDate, EndDate, report.Percentile, report.PercentileMethod, report.PercentileAvg), "percentile.xml");
            }
            SensorData sensor = null;
            if (!bw.CancellationPending)
            {
                SetStatusText("Parsing data...");
                SensorDataXmlParser parser = new SensorDataXmlParser(report.SensorId);
                sensor = parser.parse(tmpChannelsFile, tmpDataFile);
                if (report.HasPercentile)
                {
                    parser.ParsePercentile(percentileTmp);
                }
                sensor.chartPath = chartPath;
            }
            if (!bw.CancellationPending)
            {
                SetStatusText("Running script...");
                if (sensor != null)
                {
                    ScriptEngine scr = new ScriptEngine(sensor, report.ScriptName, report.TemplateName, reportId, StartDate, EndDate);
                    scr.RunScript();
                    if (scr.error)
                    {
                        bw.CancelAsync();
                    }
                }
            }
            if (!bw.CancellationPending)
            {
                SetStatusText("Creating output...");
                Settings.Instance.ServerSettings.Server[ServerId].Groups[GroupId].Reports[reportId].LastRun = DateTime.Now;
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

        private void RunDialog_Shown(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

                foreach (int i in ReportList)
                {
                    if (!bw.CancellationPending)  run(i);

                    if (bw.CancellationPending) e.Cancel = true;
                }
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

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }
    }
}
