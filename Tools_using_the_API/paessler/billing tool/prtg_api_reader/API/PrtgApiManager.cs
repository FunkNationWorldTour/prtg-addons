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
using System.Collections.Specialized;
using System.Web;
using System.IO;
using System.Net;


namespace Paessler.Billingtool
{
    class PrtgApiManager
    {
       

        public enum ApiFunction
        {
            historicCSV = 0,
            historicXml,
            table,
            passHash,
            chartImage,
            percentile,
            version
        };

        private static string[] _apiUrls = new string[] { "/api/historicdata.csv", "/api/historicdata.xml", "/api/table.xml", "/api/getpasshash.htm", "/chart.png", "/api/percentile.xml", "/api/version.xml" };
        public static string apiDateStringFormat = "yyyy-MM-dd-HH-mm-ss";

        private string _baseUrl;
        private string _apiUsername;
        private string _apiPassword;
        private bool _usePassHash;

        public static string CheckVersion(string serverIp, uint port, bool useSsl, string username, string password, bool useHash = false)
        {
            Dictionary<string, string> hashQuery = new Dictionary<string, string>();
            hashQuery.Add("username", username);
            if (useHash)
            {
                hashQuery.Add("passhash", password);
            }
            else
            {
                hashQuery.Add("password", password);
            }
            hashQuery.Add("nosession", "1");
            string query = ToQueryString(hashQuery);

            string url = HttpClient.GetUrlFromIp(serverIp, port, useSsl);
            return HttpClient.CheckUrl(new Uri(url + _apiUrls[(int)ApiFunction.percentile] + query));
        }

        public static string GetPasswordHash(string server, string username, string password)
        {
            Dictionary<string, string> hashQuery = new Dictionary<string, string>();
            hashQuery.Add("username", username);
            hashQuery.Add("password", password);
            hashQuery.Add("nosession", "1");
            string query = ToQueryString(hashQuery);
            string hashStream;
            try
            {
                hashStream = HttpClient.GetHttpStream(server + "/api/getpasshash.htm" + query, "pwTmp.xml");
            }
            catch (Exception ex)
            {
                return null;
            }
            if (hashStream != null)
            {
                TextReader trs = new StreamReader(hashStream);
                string hash = trs.ReadToEnd();
                trs.Close();
                File.Delete(hashStream);
                return hash;
            }
            return null;
        }

        public PrtgApiManager(string prtgInstanceUrl, string username, string password, bool passhash = false)
        {
            this._baseUrl = prtgInstanceUrl;
            this._apiUsername = username;
            this._usePassHash = passhash;
            this._apiPassword = password;
        }

        public void ChangeServer(string prtgInstanceUrl, string username, string password, bool passhash = false) {
            this._baseUrl = prtgInstanceUrl;
            this._apiUsername = username;
            this._usePassHash = passhash;
            this._apiPassword = password;
        }

        public string GetPercentile(int sensorId, DateTime sDate, DateTime eDate, int pct, bool pctMode, int pctAvg )
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("id", sensorId.ToString());
            arguments.Add("sdate", sDate.ToString(apiDateStringFormat));
            arguments.Add("edate", eDate.ToString(apiDateStringFormat));
            arguments.Add("pct", pct.ToString());
            arguments.Add("pctmode", pctMode.ToString().ToLower());
            arguments.Add("pctshow", "true");
            arguments.Add("pctavg", (pctAvg / 60).ToString());
            arguments.Add("show", "fullvalue");
            return BuildUrl(arguments, ApiFunction.percentile);
        }

        public string GetVersion()
        {
            return BuildUrl(new Dictionary<string, string>(), ApiFunction.version);

        }

        public string GetSensorGraph(int sensorId, string avg, DateTime sDate, DateTime eDate, int width, int height, string graphstyling = "baseFontSize='12' showLegend='1'", int graphId = -1)
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("id", sensorId.ToString());
            arguments.Add("avg", avg);
            arguments.Add("sdate", sDate.ToString(apiDateStringFormat));
            arguments.Add("edate", eDate.ToString(apiDateStringFormat));
            arguments.Add("width", width.ToString());
            arguments.Add("height", height.ToString());
            arguments.Add("graphstyling", graphstyling);
            arguments.Add("graphid", graphId.ToString());
            return BuildUrl(arguments, ApiFunction.chartImage);
        }

        public string GetSensorTree()
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>(2);
            arguments.Add("content", "sensortree");
            arguments.Add("output", "xml");
            string url = BuildUrl(arguments, ApiFunction.table);
            return url;
        }

        public string GetSensorChannelNames(int sensorId, string format = "xml")
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>(4);
            arguments.Add("content", "sensortree");
            arguments.Add("new", "1");
            arguments.Add("channel", "1");
            arguments.Add("id", sensorId.ToString());
            return BuildUrl(arguments, ApiFunction.table);
        }

        public string GetHistoricSensorData(int sensorId, string avg, DateTime sdate, DateTime edate, string format = "xml")
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>(4);
            arguments.Add("id", sensorId.ToString());
            arguments.Add("avg", avg);
            arguments.Add("sdate", sdate.ToString(apiDateStringFormat));
            arguments.Add("edate", edate.ToString(apiDateStringFormat));
            return BuildUrl(arguments, ApiFunction.historicXml);
        }
        /// <summary>
        /// Build the Url for the api GET request from some query arguments
        /// and add the authorization information.
        /// </summary>
        /// <param name="query">The query arguments</param>
        /// <param name="apiFunc">The api function </param>
        /// <returns>The complete Api url for the GET request.</returns>
        private string BuildUrl(Dictionary<string, string> query, ApiFunction apiFunc, bool useLogin = true)
        {
            /// Adding authorization information as text or hash according to the user config.
            if (useLogin)
            {
                query.Add("username", this._apiUsername);
                query.Add(_usePassHash ? "passhash" : "password", this._apiPassword);
                query.Add("nosession", "1");
                query.Add("usetz", "1");
            }
            StringBuilder urlString = new StringBuilder();
            urlString.Append(this._baseUrl);
            urlString.Append(_apiUrls[(int)apiFunc]);
            urlString.Append(ToQueryString(query));

            return urlString.ToString();
        }

        /// <summary>
        /// Build an Url-Encoded argument string from a Key => Value list.
        /// Example: user=>demo;id=>2 turn to: ?user=demo&id=2
        /// </summary>
        /// <param name="args">Key(Name) => Value collection containing the arguments.</param>
        /// <returns>Url encoded argument string for GET requests.</returns>
        private static string ToQueryString(Dictionary<string, string> args)
        {
            List<string> returnParams = new List<string>();

            foreach (KeyValuePair<string, string> param in args)
            {
                returnParams.Add(String.Format("{0}={1}", HttpUtility.UrlEncode(param.Key), HttpUtility.UrlEncode(param.Value)));
            }
            return "?" + String.Join("&", returnParams.ToArray());
        }
        private static string ToQueryString(NameValueCollection args)
        {
            return "?" + string.Join("&", Array.ConvertAll(args.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(args[key]))));
        }
    }
}
