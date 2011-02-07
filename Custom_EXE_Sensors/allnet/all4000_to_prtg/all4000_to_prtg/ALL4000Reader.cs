/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Marc Fuhrmeister
 * Datum: 13.02.2010
 * Zeit: 20:39
 * 
 */
using System;
using System.Net;
using System.IO;

namespace all4000_to_prtg
{
	/// <summary>
	/// Description of ALL4000Reader.
	/// </summary>
	public class ALL4000Reader
	{
		
		string  m_strALL_IP;
		string  m_strALL_SENSOR_NR;
		string  m_strALL_SENSOR_VAL;
		string  m_strRetVal;	

		public ALL4000Reader(string[] args)
		{		
			if (args.Length != 3) {
			/*	* 0: ok
				* 1: Warnung
			    * 2: Systemfehler (z.B.: Netzwerk-/Anschlussfehler)
			    * 3: Protokollfehler (z.B.: der Webserver meldet einen 404)
			    * 4: Inhaltsfehler (z.B.: eine Webseite beinhaltet ein benötigtes Wort nicht)
				*/

                m_strRetVal = "-2: wrong argument count";
                setExitCode(2);
			} else {
				// Get Args
				m_strALL_IP = args[0];
				m_strALL_SENSOR_NR = args[1];
				m_strALL_SENSOR_VAL = args[2];
				
				switch (m_strALL_SENSOR_VAL) {
					case "MAX":
					case "MIN":
					case "CURRENT":
						readVal();
						break;
					default:
						m_strRetVal = "-1: wrong sensor value to get {MIN|MAX|CURRENT}";
						setExitCode(1);
						break;
				}
			}
            Console.WriteLine(m_strRetVal);
        }
		
		public void readVal(){
			try {
				string strUrl = String.Format("http://{0}/xml", m_strALL_IP);
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                //request.Credentials = New System.Net.NetworkCredential( strUser, strPassword);
                request.Method = WebRequestMethods.Http.Get;
	        

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                string strResult = sr.ReadToEnd();
                strResult = strResult.Substring(strResult.IndexOf("<xml>"), strResult.IndexOf("</xml>") - strResult.IndexOf("<xml>") +6);
                strResult.Replace("\n","");
                strResult.Replace("\r","");
                response.Close();
            
//                string strResult = "<xml><data><devicename>MySensoren</devicename><n0>0</n0><t0> 32.15</t0><min0> 28.69</min0><max0> 32.60</max0><l0>0</l0><h0>100</h0><s0>65</s0><n1>1</n1><t1> 21.05</t1><min1> 20.18</min1><max1> 23.73</max1><l1>-40</l1><h1>40</h1><s1>3</s1><n2>2</n2><t2> 1020.88</t2><min2> 955.43</min2><max2>-20480.00</max2><l2>850</l2><h2>1035</h2><s2>40</s2><n3>3</n3><t3>-20480.00</t3><min3> 20480.00</min3><max3>-20480.00</max3><l3>-55</l3><h3>150</h3><s3>0</s3><n4>4</n4><t4>-20480.00</t4><min4> 20480.00</min4><max4>-20480.00</max4><l4>-55</l4><h4>150</h4><s4>0</s4><n5>5</n5><t5>-20480.00</t5><min5> 20480.00</min5><max5>-20480.00</max5><l5>-55</l5><h5>150</h5><s5>0</s5><n6>6</n6><t6>-20480.00</t6><min6> 20480.00</min6><max6>-20480.00</max6><l6>-55</l6><h6>150</h6><s6>0</s6><n7>7</n7><t7> 21.68</t7><min7> 19.87</min7><max7> 23.50</max7><l7>-40</l7><h7>40</h7><s7>2</s7><date>08.04.2006</date><time>08:20:32</time><ad>1</ad><i>60</i><f>0</f><sys>28409</sys><mem>31656</mem><fw>2.59</fw><dev>ALL4000</dev></data></xml>";               
                	/*
					 * <n0>0</n0>
					 * <t0> 32.15</t0>
					 * <min0> 28.69</min0>
					 * <max0> 32.60</max0>
					 * <l0>0</l0>
					 * <h0>100</h0>
					 * <s0>65</s0>
					 */
                
                System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                
                xml.LoadXml(strResult);
				
				string strTag = "";
				switch (m_strALL_SENSOR_VAL) {
					case "MAX":
						strTag = "max";
						break;
					case "MIN":
						strTag = "min";
						break;
					case "CURRENT":
						strTag = "t";
						break;
				}
				m_strRetVal = xml.GetElementsByTagName(strTag + m_strALL_SENSOR_NR)[0].InnerText + ":" + xml.GetElementsByTagName("n" + m_strALL_SENSOR_NR)[0].InnerText;
				setExitCode(0);
			} catch (Exception ex) {
            	m_strRetVal = "-3: Exception:" + ex.Message;
            	setExitCode(2);
        	}
		}
		
		private void setExitCode(int nExitCode) {
			Environment.ExitCode = nExitCode;
		}

	}
}
