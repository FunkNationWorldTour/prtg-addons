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
using System.Collections.Generic;
using System.Drawing;

namespace Paessler.Billingtool
{
    public partial class ReportDialog : Form
    {
        private Dictionary<int, string> Averages;
        TreeNode saveSelectedNode;
        private bool IsInEditMode;
        private int EditId;
        private SensorReport report;
        private ErrorProvider errProv;

        public ReportDialog()
        {
            InitializeComponent();
            IsInEditMode = false;
            errProv = new ErrorProvider(this);
        }

        public ReportDialog(int editId)
        {
            InitializeComponent();
            IsInEditMode = true;
            EditId = editId;
            report = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[editId];
            errProv = new ErrorProvider(this);
        }

        private void LoadReport()
        {
            Txb_ReportName.Text = report.Name;
            Txb_SensorId.Text = report.SensorName;

            Cb_Average.SelectedValue = report.Average;
            Cb_ScriptNames.SelectedIndex = Cb_ScriptNames.FindStringExact(report.ScriptName);
            Cb_TemplteNames.SelectedIndex = Cb_TemplteNames.FindStringExact(report.TemplateName);

            Txb_ClientAddress.Text = report.ClientAddress;
            Txb_ClientInfo.Text = report.ClientInfo;

            if (string.IsNullOrEmpty(report.HeaderText))
            {
                Txb_BillingHeader.Text = Settings.Instance.DefaultBillingHeader;
            }
            else
            {
                Txb_BillingHeader.Text = report.HeaderText; 
            }

            if (string.IsNullOrEmpty(report.FooterText))
            {
                Txb_BillingFooter.Text = Settings.Instance.DefaultBillingFooter;
            }
            else
            {
                Txb_BillingFooter.Text = report.FooterText;   
            }

            if (report.HasPercentile)
            {
                Cb_UsePercentile.Checked = true;
                Nud_PercentilePercent.Value = report.Percentile;
                Nud_PercentileAvg.Value = report.PercentileAvg/60;

                Rb_PercentileContinuous.Checked = report.PercentileMethod;
                Rb_PercentileDiscrete.Checked = !report.PercentileMethod;
            }
            else
            {
                Cb_UsePercentile.Checked = false;
            }
            
        }

        private bool CheckFields()
        {
            if (Txb_ReportName.Text == string.Empty)
            {
                MessageBox.Show("Please insert a name!");
                return false;
            }

            if (Txb_SensorId.Text == string.Empty)
            {
                MessageBox.Show("Please select a sensor!");
                return false;
            }
            return true;
        }

