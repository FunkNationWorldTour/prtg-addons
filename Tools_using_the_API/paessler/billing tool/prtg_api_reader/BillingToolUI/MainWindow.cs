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
using System.Globalization;
using System.Collections.Generic;
using System.IO;

namespace Paessler.Billingtool
{
    public partial class MainWindow : Form
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CheckForServer();
            BuildSelectServerMenu();
            ChangeServer(Settings.Instance.SelectedServer, true);
            BuildGroupList();
            BuildReportList();
            if(string.IsNullOrEmpty(Settings.Instance.CompanyLogo)) {
                System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
                string baseDir = System.IO.Path.GetDirectoryName(a.Location);

                Settings.Instance.CompanyLogo = baseDir + "\\templates\\logo.jpg";
            }
        }

        private void ChangeServer(int serverId, bool isFirstStart = false)
        {
            using (ServerChangeDialog sConnectDialog = new ServerChangeDialog(serverId))
            {
                if (isFirstStart)
                {
                    sConnectDialog.StartPosition = FormStartPosition.CenterScreen;
                }
                DialogResult sConnectResult = sConnectDialog.ShowDialog();

                if (sConnectResult == DialogResult.OK)
                {
                    foreach (ToolStripMenuItem item in selectServerToolStripMenuItem.DropDownItems)
                    {
                        item.Checked = false;
                    }
                    ((ToolStripMenuItem)selectServerToolStripMenuItem.DropDownItems[serverId]).Checked = true;
                    BuildGroupList();
                    BuildReportList();
                    CheckButtons();
                }
                sConnectDialog.Dispose();
            }
        }

        private void ChangeGroup(int groupId)
        {
            Settings.Instance.SelectedGroup = groupId;
            BuildReportList();
            CheckButtons();
        }

        private void CheckForServer()
        {
            if (Settings.Instance.SelectedServer < 0)
            {
                ServerDialog serverDialog = new ServerDialog(true);
                DialogResult serverResult = serverDialog.ShowDialog();
                if (serverResult == DialogResult.OK)
                {
                    Settings.Instance.SelectedServer = 0;
                    Settings.Instance.SaveSettings();
                }
                else
                {
                    Application.Exit();
                }
                serverDialog.Dispose();
            }
        }

        private void BuildGroupList()
        {
            Lb_ReportGroups.Items.Clear();

            if (Settings.Instance.SelectedServer > -1)
            {
                foreach (ReportGroup group in Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups)
                {
                    Lb_ReportGroups.Items.Add(group.GroupName);
                }
                if (Lb_ReportGroups.Items.Count > 0 && Lb_ReportGroups.SelectedIndex == -1)
                {
                    Lb_ReportGroups.SelectedIndex = 0;
                    ChangeGroup(0);
                }
            }
            else
            {
                CheckForServer();
            }
        }

        private void BuildReportList()
        {
            if (Lb_ReportGroups.SelectedIndex != -1)
            {
                Lv_BillingReportList.Clear();
                Lv_BillingReportList.Columns.Add("Name");
                Lv_BillingReportList.Columns.Add("Sensor");
                Lv_BillingReportList.Columns.Add("Billing Script");
                Lv_BillingReportList.Columns.Add("Invoice Template");
                Lv_BillingReportList.Columns.Add("Last Run");

                string lastRun;
                foreach (SensorReport seRe in Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports)
                {
                    if (seRe.LastRun != null)
                    {
                        lastRun = seRe.LastRun.ToString("yyyy-MM-dd-HH-mm-ss");
                        if (string.Compare(lastRun, "0001-01-01-00-00-00") == 0)
                        {
                            lastRun = "None";
                        }
                    }
                    else
                    {
                        lastRun = "None";
                    }
                    Lv_BillingReportList.Items.Add(new ListViewItem(new string[] { seRe.Name, seRe.GetSensorName(), seRe.ScriptName, seRe.TemplateName, lastRun }));
                }

                int contentWidth;
                int headerWidth;
                ColumnHeaderAutoResizeStyle headerResize;
                for (int i = 0; i < Lv_BillingReportList.Columns.Count; i++)
                {
                    ColumnHeader header = Lv_BillingReportList.Columns[i];
                    header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    contentWidth = header.Width;


                    header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    headerWidth = header.Width;

                    if (contentWidth > headerWidth)
                    {
                        headerResize = ColumnHeaderAutoResizeStyle.ColumnContent;
                    }
                    else
                    {
                        headerResize = ColumnHeaderAutoResizeStyle.HeaderSize;
                    }

                    header.AutoResize(headerResize);
                }
            }
            else
            {
                Lv_BillingReportList.Clear();
            }
        }

        private void BuildSelectServerMenu()
        {
            selectServerToolStripMenuItem.DropDownItems.Clear();
            if (Settings.Instance.ServerSettings.Server.Count > 0)
            {
                foreach (ServerSettings setting in Settings.Instance.ServerSettings.Server)
                {
                    ToolStripMenuItem sItem = new ToolStripMenuItem(setting.ToString(), null, new EventHandler(selectserver_submenu_click));
                    selectServerToolStripMenuItem.DropDownItems.Add(sItem);
                }
                ((ToolStripMenuItem)selectServerToolStripMenuItem.DropDownItems[Settings.Instance.SelectedServer]).Checked = true;              
            }
        }

        private void CheckButtons()
        {

            if (Lb_ReportGroups.SelectedIndex < 0)
            {
                Btn_DelGroup.Enabled = false;
                Btn_EditGroup.Enabled = false;
                Btn_GenReport.Enabled = false;
                Btn_GenReportGroup.Enabled = false;
                Btn_AddReport.Enabled = false;
                Btn_DelReport.Enabled = false;
                Btn_EditReport.Enabled = false;
            }
            else
            {
                Btn_DelGroup.Enabled = true;
                Btn_EditGroup.Enabled = true;
                if (Lv_BillingReportList.Items.Count > 0)
                {
                    Btn_GenReportGroup.Enabled = true;
                }
                else
                {
                    Btn_GenReportGroup.Enabled = false;
                }
                Btn_AddReport.Enabled = true;
                if (Lv_BillingReportList.SelectedItems.Count <= 0)
                {
                    Btn_GenReport.Enabled = false;
                    Btn_DelReport.Enabled = false;
                    Btn_EditReport.Enabled = false;
                }
                else
                {
                    Btn_GenReport.Enabled = true;
                    Btn_DelReport.Enabled = true;
                    Btn_EditReport.Enabled = true;
                }
            }
        }

        private void selectserver_submenu_click(object sender, EventArgs e)
        {
            ChangeServer(selectServerToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender));
        }

        private void serverConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionDialog optionDialog = new OptionDialog();
            DialogResult optionDialogResult = optionDialog.ShowDialog(this);
            if (optionDialogResult == DialogResult.OK)
            {
                Settings.Instance.SaveSettings();
                BuildSelectServerMenu();
                BuildGroupList();
                BuildReportList();
                CheckButtons();
            }
            optionDialog.Dispose();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Lv_BillingReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckButtons();
        }

        private void Lb_ReportGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Settings.Instance.SelectedGroup != Lb_ReportGroups.SelectedIndex)
            {
                Settings.Instance.SelectedGroup = Lb_ReportGroups.SelectedIndex;
                BuildReportList();
            }
            CheckButtons();
        }

        private void AddGroup()
        {
            if (Settings.Instance.SelectedServer != -1)
            {
                InputTextDialog inputTextDialog = new InputTextDialog("Add Group", "New groupname:");
                DialogResult inputTextDialogResult = inputTextDialog.ShowDialog(this);
                string newGroupName;
                if (inputTextDialogResult == DialogResult.Cancel)
                {
                    return;
                }
                newGroupName = inputTextDialog.UserText;
                inputTextDialog.Dispose();

                ReportGroup newGroup = new ReportGroup();
                newGroup.GroupName = newGroupName;
                Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups.Add(newGroup);

                Lb_ReportGroups.Items.Add(newGroupName);
            }
            else
            {
                MessageBox.Show("Please add an select an server!");
            }
            CheckButtons();
        }
        private void Btn_AddGroup_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void EditGroup()
        {
            InputTextDialog inputTextDialog = new InputTextDialog("Edit Group", "Edit groupname:", Lb_ReportGroups.SelectedItem.ToString());
            DialogResult inputTextDialogResult = inputTextDialog.ShowDialog(this);
            string newGroupName;
            if (inputTextDialogResult == DialogResult.Cancel)
            {
                return;
            }
            newGroupName = inputTextDialog.UserText;
            inputTextDialog.Dispose();
            Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Lb_ReportGroups.SelectedIndex].GroupName = newGroupName;
            BuildGroupList();
        }

        private void Btn_EditGroup_Click(object sender, EventArgs e)
        {
            EditGroup();
        }

        private void AddReport()
        {
            ReportDialog reportDialog = new ReportDialog();
            DialogResult reportDialogResult = reportDialog.ShowDialog();
            if (reportDialogResult == DialogResult.OK)
            {
                BuildReportList();
                Settings.Instance.SaveSettings();
            }
            reportDialog.Dispose();
            CheckButtons();
        }

        private void Btn_AddReport_Click(object sender, EventArgs e)
        {

            AddReport();
        }

        private void RunReport()
        {
            SelectPeriodDialog selectPeriodDialog = new SelectPeriodDialog();
            DialogResult selectPeriodDialogResult = selectPeriodDialog.ShowDialog();
            if (selectPeriodDialogResult == DialogResult.OK)
            {

                int[] selectedReports = new int[Lv_BillingReportList.SelectedItems.Count];
                for (int i = 0; i < Lv_BillingReportList.SelectedItems.Count; i++)
                {
                    selectedReports[i] = Lv_BillingReportList.SelectedItems[i].Index;
                }
                RunDialog runDialog = new RunDialog(Settings.Instance.SelectedServer, Settings.Instance.SelectedGroup, selectPeriodDialog.StartDate, selectPeriodDialog.EndDate, selectedReports);
                DialogResult runDialogResult = runDialog.ShowDialog();
                
                if (runDialogResult == DialogResult.OK)
                {
                    AfterRunDialog afterDialog = new AfterRunDialog();
                    DialogResult afterDialogResult = afterDialog.ShowDialog();
                    afterDialog.Dispose();
                    BuildReportList();
                }
                else if (runDialogResult == DialogResult.Abort)
                {
                   
                }
                runDialog.Dispose();
            }
            selectPeriodDialog.Dispose();
            CheckButtons();
        }

        private void Btn_GenReport_Click(object sender, EventArgs e)
        {

            RunReport();
            CheckButtons();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }


        private void DeleteReport()
        {
            if (Lv_BillingReportList.SelectedItems.Count >= 1)
            {
                Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports.RemoveAt(Lv_BillingReportList.SelectedItems[0].Index);
                Settings.Instance.SaveSettings();
                BuildReportList();
            }
            CheckButtons();
        }
        private void Btn_DelReport_Click(object sender, EventArgs e)
        {
            DeleteReport();
        }


        private void RunReportGroup()
        {
            SelectPeriodDialog selectPeriodDialog = new SelectPeriodDialog();
            DialogResult selectPeriodDialogResult = selectPeriodDialog.ShowDialog();
            if (selectPeriodDialogResult == DialogResult.OK)
            {
                int[] reports = new int[Lv_BillingReportList.Items.Count];
                for (int i = 0; i < Lv_BillingReportList.Items.Count; i++)
                {
                    reports[i] = Lv_BillingReportList.Items[i].Index;
                }
                RunDialog runDialog = new RunDialog(Settings.Instance.SelectedServer, Settings.Instance.SelectedGroup, selectPeriodDialog.StartDate, selectPeriodDialog.EndDate, reports);
                DialogResult runDialogResult = runDialog.ShowDialog();
                runDialog.Dispose();

              
                if (runDialogResult == DialogResult.OK)
                {
                    AfterRunDialog afterDialog = new AfterRunDialog();
                    DialogResult afterDialogResult = afterDialog.ShowDialog();
                    afterDialog.Dispose();
                    BuildReportList();
                }
                else if (runDialogResult == DialogResult.Abort)
                {

                }
            }
            selectPeriodDialog.Dispose();
            BuildReportList();
        }

        private void Btn_GenReportGroup_Click(object sender, EventArgs e)
        {
            RunReportGroup();
            CheckButtons();
        }

        private void RemoveGroup()
        {
            if (Lb_ReportGroups.Items.Count > 0)
            {
                if (MessageBox.Show("Delete all reports in group?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups.RemoveAt(Settings.Instance.SelectedGroup);
                    Settings.Instance.SaveSettings();
                    BuildGroupList();
                    BuildReportList();
                }
            }
            CheckButtons();
        }

        private void Btn_DelGroup_Click(object sender, EventArgs e)
        {
            RemoveGroup();
        }

        private void Lv_BillingReportList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = (ListView)sender;
            int column = 0; //e.Column; // 0 = only sort name column

            ListViewSorter Sorter = new ListViewSorter();
            listView.ListViewItemSorter = Sorter;
            if (!(listView.ListViewItemSorter is ListViewSorter))
            {
                return;
            }
            Sorter = (ListViewSorter)listView.ListViewItemSorter;

            if (Sorter.LastSort == column)
            {
                if (listView.Sorting == SortOrder.Ascending)
                {
                    listView.Sorting = SortOrder.Descending;
                }
                else
                {
                    listView.Sorting = SortOrder.Ascending;
                }
            }
            else
            {
                listView.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = column;

            listView.Sort();

        }

        private void OpenEditReportDialog()
        {
            if (Lv_BillingReportList.SelectedItems.Count > 0)
            {
                int reportSelection = Lv_BillingReportList.SelectedIndices[0];
                ReportDialog reportDialog = new ReportDialog(reportSelection);
                DialogResult reportDialogResult = reportDialog.ShowDialog();
                if (reportDialogResult == DialogResult.OK)
                {
                    BuildReportList();
                    Lv_BillingReportList.Items[reportSelection].Selected = true;
                    Settings.Instance.SaveSettings();
                }
                reportDialog.Dispose();
            }
        }
        private void Lv_BillingReportList_ItemActivate(object sender, EventArgs e)
        {
            OpenEditReportDialog();
        }

        private void Btn_EditReport_Click(object sender, EventArgs e)
        {
            OpenEditReportDialog();
        }

        private void Lv_BillingReportList_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void Lv_BillingReportList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Lv_BillingReportList.SelectedItems.Count > 0)
                {
                   
                    cms_reportMenu.Show(Lv_BillingReportList, e.Location);
                }
                else
                {
                    cms_reportListViewMenu.Show(Lv_BillingReportList, e.Location);
                }
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void editReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditReportDialog();
        }

        private void addReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddReport();
        }

        private void removeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteReport();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void addReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddReport();
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RunReportGroup();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        private void removeGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveGroup();
        }

        private void editGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGroup();
        }

        private void Lb_ReportGroups_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Lb_ReportGroups.SelectedItems.Count > 0)
                {
                    cms_groupMenu.Show(Lb_ReportGroups, e.Location);
                }
                else
                {
                    cms_groupListViewMenu.Show(Lb_ReportGroups, e.Location);
                }
            }
        }

        private void addGroupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddGroup();
        }
    }
}
