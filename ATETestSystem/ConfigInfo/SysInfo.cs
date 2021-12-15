using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Reflection;
using System.Net;

namespace ATETestSystem
{
    class SysInfo//该类记录系统的配置信息
    {
        public string ProjectName { get; set; }
        public string SN_Sample { get; set; }
        public bool KeyStartFlag { get; set; }
        public bool ScanStartFlag { get; set; }
        public bool SaveInfoFlag { get; set; }
        public bool FailStopFlag { get; set; }
        public bool LoopTestFlag { get; set; }
        public int Column { get; set; }
        public bool DutSortMethod { get; set; }
        public bool AutoAddrFlag { get; set; }
        public List<DeviceInfo> DeviceInfo { get; set; }    //记录主窗口使用的外部设备信息
        public SysInfo()
        {
            DutSortMethod = false;
            ProjectName = "";
            SN_Sample = "";
            KeyStartFlag = false;
            ScanStartFlag = false;
            SaveInfoFlag = false;
            FailStopFlag = false;
            LoopTestFlag = false;
            AutoAddrFlag = false;
            Column = 1;
            DeviceInfo = new List<DeviceInfo>();
        }
    }
}
