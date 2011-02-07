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
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Paessler.Billingtool
{
    public sealed class HttpClient
    {
        private HttpClient() { }

        public static string GetUrlFromIp(string address, uint port, bool useSsl = false)
        {
            string url = string.Empty;
            if (useSsl)
            {
                url = "https://" + address;
            }
            else
            {
                url = "http://" + address + ":" + port;
            }
            return url;
        }

        public static string CheckUrl(Uri url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Close();
                return "ok";
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return e.Message;
                }
                else if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    if (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        return "PRTG version to old and not supported!";
                    }
                    else
                    {
                        return ((HttpWebResponse)e.Response).StatusCode.ToString();
                    }
                }
            }
            return "ok";
        }

        public static string GetHttpStream(string urlString, string tmp = "api_tmp.xml")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            ErrorHandler.WritoToLogFile("Url call:" + urlString);
            try
            {
                string tmpFile = Path.GetTempPath() + tmp;
                Uri url = new Uri(urlString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                //request.ContentType = "text/xml";
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "GET";

                request.Timeout = 3600000;
                //request.ContentLength = 0;

                ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream resStream = response.GetResponseStream())
                    {
                        File.Delete(tmpFile);
                        using (Stream file = File.OpenWrite(tmpFile))
                        {
                            CopyStream(resStream, file);
                            file.Close();
                        }
                    }
                    response.Close();
                    
                    return tmpFile;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.HandleError(e);
                throw;
            }
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

    }
}


