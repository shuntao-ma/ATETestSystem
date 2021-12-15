using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace ATETestSystem
{
    partial class SetMainForm : Form
    {
        private string PathTemp;
        private List<SetDutInfo> SetDutForm;

        #region 系统配置信息页面
        private void SysInfoValuComBox(DataGridView dg, string name, int val)//设置单元格为Combox,并将系统设置数据显示到单元格内
        {
            DataGridViewComboBoxCell Cb = new DataGridViewComboBoxCell();
            Cb.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //if (SysSetup.Dut.Count>1)
            //{
            //    Cb.Items.AddRange(new object[]{ "1","2"});
            //}
            //else
            //{
            //    Cb.Items.AddRange(new object[] { "1"});
            //}
            for (int i = 0; i < SysSetup.Dut.Count; i++)
            {
                if (i > 3)
                {
                    i = 3;
                }
                Cb.Items.Add((i + 1).ToString());
            }
            dg.Rows.Add();
            dg.Rows[dg.Rows.Count - 1].Cells[SetupSnDgv.Name].Value = dg.Rows.Count;
            dg.Rows[dg.Rows.Count - 1].Cells[1].Value = name;
            dg.Rows[dg.Rows.Count - 1].Cells[2] = Cb;
            dg.Rows[dg.Rows.Count - 1].Cells[2].Value = val.ToString();
            dg.Rows[dg.Rows.Count - 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void SysInfoValuCheckBox(DataGridView dg, string name, bool val)//设置单元格为Ceckbox,并将系统设置数据显示到单元格内
        {
            DataGridViewCheckBoxCell Cb = new DataGridViewCheckBoxCell();
            dg.Rows.Add();
            dg.Rows[dg.Rows.Count - 1].Cells[SetupSnDgv.Name].Value = dg.Rows.Count;
            dg.Rows[dg.Rows.Count - 1].Cells[1].Value = name;
            dg.Rows[dg.Rows.Count - 1].Cells[2] = Cb;
            dg.Rows[dg.Rows.Count - 1].Cells[2].Value = val;
            dg.Rows[dg.Rows.Count - 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void SysInfoPage()//将系统设置的数据显示到表格内
        {
            SysInfoDgv.Rows.Clear();
            SysInfoValuCheckBox(SysInfoDgv, nameof(MesInfo.MesFlag), SysSetup.Mes.MesFlag);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.PartNo), SysSetup.Mes.PartNo);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.Moid), SysSetup.Mes.Moid);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.LineId), SysSetup.Mes.LineId);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.StationId), SysSetup.Mes.StationId);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.ProductGroup), SysSetup.Mes.ProductGroup);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.UserId), SysSetup.Mes.UserId);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.EquipID), SysSetup.Mes.EquipID);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.MesIP), SysSetup.Mes.MesIP);

            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(SysInfo.ProjectName), SysSetup.System.ProjectName);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(MesInfo.StationName), SysSetup.Mes.StationName);
            SysInfoDgv.Rows.Add(SysInfoDgv.Rows.Count + 1, nameof(SysInfo.SN_Sample), SysSetup.System.SN_Sample);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.KeyStartFlag), SysSetup.System.KeyStartFlag);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.ScanStartFlag), SysSetup.System.ScanStartFlag);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.SaveInfoFlag), SysSetup.System.SaveInfoFlag);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.FailStopFlag), SysSetup.System.FailStopFlag);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.LoopTestFlag), SysSetup.System.LoopTestFlag);
            SysInfoValuComBox(SysInfoDgv, nameof(SysInfo.Column), SysSetup.System.Column);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.DutSortMethod), SysSetup.System.DutSortMethod);
            SysInfoValuCheckBox(SysInfoDgv, nameof(SysInfo.AutoAddrFlag), SysSetup.System.AutoAddrFlag);
            SysInfoDgv.Columns[SetupSnDgv.Index].DefaultCellStyle.BackColor = Color.LightGray;
            SysInfoDgv.Columns[SetupNameDgv.Index].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void SysInfoDgv_MouseClick(object sender, MouseEventArgs e)//鼠标右键按下，清除表格选中，checkBox单元格选中，设置单元格的值
        {
            DataGridView dg = (DataGridView)sender;
            string str = dg.Rows[dg.CurrentRow.Index].Cells[SetupNameDgv.Index].Value.ToString();
            if (e.Button == MouseButtons.Right || dg.CurrentCell.ColumnIndex == 0 || dg.CurrentCell.ColumnIndex == 1 ||
                str == nameof(SysSetup.Mes.MesFlag) || str == nameof(SysSetup.System.KeyStartFlag) ||
                str == nameof(SysSetup.System.ScanStartFlag) || str == nameof(SysSetup.System.SaveInfoFlag) ||
                str == nameof(SysSetup.System.FailStopFlag) || str == nameof(SysSetup.System.LoopTestFlag)
                || str == nameof(SysSetup.System.AutoAddrFlag))
            {
                dg.ClearSelection();
                if (str == nameof(SysSetup.Mes.MesFlag) || str == nameof(SysSetup.System.KeyStartFlag) ||
                    str == nameof(SysSetup.System.ScanStartFlag) || str == nameof(SysSetup.System.SaveInfoFlag) ||
                    str == nameof(SysSetup.System.FailStopFlag) || str == nameof(SysSetup.System.LoopTestFlag)
                    || str == nameof(SysSetup.System.AutoAddrFlag))
                {
                    if (dg.CurrentCell.ColumnIndex == 2)
                    {
                        dg.Rows[dg.CurrentRow.Index].Cells[SetupValueDgv.Index].Value = !(bool)dg.Rows[dg.CurrentRow.Index].Cells[SetupValueDgv.Index].EditedFormattedValue;
                    }
                }
            }
            else
            {
                int row = dg.CurrentCell.RowIndex;
                int column = dg.CurrentCell.ColumnIndex;
                dg.CurrentCell.Selected = false;
                if (column > 0)
                {
                    dg.CurrentCell = dg.Rows[row].Cells[column - 1];
                }
                else
                {
                    if (row > 0)
                    {
                        dg.CurrentCell = dg.Rows[row - 1].Cells[column];
                    }
                }
                dg.CurrentCell = dg.Rows[row].Cells[column];
            }
            dg.CurrentCell.Selected = true;
            Invalidate();
        }
        private void SysInfoDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    DataGridViewSelectedCellCollection SelectedCell = ((DataGridView)sender).SelectedCells;
                    foreach (var UPPER in SelectedCell)
                    {
                        DataGridViewTextBoxCell Cell = (DataGridViewTextBoxCell)UPPER;
                        Cell.Value = "";
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        private void SysInfoDgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (e.KeyChar == 22)//22  ctr+V粘贴
            {
                try
                {
                    var idataObject = Clipboard.GetText();
                    int columnCount = dg.ColumnCount - dg.CurrentCell.ColumnIndex;
                    int rowCount = dg.RowCount - dg.CurrentCell.RowIndex;
                    string[] ClipDataRows = idataObject.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (ClipDataRows.Length > rowCount)
                    {
                        MessageBox.Show("剪切板行数据格式错误");
                        return;
                    }
                    List<string[]> ClipDataColumns = new List<string[]>();
                    for (int i = 0; i < ClipDataRows.Length; i++)
                    {
                        ClipDataColumns.Add(ClipDataRows[i].Split(new[] { "\t" }, StringSplitOptions.None));
                        if (ClipDataColumns[i].Length > columnCount)
                        {
                            MessageBox.Show("剪切板列数据格式错误");
                            return;
                        }
                    }
                    for (int i = 0; i < ClipDataRows.Length; i++)
                    {
                        for (int j = 0; j < ClipDataColumns[i].Length; j++)
                        {
                            dg.Rows[dg.CurrentCell.RowIndex + i].Cells[dg.CurrentCell.ColumnIndex + j].Value =
                                ClipDataColumns[i][j];
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        private void SysInfoDgv_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentCell.ColumnIndex == 0 || dg.CurrentCell.ColumnIndex == 1)
            {
                dg.ClearSelection();
            }
        }

        private void SysInfoDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSysInfo(e.RowIndex, e.ColumnIndex);
        }
        private void SysInfoDgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSysInfo(e.RowIndex, e.ColumnIndex);
        }
        private void UpdateSysInfo(int row, int column)
        {
            if (column == 2)
            {
                object cell = SysInfoDgv.Rows[row].Cells[column].Value;
                switch (SysInfoDgv.Rows[row].Cells[1].Value.ToString())
                {
                    case nameof(MesInfo.StationName): SysSetup.Mes.StationName = cell.ToString(); break;
                    case nameof(SysInfo.ProjectName): SysSetup.System.ProjectName = cell.ToString(); break;
                    case nameof(MesInfo.MesFlag): SysSetup.Mes.MesFlag = (bool)cell; break;
                    case nameof(MesInfo.PartNo): SysSetup.Mes.PartNo = cell.ToString(); break;
                    case nameof(MesInfo.Moid): SysSetup.Mes.Moid = cell.ToString(); break;
                    case nameof(MesInfo.LineId): SysSetup.Mes.LineId = cell.ToString(); break;
                    case nameof(MesInfo.StationId): SysSetup.Mes.StationId = cell.ToString(); break;
                    case nameof(MesInfo.ProductGroup): SysSetup.Mes.ProductGroup = cell.ToString(); break;
                    case nameof(MesInfo.UserId): SysSetup.Mes.UserId = cell.ToString(); break;
                    case nameof(MesInfo.EquipID): SysSetup.Mes.EquipID = Convert.ToInt32(cell.ToString()); break;
                    case nameof(MesInfo.MesIP): SysSetup.Mes.MesIP = cell.ToString(); break;
                    case nameof(SysInfo.SN_Sample): SysSetup.System.SN_Sample = cell.ToString(); break;
                    case nameof(SysInfo.KeyStartFlag): SysSetup.System.KeyStartFlag = (bool)cell; break;
                    case nameof(SysInfo.ScanStartFlag): SysSetup.System.ScanStartFlag = (bool)cell; break;
                    case nameof(SysInfo.SaveInfoFlag): SysSetup.System.SaveInfoFlag = (bool)cell; break;
                    case nameof(SysInfo.FailStopFlag): SysSetup.System.FailStopFlag = (bool)cell; break;
                    case nameof(SysInfo.LoopTestFlag): SysSetup.System.LoopTestFlag = (bool)cell; break;
                    case nameof(SysInfo.Column): SysSetup.System.Column = Convert.ToInt32(cell.ToString()); break;
                    case nameof(SysInfo.DutSortMethod): SysSetup.System.DutSortMethod = (bool)cell; break;
                    case nameof(SysInfo.AutoAddrFlag): SysSetup.System.AutoAddrFlag = (bool)cell; break;
                }
            }
            Invalidate();
        }
        #endregion

        #region 设备端口配置页面
        private void DutDevParamPage()
        {
            SetDutForm.Clear();
            DutInfoTbc.Controls.Clear();
            DutInfo MainTemp = new DutInfo() { DeviceInfo = SysSetup.System.DeviceInfo };
            SetDutInfo MainDut = new SetDutInfo(MainTemp);
            MainDut.Show();

            SetDutForm.Add(MainDut);
            TabPage MainPagetemp = new TabPage();
            MainPagetemp.Text = "Main窗口";
            MainPagetemp.Controls.Add(MainDut);
            MainPagetemp.Size = DutInfoTbc.Size;
            DutInfoTbc.TabPages.Add(MainPagetemp);

            for (int i = 0; i < SysSetup.Dut.Count; i++)
            {
                SetDutInfo DutTemp = new SetDutInfo(SysSetup.Dut[i]);
                DutTemp.Show();

                SetDutForm.Add(DutTemp);
                TabPage Pagetemp = new TabPage();
                Pagetemp.Text = "Dut窗口" + (i + 1);
                Pagetemp.Controls.Add(DutTemp);
                Pagetemp.Size = DutInfoTbc.Size;
                DutInfoTbc.TabPages.Add(Pagetemp);
            }
            UpdateDeviceList();
        }
        public void UpdateDeviceList()
        {
            foreach (var item in SysSetup.AllDevice)
            {
                DutInfoDevList.Items.Add(item.Key + " " + item.Value);
            }
        }
        private void AddDutInfo_Click(object sender, EventArgs e)//增加测试窗口
        {
            DutInfo InfoTemp = new DutInfo();
            SysSetup.Dut.Add(InfoTemp);
            SetDutInfo DutTemp = new SetDutInfo(InfoTemp);

            DutTemp.Show();
            DutTemp.Size = DutInfoTbc.Size;
            TabPage Pagetemp = new TabPage();
            Pagetemp.Text = "Dut窗口" + (DutInfoTbc.TabPages.Count);
            Pagetemp.Controls.Add(DutTemp);
            Pagetemp.Size = DutInfoTbc.Size;
            DutInfoTbc.TabPages.Add(Pagetemp);
            SysSetup.System.Column = DutInfoTbc.TabPages.Count - 1;
            for (int i = 1; i < DutInfoTbc.TabPages.Count; i++)
            {
                DutInfoTbc.TabPages[i].Text = "Dut窗口" + i;
            }
            DutInfoTbc.SelectedIndex = DutInfoTbc.TabPages.Count - 1;
            Invalidate();
        }
        private void DeleteDutInfo_Click(object sender, EventArgs e)//删除测试窗口
        {
            if (DutInfoTbc.TabPages.Count == 2)
            {
                return;
            }
            DutInfoTbc.TabPages.RemoveAt(DutInfoTbc.TabPages.Count - 1);
            SysSetup.Dut.RemoveAt(DutInfoTbc.TabPages.Count - 1);
            SysSetup.System.Column = DutInfoTbc.TabPages.Count - 1;
            for (int i = 1; i < DutInfoTbc.TabPages.Count; i++)
            {
                DutInfoTbc.TabPages[i].Text = "Dut窗口" + i;
            }
            DutInfoTbc.SelectedIndex = DutInfoTbc.TabPages.Count - 1;
            Invalidate();
        }
        private void DutInfoTbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int SelectIndex = DutInfoTbc.SelectedIndex;
                if (SelectIndex>=0)
                {
                    SetDutForm[SelectIndex].DistinguishDevice();
                    Invalidate();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }
        #endregion

        #region 测试项目配置页面
        private void SetTestItemPage()
        {
            TestMethodLB.Items.Clear();
            for (int i = 0; i < SysSetup.Method.Count; i++)
            {
                TestMethodLB.Items.Add(SysSetup.Method.ElementAt(i).Key);
            }
            ShowTestItemInfo(0, TestName.Index);
        }
        private void ShowTestItemInfo(int row, int colum)
        {
            TestItemInfoGrop.Controls.Clear();
            TestItemInfoGrop.Controls.Add(TestItemDgv);
            TestItemDgv.Rows.Clear();
            for (int i = 0; i < SysSetup.TestItem.Count; i++)
            {
                TestItemDgv.Rows.Add();
                TestItemDgv.Rows[i].Cells[TestNum.Index].Value = SysSetup.TestItem[i].Number;
                TestItemDgv.Rows[i].Cells[Method.Index].Value = SysSetup.TestItem[i].Method;
                TestItemDgv.Rows[i].Cells[TestName.Index].Value = SysSetup.TestItem[i].Name;
                TestItemDgv.Rows[i].Cells[UpLimit.Index].Value = SysSetup.TestItem[i].UpLimit;
                TestItemDgv.Rows[i].Cells[LowLimit.Index].Value = SysSetup.TestItem[i].LowLimit;
                TestItemDgv.Rows[i].Cells[RetestTimes.Index].Value = SysSetup.TestItem[i].RetestTimes;
                TestItemDgv.Rows[i].Cells[MethodMsg.Index].Value = SysSetup.TestItem[i].MethodMsg;
                TestItemDgv.Rows[i].Cells[ErrCode.Index].Value = SysSetup.TestItem[i].ErrCode;
            }
            if (row >= 0)//选择的测试项目是否有效项目，是 显示设备设置窗口，否 不显示设备设置窗口
            {
                TestItemDgv.CurrentCell = TestItemDgv.Rows[row].Cells[colum];
            }
            else
            {
                TestItemInfoGrop.Controls.RemoveAt(1);
            }
        }
        private void TestItemDgv_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            string str = dg.Rows[dg.CurrentRow.Index].Cells[SetupNameDgv.Index].Value.ToString();
            if (e.Button == MouseButtons.Right || dg.CurrentCell.ColumnIndex == 0 || dg.CurrentCell.ColumnIndex == 1)
            {
                dg.ClearSelection();
            }
            else
            {
                //int row = dg.CurrentCell.RowIndex;
                //int column = dg.CurrentCell.ColumnIndex;
                //dg.CurrentCell.Selected = false;
                //if (column > 0)
                //{
                //    dg.CurrentCell = dg.Rows[row].Cells[column - 1];
                //}
                //else
                //{
                //    if (row > 0)
                //    {
                //        dg.CurrentCell = dg.Rows[row - 1].Cells[column];
                //    }
                //}
                //dg.CurrentCell = dg.Rows[row].Cells[column];
            }
            //dg.CurrentCell.Selected = true;
            Invalidate();
        }
        private void TestItemDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTestItemInfo(e.RowIndex, e.ColumnIndex);
        }
        private void TestItemDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTestItemInfo(e.RowIndex, e.ColumnIndex);
        }
        private void UpdateTestItemInfo(int row, int column)
        {
            if (row >= 0 && column >= 2)
            {
                switch (column)
                {
                    case 0: SysSetup.TestItem[row].Number = Convert.ToInt32(TestItemDgv.Rows[row].Cells[column].Value.ToString()); break;
                    case 1: SysSetup.TestItem[row].Method = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                    case 2: SysSetup.TestItem[row].Name = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                    case 3: SysSetup.TestItem[row].UpLimit = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                    case 4: SysSetup.TestItem[row].LowLimit = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                    case 5: SysSetup.TestItem[row].RetestTimes = Convert.ToInt32(TestItemDgv.Rows[row].Cells[column].Value.ToString()); break;
                    case 6: SysSetup.TestItem[row].MethodMsg = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                    case 7: SysSetup.TestItem[row].ErrCode = TestItemDgv.Rows[row].Cells[column].Value.ToString(); break;
                }
                //if (column==TestNum.Index)
                //{
                //    SysSetup.TestItem[row].Number = Convert.ToInt32(TestItemDgv.Rows[row].Cells[column].Value.ToString());
                //}
                //else if (column == Method.Index)
                //{
                //    SysSetup.TestItem[row].Method = TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
                //else if (column == TestName.Index)
                //{
                //    SysSetup.TestItem[row].Name = TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
                //else if (column == UpLimit.Index)
                //{
                //    SysSetup.TestItem[row].UpLimit =TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
                //else if (column == LowLimit.Index)
                //{
                //    SysSetup.TestItem[row].LowLimit = TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
                //else if (column == RetestTimes.Index)
                //{
                //    SysSetup.TestItem[row].RetestTimes = Convert.ToInt32(TestItemDgv.Rows[row].Cells[column].Value.ToString());
                //}
                //else if (column == MethodMsg.Index)
                //{
                //    SysSetup.TestItem[row].MethodMsg = TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
                //else if (column == ErrCode.Index)
                //{
                //    SysSetup.TestItem[row].ErrCode = TestItemDgv.Rows[row].Cells[column].Value.ToString();
                //}
            }
            Invalidate();
        }
        private void TestItemDgv_CellEnter(object sender, DataGridViewCellEventArgs e)//根据选中的单元格的确认测试项目
        {
            if (TestItemDgv.CurrentCell != null)
            {
                if (TestItemDgv.CurrentCell.ColumnIndex == 0 || TestItemDgv.CurrentCell.ColumnIndex == 1)
                {
                    TestItemDgv.ClearSelection();
                }
                else
                {
                    if (TestItemInfoGrop.Controls.Count == 2)//确认TestItemInfo群组是否有两个控件
                    {
                        TestItemInfoGrop.Controls.RemoveAt(1);
                    }
                    if (SysSetup.TestItem.Count > 0)//根据选中的单元格显示该项目的设备参数
                    {
                        SetCmdInfo infotemp = new SetCmdInfo(true, SysSetup.TestItem[e.RowIndex].CmdInfo);
                        infotemp.Show();
                        TestItemInfoGrop.Controls.Add(infotemp);
                    }
                    Invalidate();
                }
            }
        }
        private void TestItemLV_DoubleClick(object sender, EventArgs e)//双击方法列表添加方法到测试项
        {
            if (TestItemDgv.CurrentCell != null)
            {
                int row = 0;
                int column = TestItemDgv.CurrentCell.ColumnIndex;

                TestItemInfo ItemTemp = new TestItemInfo();
                ItemTemp.Method = TestMethodLB.Text;
                ItemTemp.Name = TestMethodLB.Text;
                if (TestItemDgv.CurrentCell != null)
                {
                    row = TestItemDgv.CurrentCell.RowIndex;
                    SysSetup.TestItem.Insert(row, ItemTemp);
                }
                else
                {
                    SysSetup.TestItem.Add(ItemTemp);
                    row = SysSetup.TestItem.Count - 1;
                }

                for (int i = 0; i < SysSetup.TestItem.Count; i++)
                {
                    SysSetup.TestItem[i].Number = i + 1;
                    SysSetup.TestItem[i].ErrCode = "Err00" + (i + 1);
                }
                ShowTestItemInfo(row, column);
            }
        }
        private void DeleteTestItem_Click(object sender, EventArgs e)//删除测试项目
        {
            if (TestItemDgv.CurrentCell != null)
            {
                int row = TestItemDgv.CurrentCell.RowIndex;
                int column = TestItemDgv.CurrentCell.ColumnIndex;
                if (row > 0)
                {
                    SysSetup.TestItem.RemoveAt(row);
                    for (int i = 0; i < SysSetup.TestItem.Count; i++)
                    {
                        SysSetup.TestItem[i].Number = i + 1;
                        SysSetup.TestItem[i].ErrCode = "Err00" + (i + 1);
                    }
                    if (SysSetup.TestItem.Count > 0)
                    {
                        ShowTestItemInfo(row - 1, column);
                    }
                    else
                    {
                        ShowTestItemInfo(-1, column);
                    }
                }
            }
        }
        private void TestItemPrevious_Click(object sender, EventArgs e)//测试项目前移
        {
            if (TestItemDgv.CurrentCell != null)
            {
                int row = TestItemDgv.CurrentCell.RowIndex;
                int column = TestItemDgv.CurrentCell.ColumnIndex;
                if (row > 0)
                {
                    SwapTestItem(SysSetup.TestItem[row - 1], SysSetup.TestItem[row]);
                    for (int i = 0; i < SysSetup.TestItem.Count; i++)
                    {
                        SysSetup.TestItem[i].Number = i + 1;
                        SysSetup.TestItem[i].ErrCode = "Err00" + (i + 1);
                    }
                    ShowTestItemInfo(row - 1, column);
                }
            }
        }
        private void TestItemNext_Click(object sender, EventArgs e)//测试项目后移
        {
            if (TestItemDgv.CurrentCell != null)
            {
                int row = TestItemDgv.CurrentCell.RowIndex;
                int column = TestItemDgv.CurrentCell.ColumnIndex;
                if (row > 0)
                {
                    SwapTestItem(SysSetup.TestItem[row + 1], SysSetup.TestItem[row]);
                    for (int i = 0; i < SysSetup.TestItem.Count; i++)
                    {
                        SysSetup.TestItem[i].Number = i + 1;
                        SysSetup.TestItem[i].ErrCode = "Err00" + (i + 1);
                    }
                    ShowTestItemInfo(row + 1, column);
                }
            }
        }
        private void SwapTestItem(TestItemInfo info1, TestItemInfo info2)
        {
            TestItemInfo infotemp = new TestItemInfo();
            infotemp.Number = info1.Number;           //记录测试编号
            infotemp.Method = info1.Method;        //记录测试方法的名称
            infotemp.Name = info1.Name;          //记录测试名称
            infotemp.UpLimit = info1.UpLimit;   //记录测试上限
            infotemp.LowLimit = info1.LowLimit;      //记录测试下限
            infotemp.RetestTimes = info1.RetestTimes;   //记录该项目测试NG时需要重复测试的次数
            infotemp.MethodMsg = info1.MethodMsg;

            infotemp.CmdInfo.DevType = info1.CmdInfo.DevType;
            infotemp.CmdInfo.DevNumber = info1.CmdInfo.DevNumber;
            infotemp.CmdInfo.CmdType = info1.CmdInfo.CmdType;
            infotemp.CmdInfo.Cmd = info1.CmdInfo.Cmd;
            infotemp.CmdInfo.CmdPram.Clear();
            for (int i = 0; i < info1.CmdInfo.CmdPram.Count; i++)
            {
                infotemp.CmdInfo.CmdPram.Add(info1.CmdInfo.CmdPram[i]);
            }
            infotemp.CmdInfo.CmdRecdata.Clear();
            for (int i = 0; i < info1.CmdInfo.CmdRecdata.Count; i++)
            {
                infotemp.CmdInfo.CmdRecdata.Add(info1.CmdInfo.CmdRecdata[i]);
            }
            infotemp.CmdInfo.CmdTimeOut = info1.CmdInfo.CmdTimeOut;
            infotemp.ErrCode = info1.ErrCode;       //记录测试NG时的不良代码

            info1.Number = info2.Number;           //记录测试编号
            info1.Method = info2.Method;        //记录测试方法的名称
            info1.Name = info2.Name;          //记录测试名称
            info1.UpLimit = info2.UpLimit;   //记录测试上限
            info1.LowLimit = info2.LowLimit;      //记录测试下限
            info1.RetestTimes = info2.RetestTimes;   //记录该项目测试NG时需要重复测试的次数
            info1.MethodMsg = info2.MethodMsg;

            info1.CmdInfo.DevType = info2.CmdInfo.DevType;
            info1.CmdInfo.DevNumber = info2.CmdInfo.DevNumber;
            info1.CmdInfo.CmdType = info2.CmdInfo.CmdType;
            info1.CmdInfo.Cmd = info2.CmdInfo.Cmd;
            info1.CmdInfo.CmdPram.Clear();
            for (int i = 0; i < info2.CmdInfo.CmdPram.Count; i++)
            {
                info1.CmdInfo.CmdPram.Add(info2.CmdInfo.CmdPram[i]);
            }
            info1.CmdInfo.CmdRecdata.Clear();
            for (int i = 0; i < info2.CmdInfo.CmdRecdata.Count; i++)
            {
                info1.CmdInfo.CmdRecdata.Add(info2.CmdInfo.CmdRecdata[i]);
            }
            info1.CmdInfo.CmdTimeOut = info2.CmdInfo.CmdTimeOut;
            info1.ErrCode = info2.ErrCode;       //记录测试NG时的不良代码

            info2.Number = infotemp.Number;           //记录测试编号
            info2.Method = infotemp.Method;        //记录测试方法的名称
            info2.Name = infotemp.Name;          //记录测试名称
            info2.UpLimit = infotemp.UpLimit;   //记录测试上限
            info2.LowLimit = infotemp.LowLimit;      //记录测试下限
            info2.RetestTimes = infotemp.RetestTimes;   //记录该项目测试NG时需要重复测试的次数
            info2.MethodMsg = infotemp.MethodMsg;

            info2.CmdInfo.DevType = infotemp.CmdInfo.DevType;
            info2.CmdInfo.DevNumber = infotemp.CmdInfo.DevNumber;
            info2.CmdInfo.CmdType = infotemp.CmdInfo.CmdType;
            info2.CmdInfo.Cmd = infotemp.CmdInfo.Cmd;
            info2.CmdInfo.CmdPram.Clear();
            for (int i = 0; i < infotemp.CmdInfo.CmdPram.Count; i++)
            {
                info2.CmdInfo.CmdPram.Add(infotemp.CmdInfo.CmdPram[i]);
            }
            info2.CmdInfo.CmdRecdata.Clear();
            for (int i = 0; i < infotemp.CmdInfo.CmdRecdata.Count; i++)
            {
                info2.CmdInfo.CmdRecdata.Add(infotemp.CmdInfo.CmdRecdata[i]);
            }
            info2.CmdInfo.CmdTimeOut = infotemp.CmdInfo.CmdTimeOut;
            info2.ErrCode = infotemp.ErrCode;       //记录测试NG时的不良代码
        }
        #endregion

        public SetMainForm(int Permission)
        {
            InitializeComponent();
            if (Permission == 0)
            {
                DutInfoPage.Enabled = true;
                TestItemInfoPage.Enabled = true;
                ModifyPasswordPage.Enabled = true;
                CreatePasswordPage.Enabled = true;
            }
            else
            {
                DutInfoPage.Enabled = false;
                TestItemInfoPage.Enabled = false;
                ModifyPasswordPage.Enabled = false;
                CreatePasswordPage.Enabled = false;
            }
            //DevConUpdate();
            SetDutForm = new List<SetDutInfo>();
            SetForm_init();
        }
        public void SetForm_init()
        {
            //TestItemDgv.CellEndEdit -= new DataGridViewCellEventHandler(this.TestItemDgv_CellEndEdit);
            TestItemDgv.CellValueChanged -= new DataGridViewCellEventHandler(this.TestItemDgv_CellValueChanged);
            Text = SysSetup.Mes.StationName;
            SysInfoPage();
            DutDevParamPage();
            SetTestItemPage();
            //TestItemDgv.CellEndEdit += new DataGridViewCellEventHandler(this.TestItemDgv_CellEndEdit);
            TestItemDgv.CellValueChanged += new DataGridViewCellEventHandler(this.TestItemDgv_CellValueChanged);
        }
        private void SetForm_Paint(object sender, PaintEventArgs e)//设置对话框窗口重绘，改变Dut子窗口和测试项目子窗口的布局
        {
            for (int i = 0; i < DutInfoTbc.TabPages.Count; i++)
            {
                DutInfoTbc.TabPages[i].Size = new Size(DutInfoTbc.Size.Width, DutInfoTbc.Size.Height - 5);
                DutInfoTbc.TabPages[i].Controls[0].Size = new Size(DutInfoTbc.Size.Width - 10, DutInfoTbc.Size.Height - 20);
            }

            TestItemDgv.Size = new Size((int)(TestItemInfoGrop.Width * 2.05 / 3) - 10, TestItemInfoGrop.Height - 25);
            TestItemDgv.Location = new Point(5, 20);

            TestItemInfoGrop.Controls[1].Location = new Point(TestItemDgv.Location.X + TestItemDgv.Width + 5, 20);
            TestItemInfoGrop.Controls[1].Size = new Size((TestItemInfoGrop.Width - TestItemDgv.Width) - 10, TestItemInfoGrop.Height - 10);
        }

        #region 设置主页面按键事件
        private void ImportBtn_Click(object sender, EventArgs e)//ImportStation窗口鼠标双击时导入选择的对应测试项目
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "请选择需要导入的站别";
                fileDialog.InitialDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Config";
                fileDialog.Filter = "xml文件（*.xml）|*.xml|All files(*.*)|*.* ";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //PathTemp=Path.GetExtension(fileDialog.FileName); //文件扩展名
                    //PathTemp=Path.GetFileNameWithoutExtension(fileDialog.FileName); //文件名没有扩展名
                    //PathTemp=Path.GetFileName(fileDialog.FileName); //得到文件
                    //PathTemp=Path.GetDirectoryName(fileDialog.FileName); //得到路径
                    PathTemp = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                    PathTemp = Path.GetFullPath(fileDialog.FileName); //绝对路径   
                    XmlDocument xmlWrite = new XmlDocument();
                    xmlWrite.Load(PathTemp); //加载XML
                    SysSetup.ReadSystemSetupFile(PathTemp);
                    SetForm_init();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Config";
            fileDialog.Filter = "xml文件（*.xml）|*.xml|All files(*.*)|*.* ";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                PathTemp = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                PathTemp = Path.GetFullPath(fileDialog.FileName); //绝对路径   
                //PathTemp=Path.GetExtension(fileDialog.FileName); //文件扩展名
                //PathTemp=Path.GetFileNameWithoutExtension(fileDialog.FileName); //文件名没有扩展名
                //PathTemp=Path.GetFileName(fileDialog.FileName); //得到文件
                //PathTemp=Path.GetDirectoryName(fileDialog.FileName); //得到路径
                SaveConfigInfo();
                SysSetup.WriteSystemSetupFile(true, PathTemp);
                SetForm_init();
            }
        }
        private void SaveBTN_Click(object sender, EventArgs e) //点击保存按键将相关设置保存到文件 
        {
            SaveConfigInfo();
        }
        private void SaveConfigInfo()//保存设置信息到文件
        {
            SysSetup.System.DeviceInfo.Clear();
            for (int i = 0; i < DutInfoTbc.TabPages.Count; i++)
            {
                SetDutInfo info = DutInfoTbc.TabPages[i].Controls[0] as SetDutInfo;
                if (i == 0)//i==0时代表主窗口,i大于0时代表测试窗口
                {
                    SetDeviceInfo(SysSetup.System.DeviceInfo, info);
                }
                else
                {
                    SysSetup.Dut[i - 1].DeviceInfo.Clear();
                    SetDeviceInfo(SysSetup.Dut[i - 1].DeviceInfo, info);
                }
            }
            SysSetup.WriteSystemSetupFile(true);
            SetForm_init();
            Refresh();
        }
        private void SetDeviceInfo(List<DeviceInfo> SysDev, SetDutInfo Devtemp)
        {
            for (int i = 0; i < Devtemp.SerialDevice.Count; i++)
            {
                SysDev.Add(Devtemp.SerialDevice[i]);
            }
            for (int i = 0; i < Devtemp.NetDevice.Count; i++)
            {
                SysDev.Add(Devtemp.NetDevice[i]);
            }
            for (int i = 0; i < Devtemp.USBDevice.Count; i++)
            {
                SysDev.Add(Devtemp.USBDevice[i]);
            }
        }
        private void CancleBTN_Click(object sender, EventArgs e)//退出此对话框并返回取消信息
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 修改密码页面参数设置
        private void MDPassWordTB_KeyDown(object sender, KeyEventArgs e)//修改页面密码文本框回车键按下设置第2次输入密码文本框焦点
        {
            if (e.KeyData == Keys.Enter)
            {
                MDConfirmPassWordTB.SelectAll();
                MDConfirmPassWordTB.Focus();
            }
        }
        private void MDConfirmPassWordTB_KeyDown(object sender, KeyEventArgs e)//第2次输入密码文本框回车键按下设置修改按键焦点
        {
            if (e.KeyData == Keys.Enter)
            {
                ModifyBTN.Focus();
            }
        }
        private void MDPassWordTB_MouseClick(object sender, MouseEventArgs e)//密码窗口鼠标点击事件清除文本框内容
        {
            MDPassWordTB.Clear();
        }
        private void MDConfirmPassWordTB_MouseClick(object sender, MouseEventArgs e)//密码窗口鼠标点击事件清除文本框内容
        {
            MDConfirmPassWordTB.Clear();
        }
        private void MDcancelBTN_Click(object sender, EventArgs e)//点击取消按键重新设置密码窗口文本
        {
            MDPassWordTB.Text = "请输入新密码";
            MDConfirmPassWordTB.Text = "请再次输入新密码";
        }
        private void ModifyBTN_Click(object sender, EventArgs e)//点击修改按键修改密码
        {
            if (!MDPassWordTB.Text.Contains("输入") && MDPassWordTB.Text != string.Empty && !MDConfirmPassWordTB.Text.Contains("输入") && MDConfirmPassWordTB.Text != string.Empty)
            {
                if (MDConfirmPassWordTB.Text == MDPassWordTB.Text)
                {
                    //UserItem[MDUserNameLB.Text] = ConfigFile.GetMD5(MDConfirmPassWordTB.Text);
                    MessageBox.Show("密码修改成功,请保存设置");
                }
                else
                {
                    MessageBox.Show("密码输入不一致，请重新输入");
                }
                MDPassWordTB.Text = "请输入新密码";
                MDConfirmPassWordTB.Text = "请再次输入新密码";
            }
            else
            {
                MessageBox.Show("用户名或者密码输入错误，请重新输入");
            }
        }
        #endregion

        #region 创建密码页面参数设置
        private void CRUserNameTB_MouseClick(object sender, MouseEventArgs e)//鼠标点击创建用户名文本框时清除此文本框内容
        {
            CRUserNameTB.Clear();
        }
        private void CRPassWordTB_MouseClick(object sender, MouseEventArgs e)//鼠标点击创建密码文本框时清除此文本框内容
        {
            CRPassWordTB.Clear();
        }
        private void CRPassWordTB_KeyDown(object sender, KeyEventArgs e)//创建密码文本框按下回车键时创建用户名和密码
        {
            if (e.KeyData == Keys.Enter)
            {
                CreateBTN.Focus();
            }
        }
        private void CRcancelBTN_Click(object sender, EventArgs e)//点击取消创建时恢复控件的默认状态
        {
            CRUserNameTB.Text = "请输入新用户名";
            CRPassWordTB.Text = "请输入密码";
        }
        private void CreateBTN_Click(object sender, EventArgs e)//点击创建按键时显示密码输入框
        {
            if (CRUserNameTB.Text != "" && CRUserNameTB.Text != null &&
                CRPassWordTB.Text != "" && CRPassWordTB.Text != null &&
                !CRUserNameTB.Text.Contains("输入") && !CRPassWordTB.Text.Contains("输入"))
            {
                //if (UserItem.ContainsKey(CRUserNameTB.Text))
                //{
                //    MessageBox.Show("用户名已存在，请重新输入！");
                //}
                //else
                //{
                //    UserItem.Add(CRUserNameTB.Text, ConfigFile.GetMD5(CRPassWordTB.Text));
                //    MessageBox.Show("新用户创建成功，请保存！");
                //}
                CRUserNameTB.Text = "请输入新用户名";
                CRPassWordTB.Text = "请输入密码";
            }
        }




        #endregion


    }
}
