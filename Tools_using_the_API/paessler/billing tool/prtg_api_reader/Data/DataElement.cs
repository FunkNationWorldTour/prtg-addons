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

namespace Paessler.Billingtool
{
    class DataElement
    {
        public string Name;
        public int Typ;
        public int Id;
        public List<object> Values;
        public List<double> RawValues;

        public DataElement()
        {
            Values = new List<object>();
            RawValues = new List<double>();

        }
        
        public void AddValue(string value)
        {
            Values.Add(value);
        }

        public void AddRawValue(double value)
        {
            RawValues.Add(value);
        }
        
        public double GetRawValue(int index)
        {
            if (index < RawValues.Count)
            {
                return Convert.ToDouble(RawValues[index]);
            }
            return 0.0;
        }

        public object GetValue(int index)
        {
            if (index < Values.Count)
            {
                return Values[index];
            }
            return null;
        }

        public double GetRawSum()
        {
            double sum = 0;
            for (int i = 0; i < RawValues.Count; i++)
            {
                sum += (double)RawValues[i];
            }
        
            return sum;
        }
    }
}
