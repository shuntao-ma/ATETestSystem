using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ATETestSystem
{
    class MesInfo//该类记录Mes的配置信息及方法
    {
        private const string MesAddress = "http://mes.luxshare-ict.com:8088/DataService.asmx";
        public event TestInfo Logmessage;
        public bool MesFlag { get; set; }
        public string MesIP { get; set; }
        public string Barcode { get; set; }
        public string CustID { get; set; }
        public string PartNo { get; set; }
        public string Moid { get; set; }
        public string LineId { get; set; }
        public string StationName { get; set; }
        public string StationId { get; set; }
        public string ProductGroup { get; set; }
        public string UserId { get; set; }
        public int EquipID { get; set; }
        public MesInfo()
        {
            Logmessage = null;
            MesFlag = false;
            MesIP = "";
            Barcode = "";
            CustID = "";
            PartNo = "";
            Moid = "";
            LineId = "";
            StationName = "";
            StationId = "";
            ProductGroup = "";
            UserId = "";
            EquipID = 0;
        }

        #region 检查SN的流程状态，确认是否是当前工位
        public string CheckProcess()
        {
            try
            {
                string url = MesAddress + "/CommonApproveStationNew?";
                if (Moid != string.Empty &&
                    PartNo != string.Empty &&
                    StationId != string.Empty &&
                    LineId != null &&
                    UserId != string.Empty &&
                    ProductGroup != string.Empty)
                {
                    string str = "barcode=" + Barcode +
                                 "&custID=" + CustID +
                                 "&moid=" + Moid +
                                 "&partno=" + PartNo +
                                 "&stationid=" + StationId +
                                 "&lineid=" + LineId +
                                 "&equipID=" + EquipID +
                                 "&userid=" + UserId +
                                 "&productgroup=" + ProductGroup;
                    List<string> strList = XMLHttpRequest(str, url);
                    if (strList.Count > 0)
                    {
                        return strList[0];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "NG";
        }
        #endregion

        #region 上传数据到MES系统
        public string UpdateSFdata(string TestData, string Result, string Errcode)
        {
            try
            {
                //string url = MesAddress + "/CommonCompleteStationNew?";
                string url = MesAddress + "/CommonCompleteStationNew?";
                if (Moid != string.Empty &&
                    PartNo != string.Empty &&
                    StationId != string.Empty &&
                    LineId != string.Empty &&
                    ProductGroup != string.Empty &&
                    UserId != string.Empty)
                {
                    string strTemp = "{\"item1\":\"" + Barcode + "\",";
                    strTemp += "\"item2\":\"" + Moid + "\"," +
                             "\"item3\":\"" + PartNo + "\"," +
                             "\"item4\":\"" + LineId + "\"," +
                             "\"item5\":\"" + EquipID + "\"," +
                             "\"item6\":\"" + UserId + "\"," +
                             "\"item7\":\"" + TestData;
                    strTemp += "\"}";
                    string str = "barcode=" + Barcode +
                             "&custID=" + CustID +
                             "&moid=" + Moid +
                             "&partno=" + PartNo +
                             "&stationid=" + StationId +
                             "&lineid=" + LineId +
                             "&equipID=" + EquipID +
                             "&productgroup=" + ProductGroup +
                             "&testresult=" + Result +
                             "&errorcode=" + Errcode +
                             "&userid=" + UserId +
                             "&json=" + strTemp;
                    List<string> strList = XMLHttpRequest(str, url);
                    if (strList.Count > 0)
                    {
                        return strList[0];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "NG";
        }
        #endregion

        #region 调用Post方法上传测试数据到SFC
        private List<string> XMLHttpRequest(string strPostdata, string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "post";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/x-www-form-urlencoded";
                //request.ContentType = "text/xml;charset=utf-8";
                byte[] buffer = Encoding.Default.GetBytes(strPostdata);
                request.ContentLength = buffer.Length;
                request.Timeout = 5000;
                request.ReadWriteTimeout = 1500;
                request.ContinueTimeout = 1500;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Logmessage.Invoke("ToMesSever:" + URL + strPostdata);
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string rivece = readStream.ReadToEnd();

                XmlDocument doc = new XmlDocument();//创建XML文件 解析XML文件按
                doc.LoadXml(rivece);
                XmlNodeList xnl = doc.ChildNodes;//获得子节点 返回节点的集合
                XmlElement User = doc.DocumentElement; //获得文件的根节点
                List<string> vaList = new List<string>();
                foreach (XmlNode item in User)
                {
                    enumXmlChildNodes(item, ref vaList);
                }
                for (int i = 0; i < vaList.Count; i++)
                {
                    Logmessage.Invoke("FromMesSever:" + vaList[i]);
                }
                return vaList;
            }
            catch (Exception e)
            {
                return new List<string>() { e.Message };
            }
        }

        private void enumXmlChildNodes(XmlNode xml, ref List<string> vaList)
        {
            if (xml.ChildNodes.Count > 0)
            {
                foreach (XmlNode item in xml)
                {
                    enumXmlChildNodes(item, ref vaList);
                }
            }
            else
            {
                vaList.Add(xml.InnerText);
                return;
            }
        }

        private List<string> XMLHttpRequest1(string strPostdata, string URL)
        {
            var result = string.Empty;
            //创建一个HTTP请求
            byte[] byt = Encoding.UTF8.GetBytes(strPostdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byt.Length;

            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            Stream outputStream = request.GetRequestStream();
            outputStream.Write(byt, 0, byt.Length);
            outputStream.Close();

            HttpWebResponse response;
            Stream responseStream;
            StreamReader reader;
            string srcString;
            try
            {
                response = (HttpWebResponse)request.GetResponse();//获取http请求的响应对象
            }
            catch (WebException ex)
            {
                return new List<string>() { ex.Message };
            }
            responseStream = response.GetResponseStream();
            reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            srcString = reader.ReadToEnd();
            result = srcString;   //返回值赋值
            reader.Close();
            return new List<string>() { result };
        }
        #endregion
    }
}
