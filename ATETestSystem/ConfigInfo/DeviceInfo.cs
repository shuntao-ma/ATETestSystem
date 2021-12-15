using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    public class DeviceInfo//该类记录读取配置文件中设备的配置信息
    {
        public string DevType { get; set; }         //记录设备类型
        public int DevNumber { get; set; }          //记录设备编号
        public string DevName { get; set; }         //记录设备名称
        public string CmdType { get; set; }         //该项目设备发送指令的类型
        public string CmdSendHead { get; set; }         //测试项目使用的设备类型
        public string CmdSendTail { get; set; }         //测试项目使用的设备名称
        public string CmdRecHead { get; set; }          //测试项目使用的设备类型
        public string CmdRecTail { get; set; }          //测试项目使用的设备名称
        public List<string> DevParam { get; set; }      //记录设备初始化时的配置参数
        public List<CmdInfo> CmdItem { get; set; }      //记录设备初始化完成后需要发送的信息和返回的信息
        public DeviceInfo()
        {
            DevType = "Serial";
            DevNumber = 0;
            DevName = "";
            CmdType = "String";       //该项目设备发送指令的类型
            CmdSendHead = "";       //测试项目使用的设备类型
            CmdSendTail = "";       //测试项目使用的设备名称
            CmdRecHead = "";       //测试项目使用的设备类型
            CmdRecTail = "";       //测试项目使用的设备名称
            DevParam = new List<string>();
            CmdItem = new List<CmdInfo>();
        }
    }
}
