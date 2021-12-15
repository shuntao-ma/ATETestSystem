using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    public class DutInfo//该类记录每个测试窗口的信息
    {
        public int DutNumber { get; set; }      //记录窗口编号
        public int PassCount { get; set; }      //记录该窗口Pass的数量
        public int FailCount { get; set; }      //记录该窗口Fail的数量
        public string BarCode { get; set; }
        public string Result { get; set; }           //记录产品的测试结果
        public string Errcode { get; set; }          //记录产品的不良代码
        public string TestData { get; set; }        //记录产品的测试数据
        public double timeOut { get; set; }         //等待超时的时间
        public bool TestFlag { get; set; }          //标记此窗口是否在测试中
        public List<DeviceInfo> DeviceInfo { get; set; }    //记录该窗口使用的设备信息
        public TestInfo LogMsg { get; set; }

        public DutInfo()
        {
            DutNumber = 0; //记录产品编号
            PassCount = 0;  //记录产品的IP地址
            FailCount = 0;  //记录产品的IP地址
            BarCode = "";
            Result = "";
            Errcode = "";
            TestData = "";
            timeOut = 0;
            TestFlag = false;
            DeviceInfo = new List<DeviceInfo>(); //记录产口1的串口编号
            LogMsg = null;
        }
    }
}
