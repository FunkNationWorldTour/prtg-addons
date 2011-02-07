using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Paessler.Billingtool
{
    class SensorDataXmlParser
    {
        private SensorData sensor;

        public SensorDataXmlParser(int sensorId)
        {
            this.sensor = new SensorData(sensorId);
        }

        public static string GetVerion(string xmlFile)
        {
            string version;
            using (XmlReader readerXml = XmlReader.Create(xmlFile))
            {
                readerXml.ReadToDescendant("version");
                version = readerXml.ReadElementContentAsString();
            }
            return version;
        }

        public SensorData parse(string sensorChannelNamesFile, string sensorDataFile)
        {
            ParseSensorChannelNames(sensorChannelNamesFile);
            ParseSensorData(sensorDataFile);
            return sensor;
        }

        public void ParsePercentile(string xmlFile)
        {
            using (XmlReader readerXml = XmlReader.Create(xmlFile))
            {
                readerXml.ReadToFollowing("result");
                sensor.HasPercentile = true;
                sensor.Percentile = readerXml.ReadElementContentAsDouble();
            }
        }


        private void ParseSensorChannelNames(string xmlFile)
        {
            using (XmlReader readerXml = XmlReader.Create(xmlFile))
            {

                sensor.SensorResults.Add(new DataElement());

                sensor.SensorResults[0].Name = "DateTime";
                sensor.SensorResults[0].Typ = 0;
                sensor.SensorResults[0].Id = -99;
                int i = 1;
                int a = 0;
                while (readerXml.ReadToFollowing("channel"))
                {
                    if (a == 0)
                    {
                        a++;
                        continue;
                    }
                    int id = -99;
                    if (readerXml.HasAttributes && string.Equals(readerXml.Name, "channel"))
                    {
                        id = Convert.ToInt32(readerXml[0]);
                    }

                    using (XmlReader values = readerXml.ReadSubtree())
                    {
                        values.ReadToFollowing("name");
                        string name = values.ReadString();
                        values.ReadToFollowing("mode");
                        int mode = values.ReadElementContentAsInt();
                        if (mode == 2)
                        {
                            sensor.SensorResults.Add(new DataElement());
                            sensor.SensorResults.Add(new DataElement());

                            sensor.SensorResults[i].Name = name + "(volume)";
                            sensor.SensorResults[i].Typ = mode;
                            sensor.SensorResults[i].Id = id;
                            i++;
                            sensor.SensorResults[i].Name = name + "(speed)";
                            sensor.SensorResults[i].Typ = mode;
                            sensor.SensorResults[i].Id = id;
                            i++;
                        }
                        else
                        {
                            sensor.SensorResults.Add(new DataElement());
                            sensor.SensorResults[i].Name = name;
                            sensor.SensorResults[i].Typ = mode;
                            sensor.SensorResults[i].Id = id;
                            i++;
                        }
                    }
                }
                int count = sensor.SensorResults.Count;
                sensor.SensorResults.Add(new DataElement());
                sensor.SensorResults.Add(new DataElement());
                sensor.SensorResults[i].Name = "Downtime";
                sensor.SensorResults[i].Typ = 0;
                sensor.SensorResults[i].Id = -97;
                i++;
                sensor.SensorResults[i].Name = "Coverage";
                sensor.SensorResults[i].Typ = 0;
                sensor.SensorResults[i].Id = -98;
                i++;
                readerXml.Close();
            }
        }

        private void ParseSensorData(string xmlFile)
        {
            using (StreamReader xmlData = new StreamReader(xmlFile))
            {

                // Skip first line in hitoric Xml, because its empty and not Xml conform (XmlReader Error).
                xmlData.ReadLine();
                try
                {
                    using (XmlReader readerXml = XmlReader.Create(xmlData))
                    {

                        while (readerXml.ReadToFollowing("item"))
                        {
                            using (XmlReader values = readerXml.ReadSubtree())
                            {
                                int i = 0;
                                while (values.Read())
                                {
                                    if (values.NodeType == XmlNodeType.Element && (string.Equals(values.Name, "value") || string.Equals(values.Name, "datetime") || string.Equals(values.Name, "coverage")))
                                    {
                                        values.Read();
                                        if (values.NodeType == XmlNodeType.Text)
                                        {
                                            sensor.SensorResults[i].AddValue(values.Value);
                                            while (values.Read())
                                            {
                                                if (values.NodeType == XmlNodeType.Element && (string.Equals(values.Name, "value_raw") || string.Equals(values.Name, "datetime_raw") || string.Equals(values.Name, "coverage_raw")))
                                                {
                                                    values.Read();
                                                    if (values.NodeType == XmlNodeType.Text)
                                                    {
                                                        sensor.SensorResults[i].AddRawValue(values.ReadContentAsDouble());
                                                        break;
                                                    }
                                                }
                                            }
                                            i++;
                                        }
                                    }

                                }
                            }
                        }
                        readerXml.Close();
                    }
                }
                catch (Exception e)
                {
                    ErrorHandler.WritoToLogFile("Error in ParseSensorData: " + e.Message);
                }
                xmlData.Close();
            }
        }

        public static List<TreeProbeElement> ParseSensorTree(string xmlFile)
        {
            List<TreeProbeElement> probes = new List<TreeProbeElement>();
            bool group = false;
            using (XmlReader readerXml = XmlReader.Create(xmlFile))
            {
                readerXml.ReadToFollowing("sensortree");
                readerXml.ReadToDescendant("nodes");
                using (XmlReader rootNode = readerXml.ReadSubtree())
                {
                    while (rootNode.Read())
                    {
                        if (rootNode.NodeType == XmlNodeType.Element)
                        {
                            int lastProbeIndex = -1;
                            int lastGroupIndex = -1;
                            int lastDeviceIndex = -1;
                            if (probes.Count > 0)
                            {
                                lastProbeIndex = probes.Count - 1;
                                if (probes[lastProbeIndex].Groups.Count > 0)
                                {
                                    lastGroupIndex = probes[lastProbeIndex].Groups.Count - 1;
                                    if (probes[lastProbeIndex].Groups[lastGroupIndex].Devices.Count > 0)
                                    {
                                        lastDeviceIndex = probes[lastProbeIndex].Groups[lastGroupIndex].Devices.Count - 1;
                                    }
                                }
                            }
                            switch (rootNode.Name)
                            {
                                case "probenode":
                                    readerXml.ReadToDescendant("name");
                                    probes.Add(new TreeProbeElement(readerXml.ReadElementContentAsString()));
                                    group = false;
                                    break;
                                case "group":
                                    readerXml.ReadToDescendant("name");
                                    if (lastProbeIndex != -1)
                                    {
                                        probes[lastProbeIndex].Groups.Add(new TreeGroupElement(readerXml.ReadElementContentAsString()));
                                        group = true;
                                    }
                                    else
                                    {
                                        TreeProbeElement.RootGroup = readerXml.ReadElementContentAsString();
                                    }
                                    break;

                                case "device":
                                    readerXml.ReadToDescendant("name");
                                    if (!group)
                                    {
                                        probes[lastProbeIndex].Groups.Add(new TreeGroupElement(string.Empty, true));
                                        lastGroupIndex = probes[lastProbeIndex].Groups.Count - 1;
                                    }
                                    probes[lastProbeIndex].Groups[lastGroupIndex].Devices.Add(new TreeDeviceElement(readerXml.ReadElementContentAsString()));
                                    break;
                                case "sensor":
                                    int sensId = Convert.ToInt32(readerXml[0]);
                                    readerXml.ReadToDescendant("name");
                                    string sensorName = readerXml.ReadElementContentAsString();
                                    probes[lastProbeIndex].Groups[lastGroupIndex].Devices[lastDeviceIndex].Sensors.Add(new TreeSensorElement(sensorName, sensId));
                                    break;
                            }
                        }
                    }
                }
                return probes;
            }
        }
    }
}
