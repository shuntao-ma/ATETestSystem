using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATETestSystem
{
    public class CmdInfo
    {
        public string DevType { get; set; }             //测试项目使用的设备类型
        public int DevNumber { get; set; }              //测试项目使用的设备名称
        public string CmdType { get; set; }          //该项目设备发送指令的类型
        public string Cmd { get; set; }              //该项目设备需要发送的指令
        public List<string> CmdPram { get; set; }       //该项目设备需要发送的参数
        public List<string> CmdRecdata { get; set; }    //该项目设备发送指令后等待的返回值
        public double CmdTimeOut { get; set; }          //该项目设备发送指令后超时时间
        public CmdInfo()
        {
            DevType = "Serial";
            DevNumber = 0;
            CmdType = "String";
            Cmd = "";
            CmdPram = new List<string>();
            CmdRecdata = new List<string>();
            CmdTimeOut = 2;
        }
    }
}
