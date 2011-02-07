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
using System.IO;

namespace Paessler.Billingtool
{
    class ErrorHandler
    {

        public static bool Debug = false;
        public static string LogFilePath = "Error.log";

        private static string _datePatt = @"M/d/yyyy hh:mm:ss tt- ";

        public static void HandleError(Exception e, string text = "")
        {
            ErrorMessage err = new ErrorMessage(text + " " + e.Message);
            err.ShowDialog();
            err.Dispose();
            WritoToLogFile(text + ": " + e.Message);
        }

        public static void WritoToLogFile(string text)
        {
            if (Debug)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string dateString = now.ToString(_datePatt);
                    File.AppendAllText(LogFilePath, dateString + text + Environment.NewLine);
                }
                catch (Exception e)
                {
                    ErrorHandler.HandleError(e, "Lua script Error: ");
                }
            }
        }

        private ErrorHandler() { }
    }
}
