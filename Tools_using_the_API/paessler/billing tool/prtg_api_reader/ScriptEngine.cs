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
using LuaInterface;
using System.IO;

namespace Paessler.Billingtool
{
    class ScriptEngine
    {
        private Lua LuaInterpreter;
        private SensorData Sensor;
        private string ScriptName;
        private string TemplateName;
        private Invoice invoice;
        private int ReportId;
        private DateTime StartDate;
        private DateTime EndDate;
        public bool error;

        public ScriptEngine(SensorData sensor, string script, string template, int reportId, DateTime startDate, DateTime endDate)
        {
            error = false;
            Sensor = sensor;
            LuaInterpreter = new Lua();
            ScriptName = script;
            TemplateName = template;
            invoice = new Invoice(startDate, endDate);
            StartDate = startDate;
            EndDate = endDate;

            ReportId = reportId;
        }

        public Invoice getInvoice()
        {
            return invoice;
        }
        
        public SensorData getSensor()
        {
            return Sensor;
        }

        public string Null()
        {
            return null;
        }

        public Invoice RunScript()
        {
            try
            {
                LuaInterpreter.RegisterFunction("GetInvoice", this, this.GetType().GetMethod("getInvoice"));
                LuaInterpreter.RegisterFunction("SensorChannel", Sensor, Sensor.GetType().GetMethod("GetChannel"));
                LuaInterpreter.RegisterFunction("SensorValue", Sensor, Sensor.GetType().GetMethod("GetValue"));
                LuaInterpreter.RegisterFunction("Count", Sensor, Sensor.GetType().GetMethod("ValuesCount"));
                
                if (Sensor.HasPercentile)
                {
                    LuaInterpreter.RegisterFunction("GetPercentile", Sensor, Sensor.GetType().GetMethod("GetPercentile"));
                } else {
                    LuaInterpreter.RegisterFunction("GetPercentile", this, this.GetType().GetMethod("Null"));
                }
                try
                {
                    LuaInterpreter.DoFile(Settings.Instance.ScriptFolder + ScriptName + ".lua");
                }
                catch (Exception sExc)
                {
                    ErrorHandler.HandleError(sExc, "Lua script Error: ");
                    error = true;
                }
                invoice.HeadLogoPath = Settings.Instance.CompanyLogo;
                invoice.Footer = Settings.Instance.FooterText;

                invoice.ClientAddress = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].ClientAddress;
                invoice.ClientInfo = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].ClientInfo;

                invoice.Heading = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].HeaderText;
                invoice.ListFooter = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].FooterText;

                invoice.GraphPath = Sensor.chartPath;

                string reportname = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].Name;

                invoice.Sensorname = Settings.Instance.ServerSettings.Server[Settings.Instance.SelectedServer].Groups[Settings.Instance.SelectedGroup].Reports[ReportId].SensorName;

                reportname = reportname.Replace(" ", "_");

                if (!Directory.Exists(Settings.Instance.OutputFolder))
                {
                    DirectoryInfo dir1 = new DirectoryInfo(Settings.Instance.OutputFolder);
                    dir1.Create();
                }

                invoice.ConvertToPdf(Settings.Instance.TemplateFolder + TemplateName + "/template.html", Settings.Instance.OutputFolder + "Billing_" + reportname + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf");
            }
            catch (Exception e)
            {
                ErrorHandler.HandleError(e, "Error: ");
                //throw;
            }
            return null;
        }
    }
}
