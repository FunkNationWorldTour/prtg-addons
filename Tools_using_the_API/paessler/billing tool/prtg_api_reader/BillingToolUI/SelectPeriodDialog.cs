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
    public partial class SelectPeriodDialog : Form
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public SelectPeriodDialog()
        {
            InitializeComponent();
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            StartDate = Dtp_StartDate.Value;
            EndDate = Dtp_EndDate.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void SelectPeriodDialog_Load(object sender, EventArgs e)
        {

            DateTime start = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day+1);
            DateTime end = DateTime.Now.AddMonths(-1).AddDays(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - DateTime.Now.Day - 1);
            TimeSpan tsStart = new TimeSpan(0, 0, 0);
            TimeSpan tsEnd = new TimeSpan(24, 00, 00); 
            
            Dtp_StartDate.Value = start.Date + tsStart;
            Dtp_EndDate.Value = end.Date + tsEnd;
        }
    }
}
