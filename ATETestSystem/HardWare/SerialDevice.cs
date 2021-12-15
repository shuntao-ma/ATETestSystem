using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace ATETestSystem
{
    class SerialDevice : Device
    {
        private SerialPort Serial { get; set; }//实例化串口通讯类
        private List<byte> allRecdata { get; set; }//串口有接收到数据后将所有数据存储到该数组中
        public SerialDevice(DeviceInfo _Dev, TestInfo _logmessage) : base()
        {
            Logmessage = _logmessage;
            allRecdata = new List<byte>();
            Dev = _Dev;
            TransferData();//将配置的数据统一转换为Byte数型的数据

            Serial = new SerialPort();
            Serial.DataBits = 8;
            Serial.StopBits = StopBits.One;
            Serial.ReadTimeout = 1000;
            Serial.BaudRate = 115200;
            for (int i = 0; i < Dev.DevParam.Count; i++)//参数i: 1=波特率,2=数据位,3=停止位,4=超时时间
            {
                switch (i)
                {
                    case 0:
                        int BaudRate = 0;
                        if (int.TryParse(Dev.DevParam[i], out BaudRate))
                        {
                            Serial.BaudRate = BaudRate;
                        }
                        break;
                    case 1:
                        int DataBits = 0;
                        if (int.TryParse(Dev.DevParam[i], out DataBits))
                        {
                            Serial.DataBits = DataBits;
                        }
                        break;
                    case 2:
                        int stopBits = 0;
                        if (int.TryParse(Dev.DevParam[i], out stopBits))
                        {
                            Serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Dev.DevParam[i]);
                        }
                        break;
                    case 3:
                        int ReadTimeout = 0;
                        if (int.TryParse(Dev.DevParam[i], out ReadTimeout))
                        {
                            Serial.ReadTimeout = ReadTimeout;
                        }
                        break;
                }
            }
            Serial.PortName = Dev.DevName; //串口号
            Serial.DataReceived += serialPort_DataReceived; //添加接收数据事件;
        }
        public override bool DevOpen()
        {
            try
            {
                if (!Serial.IsOpen)
                {
                    Serial.Open();
                    return true;
                }
                else
                {
                    Serial.Close();
                    Serial = null;
                    return false;
                }
            }
            catch (Exception e)
            {
                Serial = null;
                Logmessage(Dev.DevName + e.Message);
                return false;
            }
        }
        public override bool DevSendData(CmdInfo cmdinf)//发送数据
        {
            try
            {
                if (Serial.IsOpen)
                {
                    StringBuilder CmdStr = new StringBuilder();
                    CmdStr.Append(cmdinf.Cmd);
                    for (int j = 0; j < cmdinf.CmdPram.Count; j++)
                    {
                        if (cmdinf.CmdType == "String")
                        {
                            CmdStr.Append(" " + cmdinf.CmdPram[j]);
                        }
                        else
                        {
                            CmdStr.Append("," + cmdinf.CmdPram[j]);
                        }
                    }
                    List<byte> cmdBytes = StringToBytes(cmdinf.CmdType, CmdStr.ToString());
                    SendHead.AddRange(cmdBytes);
                    SendHead.AddRange(SendTail);

                    allRecdata.Clear();
                    Logmessage(Serial.PortName + "_S:" + Encoding.ASCII.GetString(SendHead.ToArray()));
                    Serial.Write(SendHead.ToArray(), 0, SendHead.Count);
                    return WaitDecodingFinish(allRecdata, cmdinf);
                }
                else
                {
                    Logmessage(Serial.PortName + ":串口未打开");
                    return false;
                }
            }
            catch (Exception e)
            {
                Logmessage(Serial.PortName + "Hardware abnormality!" + e.Message);
                return false;
            }
        }
        public override void DevClose()
        {
            if (Serial != null && Serial.IsOpen)
            {
                Serial.Close();
            }
        }
        public void Devc()
        {
            if (Serial != null)
            {
                Serial.Dispose();
                //SysSetup.AllDevice
            }
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)// 串口接收数据的事件
        {
            try
            {
                SerialPort serialTemp = new SerialPort();
                serialTemp = (SerialPort)sender;
                int Lenght = serialTemp.BytesToRead;
                byte[] temp = new byte[Lenght];
                serialTemp.Read(temp, 0, Lenght);
                allRecdata.AddRange(temp.ToList());
                Logmessage(Serial.PortName + "_R:" + Encoding.ASCII.GetString(temp));
            }
            catch (Exception exception)
            {
                Logmessage(exception.Message);
            }
        }
    }
}
