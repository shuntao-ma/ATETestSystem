using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    public partial class SetCmdInfo : Form//指令配置窗口
    {
        private CmdInfo ItemInfo;
        public SetCmdInfo(bool initFlag, CmdInfo _ItemInfo)
        {
            InitializeComponent();
            TopLevel = false;
            ItemInfo = _ItemInfo;
            DevType.Enabled = initFlag;
            DevNumber.Enabled = initFlag;
        }
        private void SetCmdInfo_Load(object sender, EventArgs e)
        {
            DevType.Text = ItemInfo.DevType;
            DevNumber.Text = ItemInfo.DevNumber.ToString();

            CmdType.Text = ItemInfo.CmdType;
            DevInitItemCmd.Text = ItemInfo.Cmd;
            DevInitItemTimeOut.Text = ItemInfo.CmdTimeOut.ToString();
            ShowParamDgv(0, 0);
            ShowRecDataDgv(0, 0);

            DevType.SelectedIndexChanged += new EventHandler(this.DevType_SelectedIndexChanged);
            DevNumber.SelectedIndexChanged += new EventHandler(this.DevNumber_SelectedIndexChanged);
            CmdType.SelectedIndexChanged += new EventHandler(DevInitItemCmdType_SelectedIndexChanged);
            DevInitItemTimeOut.Leave += new EventHandler(this.DevInitItemTimeOut_Leave);
            DevInitItemCmd.Leave += new EventHandler(this.DevInitItemCmd_Leave);
        }

        private void ShowParamDgv(int row, int colum)//显示发送参数控件配置窗口
        {
            DevInitItemParamDgv.Rows.Clear();
            for (int i = 0; i < ItemInfo.CmdPram.Count; i++)
            {
                DevInitItemParamDgv.Rows.Add();
                DevInitItemParamDgv.Rows[i].Cells[DevInitItemParamNum.Index].Value = i + 1;
                DevInitItemParamDgv.Rows[i].Cells[DevInitItemParam.Index].Value = ItemInfo.CmdPram[i];
            }
            DevInitItemParamDgv.ClearSelection();
        }
        private void ShowRecDataDgv(int row, int colum)//显示返回值控件配置窗口
        {
            DevInitItemRecDataDgv.Rows.Clear();
            for (int i = 0; i < ItemInfo.CmdRecdata.Count; i++)
            {
                DevInitItemRecDataDgv.Rows.Add();
                DevInitItemRecDataDgv.Rows[i].Cells[DevInitItemRecDataNumber.Index].Value = i + 1;
                DevInitItemRecDataDgv.Rows[i].Cells[DevInitItemRecData.Index].Value = ItemInfo.CmdRecdata[i];
            }
            DevInitItemRecDataDgv.ClearSelection();
        }
        private void DevInitItem_Paint(object sender, PaintEventArgs e)
        {
            DevInitItemParamDgv.Size = new Size(Size.Width - 12, (Size.Height - 120) / 2);
            DevInitItemRecDataDgv.Size = new Size(Size.Width - 12, (Size.Height - 120) / 2);
            DevInitItemRecDataDgv.Location = new Point(DevInitItemRecDataDgv.Location.X, DevInitItemParamDgv.Location.Y + DevInitItemParamDgv.Height + 5);
        }

        private void AddInitItemParam_Click(object sender, EventArgs e)//当前位置增加参数
        {
            int RowIndex = 0;
            if (DevInitItemParamDgv.CurrentCell != null && ItemInfo.CmdPram.Count > 0)
            {
                RowIndex = DevInitItemParamDgv.CurrentCell.RowIndex;
                ItemInfo.CmdPram.Insert(RowIndex, "");
            }
            else
            {
                ItemInfo.CmdPram.Add("");
                RowIndex = ItemInfo.CmdPram.Count - 1;
            }
            ShowParamDgv(RowIndex, 1);
        }
        private void DeleteInitItemParam_Click(object sender, EventArgs e)//删除当前参数
        {
            int RowIndex = 0;
            if (DevInitItemParamDgv.CurrentCell != null && ItemInfo.CmdPram.Count > 0)
            {
                RowIndex = DevInitItemParamDgv.CurrentCell.RowIndex;
                ItemInfo.CmdPram.RemoveAt(RowIndex);
            }
            if ((RowIndex - 1) > 0)
            {
                RowIndex = RowIndex - 1;
            }
            else
            {
                RowIndex = 0;
            }
            ShowParamDgv(RowIndex, 1);
        }
        private void ParamPrevious_Click(object sender, EventArgs e)//当前参数前移
        {
            int RowIndex = 0;
            if (DevInitItemParamDgv.CurrentCell != null && ItemInfo.CmdPram.Count > 1)
            {
                RowIndex = DevInitItemParamDgv.CurrentCell.RowIndex;
                if (RowIndex > 0)
                {
                    string temp = ItemInfo.CmdPram[RowIndex - 1];
                    ItemInfo.CmdPram[RowIndex - 1] = ItemInfo.CmdPram[RowIndex];
                    ItemInfo.CmdPram[RowIndex] = temp;
                    ShowParamDgv(RowIndex - 1, 1);
                }
                else
                {
                    ShowParamDgv(RowIndex, 1);
                }
            }
        }
        private void ParamNext_Click(object sender, EventArgs e)//当前参数后移
        {
            int RowIndex = 0;
            if (DevInitItemParamDgv.CurrentCell != null && ItemInfo.CmdPram.Count > 1)
            {
                RowIndex = DevInitItemParamDgv.CurrentCell.RowIndex;
                if (RowIndex < ItemInfo.CmdPram.Count - 1)
                {
                    string temp = ItemInfo.CmdPram[RowIndex + 1];
                    ItemInfo.CmdPram[RowIndex + 1] = ItemInfo.CmdPram[RowIndex];
                    ItemInfo.CmdPram[RowIndex] = temp;
                    ShowParamDgv(RowIndex + 1, 1);
                }
                else
                {
                    ShowParamDgv(RowIndex, 1);
                }
            }
        }

        private void AddRecData_Click(object sender, EventArgs e)//增加返回值
        {
            int RowIndex = 0;
            if (DevInitItemRecDataDgv.CurrentCell != null && ItemInfo.CmdRecdata.Count > 0)
            {
                RowIndex = DevInitItemRecDataDgv.CurrentCell.RowIndex;
                ItemInfo.CmdRecdata.Insert(RowIndex, "");
            }
            else
            {
                ItemInfo.CmdRecdata.Add("");
                RowIndex = ItemInfo.CmdRecdata.Count - 1;
            }
            ShowRecDataDgv(RowIndex, 1);
        }
        private void DeleteRecData_Click(object sender, EventArgs e)//删除当前返回值
        {
            int RowIndex = 0;
            if (DevInitItemRecDataDgv.CurrentCell != null && ItemInfo.CmdRecdata.Count > 0)
            {
                RowIndex = DevInitItemRecDataDgv.CurrentCell.RowIndex;
                ItemInfo.CmdRecdata.RemoveAt(RowIndex);
            }

            if ((RowIndex - 1) > 0)
            {
                RowIndex = RowIndex - 1;
            }
            else
            {
                RowIndex = 0;
            }
            ShowRecDataDgv(RowIndex, 1);
        }
        private void RecDataPrevious_Click(object sender, EventArgs e)//当前返回值前移
        {
            int RowIndex = 0;
            if (DevInitItemRecDataDgv.CurrentCell != null && ItemInfo.CmdRecdata.Count > 1)
            {
                RowIndex = DevInitItemRecDataDgv.CurrentCell.RowIndex;
                if (RowIndex > 0)
                {
                    string temp = ItemInfo.CmdRecdata[RowIndex - 1];
                    ItemInfo.CmdRecdata[RowIndex - 1] = ItemInfo.CmdRecdata[RowIndex];
                    ItemInfo.CmdRecdata[RowIndex] = temp;
                    ShowRecDataDgv(RowIndex - 1, 1);
                }
                else
                {
                    ShowRecDataDgv(RowIndex, 1);
                }
            }
        }
        private void RecDataNext_Click(object sender, EventArgs e)//当前返回值后移
        {
            int RowIndex = 0;
            if (DevInitItemRecDataDgv.CurrentCell != null && ItemInfo.CmdRecdata.Count > 1)
            {
                RowIndex = DevInitItemRecDataDgv.CurrentCell.RowIndex;
                if (RowIndex < ItemInfo.CmdRecdata.Count - 1)
                {
                    string temp = ItemInfo.CmdRecdata[RowIndex + 1];
                    ItemInfo.CmdRecdata[RowIndex + 1] = ItemInfo.CmdRecdata[RowIndex];
                    ItemInfo.CmdRecdata[RowIndex] = temp;
                    ShowRecDataDgv(RowIndex + 1, 1);
                }
                else
                {
                    ShowRecDataDgv(RowIndex, 1);
                }
            }
        }

        private void DevType_SelectedIndexChanged(object sender, EventArgs e)//将修改后的设备类型更新到设备变量
        {
            ItemInfo.DevType = DevType.SelectedItem.ToString();
        }
        private void DevNumber_SelectedIndexChanged(object sender, EventArgs e)//将修改后的设备编号更新到设备编号变量
        {
            ItemInfo.DevNumber = DevNumber.SelectedIndex;
        }
        private void DevInitItemCmdType_SelectedIndexChanged(object sender, EventArgs e)//设备指令类型修改后将变更更新内容到设备变量
        {
            ItemInfo.CmdType = CmdType.SelectedItem.ToString();
        }
        private void DevInitItemTimeOut_Leave(object sender, EventArgs e)//将变更后的时间更新到设备变量
        {
            double timeout = 0;
            if (double.TryParse(DevInitItemTimeOut.Text, out timeout))
            {
                ItemInfo.CmdTimeOut = timeout;
            }
            else
            {
                MessageBox.Show("请输入数字");
                DevInitItemTimeOut.Focus();
                DevInitItemTimeOut.SelectAll();
            }
        }
        private void DevInitItemCmd_Leave(object sender, EventArgs e)//设备指令文本框失去焦点后更新内容到指令框
        {
            ItemInfo.Cmd = DevInitItemCmd.Text;
        }

        private void DevInitItemParamDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)//参数修改完成后更新数据到设备变量
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            if (column == 1)
            {
                ItemInfo.CmdPram[row] = DevInitItemParamDgv.Rows[row].Cells[column].Value == null ?
                                        "" : DevInitItemParamDgv.Rows[row].Cells[column].Value.ToString();
            }
        }
        private void DevInitItemRecDataDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)//返回值修改完成后更新数据到设备变量
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            if (column == 1)
            {
                ItemInfo.CmdRecdata[row] = DevInitItemRecDataDgv.Rows[row].Cells[column].Value == null ?
                    "" : DevInitItemRecDataDgv.Rows[row].Cells[column].Value.ToString();
            }
        }

        private void DevInitItemParamDgv_Leave(object sender, EventArgs e)
        {
            DevInitItemParamDgv.ClearSelection();
        }
        private void DevInitItemRecDataDgv_Leave(object sender, EventArgs e)
        {
            DevInitItemRecDataDgv.ClearSelection();
        }
    }
}
