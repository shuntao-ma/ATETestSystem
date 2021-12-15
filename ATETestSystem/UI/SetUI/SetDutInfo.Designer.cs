using System.Windows.Forms;

namespace ATETestSystem
{
    partial class SetDutInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PassLb = new System.Windows.Forms.Label();
            this.FailLb = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.Fail = new System.Windows.Forms.TextBox();
            this.DevRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceAddParam = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceDeleteParam = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteInitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InitItemPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.InitItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.DevInfo = new System.Windows.Forms.GroupBox();
            this.InitItemTbc = new System.Windows.Forms.TabControl();
            this.DutUsbDevDgv = new System.Windows.Forms.DataGridView();
            this.DevUSBType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBCmdType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DevUSBCmdSendHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBCmdSendTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBCmdRcdHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevUSBCmdRcdTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DutNetDevDgv = new System.Windows.Forms.DataGridView();
            this.DevNetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetCmdType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DevNetCmdSendHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetCmdSendTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetCmdRcdHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNetCmdRcdTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DutSerialDevDgv = new System.Windows.Forms.DataGridView();
            this.DevSerialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialCmdType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DevSerialCmdSendHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialCmdSendTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialCmdRcdHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSerialCmdRcdTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevRightMenu.SuspendLayout();
            this.DevInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DutUsbDevDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutNetDevDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutSerialDevDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // PassLb
            // 
            this.PassLb.AutoSize = true;
            this.PassLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassLb.Location = new System.Drawing.Point(7, 14);
            this.PassLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PassLb.Name = "PassLb";
            this.PassLb.Size = new System.Drawing.Size(80, 16);
            this.PassLb.TabIndex = 2;
            this.PassLb.Text = "PassCount";
            // 
            // FailLb
            // 
            this.FailLb.AutoSize = true;
            this.FailLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FailLb.Location = new System.Drawing.Point(206, 14);
            this.FailLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FailLb.Name = "FailLb";
            this.FailLb.Size = new System.Drawing.Size(80, 16);
            this.FailLb.TabIndex = 3;
            this.FailLb.Text = "FailCount";
            // 
            // Pass
            // 
            this.Pass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pass.Location = new System.Drawing.Point(90, 12);
            this.Pass.Margin = new System.Windows.Forms.Padding(4);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(110, 26);
            this.Pass.TabIndex = 4;
            this.Pass.TextChanged += new System.EventHandler(this.Pass_TextChanged);
            // 
            // Fail
            // 
            this.Fail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Fail.Location = new System.Drawing.Point(290, 12);
            this.Fail.Margin = new System.Windows.Forms.Padding(4);
            this.Fail.Name = "Fail";
            this.Fail.Size = new System.Drawing.Size(110, 26);
            this.Fail.TabIndex = 5;
            this.Fail.TextChanged += new System.EventHandler(this.Fail_TextChanged);
            // 
            // DevRightMenu
            // 
            this.DevRightMenu.AccessibleDescription = "";
            this.DevRightMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDevice,
            this.DeleteDevice,
            this.DeviceAddParam,
            this.DeviceDeleteParam,
            this.AddInitItem,
            this.DeleteInitItem,
            this.InitItemPrevious,
            this.InitItemNext});
            this.DevRightMenu.Name = "RigtMenu";
            this.DevRightMenu.Size = new System.Drawing.Size(177, 196);
            // 
            // AddDevice
            // 
            this.AddDevice.Name = "AddDevice";
            this.AddDevice.Size = new System.Drawing.Size(176, 24);
            this.AddDevice.Tag = "DutSerialDevDgv";
            this.AddDevice.Text = "添加设备";
            this.AddDevice.Click += new System.EventHandler(this.AddDevice_Click);
            // 
            // DeleteDevice
            // 
            this.DeleteDevice.Name = "DeleteDevice";
            this.DeleteDevice.Size = new System.Drawing.Size(176, 24);
            this.DeleteDevice.Text = "删除设备";
            this.DeleteDevice.Click += new System.EventHandler(this.DeleteDevice_Click);
            // 
            // DeviceAddParam
            // 
            this.DeviceAddParam.Name = "DeviceAddParam";
            this.DeviceAddParam.Size = new System.Drawing.Size(176, 24);
            this.DeviceAddParam.Text = "添加参数";
            this.DeviceAddParam.Click += new System.EventHandler(this.DeviceAddParam_Click);
            // 
            // DeviceDeleteParam
            // 
            this.DeviceDeleteParam.Name = "DeviceDeleteParam";
            this.DeviceDeleteParam.Size = new System.Drawing.Size(176, 24);
            this.DeviceDeleteParam.Text = "删除参数";
            this.DeviceDeleteParam.Click += new System.EventHandler(this.DeviceDeleteParam_Click);
            // 
            // AddInitItem
            // 
            this.AddInitItem.Name = "AddInitItem";
            this.AddInitItem.Size = new System.Drawing.Size(176, 24);
            this.AddInitItem.Text = "添加初始化项目";
            this.AddInitItem.Click += new System.EventHandler(this.AddInitItem_Click);
            // 
            // DeleteInitItem
            // 
            this.DeleteInitItem.Name = "DeleteInitItem";
            this.DeleteInitItem.Size = new System.Drawing.Size(176, 24);
            this.DeleteInitItem.Text = "删除初始化项目";
            this.DeleteInitItem.Click += new System.EventHandler(this.DeleteInitItem_Click);
            // 
            // InitItemPrevious
            // 
            this.InitItemPrevious.Name = "InitItemPrevious";
            this.InitItemPrevious.Size = new System.Drawing.Size(176, 24);
            this.InitItemPrevious.Text = "项目前移";
            this.InitItemPrevious.Click += new System.EventHandler(this.InitItemPrevious_Click);
            // 
            // InitItemNext
            // 
            this.InitItemNext.Name = "InitItemNext";
            this.InitItemNext.Size = new System.Drawing.Size(176, 24);
            this.InitItemNext.Text = "项目后移";
            this.InitItemNext.Click += new System.EventHandler(this.InitItemNext_Click);
            // 
            // DevInfo
            // 
            this.DevInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DevInfo.Controls.Add(this.InitItemTbc);
            this.DevInfo.Controls.Add(this.DutUsbDevDgv);
            this.DevInfo.Controls.Add(this.DutNetDevDgv);
            this.DevInfo.Controls.Add(this.DutSerialDevDgv);
            this.DevInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevInfo.Location = new System.Drawing.Point(5, 43);
            this.DevInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DevInfo.Name = "DevInfo";
            this.DevInfo.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DevInfo.Size = new System.Drawing.Size(1088, 434);
            this.DevInfo.TabIndex = 6;
            this.DevInfo.TabStop = false;
            this.DevInfo.Text = "设备信息";
            // 
            // InitItemTbc
            // 
            this.InitItemTbc.Location = new System.Drawing.Point(788, 20);
            this.InitItemTbc.Name = "InitItemTbc";
            this.InitItemTbc.SelectedIndex = 0;
            this.InitItemTbc.Size = new System.Drawing.Size(301, 407);
            this.InitItemTbc.TabIndex = 5;
            // 
            // DutUsbDevDgv
            // 
            this.DutUsbDevDgv.AllowUserToAddRows = false;
            this.DutUsbDevDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutUsbDevDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DutUsbDevDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DutUsbDevDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevUSBType,
            this.DevUSBNumber,
            this.DevUSBName,
            this.DevUSBCmdType,
            this.DevUSBCmdSendHead,
            this.DevUSBCmdSendTail,
            this.DevUSBCmdRcdHead,
            this.DevUSBCmdRcdTail});
            this.DutUsbDevDgv.ContextMenuStrip = this.DevRightMenu;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutUsbDevDgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.DutUsbDevDgv.GridColor = System.Drawing.SystemColors.Control;
            this.DutUsbDevDgv.Location = new System.Drawing.Point(5, 300);
            this.DutUsbDevDgv.Margin = new System.Windows.Forms.Padding(4);
            this.DutUsbDevDgv.MultiSelect = false;
            this.DutUsbDevDgv.Name = "DutUsbDevDgv";
            this.DutUsbDevDgv.RowTemplate.Height = 23;
            this.DutUsbDevDgv.Size = new System.Drawing.Size(776, 127);
            this.DutUsbDevDgv.TabIndex = 4;
            this.DutUsbDevDgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutUsbDevDgv_CellDataUpdate);
            this.DutUsbDevDgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutUsbDevDgv_CellDataUpdate);
            // 
            // DevUSBType
            // 
            this.DevUSBType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBType.DefaultCellStyle = dataGridViewCellStyle2;
            this.DevUSBType.HeaderText = "USBDevice";
            this.DevUSBType.Name = "DevUSBType";
            this.DevUSBType.ReadOnly = true;
            this.DevUSBType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevUSBType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBType.Width = 86;
            // 
            // DevUSBNumber
            // 
            this.DevUSBNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.DevUSBNumber.HeaderText = "DevNumber";
            this.DevUSBNumber.Name = "DevUSBNumber";
            this.DevUSBNumber.ReadOnly = true;
            this.DevUSBNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBNumber.Width = 86;
            // 
            // DevUSBName
            // 
            this.DevUSBName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBName.DefaultCellStyle = dataGridViewCellStyle4;
            this.DevUSBName.HeaderText = "DevName";
            this.DevUSBName.Name = "DevUSBName";
            this.DevUSBName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBName.Width = 70;
            // 
            // DevUSBCmdType
            // 
            this.DevUSBCmdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBCmdType.DefaultCellStyle = dataGridViewCellStyle5;
            this.DevUSBCmdType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DevUSBCmdType.HeaderText = "CmdType";
            this.DevUSBCmdType.Items.AddRange(new object[] {
            "String",
            "Byte"});
            this.DevUSBCmdType.Name = "DevUSBCmdType";
            this.DevUSBCmdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevUSBCmdType.Width = 70;
            // 
            // DevUSBCmdSendHead
            // 
            this.DevUSBCmdSendHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBCmdSendHead.DefaultCellStyle = dataGridViewCellStyle6;
            this.DevUSBCmdSendHead.HeaderText = "CmdSendHead";
            this.DevUSBCmdSendHead.Name = "DevUSBCmdSendHead";
            this.DevUSBCmdSendHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBCmdSendHead.Width = 102;
            // 
            // DevUSBCmdSendTail
            // 
            this.DevUSBCmdSendTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBCmdSendTail.DefaultCellStyle = dataGridViewCellStyle7;
            this.DevUSBCmdSendTail.HeaderText = "CmdSendTail";
            this.DevUSBCmdSendTail.Name = "DevUSBCmdSendTail";
            this.DevUSBCmdSendTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBCmdSendTail.Width = 102;
            // 
            // DevUSBCmdRcdHead
            // 
            this.DevUSBCmdRcdHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBCmdRcdHead.DefaultCellStyle = dataGridViewCellStyle8;
            this.DevUSBCmdRcdHead.HeaderText = "CmdRcdHead";
            this.DevUSBCmdRcdHead.Name = "DevUSBCmdRcdHead";
            this.DevUSBCmdRcdHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBCmdRcdHead.Width = 94;
            // 
            // DevUSBCmdRcdTail
            // 
            this.DevUSBCmdRcdTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevUSBCmdRcdTail.DefaultCellStyle = dataGridViewCellStyle9;
            this.DevUSBCmdRcdTail.HeaderText = "CmdRcdTail";
            this.DevUSBCmdRcdTail.Name = "DevUSBCmdRcdTail";
            this.DevUSBCmdRcdTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevUSBCmdRcdTail.Width = 94;
            // 
            // DutNetDevDgv
            // 
            this.DutNetDevDgv.AllowUserToAddRows = false;
            this.DutNetDevDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutNetDevDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DutNetDevDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DutNetDevDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevNetType,
            this.DevNetNumber,
            this.DevNetName,
            this.DevNetCmdType,
            this.DevNetCmdSendHead,
            this.DevNetCmdSendTail,
            this.DevNetCmdRcdHead,
            this.DevNetCmdRcdTail});
            this.DutNetDevDgv.ContextMenuStrip = this.DevRightMenu;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutNetDevDgv.DefaultCellStyle = dataGridViewCellStyle20;
            this.DutNetDevDgv.GridColor = System.Drawing.SystemColors.Control;
            this.DutNetDevDgv.Location = new System.Drawing.Point(5, 162);
            this.DutNetDevDgv.Margin = new System.Windows.Forms.Padding(4);
            this.DutNetDevDgv.MultiSelect = false;
            this.DutNetDevDgv.Name = "DutNetDevDgv";
            this.DutNetDevDgv.RowTemplate.Height = 23;
            this.DutNetDevDgv.Size = new System.Drawing.Size(776, 127);
            this.DutNetDevDgv.TabIndex = 4;
            this.DutNetDevDgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutNetDevDgv_CellDataUpdate);
            this.DutNetDevDgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutNetDevDgv_CellDataUpdate);
            // 
            // DevNetType
            // 
            this.DevNetType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetType.DefaultCellStyle = dataGridViewCellStyle12;
            this.DevNetType.HeaderText = "NetDevice";
            this.DevNetType.Name = "DevNetType";
            this.DevNetType.ReadOnly = true;
            this.DevNetType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevNetType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetType.Width = 86;
            // 
            // DevNetNumber
            // 
            this.DevNetNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetNumber.DefaultCellStyle = dataGridViewCellStyle13;
            this.DevNetNumber.HeaderText = "DevNumber";
            this.DevNetNumber.Name = "DevNetNumber";
            this.DevNetNumber.ReadOnly = true;
            this.DevNetNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetNumber.Width = 86;
            // 
            // DevNetName
            // 
            this.DevNetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetName.DefaultCellStyle = dataGridViewCellStyle14;
            this.DevNetName.HeaderText = "DevName";
            this.DevNetName.Name = "DevNetName";
            this.DevNetName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetName.Width = 70;
            // 
            // DevNetCmdType
            // 
            this.DevNetCmdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetCmdType.DefaultCellStyle = dataGridViewCellStyle15;
            this.DevNetCmdType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DevNetCmdType.HeaderText = "CmdType";
            this.DevNetCmdType.Items.AddRange(new object[] {
            "String",
            "Byte"});
            this.DevNetCmdType.Name = "DevNetCmdType";
            this.DevNetCmdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevNetCmdType.Width = 70;
            // 
            // DevNetCmdSendHead
            // 
            this.DevNetCmdSendHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetCmdSendHead.DefaultCellStyle = dataGridViewCellStyle16;
            this.DevNetCmdSendHead.HeaderText = "CmdSendHead";
            this.DevNetCmdSendHead.Name = "DevNetCmdSendHead";
            this.DevNetCmdSendHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetCmdSendHead.Width = 102;
            // 
            // DevNetCmdSendTail
            // 
            this.DevNetCmdSendTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetCmdSendTail.DefaultCellStyle = dataGridViewCellStyle17;
            this.DevNetCmdSendTail.HeaderText = "CmdSendTail";
            this.DevNetCmdSendTail.Name = "DevNetCmdSendTail";
            this.DevNetCmdSendTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetCmdSendTail.Width = 102;
            // 
            // DevNetCmdRcdHead
            // 
            this.DevNetCmdRcdHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetCmdRcdHead.DefaultCellStyle = dataGridViewCellStyle18;
            this.DevNetCmdRcdHead.HeaderText = "CmdRcdHead";
            this.DevNetCmdRcdHead.Name = "DevNetCmdRcdHead";
            this.DevNetCmdRcdHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetCmdRcdHead.Width = 94;
            // 
            // DevNetCmdRcdTail
            // 
            this.DevNetCmdRcdTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevNetCmdRcdTail.DefaultCellStyle = dataGridViewCellStyle19;
            this.DevNetCmdRcdTail.HeaderText = "CmdRcdTail";
            this.DevNetCmdRcdTail.Name = "DevNetCmdRcdTail";
            this.DevNetCmdRcdTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevNetCmdRcdTail.Width = 94;
            // 
            // DutSerialDevDgv
            // 
            this.DutSerialDevDgv.AllowUserToAddRows = false;
            this.DutSerialDevDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutSerialDevDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.DutSerialDevDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DutSerialDevDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevSerialType,
            this.DevSerialNumber,
            this.DevSerialName,
            this.DevSerialCmdType,
            this.DevSerialCmdSendHead,
            this.DevSerialCmdSendTail,
            this.DevSerialCmdRcdHead,
            this.DevSerialCmdRcdTail});
            this.DutSerialDevDgv.ContextMenuStrip = this.DevRightMenu;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DutSerialDevDgv.DefaultCellStyle = dataGridViewCellStyle30;
            this.DutSerialDevDgv.GridColor = System.Drawing.SystemColors.Control;
            this.DutSerialDevDgv.Location = new System.Drawing.Point(5, 24);
            this.DutSerialDevDgv.Margin = new System.Windows.Forms.Padding(4);
            this.DutSerialDevDgv.MultiSelect = false;
            this.DutSerialDevDgv.Name = "DutSerialDevDgv";
            this.DutSerialDevDgv.RowTemplate.Height = 23;
            this.DutSerialDevDgv.Size = new System.Drawing.Size(776, 127);
            this.DutSerialDevDgv.TabIndex = 4;
            this.DutSerialDevDgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutSerialDevDgv_CellDataUpdate);
            this.DutSerialDevDgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DutSerialDevDgv_CellDataUpdate);
            // 
            // DevSerialType
            // 
            this.DevSerialType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialType.DefaultCellStyle = dataGridViewCellStyle22;
            this.DevSerialType.HeaderText = "SerialDevice";
            this.DevSerialType.Name = "DevSerialType";
            this.DevSerialType.ReadOnly = true;
            this.DevSerialType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevSerialType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialType.Width = 110;
            // 
            // DevSerialNumber
            // 
            this.DevSerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialNumber.DefaultCellStyle = dataGridViewCellStyle23;
            this.DevSerialNumber.HeaderText = "DevNumber";
            this.DevSerialNumber.Name = "DevSerialNumber";
            this.DevSerialNumber.ReadOnly = true;
            this.DevSerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialNumber.Width = 86;
            // 
            // DevSerialName
            // 
            this.DevSerialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialName.DefaultCellStyle = dataGridViewCellStyle24;
            this.DevSerialName.HeaderText = "DevName";
            this.DevSerialName.Name = "DevSerialName";
            this.DevSerialName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialName.Width = 70;
            // 
            // DevSerialCmdType
            // 
            this.DevSerialCmdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialCmdType.DefaultCellStyle = dataGridViewCellStyle25;
            this.DevSerialCmdType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DevSerialCmdType.HeaderText = "CmdType";
            this.DevSerialCmdType.Items.AddRange(new object[] {
            "String",
            "Byte"});
            this.DevSerialCmdType.Name = "DevSerialCmdType";
            this.DevSerialCmdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DevSerialCmdType.Width = 70;
            // 
            // DevSerialCmdSendHead
            // 
            this.DevSerialCmdSendHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialCmdSendHead.DefaultCellStyle = dataGridViewCellStyle26;
            this.DevSerialCmdSendHead.HeaderText = "CmdSendHead";
            this.DevSerialCmdSendHead.Name = "DevSerialCmdSendHead";
            this.DevSerialCmdSendHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialCmdSendHead.Width = 102;
            // 
            // DevSerialCmdSendTail
            // 
            this.DevSerialCmdSendTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialCmdSendTail.DefaultCellStyle = dataGridViewCellStyle27;
            this.DevSerialCmdSendTail.HeaderText = "CmdSendTail";
            this.DevSerialCmdSendTail.Name = "DevSerialCmdSendTail";
            this.DevSerialCmdSendTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialCmdSendTail.Width = 102;
            // 
            // DevSerialCmdRcdHead
            // 
            this.DevSerialCmdRcdHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialCmdRcdHead.DefaultCellStyle = dataGridViewCellStyle28;
            this.DevSerialCmdRcdHead.HeaderText = "CmdRcdHead";
            this.DevSerialCmdRcdHead.Name = "DevSerialCmdRcdHead";
            this.DevSerialCmdRcdHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialCmdRcdHead.Width = 94;
            // 
            // DevSerialCmdRcdTail
            // 
            this.DevSerialCmdRcdTail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevSerialCmdRcdTail.DefaultCellStyle = dataGridViewCellStyle29;
            this.DevSerialCmdRcdTail.HeaderText = "CmdRcdTail";
            this.DevSerialCmdRcdTail.Name = "DevSerialCmdRcdTail";
            this.DevSerialCmdRcdTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevSerialCmdRcdTail.Width = 94;
            // 
            // SetDutInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1097, 487);
            this.Controls.Add(this.DevInfo);
            this.Controls.Add(this.Fail);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.FailLb);
            this.Controls.Add(this.PassLb);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetDutInfo";
            this.Text = "DutDgv";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SetDutInfo_Paint);
            this.DevRightMenu.ResumeLayout(false);
            this.DevInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DutUsbDevDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutNetDevDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutSerialDevDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PassLb;
        private System.Windows.Forms.Label FailLb;
        public System.Windows.Forms.TextBox Pass;
        public System.Windows.Forms.TextBox Fail;
        private ContextMenuStrip DevRightMenu;
        private ToolStripMenuItem AddDevice;
        private ToolStripMenuItem DeleteDevice;
        private ToolStripMenuItem DeviceAddParam;
        private ToolStripMenuItem DeviceDeleteParam;
        private GroupBox DevInfo;
        private DataGridView DutSerialDevDgv;
        private TabControl InitItemTbc;
        private DataGridView DutUsbDevDgv;
        private DataGridView DutNetDevDgv;
        private ToolStripMenuItem AddInitItem;
        private ToolStripMenuItem DeleteInitItem;
        private ToolStripMenuItem InitItemPrevious;
        private ToolStripMenuItem InitItemNext;
        private DataGridViewTextBoxColumn DevUSBType;
        private DataGridViewTextBoxColumn DevUSBNumber;
        private DataGridViewTextBoxColumn DevUSBName;
        private DataGridViewComboBoxColumn DevUSBCmdType;
        private DataGridViewTextBoxColumn DevUSBCmdSendHead;
        private DataGridViewTextBoxColumn DevUSBCmdSendTail;
        private DataGridViewTextBoxColumn DevUSBCmdRcdHead;
        private DataGridViewTextBoxColumn DevUSBCmdRcdTail;
        private DataGridViewTextBoxColumn DevNetType;
        private DataGridViewTextBoxColumn DevNetNumber;
        private DataGridViewTextBoxColumn DevNetName;
        private DataGridViewComboBoxColumn DevNetCmdType;
        private DataGridViewTextBoxColumn DevNetCmdSendHead;
        private DataGridViewTextBoxColumn DevNetCmdSendTail;
        private DataGridViewTextBoxColumn DevNetCmdRcdHead;
        private DataGridViewTextBoxColumn DevNetCmdRcdTail;
        private DataGridViewTextBoxColumn DevSerialType;
        private DataGridViewTextBoxColumn DevSerialNumber;
        private DataGridViewTextBoxColumn DevSerialName;
        private DataGridViewComboBoxColumn DevSerialCmdType;
        private DataGridViewTextBoxColumn DevSerialCmdSendHead;
        private DataGridViewTextBoxColumn DevSerialCmdSendTail;
        private DataGridViewTextBoxColumn DevSerialCmdRcdHead;
        private DataGridViewTextBoxColumn DevSerialCmdRcdTail;
    }
}