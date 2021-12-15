using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    partial class SetDutInfo : Form
    {
        private DutInfo dutInfo;
        public List<DeviceInfo> SerialDevice;
        public List<DeviceInfo> NetDevice;
        public List<DeviceInfo> USBDevice;
        public SetDutInfo(DutInfo _dutInfo)
        {
            InitializeComponent();
            this.TopLevel = false;
            dutInfo = _dutInfo;

            Pass.Text = dutInfo.PassCount.ToString();
            Fail.Text = dutInfo.FailCount.ToString();
            //以下代码区分出不同种类的设备，及数量
            SerialDevice = new List<DeviceInfo>();
            NetDevice = new List<DeviceInfo>();
            USBDevice = new List<DeviceInfo>();
            DistinguishDevice();
        }
        public void DistinguishDevice()//区分不同设备并显示到相对应的表格内
        {
            SerialDevice.Clear();
            NetDevice.Clear();
            USBDevice.Clear();
            for (int i = 0; i < dutInfo.DeviceInfo.Count; i++)
            {
                switch (dutInfo.DeviceInfo[i].DevType)
                {
                    case "Serial": SerialDevice.Add(dutInfo.DeviceInfo[i]); break;
                    case "Net": NetDevice.Add(dutInfo.DeviceInfo[i]); break;
                    case "USB": USBDevice.Add(dutInfo.DeviceInfo[i]); break;
                }
            }
            DgvAddParamColum(DutSerialDevDgv, SerialDevice);
            DgvAddParamColum(DutNetDevDgv, NetDevice);
            DgvAddParamColum(DutUsbDevDgv, USBDevice);

            SetDgvVal(DutSerialDevDgv.Rows, SerialDevice);
            SetDgvVal(DutNetDevDgv.Rows, NetDevice);
            SetDgvVal(DutUsbDevDgv.Rows, USBDevice);

            DutSerialDevDgv.ClearSelection();
            DutNetDevDgv.ClearSelection();
            DutUsbDevDgv.ClearSelection();
            Invalidate();
        }
        private void SetDutInfo_Paint(object sender, PaintEventArgs e)//Dut配置页面窗口重绘
        {
            DutSerialDevDgv.Height = (Size.Height - 110) / 3;
            DutSerialDevDgv.Width = (int)((Size.Width - 10) * 1.9 / 3);

            DutNetDevDgv.Height = (Size.Height - 110) / 3;
            DutNetDevDgv.Width = (int)((Size.Width - 10) * 1.9 / 3);
            DutNetDevDgv.Location = new Point(DutNetDevDgv.Location.X, DutSerialDevDgv.Location.Y + DutSerialDevDgv.Height + 11);

            DutUsbDevDgv.Height = (Size.Height - 100) / 3;
            DutUsbDevDgv.Width = (int)((Size.Width - 10) * 1.9 / 3);
            DutUsbDevDgv.Location = new Point(DutNetDevDgv.Location.X, DutNetDevDgv.Location.Y + DutNetDevDgv.Height + 11);

            InitItemTbc.Height = this.Size.Height - 80;
            InitItemTbc.Width = this.Size.Width - DutSerialDevDgv.Width - 10;
            InitItemTbc.Location = new Point(DutSerialDevDgv.Location.X + DutSerialDevDgv.Width + 5, InitItemTbc.Location.Y);
            for (int i = 0; i < InitItemTbc.TabPages.Count; i++)
            {
                InitItemTbc.TabPages[i].Size = new Size(InitItemTbc.Width, InitItemTbc.Height - 5);
                InitItemTbc.TabPages[i].Controls[0].Size = new Size(InitItemTbc.Width - 10, InitItemTbc.Height - 10);
            }
        }

        private void DgvAddParamColum(DataGridView Dgv, List<DeviceInfo> Dev)//确认参数列数目,根据参数列数目动态增加参数列
        {
            if (Dgv.ColumnCount > 8)//确认设备控件窗口列是否有参数列，有就删除
            {
                for (int i = 8; i < Dgv.ColumnCount; i++)
                {
                    Dgv.Columns.RemoveAt(i);
                }
            }
            int ParamColum = 0;
            for (int i = 0; i < Dev.Count; i++)//确认所有设备参数列的最大数量
            {
                if (ParamColum < Dev[i].DevParam.Count)
                {
                    ParamColum = Dev[i].DevParam.Count;
                }
            }
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            for (int i = 0; i < ParamColum; i++)//设备控件窗口增加按最大数量增加参数列
            {
                DataGridViewTextBoxColumn Param = new DataGridViewTextBoxColumn();
                Param.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Param.DefaultCellStyle = dataGridViewCellStyle2;
                Param.HeaderText = nameof(DeviceInfo.DevParam) + (i + 1);
                Param.Name = nameof(DeviceInfo.DevParam) + (i + 1);
                Param.ReadOnly = false;
                Param.SortMode = DataGridViewColumnSortMode.NotSortable;
                Param.Width = 53;
                Dgv.Columns.Add(Param);
            }
            for (int i = 0; i < Dev.Count; i++)//所有设备增加按最多参数列进行增加
            {
                if (Dev[i].DevParam.Count < ParamColum)
                {
                    for (int j = 0; j < (ParamColum - Dev[i].DevParam.Count); j++)
                    {
                        Dev[i].DevParam.Add("");
                    }
                }
            }
            Dgv.ClearSelection();
        }
        private void SetDgvVal(DataGridViewRowCollection row, List<DeviceInfo> Dev)//将设备配置信息显示到窗口控件
        {
            row.Clear();
            for (int i = 0; i < Dev.Count; i++)
            {
                row.Add();
                row[i].Cells[0].Value = Dev[i].DevType;
                row[i].Cells[1].Value = (i+1);
                row[i].Cells[2].Value = Dev[i].DevName;
                row[i].Cells[3].Value = Dev[i].CmdType;
                row[i].Cells[4].Value = Dev[i].CmdSendHead;
                row[i].Cells[5].Value = Dev[i].CmdSendTail;
                row[i].Cells[6].Value = Dev[i].CmdRecHead;
                row[i].Cells[7].Value = Dev[i].CmdRecTail;
                for (int j = 0; j < Dev[i].DevParam.Count; j++)
                {
                    row[i].Cells[j + 8].Value = Dev[i].DevParam[j];
                }
            }
        }

        private void AddDevice_Click(object sender, EventArgs e)//增加设备按键事件
        {
            string DevType = "";
            switch (DevRightMenu.SourceControl.Name)
            {
                case nameof(DutNetDevDgv): DevType = "Net"; break;
                case nameof(DutUsbDevDgv): DevType = "USB"; break;
                default: DevType = "Serial"; break;
            }
            if (this.Parent.Text == "Main窗口")
            {
                DeviceInfo infotemp = new DeviceInfo();
                infotemp.DevType = DevType;
                SysSetup.System.DeviceInfo.Add(infotemp);
            }
            else
            {
                for (int i = 0; i < SysSetup.Dut.Count; i++)
                {
                    DeviceInfo infotemp = new DeviceInfo();
                    infotemp.DevType = DevType;
                    SysSetup.Dut[i].DeviceInfo.Add(infotemp);
                    infotemp.DevNumber = SysSetup.Dut[i].DeviceInfo.Count;
                }
            }
            DistinguishDevice();
            Invalidate();
        }
        private void DeleteDevice_Click(object sender, EventArgs e)//删除设备按键事件
        {
            string DevType = "";
            switch (DevRightMenu.SourceControl.Name)
            {
                case nameof(DutNetDevDgv): DevType = "Net"; break;
                case nameof(DutUsbDevDgv): DevType = "USB"; break;
                default: DevType = "Serial"; break;
            }
            if (this.Parent.Text == "Main窗口")
            {
                int index = SysSetup.System.DeviceInfo.FindLastIndex((DeviceInfo s) => s.DevType == DevType);
                SysSetup.System.DeviceInfo.RemoveAt(index);
            }
            else
            {
                for (int i = 0; i < SysSetup.Dut.Count; i++)
                {
                    int index = SysSetup.Dut[i].DeviceInfo.FindLastIndex((DeviceInfo s) => s.DevType == DevType);
                    if (index >= 0)
                    {
                        SysSetup.Dut[i].DeviceInfo.RemoveAt(index);
                    }
                }
            }
            DistinguishDevice();
            Invalidate();
        }
        private void DeviceAddParam_Click(object sender, EventArgs e)//增加参数按键事件
        {
            string DevType = "";
            switch (DevRightMenu.SourceControl.Name)
            {
                case nameof(DutNetDevDgv): DevType = "Net"; break;
                case nameof(DutUsbDevDgv): DevType = "USB"; break;
                default: DevType = "Serial"; break;
            }
            if (this.Parent.Text == "Main窗口")
            {
                for (int i = 0; i < SysSetup.System.DeviceInfo.Count; i++)
                {
                    if (SysSetup.System.DeviceInfo[i].DevType == DevType)
                    {
                        SysSetup.System.DeviceInfo[i].DevParam.Add("");
                    }
                }
            }
            else
            {
                for (int i = 0; i < SysSetup.Dut.Count; i++)
                {
                    for (int j = 0; j < SysSetup.Dut[i].DeviceInfo.Count; j++)
                    {
                        if (SysSetup.Dut[i].DeviceInfo[j].DevType == DevType)
                        {
                            SysSetup.Dut[i].DeviceInfo[j].DevParam.Add("");
                        }
                    }
                }
            }
            DistinguishDevice();
            Invalidate();
        }
        private void DeviceDeleteParam_Click(object sender, EventArgs e)//删除参数按键事件
        {
            string DevType = "";
            switch (DevRightMenu.SourceControl.Name)
            {
                case nameof(DutNetDevDgv): DevType = "Net"; break;
                case nameof(DutUsbDevDgv): DevType = "USB"; break;
                default: DevType = "Serial"; break;
            }
            if (this.Parent.Text == "Main窗口")
            {
                for (int i = 0; i < SysSetup.System.DeviceInfo.Count; i++)
                {
                    if (SysSetup.System.DeviceInfo[i].DevType == DevType)
                    {
                        if (SysSetup.System.DeviceInfo[i].DevParam.Count > 0)
                        {
                            SysSetup.System.DeviceInfo[i].DevParam.RemoveAt(SysSetup.System.DeviceInfo[i].DevParam.Count - 1);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < SysSetup.Dut.Count; i++)
                {
                    for (int j = 0; j < SysSetup.Dut[i].DeviceInfo.Count; j++)
                    {
                        if (SysSetup.Dut[i].DeviceInfo[j].DevType == DevType)
                        {
                            if (SysSetup.Dut[i].DeviceInfo[j].DevParam.Count > 0)
                            {
                                SysSetup.Dut[i].DeviceInfo[j].DevParam.RemoveAt(SysSetup.Dut[i].DeviceInfo[j].DevParam.Count - 1);
                            }
                        }
                    }
                }
            }
            DistinguishDevice();
            Invalidate();










            DataGridView DgvTemp = null;
            List<DeviceInfo> DevTemp = null;
            switch (DevRightMenu.SourceControl.Name)
            {
                //case nameof(DutSerialDevDgv): break;
                case nameof(DutNetDevDgv): DgvTemp = DutNetDevDgv; DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DgvTemp = DutUsbDevDgv; DevTemp = USBDevice; break;
                default: DgvTemp = DutSerialDevDgv; DevTemp = SerialDevice; break;
            }
            if (DgvTemp.CurrentCell != null)
            {
                int RowIndex = DgvTemp.CurrentCell.RowIndex;
                int ColumnIndex = DgvTemp.CurrentCell.ColumnIndex;
                for (int i = 0; i < DevTemp.Count; i++)
                {
                    if (DevTemp[i].DevParam.Count != 0)
                    {
                        DevTemp[i].DevParam.RemoveAt(DevTemp[i].DevParam.Count - 1);
                    }
                }
                DgvAddParamColum(DutSerialDevDgv, SerialDevice);
                SetDgvVal(DgvTemp.Rows, DevTemp);
                DgvTemp.CurrentCell = DgvTemp.Rows[RowIndex].Cells[ColumnIndex];
                DgvTemp.Focus();
                Invalidate();
            }
        }
        private void SwapDeviceInfo(DeviceInfo Dev1, DeviceInfo Dev2)
        {
            DeviceInfo temp = new DeviceInfo();
            temp.DevType = Dev1.DevType;
            temp.DevNumber = Dev1.DevNumber;
            temp.DevName = Dev1.DevName;
            temp.CmdType = Dev1.CmdType;
            temp.CmdSendHead = Dev1.CmdSendHead;
            temp.CmdSendTail = Dev1.CmdSendTail;
            temp.CmdRecHead = Dev1.CmdRecHead;
            temp.CmdRecTail = Dev1.CmdRecTail;
            for (int i = 0; i < Dev1.DevParam.Count; i++)
            {
                temp.DevParam.Add(Dev1.DevParam[i]);
            }

            for (int i = 0; i < Dev1.CmdItem.Count; i++)
            {
                CmdInfo info = new CmdInfo();
                info.Cmd = Dev1.CmdItem[i].Cmd;
                info.CmdTimeOut = Dev1.CmdItem[i].CmdTimeOut;
                for (int j = 0; j < Dev1.CmdItem[i].CmdPram.Count; j++)
                {
                    info.CmdPram.Add(Dev1.CmdItem[i].CmdPram[j]);
                }
                for (int j = 0; j < Dev1.CmdItem[i].CmdRecdata.Count; j++)
                {
                    info.CmdRecdata.Add(Dev1.CmdItem[i].CmdRecdata[j]);
                }
                temp.CmdItem.Add(info);
            }

            Dev1.DevType = Dev2.DevType;
            Dev1.DevNumber = Dev2.DevNumber;
            Dev1.DevName = Dev2.DevName;
            Dev1.CmdType = Dev2.CmdType;
            Dev1.CmdSendHead = Dev2.CmdSendHead;
            Dev1.CmdSendTail = Dev2.CmdSendTail;
            Dev1.CmdRecHead = Dev2.CmdRecHead;
            Dev1.CmdRecTail = Dev2.CmdRecTail;
            Dev1.DevParam.Clear();
            for (int i = 0; i < Dev2.DevParam.Count; i++)
            {
                Dev1.DevParam.Add(Dev2.DevParam[i]);
            }
            Dev1.CmdItem.Clear();
            for (int i = 0; i < Dev2.CmdItem.Count; i++)
            {
                CmdInfo info = new CmdInfo();
                info.Cmd = Dev2.CmdItem[i].Cmd;
                info.CmdTimeOut = Dev2.CmdItem[i].CmdTimeOut;
                for (int j = 0; j < Dev2.CmdItem[i].CmdPram.Count; j++)
                {
                    info.CmdPram.Add(Dev2.CmdItem[i].CmdPram[j]);
                }
                for (int j = 0; j < Dev2.CmdItem[i].CmdRecdata.Count; j++)
                {
                    info.CmdRecdata.Add(Dev2.CmdItem[i].CmdRecdata[j]);
                }
                Dev1.CmdItem.Add(info);
            }
            Dev2.DevType = temp.DevType;
            Dev2.DevNumber = temp.DevNumber;
            Dev2.DevName = temp.DevName;
            Dev2.CmdType = temp.CmdType;
            Dev2.CmdSendHead = temp.CmdSendHead;
            Dev2.CmdSendTail = temp.CmdSendTail;
            Dev2.CmdRecHead = temp.CmdRecHead;
            Dev2.CmdRecTail = temp.CmdRecTail;
            Dev2.DevParam.Clear();
            for (int i = 0; i < temp.DevParam.Count; i++)
            {
                Dev2.DevParam.Add(temp.DevParam[i]);
            }
            Dev2.CmdItem.Clear();
            for (int i = 0; i < temp.CmdItem.Count; i++)
            {
                CmdInfo info = new CmdInfo();
                info.Cmd = temp.CmdItem[i].Cmd;
                info.CmdTimeOut = temp.CmdItem[i].CmdTimeOut;
                for (int j = 0; j < temp.CmdItem[i].CmdPram.Count; j++)
                {
                    info.CmdPram.Add(temp.CmdItem[i].CmdPram[j]);
                }
                for (int j = 0; j < temp.CmdItem[i].CmdRecdata.Count; j++)
                {
                    info.CmdRecdata.Add(temp.CmdItem[i].CmdRecdata[j]);
                }
                Dev2.CmdItem.Add(info);
            }
        }

        private void AddInitItem_Click(object sender, EventArgs e)//增加初始化信息项目并更新TabControl的显示
        {
            DataGridView DgvTemp = null;
            List<DeviceInfo> DevTemp = null;
            switch (DevRightMenu.SourceControl.Name)
            {
                //case nameof(DutSerialDevDgv): break;
                case nameof(DutNetDevDgv): DgvTemp = DutNetDevDgv; DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DgvTemp = DutUsbDevDgv; DevTemp = USBDevice; break;
                default: DgvTemp = DutSerialDevDgv; DevTemp = SerialDevice; break;
            }
            if (DgvTemp.CurrentCell != null)
            {
                List<CmdInfo> CmdItemTemp = DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem;
                CmdInfo CmdTemp = new CmdInfo();
                if (CmdItemTemp.Count > 0)
                {
                    int index = InitItemTbc.SelectedIndex;
                    CmdItemTemp.Insert(index, CmdTemp);
                }
                else
                {
                    CmdItemTemp.Add(CmdTemp);
                }
                InitItemTbc.TabPages.Clear();
                for (int i = 0; i < CmdItemTemp.Count; i++)
                {
                    TabPage page = new TabPage();
                    page.Text = "Item" + (i + 1);
                    SetCmdInfo item = new SetCmdInfo(false, CmdItemTemp[i]);
                    item.Show();
                    page.Controls.Add(item);
                    InitItemTbc.TabPages.Add(page);
                }
                Invalidate();
                DgvTemp.Focus();
            }
        }
        private void DeleteInitItem_Click(object sender, EventArgs e)//删除初始化信息项目并更新TabControl的显示
        {
            DataGridView DgvTemp = null;
            List<DeviceInfo> DevTemp = null;
            switch (DevRightMenu.SourceControl.Name)
            {
                //case nameof(DutSerialDevDgv): break;
                case nameof(DutNetDevDgv): DgvTemp = DutNetDevDgv; DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DgvTemp = DutUsbDevDgv; DevTemp = USBDevice; break;
                default: DgvTemp = DutSerialDevDgv; DevTemp = SerialDevice; break;
            }
            if (DgvTemp.CurrentCell != null && InitItemTbc.SelectedIndex >= 0)
            {
                if (DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem.Count - 1 >= InitItemTbc.SelectedIndex &&
                    InitItemTbc.SelectedIndex >= 0)
                {
                    InitItemTbc.TabPages.RemoveAt(InitItemTbc.SelectedIndex);
                    DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem.RemoveAt(InitItemTbc.SelectedIndex);
                }
                for (int i = 0; i < InitItemTbc.TabPages.Count; i++)
                {
                    InitItemTbc.TabPages[i].Text = "Item" + (i + 1);
                }
                DgvTemp.Focus();
            }
            Invalidate();
        }
        private void InitItemPrevious_Click(object sender, EventArgs e)//发送初始化信息项目前移并更新TabControl的显示
        {
            DataGridView DgvTemp = null;
            List<DeviceInfo> DevTemp = null;
            switch (DevRightMenu.SourceControl.Name)
            {
                //case nameof(DutSerialDevDgv): break;
                case nameof(DutNetDevDgv): DgvTemp = DutNetDevDgv; DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DgvTemp = DutUsbDevDgv; DevTemp = USBDevice; break;
                default: DgvTemp = DutSerialDevDgv; DevTemp = SerialDevice; break;
            }
            if (DgvTemp.CurrentCell != null)
            {
                int DevDgvRow = DgvTemp.CurrentCell.RowIndex;
                if (DevTemp[DevDgvRow].CmdItem.Count > 2)
                {
                    if (InitItemTbc.SelectedIndex > 1)
                    {
                        TabPage pagetemp = new TabPage();
                        pagetemp = InitItemTbc.TabPages[InitItemTbc.SelectedIndex - 1];
                        InitItemTbc.TabPages[InitItemTbc.SelectedIndex - 1] = InitItemTbc.TabPages[InitItemTbc.SelectedIndex];
                        InitItemTbc.TabPages[InitItemTbc.SelectedIndex] = pagetemp;
                    }
                    for (int i = 0; i < InitItemTbc.TabPages.Count; i++)
                    {
                        InitItemTbc.TabPages[i].Text = "Item" + (i + 1);
                    }
                }
                InitItemTbc.SelectedIndex = InitItemTbc.SelectedIndex - 1;
                DgvTemp.Focus();
            }
        }
        private void InitItemNext_Click(object sender, EventArgs e)//发送初始化信息项目后移并更新TabControl的显示
        {
            DataGridView DgvTemp = null;
            List<DeviceInfo> DevTemp = null;
            switch (DevRightMenu.SourceControl.Name)
            {
                //case nameof(DutSerialDevDgv): break;
                case nameof(DutNetDevDgv): DgvTemp = DutNetDevDgv; DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DgvTemp = DutUsbDevDgv; DevTemp = USBDevice; break;
                default: DgvTemp = DutSerialDevDgv; DevTemp = SerialDevice; break;
            }
            if (DgvTemp.CurrentCell != null)
            {
                int DevDgvRow = DgvTemp.CurrentCell.RowIndex;
                if (DevTemp[DevDgvRow].CmdItem.Count > 2)
                {
                    if (InitItemTbc.SelectedIndex < InitItemTbc.TabPages.Count)
                    {
                        TabPage pagetemp = new TabPage();
                        pagetemp = InitItemTbc.TabPages[InitItemTbc.SelectedIndex + 1];
                        InitItemTbc.TabPages[InitItemTbc.SelectedIndex + 1] = InitItemTbc.TabPages[InitItemTbc.SelectedIndex];
                        InitItemTbc.TabPages[InitItemTbc.SelectedIndex] = pagetemp;
                    }
                    for (int i = 0; i < InitItemTbc.TabPages.Count; i++)
                    {
                        InitItemTbc.TabPages[i].Text = "Item" + (i + 1);
                    }
                }
                InitItemTbc.SelectedIndex = InitItemTbc.SelectedIndex + 1;
                DgvTemp.Focus();
            }
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            int Number = 0;
            if (int.TryParse(Pass.Text, out Number))
            {
                dutInfo.PassCount = Number;
            }
            else
            {
                MessageBox.Show("请输入数字!");
            }
        }
        private void Fail_TextChanged(object sender, EventArgs e)
        {
            int Number = 0;
            if (int.TryParse(Pass.Text, out Number))
            {
                dutInfo.FailCount = Number;
            }
            else
            {
                MessageBox.Show("请输入数字!");
            }
        }

        private void DutSerialDevDgv_CellDataUpdate(object sender, DataGridViewCellEventArgs e)//单元格失去焦点时将控件数据保存到变量
        {
            DutSerialDevDgv.CellDoubleClick -= new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellClick -= new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellEndEdit -= new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellEnter -= new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellLeave -= new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            if (DutSerialDevDgv.CurrentCell != null)
            {
                DutDevDgv_CellEnter(DutSerialDevDgv, SerialDevice);
                DutNetDevDgv.ClearSelection();
                DutUsbDevDgv.ClearSelection();
            }
            DutSerialDevDgv.CellDoubleClick += new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellClick += new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellEndEdit += new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellEnter += new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
            DutSerialDevDgv.CellLeave += new DataGridViewCellEventHandler(DutSerialDevDgv_CellDataUpdate);
        }
        private void DutNetDevDgv_CellDataUpdate(object sender, DataGridViewCellEventArgs e)//单元格失去焦点时将控件数据保存到变量
        {
            DutNetDevDgv.CellDoubleClick -= new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellClick -= new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellEndEdit -= new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellEnter -= new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellLeave -= new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            if (DutNetDevDgv.CurrentCell != null)
            {
                DutDevDgv_CellEnter(DutNetDevDgv, NetDevice);
                DutSerialDevDgv.ClearSelection();
                DutUsbDevDgv.ClearSelection();
            }
            DutNetDevDgv.CellDoubleClick += new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellClick += new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellEndEdit += new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellEnter += new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
            DutNetDevDgv.CellLeave += new DataGridViewCellEventHandler(DutNetDevDgv_CellDataUpdate);
        }
        private void DutUsbDevDgv_CellDataUpdate(object sender, DataGridViewCellEventArgs e)//单元格失去焦点时将控件数据保存到变量
        {
            DutUsbDevDgv.CellDoubleClick -= new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellClick -= new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellEndEdit -= new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellEnter -= new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellLeave -= new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            if (DutUsbDevDgv.CurrentCell != null)
            {
                DutDevDgv_CellEnter(DutUsbDevDgv, USBDevice);
                DutSerialDevDgv.ClearSelection();
                DutNetDevDgv.ClearSelection();
            }
            DutUsbDevDgv.CellDoubleClick += new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellClick += new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellEndEdit += new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellEnter += new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
            DutUsbDevDgv.CellLeave += new DataGridViewCellEventHandler(DutUsbDevDgv_CellDataUpdate);
        }
        private void DutDevDgv_CellEnter(DataGridView DgvTemp, List<DeviceInfo> DevTemp)//根据单元格行做标得到设备编号,将指令的配置信息显示对应到指令控件窗口
        {
            if (DgvTemp.CurrentCell != null)
            {
                if (DgvTemp.CurrentCell.ColumnIndex == 0|| DgvTemp.CurrentCell.ColumnIndex == 1)
                {
                    DgvTemp.ClearSelection();
                }
                else
                {
                    if (DgvTemp.CurrentCell.RowIndex >= 0)
                    {
                        UpdateSysInfo(DgvTemp, DgvTemp.CurrentCell.RowIndex, DgvTemp.CurrentCell.ColumnIndex);
                        InitItemTbc.TabPages.Clear();
                        for (int i = 0; i < DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem.Count; i++)
                        {
                            DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem[i].DevType = DevTemp[DgvTemp.CurrentCell.RowIndex].DevType;
                            DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem[i].DevNumber = DevTemp[DgvTemp.CurrentCell.RowIndex].DevNumber;
                            DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem[i].CmdType = DevTemp[DgvTemp.CurrentCell.RowIndex].CmdType;
                            TabPage page = new TabPage();
                            page.Text = "Item" + (i + 1);
                            SetCmdInfo item = new SetCmdInfo(false, DevTemp[DgvTemp.CurrentCell.RowIndex].CmdItem[i]);
                            item.Show();
                            page.Controls.Add(item);
                            InitItemTbc.TabPages.Add(page);
                        }
                    }
                    else
                    {
                        InitItemTbc.TabPages.Clear();
                    }
                    //Invalidate();
                }
            }
        }
        private void UpdateSysInfo(DataGridView DgvTemp, int row, int column)//根据单元格的设定将数据更新到设备变量
        {

            List<DeviceInfo> DevTemp = new List<DeviceInfo>();
            switch (DgvTemp.Name)
            {
                case nameof(DutSerialDevDgv): DevTemp = SerialDevice; break;
                case nameof(DutNetDevDgv): DevTemp = NetDevice; break;
                case nameof(DutUsbDevDgv): DevTemp = USBDevice; break;
            }
            if (DgvTemp.Rows != null && DevTemp.Count > row)
            {

                switch (column)
                {
                    case 0:
                        DevTemp[row].DevType = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString();
                        for (int i = 0; i < DevTemp[row].CmdItem.Count; i++)
                        {
                            DevTemp[row].CmdItem[i].DevType = DevTemp[row].DevType;
                        }
                        break;
                    case 1:
                        int Number = 0;
                        string NumberStr = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString();
                        if (int.TryParse(NumberStr, out Number))
                        {
                            DevTemp[row].DevNumber = Number;
                        }
                        for (int i = 0; i < DevTemp[row].CmdItem.Count; i++)
                        {
                            DevTemp[row].CmdItem[i].DevNumber = DevTemp[row].DevNumber;
                        }
                        break;
                    case 2: DevTemp[row].DevName = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); break;
                    case 3:
                        DevTemp[row].CmdType = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString();
                        for (int i = 0; i < DevTemp[row].CmdItem.Count; i++)
                        {
                            DevTemp[row].CmdItem[i].CmdType = DevTemp[row].CmdType;
                        }
                        break;
                    case 4: DevTemp[row].CmdSendHead = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); break;
                    case 5: DevTemp[row].CmdSendTail = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); break;
                    case 6: DevTemp[row].CmdRecHead = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); break;
                    case 7: DevTemp[row].CmdRecTail = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); break;
                    default:
                        DevTemp[row].DevParam[column - 8] = DgvTemp.Rows[row].Cells[column].Value == null ? "" : DgvTemp.Rows[row].Cells[column].Value.ToString(); ;
                        break;
                }
            }
            //Invalidate();
        }
    }
}
