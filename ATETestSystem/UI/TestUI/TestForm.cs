using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATETestSystem.Properties;
using System.Diagnostics;
using System.Threading;

namespace ATETestSystem
{
    partial class TestForm : Form
    {
        private DutInfo Dut;
        private List<TestItemInfo> TestItem;
        private Label SnLab;
        public TextBox SnText;
        private BackgroundWorker TestWorker;    //测试线程
        private Stopwatch stopwatch;            //记录产品的测试时间
        public Point OldLocation;

        public TestForm(DutInfo _Dut)
        {
            TopLevel = false;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Dut = _Dut;
            Dut.LogMsg = DutLogMsg;
            Location = new Point();
            if (SysSetup.Dut.Count == 1)
            {
                TestDutTable.TabPages.Remove(TestPage);
                Controls.Add(TestLog);
                Controls.Add(DevCheckedInfo);
            }
            else
            {
                SnLab = new Label();
                SnLab.AutoSize = true;
                SnLab.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                SnLab.Location = new Point(8, 13);
                SnLab.Name = "SnLab";
                SnLab.Text = "SN";
                Controls.Add(SnLab);

                SnText = new TextBox();
                SnText.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                SnText.Location = new Point(35, 13);
                SnText.Name = "SnText";
                SnText.Enabled = false;
                SnText.Multiline = true;
                SnText.Text = "";
                Controls.Add(SnText);
                SnText.TextChanged += new EventHandler(SnText_TextChanged);
            }
        }
        private void TestForm_Load(object sender, EventArgs e)//启动时先更新一下界面，不然多窗口时第二个页面控件显示不正常
        {
            PassBtn.Visible = false;
            FailBtn.Visible = false;
            DutNumberLab.Text = "Number:" + Dut.DutNumber;
            FormSizeChange();

            ResPictureBox.Image = Resources.Waiting;
            TestItem = new List<TestItemInfo>();
            for (int i = 0; i < SysSetup.TestItem.Count; i++)
            {
                TestItemInfo temp = new TestItemInfo();
                temp.Number = SysSetup.TestItem[i].Number;
                temp.Method = SysSetup.TestItem[i].Method;
                temp.Name = SysSetup.TestItem[i].Name;
                temp.UpLimit = SysSetup.TestItem[i].UpLimit;
                temp.LowLimit = SysSetup.TestItem[i].LowLimit;
                temp.RetestTimes = SysSetup.TestItem[i].RetestTimes;
                temp.MethodMsg = SysSetup.TestItem[i].MethodMsg;
                temp.CmdInfo.DevType = SysSetup.TestItem[i].CmdInfo.DevType;
                temp.CmdInfo.DevNumber = SysSetup.TestItem[i].CmdInfo.DevNumber;
                temp.CmdInfo.CmdType = SysSetup.TestItem[i].CmdInfo.CmdType;
                temp.CmdInfo.Cmd = SysSetup.TestItem[i].CmdInfo.Cmd;
                for (int j = 0; j < SysSetup.TestItem[i].CmdInfo.CmdPram.Count; j++)
                {
                    temp.CmdInfo.CmdPram.Add(SysSetup.TestItem[i].CmdInfo.CmdPram[j]);
                }
                for (int j = 0; j < SysSetup.TestItem[i].CmdInfo.CmdRecdata.Count; j++)
                {
                    temp.CmdInfo.CmdRecdata.Add(SysSetup.TestItem[i].CmdInfo.CmdRecdata[j]);
                }
                temp.CmdInfo.CmdTimeOut = SysSetup.TestItem[i].CmdInfo.CmdTimeOut;
                temp.ErrCode = SysSetup.TestItem[i].ErrCode;
                temp.Value = SysSetup.TestItem[i].Value;
                temp.Result = SysSetup.TestItem[i].Result;
                TestItem.Add(temp);
            }

            TestWorker = new BackgroundWorker();
            TestWorker.DoWork += TestProcess;
            stopwatch = new Stopwatch();
            UpdateDgv();
            new Thread(() => { TimesUpdate(); }) { IsBackground = true, Priority = ThreadPriority.Lowest }.Start();
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == 0x0112)//WM_SYSCOMMAND
                {
                    if ((int)m.WParam == 0xF012)//
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.WndProc(ref m);
        }
        private void TestForm_Resize(object sender, EventArgs e)//窗口尺寸变更时更新控件尺寸
        {
            FormSizeChange();
        }
        private void FormSizeChange()//窗口尺寸变更时更新控件尺寸
        {
            TestProgressBar.Width = Width - 5;
            if (SysSetup.Dut.Count == 1)
            {
                DutNumberLab.Visible = false;
                TestTimesLab.Location = DutNumberLab.Location;
                PassCountLab.Location = new Point(TestTimesLab.Location.X + TestTimesLab.Width + 50, TestTimesLab.Location.Y);
                FailCountLab.Location = new Point(PassCountLab.Location.X + PassCountLab.Width + 50, TestTimesLab.Location.Y);
                TestDutTable.Location = new Point(TestDutTable.Location.X, FailCountLab.Location.Y + FailCountLab.Height + 10);
                TestDutTable.Width = Width * 2 / 3;
                TestDutTable.Height = Height - PassCountLab.Height - MethodsInfoLab.Height - PassBtn.Height - TestStatusStrip.Height - 70;

                ResPictureBox.Size = new Size(Width / 3 - 30, Height / 5);
                ResPictureBox.Location = new Point(TestDutTable.Location.X + TestDutTable.Width + 5, 5);

                DevCheckedInfo.Size = new Size(Width / 3 - 30, Height / 7);
                DevCheckedInfo.Location = new Point(ResPictureBox.Location.X, ResPictureBox.Location.Y + ResPictureBox.Height + 10);

                TestLog.Size = new Size(Width / 3 - 30, TestDutTable.Height * 2 / 3 + 15);
                TestLog.Location = new Point(TestDutTable.Location.X + TestDutTable.Width + 5, DevCheckedInfo.Location.Y + DevCheckedInfo.Height + 10);

                MethodsInfoLab.Size = new Size(TestDutTable.Width - 15, MethodsInfoLab.Height);
                TestButton.Size = new Size(TestDutTable.Width - 5, TestButton.Height);

                PassBtn.Size = new Size(TestDutTable.Width / 2 - 5, PassBtn.Height);
                PassBtn.Location = new Point(TestButton.Location.X + 5, TestButton.Location.Y);

                FailBtn.Size = new Size(TestDutTable.Width / 2 - 5, FailBtn.Height);
                FailBtn.Location = new Point(PassBtn.Location.X + PassBtn.Width + 10, PassBtn.Location.Y);

            }
            else
            {
                PassBtn.Size = new Size(Width / 2 - 20, PassBtn.Height);
                PassBtn.Location = new Point(TestButton.Location.X + 5, TestButton.Location.Y);
                FailBtn.Size = new Size(Width / 2 - 20, FailBtn.Height);
                FailBtn.Location = new Point(PassBtn.Location.X + PassBtn.Width + 10, PassBtn.Location.Y);

                SnText.Location = new Point(SnLab.Location.X + 35, SnLab.Location.Y);
                SnText.Width = Width - 65;
                SnText.Height = 30;
                DutNumberLab.Location = new Point(SnLab.Location.X, SnLab.Location.Y + SnLab.Height + 20);
                TestTimesLab.Location = new Point(DutNumberLab.Location.X + DutNumberLab.Width + 20, DutNumberLab.Location.Y);

                if (Height / 1.5 > Width)
                {
                    PassCountLab.Location = new Point(DutNumberLab.Location.X, TestTimesLab.Location.Y + TestTimesLab.Height + 20);
                    FailCountLab.Location = new Point(TestTimesLab.Location.X, PassCountLab.Location.Y);

                    TestDutTable.Location = new Point(PassCountLab.Location.X, FailCountLab.Location.Y + FailCountLab.Height + 20);
                    TestDutTable.Height = Height - SnLab.Height - DutNumberLab.Height - PassCountLab.Height - MethodsInfoLab.Height - PassBtn.Height - TestStatusStrip.Height - 120;

                    ResPictureBox.Location = new Point(TestTimesLab.Location.X + TestTimesLab.Width + 50, DutNumberLab.Location.Y);
                    ResPictureBox.Width = Width - DutNumberLab.Width - TestTimesLab.Width - 100;
                    ResPictureBox.Height = TestDutTable.Location.Y - 35;
                    if (ResPictureBox.Width < ResPictureBox.Height)
                    {
                        ResPictureBox.Location = new Point(FailCountLab.Location.X + FailCountLab.Width + 30, DutNumberLab.Location.Y + 20);
                        ResPictureBox.Width = ResPictureBox.Height + 30;
                        ResPictureBox.Height = ResPictureBox.Height - 20;
                    }
                }
                else
                {
                    PassCountLab.Location = new Point(TestTimesLab.Location.X + TestTimesLab.Width + 50, TestTimesLab.Location.Y);
                    FailCountLab.Location = new Point(PassCountLab.Location.X + PassCountLab.Width + 50, PassCountLab.Location.Y);
                    if (Width > Height)
                    {
                        ResPictureBox.Width = 150;
                        ResPictureBox.Location = new Point(Width - 170, FailCountLab.Location.Y);
                        ResPictureBox.Height = TestDutTable.Location.Y - 35;
                    }
                }
                DevCheckedInfo.Size = new Size(TestDutTable.Width / 3, TestDutTable.Height - 30);
                DevCheckedInfo.Location = new Point(5, 5);

                TestLog.Size = new Size(TestDutTable.Width * 2 / 3 - 25, TestDutTable.Height - 45);
                TestLog.Location = new Point(DevCheckedInfo.Location.X + DevCheckedInfo.Width + 5, 5);
            }
            UpLimit.Visible = true;
            LowLimit.Visible = true;
            UpLimit.Visible = UpLimit.Width < 50 ? false : true;
            LowLimit.Visible = UpLimit.Width < 50 ? false : true;
            Invalidate();
        }
        private void TestDutTable_SelectedIndexChanged(object sender, EventArgs e)//切换页面时调用
        {
            FormSizeChange();
        }
        private void SnText_TextChanged(object sender, EventArgs e)//此控件文本变更时启动测试
        {
            if (!Dut.TestFlag && !TestWorker.IsBusy)
            {
                TestWorker.RunWorkerAsync();
                DutLogMsg(Dut.DutNumber + ":开始测试");
            }
            else
            {
                DutLogMsg(Dut.DutNumber + ":测试中，请等待");
            }
        }
        private void TestDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TestDataGridView.ClearSelection();
            }
        }
        private void UpdateDgv() //更新测试数据显示控件内容
        {
            if (TestDataGridView.Rows.Count != TestItem.Count)
            {
                TestDataGridView.Rows.Clear();
                for (int i = 0; i < TestItem.Count; i++)
                {
                    TestDataGridView.Rows.Add();
                }
            }
            for (int i = 0; i < TestItem.Count; i++)
            {
                TestDataGridView.Rows[i].Cells[TestNumber.Index].Value = TestItem[i].Number + 1;
                TestDataGridView.Rows[i].Cells[TestName.Index].Value = TestItem[i].Name;
                TestDataGridView.Rows[i].Cells[UpLimit.Index].Value = TestItem[i].UpLimit;
                TestDataGridView.Rows[i].Cells[Value.Index].Value = TestItem[i].Value;
                TestDataGridView.Rows[i].Cells[LowLimit.Index].Value = TestItem[i].LowLimit;
                TestDataGridView.Rows[i].Cells[Result.Index].Value = TestItem[i].Result;
                if (TestDataGridView.Rows[i].Cells[Result.Index].Value == null ||
                    TestDataGridView.Rows[i].Cells[Result.Index].Value.ToString() == string.Empty)
                {
                    TestDataGridView.Rows[i].Cells[4].Style.BackColor = Color.White;
                }
                else if (TestDataGridView.Rows[i].Cells[Result.Index].Value.ToString() == "Pass")
                {
                    TestDataGridView.Rows[i].Cells[Result.Index].Style.BackColor = Color.Lime;
                }
                else if (TestDataGridView.Rows[i].Cells[Result.Index].Value.ToString() == "Fail")
                {
                    TestDataGridView.Rows[i].Cells[Result.Index].Style.BackColor = Color.Red;
                }
            }
            TestDataGridView.ClearSelection();
            Refresh();
        }
        public void DutLogMsg(string msg)
        {
            Invoke(new Action(() =>
            {
                TestLog.AppendText(msg);
                if (msg.Contains("Method:"))
                {
                    MethodsInfoLab.Text = msg.Replace("Method:", "");
                    Refresh();
                }
            }));
        }
        private void TimesUpdate()//测试时动态显示测试时间
        {
            while (true)
            {
                try
                {
                    string strTemp = MethodsInfoLab.Text;
                    if (Dut.timeOut > 5)
                    {
                        double timeout = Dut.timeOut * 1000 / 200;
                        while (timeout > 0 && Dut.timeOut != 0)
                        {
                            timeout--;
                            MethodsInfoLab.Text = strTemp + ((float)timeout / 5).ToString("0.00");
                            TestTimesLab.Text = "Times:" + (stopwatch.Elapsed.TotalMilliseconds / 1000).ToString("0.00") + "s";
                            Thread.Sleep(200);
                        }
                        if (timeout <= 0)
                        {
                            Dut.timeOut = 0;
                        }
                    }
                    TestTimesLab.Text = "Times:" + (stopwatch.Elapsed.TotalMilliseconds / 1000).ToString("0.00") + "s";
                    Thread.Sleep(200);
                }
                catch (Exception)
                {

                }
            }
        }
        public bool systemInit()//测试开始时初始化外部设备并等待产品连接
        {
            for (int i = 0; i < TestItem.Count; i++)
            {
                TestItem[i].Value = "";
                TestItem[i].Result = "";
            }
            Dut.LogMsg("Method:" + "系统初始化");
            Dut.Result = "";
            Dut.Errcode = "";
            Dut.TestData = "";
            Dut.timeOut = 0;
            Dut.BarCode = "";

            TestLog.Clear();
            UpdateDgv();
            SetKeyStatus();
            ResPictureBox.Image = Resources.Waiting;
            Dut.TestFlag = true;
            return true;
        }
        private void SetKeyStatus() //设置条码输入窗口和启动键的状态
        {
            if (Dut.TestFlag)
            {
                TestButton.Enabled = false;
                SnText.Enabled = false;
            }
            else
            {
                if (SysSetup.System.KeyStartFlag)
                {
                    TestButton.Enabled = true;
                }
                else
                {
                    TestButton.Enabled = false;
                }
            }
        }
        private void TestProcess(object sender, DoWorkEventArgs e)//测试线程
        {
            do
            {
                if (!systemInit())
                {
                    return;
                }
                else
                {
                    Dut.BarCode = SnLab.Text;
                    ResPictureBox.Image = Resources.Testing;
                    Dut.TestFlag = false;
                }
                stopwatch.Reset();
                stopwatch.Start();
                string LogdataTemp = "";
                for (int i = 0; i < TestItem.Count; i++)
                {
                    int retest = TestItem[i].RetestTimes;
                    while (0 < retest--)
                    {
                        if (SysSetup.Method.Keys.Contains(TestItem[i].Method))
                        {
                            if (SysSetup.Method[TestItem[i].Method](TestItem[i], Dut))
                            {
                                TestItem[i].Result = "Pass";
                                break;
                            }
                            else
                            {
                                TestItem[i].Result = "Fail";
                            }
                        }
                        Thread.Sleep(50);
                    }
                    LogdataTemp += TestItem.ElementAt(i).Value + ",";
                    Dut.TestData += TestItem.ElementAt(i).Name + "=" + TestItem.ElementAt(i).Value + "#";
                    UpdateDgv();
                    if (TestItem.ElementAt(i).Result.Equals("Fail"))
                    {
                        Dut.Result = "Fail";
                        Dut.Errcode = TestItem.ElementAt(i).ErrCode;
                        if (SysSetup.System.FailStopFlag)
                        {
                            break;
                        }
                    }
                    TestDataGridView.FirstDisplayedScrollingRowIndex = i - 7 > 0 ? i - 7 : 0;
                    TestProgressBar.Value = (i + 1) * TestProgressBar.Maximum / TestItem.Count;
                    Refresh();
                }
                stopwatch.Stop();
                string resTemp = (stopwatch.Elapsed.TotalMilliseconds / 1000).ToString("0.00");
                TestFinish(resTemp, LogdataTemp);
            } while (SysSetup.System.LoopTestFlag);
        }
        private void TestFinish(string resTemp, string LogdataTemp)//测试完保存相关数据及释放对应资源
        {
            if (Dut.Result == "")
            {
                Dut.Result = "Pass";
                Dut.PassCount = Dut.PassCount + 1;
                PassCountLab.Text = "Pass: " + Dut.PassCount;
                ResPictureBox.Image = Resources.Pass;
            }
            else
            {
                Dut.Result = "Fail";
                Dut.FailCount = Dut.FailCount + 1;
                FailCountLab.Text = "Fail: " + Dut.FailCount;
                ResPictureBox.Image = Resources.Fail;
            }

            resTemp += "," + DateTime.Now.ToLocalTime() + ",";
            resTemp += Dut.Errcode + ",";
            resTemp += Dut.Result + ",";
            resTemp += LogdataTemp + ",";
            SaveLog log = new SaveLog(Dut.LogMsg);
            string filename = Dut.BarCode;
            if (SysSetup.System.SaveInfoFlag)
            {
                log.SaveSWrunLogFile(Dut.Result + filename, TestLog.Text);
                //log.SaveTestLogFile(dutInfo, resTemp);
            }
            log.SaveTestData(Dut, resTemp);
            Dut.TestFlag = false;
            SetKeyStatus();
            //UpdateMainInfo();
        }
        private void TestForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
    }
}