        private void WriteReport(SensorReport seRe)
        {
            seRe.Name = Txb_ReportName.Text;
            string[] words = Txb_SensorId.Text.Split(',');
            seRe.SensorId = Convert.ToInt32(words[words.Length - 1]);
            seRe.SensorName = Txb_SensorId.Text;
            seRe.ScriptName = Cb_ScriptNames.SelectedItem.ToString();
            seRe.TemplateName = Cb_TemplteNames.SelectedItem.ToString();
            seRe.Average = (int)Cb_Average.SelectedValue;
            seRe.ClientAddress = Txb_ClientAddress.Text;
            seRe.ClientInfo = Txb_ClientInfo.Text;
            seRe.HeaderText = Txb_BillingHeader.Text;
            seRe.FooterText = Txb_BillingFooter.Text;
            // Percentile
            seRe.HasPercentile = Cb_UsePercentile.Checked;
            seRe.Percentile = (int)Nud_PercentilePercent.Value;
            seRe.PercentileAvg = (int)Nud_PercentileAvg.Value*60;
            
            if (Rb_PercentileContinuous.Checked)
            {
                seRe.PercentileMethod = true;
            }
            else
            {
                seRe.PercentileMethod = false;
            }
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                SensorReport seRe;
                if (IsInEditMode)
                {
                    seRe = report;
                    WriteReport(seRe);
                }
                else
                {
                    seRe = new SensorReport();
                    WriteReport(seRe);
                    Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports.Add(seRe);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FillAverages()
        {
            Averages = new Dictionary<int, string>();
            //Averages.Add("15 Seconds", 15);
            //Averages.Add("30 Seconds", 30);
            //Averages.Add("60 Seconds", 60);
            //Averages.Add("2 Minutes", 120);
            Averages.Add( 300, "5 Minutes");
            Averages.Add(600, "10 Minutes");
            Averages.Add(900, "15 Minutes");
            Averages.Add(1200, "20 Minutes");
            //Averages.Add(3600, "1 Hour" );
            //Averages.Add(7200, "2 Hours");
            //Averages.Add(14400, "4 Hours");
            //Averages.Add(21600, "6 Hours");
            //Averages.Add(43200, "12 Hours" );
            Averages.Add(86400, "1 Day");
        }

        private void ReportDialog_Load(object sender, EventArgs e)
        {
            btn_DropDownTreeView.Font = new Font("Marlett", btn_DropDownTreeView.Font.Size+ 2);

            FillAverages();
            foreach (string scriptName in FolderEngine.GetFileNamesWOExtension(Settings.Instance.ScriptFolder, "*.lua"))
            {
                Cb_ScriptNames.Items.Add(scriptName);
            }
            foreach (string templateName in FolderEngine.GetDirectoryNames(Settings.Instance.TemplateFolder))
            {
                Cb_TemplteNames.Items.Add(templateName);
            }
            Cb_Average.DataSource = new BindingSource(Averages, null);
            Cb_Average.ValueMember = "Key";
            Cb_Average.DisplayMember = "Value";


            if (IsInEditMode)
            {
                LoadReport();
            }
            else
            {
                if (Cb_ScriptNames.Items.Count > 0)
                {
                    Cb_ScriptNames.SelectedIndex = 0;
                }

                if (Cb_TemplteNames.Items.Count > 0)
                {
                    Cb_TemplteNames.SelectedIndex = 0;
                }
                
                Cb_Average.SelectedIndex = 4;
                Txb_BillingFooter.Text = Settings.Instance.DefaultBillingFooter;
                Txb_BillingHeader.Text = Settings.Instance.DefaultBillingHeader;   
            }

            CreateSensorTree();

            Tv_SensorTree.ExpandAll();
            Tv_SensorTree.Hide();
            Tv_SensorTree.Location = new Point(Txb_SensorId.Location.X, Txb_SensorId.Location.Y + Txb_SensorId.Height);
            Tv_SensorTree.Size = new Size(Txb_SensorId.Width + 50, this.Height - Txb_SensorId.Location.Y - Txb_SensorId.Height - 30);
            Tv_SensorTree.SelectedNode = Tv_SensorTree.Nodes[0];

            Txb_SensorId.ReadOnly = true;
            Txb_SensorId.BackColor = Color.White;

            TogglePercentile();
        }

        private void CreateSensorTree()
        {
            List<TreeProbeElement> probes = Settings.Instance.SelectedServerSensoorTree;
            TreeNode node;
            node = Tv_SensorTree.Nodes.Add(TreeProbeElement.RootGroup);
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            foreach (TreeProbeElement tp in probes)
            {
                TreeNode probeNode;
                probeNode = node.Nodes.Add(tp.Name);
                probeNode.ImageIndex = 3;
                probeNode.SelectedImageIndex = 3;
                foreach (TreeGroupElement tg in tp.Groups)
                {
                    TreeNode groupNode = null;
                    if (!tg.IsNoGroup)
                    {
                        groupNode = probeNode.Nodes.Add(tg.Name);
                        groupNode.ImageIndex = 1;
                        groupNode.SelectedImageIndex = 1;
                    }

                    foreach (TreeDeviceElement td in tg.Devices)
                    {
                        TreeNode deviceNode;
                        if (!tg.IsNoGroup)
                        {
                            deviceNode = groupNode.Nodes.Add(td.Name);
                        }
                        else
                        {
                            deviceNode = probeNode.Nodes.Add(td.Name);
                        }

                        deviceNode.ImageIndex = 0;
                        deviceNode.SelectedImageIndex = 0;
                        foreach (TreeSensorElement ts in td.Sensors)
                        {
                            TreeNode sensorNode;
                            sensorNode = deviceNode.Nodes.Add(ts.Name + ", " + ts.Id);
                            sensorNode.ImageIndex = 4;
                            sensorNode.SelectedImageIndex = 4;
                        }
                    }
                }
            }
        }

        private bool foundNode = false;
        private void CheckAllNodes(TreeNode parent)
        {
            foundNode = false;
            foreach (TreeNode node in parent.Nodes)
            {
                if (node.Text == Txb_SensorId.Text)
                {
                    Tv_SensorTree.SelectedNode = node;
                    foundNode = true;
                }
                if (!foundNode)
                {
                    CheckAllNodes(node);
                }
                else
                {
                    break;
                }
            }
        }

        private void btn_DropDownTreeView_Click(object sender, EventArgs e)
        {
            if (!Tv_SensorTree.Visible)
            {
                if (Txb_SensorId.Text != string.Empty)
                {
                    foreach (TreeNode node in Tv_SensorTree.Nodes)
                    {
                        CheckAllNodes(node);
                    }
                }
                else
                {
                    Tv_SensorTree.SelectedNode = null;
                }
                
                saveSelectedNode = Tv_SensorTree.SelectedNode;
                Tv_SensorTree.Visible = true;
                EnableControls();
                Tv_SensorTree.Focus();
                
            }
            else
            {
                
                Tv_SensorTree_SelectionChanged();
            }
        }

        private void Tv_SensorTree_SelectionChanged()
        {
            
            TreeNode node = Tv_SensorTree.SelectedNode;

            // Avoid runtime error if treeView has nothing in it!
            if (node != null)
            {
                string[] words = node.Text.Split(',');
                int id;
                bool ok = int.TryParse(words[words.Length - 1], out id);
                if (ok)
                {
                    saveSelectedNode = node;
                    Txb_SensorId.Text = node.Text;

                    Tv_SensorTree.Hide();
                    EnableControls();
                }
                else
                {
                    MessageBox.Show("Please select a sensor!");
                }
            }
            else
            {
                if (Txb_SensorId.Text == string.Empty)
                {
                    MessageBox.Show("Please select a sensor!");
                }
                else
                {
                    Tv_SensorTree.Hide();
                    EnableControls();
                }
            }
        }

        private void Tv_SensorTree_DoubleClick(object sender, EventArgs e) // Node was selected...
        {
            Tv_SensorTree_SelectionChanged();
        }


        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode selNode = Tv_SensorTree.SelectedNode;
            // Selection accepted...
            if (e.KeyCode == Keys.Enter)
            {
                Tv_SensorTree_SelectionChanged();
                e.Handled = true;
            }
            // Selection canceled...
            else if (e.KeyCode == Keys.Escape)
            {
                Tv_SensorTree.SelectedNode = saveSelectedNode;
                Tv_SensorTree_SelectionChanged();
                e.Handled = true;
            }
        }

        private void EnableControls()
        {
            if (Tv_SensorTree.Visible)
            {
                Tv_SensorTree.Enabled = true;
                btn_DropDownTreeView.Text = "5";

                Lbl_ScriptPath.Hide();
                Lbl_TemapltePath.Hide();
                Lbl_Average.Hide();
                Lbl_ClientAddress.Hide();
                Lbl_ClientInfo.Hide();
            }
            else
            {
                Tv_SensorTree.Enabled = false;
                btn_DropDownTreeView.Text = "6";

                Lbl_ScriptPath.Show();
                Lbl_TemapltePath.Show();
                Lbl_Average.Show();
                Lbl_ClientAddress.Show();
                Lbl_ClientInfo.Show();
            }
            ValidateTxb(Txb_SensorId);
        }

        private void Tv_SensorTree_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode selNode = Tv_SensorTree.SelectedNode;
            // Selection accepted...
            if (e.KeyCode == Keys.Enter)
            {
                Tv_SensorTree_SelectionChanged();
                e.Handled = true;
            }
            // Selection canceled...
            else if (e.KeyCode == Keys.Escape)
            {
                Tv_SensorTree.SelectedNode = saveSelectedNode;
                Tv_SensorTree_SelectionChanged();
                e.Handled = true;
            }
        }

