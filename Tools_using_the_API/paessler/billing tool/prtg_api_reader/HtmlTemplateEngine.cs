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
using System.IO;
using System.Text.RegularExpressions;

namespace Paessler.Billingtool
{
    class HtmlTemplateEngine
    {

        private Dictionary<string, string> _templateValues;
        private string _templatePath;
        private string _htmlTemplate;
        private string _startDelimiter = "<#";
        private string _endDelimiter = ">";

        public HtmlTemplateEngine(string templatePath)
        {
            _templateValues = new Dictionary<string, string>();
            this._templatePath = templatePath;

        }

        /// <summary>
        /// In Html some special characters are represented as an html tag.
        /// This list will be used to replace all special characters in the given content later.
        /// </summary>
        /// <seealso cref="ReplaceSpecialCharacter(string)"/>
        private static Dictionary<string, string> _specialCharacters = new Dictionary<string, string>
        {
            {Environment.NewLine, "<br/>"},
            {"\n", " <br/>"},
            {"Ä", "&Auml;"},
            {"ä", "&auml;"},
            {"Ü", "&Uuml;"},
            {"ü", "&uuml;"},
            {"Ö", "&Ouml;"},
            {"ö", "&ouml;"},
            {"ß", "&szlig;"},
            {"€", "&euro;"}
        };


        public static string ReplaceSpecialCharacter(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                foreach (string key in _specialCharacters.Keys)
                {
                    text = text.Replace(key, _specialCharacters[key]);
                }
            }
            return text;
        }

        /// <summary>
        /// Replace all special characters with Html conform entities and replace all placeholders with the values given by <see cref="AddKeyValue(string, string)"/>.
        /// Then the result will be written to a local path, given with the filename argument.
        /// </summary>
        /// <param name="filename">Local path on the filesystem where the generated Html should be saved.</param>
        public void Execute(string filename)
        {
            try
            {
                _htmlTemplate = File.ReadAllText(_templatePath);
            }
            catch
            {
                _htmlTemplate = string.Empty;
            }
           
            ReplacePlaceholder();
            File.WriteAllText(filename, _htmlTemplate);
        }

        /// <summary>
        /// Add a key => value pair that will be used later to replace the template placeholder (key)
        /// with the value.
        /// </summary>
        /// <param name="key">Name of the placeholder.</param>
        /// <param name="value">Value that replace the placeholder later.</param>
        public void AddKeyValue(string key, string value)
        {
            _templateValues.Add(key, value);
        }

        private void ReplacePlaceholder()
        {
            foreach (string key in _templateValues.Keys)
            {
                _htmlTemplate = Regex.Replace(_htmlTemplate, _startDelimiter + key + _endDelimiter, ReplaceSpecialCharacter(_templateValues[key]), RegexOptions.IgnoreCase);
            }
        }
    }
}
