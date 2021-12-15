using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace ATETestSystem
{
    class NetDevice : Device
    {
        private List<byte> allRecdata { get; set; }//串口有接收到数据后将所有数据存储到该数组中
        public NetDevice(DeviceInfo _Dev, TestInfo _logmessage) : base()
        {
            Logmessage = _logmessage;
            allRecdata = new List<byte>();
            Dev = _Dev;
        }
        public override bool DevOpen()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return false;
            }
        }
        public override bool DevSendData(CmdInfo cmdinf)//发送数据
        {
            return false;
        }
        public override void DevClose()
        {

        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)// 网络接收到数据的事件
        {
            try
            {
                SerialPort serialTemp = new SerialPort();
                serialTemp = (SerialPort)sender;
                int Lenght = serialTemp.BytesToRead;
                byte[] temp = new byte[Lenght];
                serialTemp.Read(temp, 0, Lenght);
                allRecdata.AddRange(temp.ToList());
                Logmessage("_R:" + Encoding.ASCII.GetString(temp));
            }
            catch (Exception exception)
            {
                Logmessage(exception.Message);
            }
        }
    }
}