        private void TogglePercentile()
        {
            if (Cb_UsePercentile.Checked)
            {
                Nud_PercentilePercent.Enabled = true;
                Nud_PercentileAvg.Enabled = true;
                Rb_PercentileContinuous.Enabled = true;
                Rb_PercentileDiscrete.Enabled = true;
                if (IsInEditMode)
                {
                    Rb_PercentileContinuous.Checked = report.PercentileMethod;
                    
                }
                else
                {
                    Rb_PercentileContinuous.Checked = true;
                }
            }
            else
            {
                Rb_PercentileContinuous.Checked = false;
                Rb_PercentileDiscrete.Checked = false;
                Nud_PercentilePercent.Enabled = false;
                Nud_PercentileAvg.Enabled = false;
                Rb_PercentileContinuous.Enabled = false;
                Rb_PercentileDiscrete.Enabled = false;
            }
        }

        private void Cb_UsePercentile_CheckedChanged(object sender, EventArgs e)
        {
            TogglePercentile(); 
        }

        private void Txb_ReportName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTxb(sender);
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

        private void Txb_SensorId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTxb(sender, "Please select a sensor!");
        }

        private void Tv_SensorTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex != 4)
            {
                Tv_SensorTree.SelectedNode = null;
            }
        }

        private bool deselected = false;

        private void Tv_SensorTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Tv_SensorTree.Visible)
            {
                if (e.Node.ImageIndex == 4)
                {
                    if (deselected == false)
                    {
                        Tv_SensorTree_SelectionChanged();
                    }
                    else
                    {
                        deselected = false;
                    }
                }
                else
                {
                    Tv_SensorTree.SelectedNode = null;
                }
            }
        }
    }
}
