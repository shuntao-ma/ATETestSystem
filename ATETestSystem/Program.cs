using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    public delegate void TestInfo(string str); //测试信息
    public delegate void MainWindowUpdate();   //更新主窗口控件
    public delegate void ShowBtn(string passbtntext, string failbtntext, string testbtntext);//测试窗口显示Pass  Fail铵键
    public delegate bool TestFunc(TestItemInfo Item, DutInfo info);//测试方法
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
