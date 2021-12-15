using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ATETestSystem
{
    partial class MainForm : Form
    {
        private List<TestForm> TestFormList;
        private StringBuilder MainLog;
        private int DevShowMaxNum = 6;//设备名称在界面显示的最大数目
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MainLog = new StringBuilder();
            SysSetup.ReadSystemSetupFile();
            TestFormList = new List<TestForm>();
            if (SysSetup.System.DutSortMethod)
            {
                for (int i = SysSetup.Dut.Count; i > 0; i--)
                {
                    SysSetup.Dut[i - 1].DutNumber = i;
                    TestForm TempForm = new TestForm(SysSetup.Dut[i - 1]);
                    TempForm.Show();
                    TestFormList.Add(TempForm);
                    MainSp.Panel2.Controls.Add(TempForm);
                }
            }
            else
            {
                for (int i = 0; i < SysSetup.Dut.Count; i++)
                {
                    SysSetup.Dut[i].DutNumber = i + 1;
                    TestForm TempForm = new TestForm(SysSetup.Dut[i]);
                    TempForm.Show();
                    TestFormList.Add(TempForm);
                    MainSp.Panel2.Controls.Add(TempForm);
                }
            }
            StartPosition = FormStartPosition.CenterScreen;
            if (MainSp.Panel2.Controls.Count > 1)
            {
                WindowState = FormWindowState.Maximized;
                MaximizeBox = true;
            }
            else
            {
                DutLab.Visible = false;
                DutText.Visible = false;

                MoidLab.Location = new Point(PartNoLab.Location.X + PartNoLab.Width + 80, PartNoLab.Location.Y);
                LineId.Location = new Point(MoidLab.Location.X + MoidLab.Width + 80, MoidLab.Location.Y);
                StationIdLab.Location = new Point(LineId.Location.X + LineId.Width + 30, LineId.Location.Y);
                UserIDLab.Location = new Point(StationIdLab.Location.X + StationIdLab.Width + 30, StationIdLab.Location.Y);
                VerLab.Location = new Point(UserIDLab.Location.X + UserIDLab.Width + 50, UserIDLab.Location.Y);
                MaximizeBox = false;
            }
            if (SysSetup.System.DeviceInfo.Count > 0 && SysSetup.System.DeviceInfo.Count < DevShowMaxNum)//确认主窗口使用的设备数量是否超过2个，2个以内在主界面显示，2个以上主界面空间问题，不再显示
            {
                int TempLocatX = PartNoLab.Location.X;
                int index = 0;
                for (int i = 0; i < SysSetup.System.DeviceInfo.Count; i++)
                {
                    Label DevLable = new Label();
                    DevLable.Show();
                    DevLable.Name = nameof(DevLable) + (i + 1);
                    DevLable.Text = "Device" + (i + 1) + ":";
                    DevLable.Font = LineId.Font;
                    DevLable.AutoSize = true;
                    TempLocatX = TempLocatX + ((i - index) * (DevLable.Width + 30));
                    if (TempLocatX > MainSp.Panel1.Width)
                    {
                        index = i + 1;
                    }
                    DevLable.Location = new Point(TempLocatX, PartNoLab.Location.Y+20);
                    MainSp.Panel1.Controls.Add(DevLable);
                }
            }
            else
            {
                MainSp.SplitterDistance = 50;
            }
            Assembly asm = Assembly.GetExecutingAssembly(); //如果是当前程序集
            PartNoLab.Text = PartNoLab.Text + SysSetup.Mes.PartNo;
            MoidLab.Text = MoidLab.Text + SysSetup.Mes.Moid;
            UserIDLab.Text = UserIDLab.Text + SysSetup.Mes.UserId;
            StationIdLab.Text = StationIdLab.Text + SysSetup.Mes.StationId;
            LineId.Text = LineId.Text + SysSetup.Mes.LineId;
            VerLab.Text = VerLab.Text + asm.GetName().Version;
            Text = SysSetup.System.ProjectName + " " + SysSetup.Mes.StationName;
        }
        protected override void WndProc(ref Message m)//设备边接或者断开时更新设备列表和显示界面的控件
        {
            if (m.Msg == 0x219)
            {
                new Thread((() => { ScanAllDevice(); })) { IsBackground = true, Priority = ThreadPriority.Highest }.Start();
            }
            base.WndProc(ref m);
        }
        public void ScanAllDevice()//扫描配置的设备是否有连接到测试系统
        {
            HardwareInfo info = new HardwareInfo();
            ScanDevice(info, SysSetup.System.DeviceInfo,SysSetup.MainDev);
        }
        private void ScanDevice(HardwareInfo _info,List<DeviceInfo> DeviceInfos, Dictionary<int,Device> DicDevice)
        {
            for (int i = 0; i < DeviceInfos.Count; i++)
            {
                if (DeviceInfos[i].DevName != "" && //需要确认的设备名是否为空
                    !DicDevice.Keys.Contains(DeviceInfos[i].DevNumber)) //确认设备列表是否已有对应设备对象
                {
                    Device temp = null;
                    switch (DeviceInfos[i].DevType)
                    {
                        case "Serial":
                            if (_info.SerialDevice.Find(user => user.Contains(DeviceInfos[i].DevName)) != null)
                            {
                                temp = new SerialDevice(DeviceInfos[i], MainLogMsg);
                            }
                            break;
                        case "Net":
                            if (_info.NetDevice.Find(user => user.Contains(DeviceInfos[i].DevName)) != null)
                            {
                                temp = new NetDevice(DeviceInfos[i], MainLogMsg);
                            }

                            break;
                        case "USB":
                            if (_info.UsbDevice.Find(user => user.Contains(DeviceInfos[i].DevName)) != null)
                            {
                                temp = new UsbDevice(DeviceInfos[i], MainLogMsg);
                            }

                            break;
                    }
                    if (temp != null && temp.DevOpen())
                    {
                        if (i < DevShowMaxNum)
                        {
                            MainSp.Panel1.Controls["DevLable" + (i + 1)].Text =
                                "Device" + (i + 1) + ":" + DeviceInfos[i].DevName;
                        }

                        for (int j = 0; j < DeviceInfos[i].CmdItem.Count; j++)
                        {
                            temp.DevSendData(DeviceInfos[i].CmdItem[j]);
                        }
                    }
                    if (temp != null)
                    {
                        DicDevice.Add(DeviceInfos[i].DevNumber, temp);
                    }
                }
                else
                {
                    MainSp.Panel1.Controls["DevLable" + (i + 1)].Text = "Device" + (i + 1) + ":";
                }
            }
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)//主窗口尺寸有变更时更新主窗口控件
        {
            FormSizeChange();
        }
        private void FormSizeChange()//更新主窗口控件
        {
            if (SysSetup.System.DeviceInfo.Count > 0 && SysSetup.System.DeviceInfo.Count < 6)//确认主窗口使用的设备数量是否超过2个，2个以内在主界面显示，2个以上主界面空间问题，不再显示
            {
                MainSp.SplitterDistance = 85;
            }
            else
            {
                MainSp.SplitterDistance = 60;
            }
            switch (MainSp.Panel2.Controls.Count)
            {
                case 0:
                    break;
                case 1:
                    TestFormList[0].Location = new Point(5, 5);
                    TestFormList[0].Width = MainSp.Panel2.Width - 10;
                    TestFormList[0].Height = MainSp.Panel2.Height;
                    break;
                default:
                    #region 根据行数量计算列的数量

                    //int column = MainSp.Panel2.Controls.Count / SysSetup.System.Row;
                    //if (MainSp.Panel2.Controls.Count % SysSetup.System.Row != 0)
                    //{
                    //    column = column + 1;
                    //}
                    //for (int i = 0; i < MainSp.Panel2.Controls.Count; i++)
                    //{
                    //    MainSp.Panel2.Controls[i].Location = new Point((i / SysSetup.System.Row) * (MainSp.Panel2.Width / column),
                    //        (i % SysSetup.System.Row) * MainSp.Panel2.Height / SysSetup.System.Row);

                    //    MainSp.Panel2.Controls[i].Width = MainSp.Panel2.Width / column;
                    //    MainSp.Panel2.Controls[i].Height = MainSp.Panel2.Height / SysSetup.System.Row;
                    //}

                    #endregion

                    #region 根据列数量计算行的数量
                    int Row = MainSp.Panel2.Controls.Count / SysSetup.System.Column;
                    if (MainSp.Panel2.Controls.Count % SysSetup.System.Column != 0)
                    {
                        Row = Row + 1;
                    }
                    for (int i = 0; i < MainSp.Panel2.Controls.Count; i++)
                    {

                        TestFormList[i].Location = new Point(
                            (i % SysSetup.System.Column) * MainSp.Panel2.Width / SysSetup.System.Column,
                            (i / SysSetup.System.Column) * (MainSp.Panel2.Height / Row));

                        TestFormList[i].Width = MainSp.Panel2.Width / SysSetup.System.Column;
                        TestFormList[i].Height = MainSp.Panel2.Height / Row;
                        TestForm TemForm = TestFormList[i];
                        if (TemForm.WindowState == FormWindowState.Maximized)
                        {
                            TemForm.WindowState = FormWindowState.Normal;
                            Invalidate();
                            TemForm.WindowState = FormWindowState.Maximized;
                        }
                    }
                    #endregion
                    break;
            }
            Invalidate();
        }
        private void DevParamSetMenu_Click(object sender, EventArgs e)//进入配置测试窗口
        {
            PassWord passWord = new PassWord();
            passWord.ShowDialog();
            if (passWord.DialogResult == DialogResult.OK)
            {
                SetMainForm form = new SetMainForm(passWord.Permission);
                form.ShowDialog();
                Application.ExitThread();

                //触发退出程序事件
                //Thread thtmp = new Thread(new ParameterizedThreadStart(run));
                //object appName = Application.ExecutablePath;
                //Thread.Sleep(100);
                //thtmp.Start(appName);
            }
        }
        private void DevPortSetMenu_Click(object sender, EventArgs e)//配置测试端口按键
        {

        }
        private void ExitMenu_Click(object sender, EventArgs e)//退出系统按键
        {
            this.Close();
        }
        private void LoopTestMenu_Click(object sender, EventArgs e)//设置循环测试标志按键
        {
            if (SysSetup.System.LoopTestFlag)
            {
                LoopTestMenu.Text = "开始循环测试";
            }
            else
            {
                LoopTestMenu.Text = "停止循环测试";
            }
            SysSetup.System.LoopTestFlag = !SysSetup.System.LoopTestFlag;
        }
        private void run(Object obj)//软件关闭后重新启动
        {
            Process ps = new Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormSizeChange();
            ScanAllDevice();
        }
        private void MainLogMsg(string str)
        {
            MainLog.Append(str);
            MainRunMsg.Text = str;
        }
        private void SnText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SnText.Text = SnText.Text.Replace("\r\n", "");
                if (SnText.Text != "")
                {
                    if (SysSetup.Dut.Count == 1)//确认测试窗口是单个窗口还是多个窗口
                    {
                        DutText.Text = 1.ToString();
                        SnText.Enabled = false;
                        TestFormList[0].SnText.Text = SnText.Text;
                        MainLogMsg(DutText.Text + ":" + SnText.Text);
                    }
                    else
                    {
                        DutText.Clear();
                        DutText.Focus();
                    }
                }
                else
                {
                    MainLogMsg("SN输入错误请重新输入");
                    DutText.Clear();
                    SnText.Clear();
                    SnText.Focus();
                }
            }
        }
        private void DutText_KeyUp(object sender, KeyEventArgs e)
        {
            int dut = 0;
            if (e.KeyData == Keys.Enter)
            {
                if (Int32.TryParse(DutText.Text, out dut))
                {
                    if (dut > 0 && dut <= Convert.ToInt32(SysSetup.Dut.Count))
                    {
                        if (SysSetup.System.DutSortMethod)
                        {
                            dut = TestFormList.Count - (dut);
                            TestFormList[dut].SnText.Text = SnText.Text;
                        }
                        else
                        {
                            TestFormList[dut - 1].SnText.Text = SnText.Text;
                        }
                        MainLogMsg(DutText.Text + ":" + SnText.Text);
                        SnText.Clear();
                        SnText.Focus();
                        return;
                    }
                }
                MainLogMsg(DutText.Text + ":" + "输入错误，请输入1到" + SysSetup.Dut.Count + "之间的数字!");
                SnText.Clear();
                DutText.Clear();
                SnText.Focus();
            }
        }
    }
}
