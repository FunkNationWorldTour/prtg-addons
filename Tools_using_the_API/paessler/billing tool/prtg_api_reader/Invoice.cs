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
using System.Text;
using System.IO;

namespace Paessler.Billingtool
{
    class Invoice
    {
        #region PrivateProperties
        private string _headLogoPath = string.Empty;
        private string _clientAddress = string.Empty;

        private string _clientInfo = string.Empty;
        private DateTime _invoiceDate = DateTime.Now;

        private string _heading = string.Empty;
        private string _sensorName = string.Empty;

        private List<string> _itemName;
        private List<string> _itemValue;

        private string _totalText;
        private string _totalValue;

        private string _graphPath = string.Empty;
        private string _listFooter = string.Empty;
        private string _footer = string.Empty;

        private DateTime StartDate;
        private DateTime EndDate;
        #endregion

        public string HeadLogoPath
        {
            set { _headLogoPath = value; }
            get { return _headLogoPath; }
        }

        public string ClientAddress
        {
            set { _clientAddress = value; }
            get { return _clientAddress; }
        }

        public string ClientInfo
        {
            set { _clientInfo = value; }
            get { return _clientInfo; }
        }

        public DateTime InvoiceDate
        {
            set { _invoiceDate = value; }
            get { return _invoiceDate; }
        }

        public string Heading {
            set { _heading = value; }
            get { return _heading; }
        }

        public string Sensorname
        {
            set { _sensorName = value; }
            get { return _sensorName; }
        }

        public string GraphPath {
            set { _graphPath = value; }
            get { return _graphPath; }
        }

        public string ListFooter {
            set { _listFooter = value; }
            get { return _listFooter; }
        }

        public string Footer {
            set { _footer = value; }
            get { return _footer; }
        }

        public Invoice(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            _itemName = new List<string>();
            _itemValue = new List<string>();
        }

        public void AddItem(string name, string value)
        {
            _itemName.Add(name);
            _itemValue.Add(value);
        }

        public void SetTotal(string text, string value)
        {
            _totalText = text;
            _totalValue = value;
        }

        public void ConvertToPdf(string template, string output)
        {
            ConvertToHtml(template);

            System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
            string baseDir = System.IO.Path.GetDirectoryName(a.Location);

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(baseDir + "\\ext\\HTMLtoPDF.exe", Path.GetDirectoryName(template) + "\\generated.html " + output + " A4 Portrait TestPDF");
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            System.Diagnostics.Process rfp = new System.Diagnostics.Process();

            rfp = System.Diagnostics.Process.Start(psi);

            StreamReader sr = rfp.StandardOutput;
            string s = sr.ReadToEnd();
            ErrorHandler.WritoToLogFile(baseDir + s);
            
            rfp.WaitForExit(5000);

            rfp.WaitForExit();

        }

        public void ConvertToHtml(string template)
        {
            StringBuilder itemsTable = new StringBuilder();

            for (int i = 0; i < _itemName.Count; i++)
            {
                itemsTable.Append("<tr><td class=\"itemkey\">");
                itemsTable.Append(_itemName[i]);
                itemsTable.Append("</td><td class=\"itemvalue\">");
                itemsTable.Append(_itemValue[i]);
                itemsTable.Append("</td></tr>");
            }
            itemsTable.Append("<tr id=\"total\"><td class=\"itemkey\" >");
            itemsTable.Append(_totalText);
            itemsTable.Append("</td><td class=\"itemvalue\"><span class=\"totalvalue\">");
            itemsTable.Append(_totalValue);
            itemsTable.Append("</span></td></tr>");

            HtmlTemplateEngine htmlEngine = new HtmlTemplateEngine(template);

            htmlEngine.AddKeyValue("HeadLogoPath", HeadLogoPath);
            htmlEngine.AddKeyValue("ClientAddress", ClientAddress);
            htmlEngine.AddKeyValue("ClientInfo", ClientInfo);
            htmlEngine.AddKeyValue("InvoiceDate", DateTime.Now.ToString("dd.MM.yyyy"));
            htmlEngine.AddKeyValue("Heading", Heading);
            htmlEngine.AddKeyValue("Sensorname", Sensorname);
            htmlEngine.AddKeyValue("GraphPath", GraphPath);
            htmlEngine.AddKeyValue("ListFooter", ListFooter);
            htmlEngine.AddKeyValue("Footer", Footer);

            htmlEngine.AddKeyValue("startdate", StartDate.ToString("dd.MM.yyyy"));
            htmlEngine.AddKeyValue("enddate", EndDate.ToString("dd.MM.yyyy"));

            htmlEngine.AddKeyValue("ItemTable", itemsTable.ToString());

            htmlEngine.Execute(Path.GetDirectoryName(template) + "\\generated.html");
        }
    }
}
