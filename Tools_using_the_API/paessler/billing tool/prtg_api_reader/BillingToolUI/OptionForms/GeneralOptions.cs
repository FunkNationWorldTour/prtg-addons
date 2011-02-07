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
    public partial class GeneralOptions : UserControl
    {
        public GeneralOptions()
        {
            InitializeComponent();
        }

        public string GetOutputFolder()
        {
            return Txb_OutputFolder.Text;
        }

        private void FolderOptions_Load(object sender, EventArgs e)
        {
            Txb_OutputFolder.Text = Settings.Instance.OutputFolder;
            Txb_BillingFooter.Text = Settings.Instance.FooterText;
            Txb_CompanyLogo.Text = Settings.Instance.CompanyLogo;
        }

        public string GetCompanyLogo()
        {
            return Txb_CompanyLogo.Text;
        }

        public string GetFooterText()
        {
            return Txb_BillingFooter.Text;
        }

        private void Btn_BrowseOutput_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Output folder";
            folderDialog.SelectedPath = Settings.Instance.OutputFolder;
            DialogResult objResult = folderDialog.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                Txb_OutputFolder.Text = folderDialog.SelectedPath;
            }
        }

        private void Btn_BrowseLogo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Select a billing logo";
            fileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png, *.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif;";

            DialogResult objResult = fileDialog.ShowDialog();
            if (objResult == DialogResult.OK)
            {
                Txb_CompanyLogo.Text = fileDialog.FileName;
            }
        }
    }
}
