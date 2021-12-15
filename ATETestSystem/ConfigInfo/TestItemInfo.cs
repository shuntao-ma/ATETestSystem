using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ATETestSystem
{
    public class TestItemInfo//该类记录测试项目信息
    {
        public int Number { get; set; }                 //记录测试编号
        public string Method { get; set; }              //记录测试方法的名称
        public string Name { get; set; }                //记录测试名称
        public string UpLimit { get; set; }             //记录测试上限
        public string LowLimit { get; set; }            //记录测试下限
        public int RetestTimes { get; set; }            //记录该项目测试NG时需要重复测试的次数
        public string MethodMsg { get; set; }           //记录调用该测试项目时显示的提示信息
        public CmdInfo CmdInfo { get; set; }
        public string ErrCode { get; set; }             //记录测试NG时的不良代码
        public string Value;                            //记录测试值
        public string Result;                           //记录测试结果
        public TestItemInfo()
        {
            Number = 0;           //记录测试编号
            Method = "";        //记录测试方法的名称
            Name = "";          //记录测试名称
            UpLimit = "Pass";   //记录测试上限
            LowLimit = "";      //记录测试下限
            RetestTimes = 1;   //记录该项目测试NG时需要重复测试的次数
            MethodMsg = "";
            CmdInfo=new CmdInfo();
            ErrCode = "";       //记录测试NG时的不良代码
            Value = "";         //记录测试上限
            Result = "";        //记录测试结果
        }
    }
}
