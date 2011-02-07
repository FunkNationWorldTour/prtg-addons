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
    public partial class OptionDialog : Form
    {

        private GeneralOptions genralPanel;
        private ServerConfig serverPanel;
        private TemplateOptions templatePanel;

        public enum MenuEntry
        {
            ServerOption = 0,
            GeneralOptions,
            TemplateOption
        };


        private static string[] MenuItem = new string[] { "ServerOptions", "GlobalOptions", "TemplateOptions" };
        private static string[] MenuText = new string[] { "PRTG Server Connection", "General", "Templates" };

        public OptionDialog()
        {
            InitializeComponent();
        }

        private void OptionDialog_Load(object sender, EventArgs e)
        {
            TreeView_OptionTree.Nodes.Add(MenuItem[(int)MenuEntry.GeneralOptions], MenuText[(int)MenuEntry.GeneralOptions]);
            TreeView_OptionTree.Nodes.Add(MenuItem[(int)MenuEntry.ServerOption],MenuText[(int)MenuEntry.ServerOption]);
            TreeView_OptionTree.Nodes.Add(MenuItem[(int)MenuEntry.TemplateOption], MenuText[(int)MenuEntry.TemplateOption]);

            genralPanel = new GeneralOptions();
            serverPanel = new ServerConfig();
            templatePanel = new TemplateOptions();
            

            OptionPanel.Controls.Add(genralPanel);
            OptionPanel.Controls.Add(serverPanel);
            OptionPanel.Controls.Add(templatePanel);

            serverPanel.Hide();
            templatePanel.Hide();

        }
   
        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            string outputFolder =genralPanel.GetOutputFolder();

            if (outputFolder[outputFolder.Length - 1].CompareTo('\\') != 0)
            {
                outputFolder += "\\";
            }

            Settings.Instance.OutputFolder = outputFolder;

            Settings.Instance.FooterText = genralPanel.GetFooterText();
            Settings.Instance.CompanyLogo = genralPanel.GetCompanyLogo();

            Settings.Instance.DefaultBillingHeader = templatePanel.GetBillingHeader();
            Settings.Instance.DefaultBillingFooter = templatePanel.GetBillingFooter();

            this.DialogResult = DialogResult.OK;

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TreeView_OptionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                foreach (Control c in OptionPanel.Controls)
                {
                    c.Hide();
                }
                if (string.Compare(e.Node.Name, MenuItem[(int)MenuEntry.GeneralOptions]) == 0)
                {
                    genralPanel.Show();
                }
                else if (string.Compare(e.Node.Name, MenuItem[(int)MenuEntry.TemplateOption]) == 0)
                {
                    templatePanel.Show();
                }
                else if (string.Compare(e.Node.Name, MenuItem[(int)MenuEntry.ServerOption]) == 0)
                {
                    serverPanel.Show();
                }
            }
        }
        
    }
}
