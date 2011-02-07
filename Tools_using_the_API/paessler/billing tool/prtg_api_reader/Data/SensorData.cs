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
    class SensorData
    {
        public List<DataElement> SensorResults;
        public int SensorId;
        public string chartPath;
        public bool HasPercentile;
        public double Percentile;

        public SensorData(int sensorId)
        {
            this.SensorId = sensorId;
            this.SensorResults = new List<DataElement>();
            this.HasPercentile = false;
        }

        public double GetPercentile()
        {
            if (HasPercentile)
            {
                return Percentile;
            }
            else
            {
                return 0.0;
            }
        }

        public DataElement GetChannel(int id)
        {
            for (int i = 0; i < SensorResults.Count; i++)
            {
                if (SensorResults[i].Id == id)
                {
                    
                   return SensorResults[i];
                }
            }
            return null;
        }

        public DataElement GetValue(int id)
        {
            return SensorResults[id];
        }

        public int ValuesCount(int id)
        {
           return GetChannel(id).Values.Count-1;
        }


        public void PrintData()
        {
            for (int i = 0; i < SensorResults.Count; i++)
            {
                Console.Write(" - |" + SensorResults[i].Name + "(" + i + ")" + "|");
            }
        }


    }
}
