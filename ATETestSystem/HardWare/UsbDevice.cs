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
    class UsbDevice : Device
    {
        private List<byte> allRecdata { get; set; }//串口有接收到数据后将所有数据存储到该数组中
        public UsbDevice(DeviceInfo _Dev, TestInfo _logmessage) : base()
        {
            Logmessage = _logmessage;
            allRecdata = new List<byte>();
            Dev = _Dev;
        }
        public override bool DevOpen()
        {
            return false;
        }
        public override bool DevSendData(CmdInfo cmdinf)//发送数据
        {
            return false;
        }
        public override void DevClose()
        {

        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)// 串口接收数据的事件
        {
            try
            {
                SerialPort serialTemp = new SerialPort();
                serialTemp = (SerialPort)sender;
                int Lenght = serialTemp.BytesToRead;
                byte[] temp = new byte[Lenght];
                serialTemp.Read(temp, 0, Lenght);
                allRecdata.AddRange(temp.ToList());
                Logmessage(  "_R:" + Encoding.ASCII.GetString(temp));
            }
            catch (Exception exception)
            {
                Logmessage(exception.Message);
            }
        }
    }
}
