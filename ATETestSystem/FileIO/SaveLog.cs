using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

// ReSharper disable InconsistentNaming

namespace ATETestSystem
{
    class SaveLog
    {
        private event TestInfo LogMessage;
        public SaveLog(TestInfo log)
        {
            LogMessage = log;
        }
        public void SaveTestLogFile(DutInfo info, string data)//保存测试结果
        {
            try
            {
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    directoryInfo.Create();
                }

                string LogfileFullName = directoryPath + "\\" + SysSetup.System.ProjectName + SysSetup.Mes.StationName;
                LogfileFullName += info.BarCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

                FileInfo fileInfo = new FileInfo(LogfileFullName);
                if ((!fileInfo.Exists))
                {
                    StreamWriter sw = new StreamWriter(LogfileFullName, false, Encoding.Default);
                    string logHeardstr = "SN,产品料号,工单号,线别,站别名称,治具编号,测试时间,当前测试时间,不良代码,测试结果,";
                    for (int i = 0; i < SysSetup.TestItem.Count; i++)
                    {
                        logHeardstr += SysSetup.TestItem.ElementAt(i).Name + ",";
                    }
                    sw.WriteLine(logHeardstr);
                    sw.Close();
                }

                if (info.BarCode != null && info.BarCode != "")
                {
                    string strTemp = info.BarCode + ",";
                    strTemp += SysSetup.Mes.PartNo + ",";
                    strTemp += SysSetup.Mes.Moid + ",";
                    strTemp += SysSetup.Mes.LineId + ",";
                    strTemp += SysSetup.Mes.StationName + ",";
                    strTemp += SysSetup.Mes.EquipID + ",";
                    strTemp += data;
                    StreamWriter sw = new StreamWriter(LogfileFullName, true, Encoding.Default);
                    sw.WriteLine(strTemp);
                    sw.Close();
                    LogMessage.Invoke(info.BarCode + "测试数据保存成功！");
                }
                else
                {
                    LogMessage.Invoke(info.BarCode + "SN错误");
                }
            }
            catch (Exception e)
            {
                LogMessage.Invoke(info.BarCode + "测试数据保存失败" + e.Message);
            }
        }
        public void SaveTestData(DutInfo info, string data)//保存测试结果
        {
            try
            {
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    directoryInfo.Create();
                }

                string LogfileFullName = directoryPath + "\\" + SysSetup.System.ProjectName + SysSetup.Mes.StationName;
                LogfileFullName += "_" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".csv";

                FileInfo fileInfo = new FileInfo(LogfileFullName);
                if ((!fileInfo.Exists))
                {
                    StreamWriter sw = new StreamWriter(LogfileFullName, false, Encoding.Default);
                    string logHeardstr = "SN,产品料号,工单号,线别,站别名称,治具编号,测试时间,当前测试时间,不良代码,测试结果,";
                    for (int i = 0; i < SysSetup.TestItem.Count; i++)
                    {
                        logHeardstr += SysSetup.TestItem.ElementAt(i).Name + ",";
                    }
                    sw.WriteLine(logHeardstr);
                    sw.Close();
                }

                if (info.BarCode != null && info.BarCode != "")
                {
                    string strTemp = info.BarCode + ",";
                    strTemp += SysSetup.Mes.PartNo+ ",";
                    strTemp += SysSetup.Mes.Moid + ",";
                    strTemp += SysSetup.Mes.LineId + ",";
                    strTemp += SysSetup.Mes.StationName + ",";
                    strTemp += SysSetup.Mes.EquipID + ",";
                    strTemp += data;
                    StreamWriter sw = new StreamWriter(LogfileFullName, true, Encoding.Default);
                    sw.WriteLine(strTemp);
                    sw.Close();
                    LogMessage.Invoke(info.BarCode + "测试数据保存成功！");
                }
                else
                {
                    LogMessage.Invoke(info.BarCode + "SN错误");
                }
            }
            catch (Exception e)
            {
                LogMessage.Invoke(info.BarCode + "测试数据保存失败" + e.Message);
            }
        }
        public void SaveSWrunLogFile(string filename, string strTemp)//保存测试结果
        {
            try
            {
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\Logfile";
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    directoryInfo.Create();
                }
                string LogfileFullName = directoryPath + "\\" + SysSetup.System.ProjectName + SysSetup.Mes.StationName + filename + DateTime.Now.ToString("_yyyyMMddHHmmss") + ".txt";
                StreamWriter sw = new StreamWriter(LogfileFullName, true, Encoding.Default);
                sw.Write(DateTime.Now.ToString("HH:mm:ss.ff") + "\r\n" + strTemp);
                sw.Close();
                Thread.Sleep(50);
            }
            catch (Exception e)
            {
                LogMessage.Invoke(filename + "信息保存失败" + e.Message);
            }
        }
        private int FindCharNumber(string str, char ch)//查找字符串中包含指定字符的个数
        {
            int num = 0;
            int Star = 0;
            while (Star != -1)
            {
                Star = str.IndexOf(ch, Star);//获取字符的索引
                if (Star != -1)
                {
                    num++;
                    Star++;
                }
            }
            return num;
        }
        public string[] ReadCsv(string filePath, int rowNum) //读取CSV文档一行的数据
        {
            try
            {
                List<string[]> ls = new List<string[]>();
                StreamReader fileReader = new StreamReader(filePath, Encoding.Default);
                string strLine = "";
                while (strLine != null)
                {
                    strLine = fileReader.ReadLine();
                    if (!string.IsNullOrEmpty(strLine))
                    {
                        ls.Add(strLine.Split(new[] { ',' })); // 将字符串分割成字符串数组
                    }
                }
                fileReader.Close();
                if (rowNum > ls.Count)
                    rowNum = ls.Count;
                return ls[rowNum];
            }
            catch (Exception e)
            {
                LogMessage.Invoke("数据读取异常" + e.Message);
                throw;
            }
        }
    }
}
