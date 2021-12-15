using System.Windows.Forms;

namespace ATETestSystem
{
    partial class SetMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SysSetTbc = new System.Windows.Forms.TabControl();
            this.SystemInfoPage = new System.Windows.Forms.TabPage();
            this.SystemConfigInfo = new System.Windows.Forms.GroupBox();
            this.SysInfoDgv = new System.Windows.Forms.DataGridView();
            this.SetupSnDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetupNameDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetupValueDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DutInfoPage = new System.Windows.Forms.TabPage();
            this.DutInfoGrop = new System.Windows.Forms.GroupBox();
            this.DutInfoDevList = new System.Windows.Forms.ListBox();
            this.DutInfoTbc = new System.Windows.Forms.TabControl();
            this.DutRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddDut = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDut = new System.Windows.Forms.ToolStripMenuItem();
            this.TestItemInfoPage = new System.Windows.Forms.TabPage();
            this.TestItemInfoGrop = new System.Windows.Forms.GroupBox();
            this.TestItemDgv = new System.Windows.Forms.DataGridView();
            this.TestNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetestTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MethodMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestItemRigtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestItemPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.TestItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodItemGrop = new System.Windows.Forms.GroupBox();
            this.TestMethodLB = new System.Windows.Forms.ListBox();
            this.ModifyPasswordPage = new System.Windows.Forms.TabPage();
            this.MDUserNameLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MDConfirmPassWordTB = new System.Windows.Forms.TextBox();
            this.MDPassWordTB = new System.Windows.Forms.TextBox();
            this.MDcancelBTN = new System.Windows.Forms.Button();
            this.ModifyBTN = new System.Windows.Forms.Button();
            this.CreatePasswordPage = new System.Windows.Forms.TabPage();
            this.CRMessageLab = new System.Windows.Forms.Label();
            this.CRUserNameTB = new System.Windows.Forms.TextBox();
            this.CRPassWordTB = new System.Windows.Forms.TextBox();
            this.CRcancelBTN = new System.Windows.Forms.Button();
            this.CreateBTN = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.ImportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveasMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SysSetTbc.SuspendLayout();
            this.SystemInfoPage.SuspendLayout();
            this.SystemConfigInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SysInfoDgv)).BeginInit();
            this.DutInfoPage.SuspendLayout();
            this.DutInfoGrop.SuspendLayout();
            this.DutRightMenu.SuspendLayout();
            this.TestItemInfoPage.SuspendLayout();
            this.TestItemInfoGrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestItemDgv)).BeginInit();
            this.TestItemRigtMenu.SuspendLayout();
            this.MethodItemGrop.SuspendLayout();
            this.ModifyPasswordPage.SuspendLayout();
            this.CreatePasswordPage.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SysSetTbc
            // 
            this.SysSetTbc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SysSetTbc.Controls.Add(this.SystemInfoPage);
            this.SysSetTbc.Controls.Add(this.DutInfoPage);
            this.SysSetTbc.Controls.Add(this.TestItemInfoPage);
            this.SysSetTbc.Controls.Add(this.ModifyPasswordPage);
            this.SysSetTbc.Controls.Add(this.CreatePasswordPage);
            this.SysSetTbc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SysSetTbc.Location = new System.Drawing.Point(1, 31);
            this.SysSetTbc.Name = "SysSetTbc";
            this.SysSetTbc.SelectedIndex = 0;
            this.SysSetTbc.ShowToolTips = true;
            this.SysSetTbc.Size = new System.Drawing.Size(1347, 697);
            this.SysSetTbc.TabIndex = 1;
            // 
            // SystemInfoPage
            // 
            this.SystemInfoPage.AutoScroll = true;
            this.SystemInfoPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SystemInfoPage.Controls.Add(this.SystemConfigInfo);
            this.SystemInfoPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SystemInfoPage.Location = new System.Drawing.Point(4, 26);
            this.SystemInfoPage.Name = "SystemInfoPage";
            this.SystemInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.SystemInfoPage.Size = new System.Drawing.Size(1339, 667);
            this.SystemInfoPage.TabIndex = 0;
            this.SystemInfoPage.Text = "系统参数";
            // 
            // SystemConfigInfo
            // 
            this.SystemConfigInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemConfigInfo.Controls.Add(this.SysInfoDgv);
            this.SystemConfigInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SystemConfigInfo.Location = new System.Drawing.Point(6, 8);
            this.SystemConfigInfo.Name = "SystemConfigInfo";
            this.SystemConfigInfo.Size = new System.Drawing.Size(1330, 652);
            this.SystemConfigInfo.TabIndex = 1;
            this.SystemConfigInfo.TabStop = false;
            // 
            // SysInfoDgv
            // 
            this.SysInfoDgv.AllowUserToAddRows = false;
            this.SysInfoDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SysInfoDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SysInfoDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SysInfoDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SysInfoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SysInfoDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SetupSnDgv,
            this.SetupNameDgv,
            this.SetupValueDgv});
            this.SysInfoDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SysInfoDgv.EnableHeadersVisualStyles = false;
            this.SysInfoDgv.Location = new System.Drawing.Point(3, 22);
            this.SysInfoDgv.MultiSelect = false;
            this.SysInfoDgv.Name = "SysInfoDgv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SysInfoDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.SysInfoDgv.RowHeadersWidth = 25;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SysInfoDgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.SysInfoDgv.RowTemplate.Height = 30;
            this.SysInfoDgv.Size = new System.Drawing.Size(1324, 627);
            this.SysInfoDgv.TabIndex = 4;
            this.SysInfoDgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SysInfoDgv_CellEndEdit);
            this.SysInfoDgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.SysInfoDgv_CellLeave);
            this.SysInfoDgv.Paint += new System.Windows.Forms.PaintEventHandler(this.SysInfoDgv_Paint);
            this.SysInfoDgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SysInfoDgv_KeyDown);
            this.SysInfoDgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SysInfoDgv_KeyPress);
            this.SysInfoDgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SysInfoDgv_MouseClick);
            // 
            // SetupSnDgv
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetupSnDgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.SetupSnDgv.HeaderText = "序号";
            this.SetupSnDgv.Name = "SetupSnDgv";
            this.SetupSnDgv.ReadOnly = true;
            this.SetupSnDgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SetupSnDgv.Width = 70;
            // 
            // SetupNameDgv
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetupNameDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.SetupNameDgv.HeaderText = "名称";
            this.SetupNameDgv.Name = "SetupNameDgv";
            this.SetupNameDgv.ReadOnly = true;
            this.SetupNameDgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SetupNameDgv.Width = 300;
            // 
            // SetupValueDgv
            // 
            this.SetupValueDgv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetupValueDgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.SetupValueDgv.HeaderText = "值";
            this.SetupValueDgv.Name = "SetupValueDgv";
            this.SetupValueDgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SetupValueDgv.Width = 29;
            // 
            // DutInfoPage
            // 
            this.DutInfoPage.Controls.Add(this.DutInfoGrop);
            this.DutInfoPage.Controls.Add(this.DutInfoTbc);
            this.DutInfoPage.Location = new System.Drawing.Point(4, 26);
            this.DutInfoPage.Name = "DutInfoPage";
            this.DutInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.DutInfoPage.Size = new System.Drawing.Size(1190, 578);
            this.DutInfoPage.TabIndex = 4;
            this.DutInfoPage.Text = "设备参数";
            this.DutInfoPage.UseVisualStyleBackColor = true;
            // 
            // DutInfoGrop
            // 
            this.DutInfoGrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DutInfoGrop.Controls.Add(this.DutInfoDevList);
            this.DutInfoGrop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutInfoGrop.Location = new System.Drawing.Point(3, 8);
            this.DutInfoGrop.Name = "DutInfoGrop";
            this.DutInfoGrop.Size = new System.Drawing.Size(312, 560);
            this.DutInfoGrop.TabIndex = 8;
            this.DutInfoGrop.TabStop = false;
            this.DutInfoGrop.Text = "设备列表";
            // 
            // DutInfoDevList
            // 
            this.DutInfoDevList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DutInfoDevList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutInfoDevList.FormattingEnabled = true;
            this.DutInfoDevList.ItemHeight = 16;
            this.DutInfoDevList.Location = new System.Drawing.Point(3, 20);
            this.DutInfoDevList.Name = "DutInfoDevList";
            this.DutInfoDevList.Size = new System.Drawing.Size(303, 532);
            this.DutInfoDevList.TabIndex = 7;
            // 
            // DutInfoTbc
            // 
            this.DutInfoTbc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DutInfoTbc.ContextMenuStrip = this.DutRightMenu;
            this.DutInfoTbc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutInfoTbc.Location = new System.Drawing.Point(323, 8);
            this.DutInfoTbc.Name = "DutInfoTbc";
            this.DutInfoTbc.SelectedIndex = 0;
            this.DutInfoTbc.Size = new System.Drawing.Size(861, 560);
            this.DutInfoTbc.TabIndex = 6;
            this.DutInfoTbc.SelectedIndexChanged += new System.EventHandler(this.DutInfoTbc_SelectedIndexChanged);
            // 
            // DutRightMenu
            // 
            this.DutRightMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDut,
            this.DeleteDut});
            this.DutRightMenu.Name = "RigtMenu";
            this.DutRightMenu.Size = new System.Drawing.Size(163, 52);
            // 
            // AddDut
            // 
            this.AddDut.Name = "AddDut";
            this.AddDut.Size = new System.Drawing.Size(162, 24);
            this.AddDut.Text = "添加测试窗口";
            this.AddDut.Click += new System.EventHandler(this.AddDutInfo_Click);
            // 
            // DeleteDut
            // 
            this.DeleteDut.Name = "DeleteDut";
            this.DeleteDut.Size = new System.Drawing.Size(162, 24);
            this.DeleteDut.Text = "删除测试窗口";
            this.DeleteDut.Click += new System.EventHandler(this.DeleteDutInfo_Click);
            // 
            // TestItemInfoPage
            // 
            this.TestItemInfoPage.AutoScroll = true;
            this.TestItemInfoPage.Controls.Add(this.TestItemInfoGrop);
            this.TestItemInfoPage.Controls.Add(this.MethodItemGrop);
            this.TestItemInfoPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestItemInfoPage.Location = new System.Drawing.Point(4, 26);
            this.TestItemInfoPage.Name = "TestItemInfoPage";
            this.TestItemInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.TestItemInfoPage.Size = new System.Drawing.Size(1190, 578);
            this.TestItemInfoPage.TabIndex = 1;
            this.TestItemInfoPage.Text = "测试参数";
            this.TestItemInfoPage.UseVisualStyleBackColor = true;
            // 
            // TestItemInfoGrop
            // 
            this.TestItemInfoGrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestItemInfoGrop.Controls.Add(this.TestItemDgv);
            this.TestItemInfoGrop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestItemInfoGrop.Location = new System.Drawing.Point(259, 3);
            this.TestItemInfoGrop.Name = "TestItemInfoGrop";
            this.TestItemInfoGrop.Size = new System.Drawing.Size(925, 568);
            this.TestItemInfoGrop.TabIndex = 13;
            this.TestItemInfoGrop.TabStop = false;
            this.TestItemInfoGrop.Text = "测试项目列表";
            // 
            // TestItemDgv
            // 
            this.TestItemDgv.AllowUserToAddRows = false;
            this.TestItemDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TestItemDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TestItemDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TestItemDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestItemDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestNum,
            this.Method,
            this.TestName,
            this.UpLimit,
            this.LowLimit,
            this.RetestTimes,
            this.MethodMsg,
            this.ErrCode});
            this.TestItemDgv.ContextMenuStrip = this.TestItemRigtMenu;
            this.TestItemDgv.Location = new System.Drawing.Point(5, 20);
            this.TestItemDgv.Margin = new System.Windows.Forms.Padding(2);
            this.TestItemDgv.MultiSelect = false;
            this.TestItemDgv.Name = "TestItemDgv";
            this.TestItemDgv.RowHeadersWidth = 15;
            this.TestItemDgv.RowTemplate.Height = 23;
            this.TestItemDgv.Size = new System.Drawing.Size(580, 542);
            this.TestItemDgv.TabIndex = 20;
            this.TestItemDgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestItemDgv_CellEnter);
            this.TestItemDgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TestItemDgv_MouseClick);
            // 
            // TestNum
            // 
            this.TestNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            this.TestNum.DefaultCellStyle = dataGridViewCellStyle8;
            this.TestNum.HeaderText = "TestNum";
            this.TestNum.Name = "TestNum";
            this.TestNum.ReadOnly = true;
            this.TestNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestNum.Width = 70;
            // 
            // Method
            // 
            this.Method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            this.Method.DefaultCellStyle = dataGridViewCellStyle9;
            this.Method.HeaderText = "Methed";
            this.Method.Name = "Method";
            this.Method.ReadOnly = true;
            this.Method.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Method.Width = 62;
            // 
            // TestName
            // 
            this.TestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TestName.HeaderText = "TestName";
            this.TestName.Name = "TestName";
            this.TestName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestName.Width = 78;
            // 
            // UpLimit
            // 
            this.UpLimit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UpLimit.HeaderText = "UpLimit";
            this.UpLimit.Name = "UpLimit";
            this.UpLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UpLimit.Width = 70;
            // 
            // LowLimit
            // 
            this.LowLimit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LowLimit.HeaderText = "LowLimit";
            this.LowLimit.Name = "LowLimit";
            this.LowLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LowLimit.Width = 78;
            // 
            // RetestTimes
            // 
            this.RetestTimes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RetestTimes.HeaderText = "RetestTimes";
            this.RetestTimes.Name = "RetestTimes";
            this.RetestTimes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RetestTimes.Width = 102;
            // 
            // MethodMsg
            // 
            this.MethodMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MethodMsg.HeaderText = "MethodMsg";
            this.MethodMsg.Name = "MethodMsg";
            this.MethodMsg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MethodMsg.Width = 86;
            // 
            // ErrCode
            // 
            this.ErrCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ErrCode.HeaderText = "ErrCode";
            this.ErrCode.Name = "ErrCode";
            this.ErrCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ErrCode.Width = 70;
            // 
            // TestItemRigtMenu
            // 
            this.TestItemRigtMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestItemRigtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteTestItem,
            this.TestItemPrevious,
            this.TestItemNext});
            this.TestItemRigtMenu.Name = "RigtMenu";
            this.TestItemRigtMenu.Size = new System.Drawing.Size(163, 76);
            // 
            // DeleteTestItem
            // 
            this.DeleteTestItem.Name = "DeleteTestItem";
            this.DeleteTestItem.Size = new System.Drawing.Size(162, 24);
            this.DeleteTestItem.Text = "删除测试项目";
            this.DeleteTestItem.Click += new System.EventHandler(this.DeleteTestItem_Click);
            // 
            // TestItemPrevious
            // 
            this.TestItemPrevious.Name = "TestItemPrevious";
            this.TestItemPrevious.Size = new System.Drawing.Size(162, 24);
            this.TestItemPrevious.Text = "测试项目前移";
            this.TestItemPrevious.Click += new System.EventHandler(this.TestItemPrevious_Click);
            // 
            // TestItemNext
            // 
            this.TestItemNext.Name = "TestItemNext";
            this.TestItemNext.Size = new System.Drawing.Size(162, 24);
            this.TestItemNext.Text = "测试项目后移";
            this.TestItemNext.Click += new System.EventHandler(this.TestItemNext_Click);
            // 
            // MethodItemGrop
            // 
            this.MethodItemGrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MethodItemGrop.Controls.Add(this.TestMethodLB);
            this.MethodItemGrop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MethodItemGrop.Location = new System.Drawing.Point(6, 3);
            this.MethodItemGrop.Name = "MethodItemGrop";
            this.MethodItemGrop.Size = new System.Drawing.Size(247, 568);
            this.MethodItemGrop.TabIndex = 12;
            this.MethodItemGrop.TabStop = false;
            this.MethodItemGrop.Text = "方法列表";
            // 
            // TestMethodLB
            // 
            this.TestMethodLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TestMethodLB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestMethodLB.FormattingEnabled = true;
            this.TestMethodLB.HorizontalScrollbar = true;
            this.TestMethodLB.ItemHeight = 16;
            this.TestMethodLB.Location = new System.Drawing.Point(4, 20);
            this.TestMethodLB.Name = "TestMethodLB";
            this.TestMethodLB.ScrollAlwaysVisible = true;
            this.TestMethodLB.Size = new System.Drawing.Size(240, 532);
            this.TestMethodLB.TabIndex = 0;
            this.TestMethodLB.DoubleClick += new System.EventHandler(this.TestItemLV_DoubleClick);
            // 
            // ModifyPasswordPage
            // 
            this.ModifyPasswordPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ModifyPasswordPage.Controls.Add(this.MDUserNameLB);
            this.ModifyPasswordPage.Controls.Add(this.label1);
            this.ModifyPasswordPage.Controls.Add(this.MDConfirmPassWordTB);
            this.ModifyPasswordPage.Controls.Add(this.MDPassWordTB);
            this.ModifyPasswordPage.Controls.Add(this.MDcancelBTN);
            this.ModifyPasswordPage.Controls.Add(this.ModifyBTN);
            this.ModifyPasswordPage.Location = new System.Drawing.Point(4, 26);
            this.ModifyPasswordPage.Name = "ModifyPasswordPage";
            this.ModifyPasswordPage.Padding = new System.Windows.Forms.Padding(3);
            this.ModifyPasswordPage.Size = new System.Drawing.Size(1190, 578);
            this.ModifyPasswordPage.TabIndex = 2;
            this.ModifyPasswordPage.Text = "修改密码";
            // 
            // MDUserNameLB
            // 
            this.MDUserNameLB.AutoSize = true;
            this.MDUserNameLB.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MDUserNameLB.Location = new System.Drawing.Point(386, 193);
            this.MDUserNameLB.Name = "MDUserNameLB";
            this.MDUserNameLB.Size = new System.Drawing.Size(73, 21);
            this.MDUserNameLB.TabIndex = 14;
            this.MDUserNameLB.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(386, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "请输入用户名和密码";
            // 
            // MDConfirmPassWordTB
            // 
            this.MDConfirmPassWordTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MDConfirmPassWordTB.Location = new System.Drawing.Point(390, 293);
            this.MDConfirmPassWordTB.MaxLength = 20;
            this.MDConfirmPassWordTB.Name = "MDConfirmPassWordTB";
            this.MDConfirmPassWordTB.Size = new System.Drawing.Size(294, 29);
            this.MDConfirmPassWordTB.TabIndex = 1;
            this.MDConfirmPassWordTB.Text = "再次输入密码";
            this.MDConfirmPassWordTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MDConfirmPassWordTB_MouseClick);
            this.MDConfirmPassWordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MDConfirmPassWordTB_KeyDown);
            // 
            // MDPassWordTB
            // 
            this.MDPassWordTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MDPassWordTB.Location = new System.Drawing.Point(390, 238);
            this.MDPassWordTB.MaxLength = 20;
            this.MDPassWordTB.Name = "MDPassWordTB";
            this.MDPassWordTB.Size = new System.Drawing.Size(294, 29);
            this.MDPassWordTB.TabIndex = 0;
            this.MDPassWordTB.Text = "请输入新密码";
            this.MDPassWordTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MDPassWordTB_MouseClick);
            this.MDPassWordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MDPassWordTB_KeyDown);
            // 
            // MDcancelBTN
            // 
            this.MDcancelBTN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MDcancelBTN.Location = new System.Drawing.Point(559, 351);
            this.MDcancelBTN.Name = "MDcancelBTN";
            this.MDcancelBTN.Size = new System.Drawing.Size(106, 35);
            this.MDcancelBTN.TabIndex = 3;
            this.MDcancelBTN.Text = "取消";
            this.MDcancelBTN.UseVisualStyleBackColor = true;
            this.MDcancelBTN.Click += new System.EventHandler(this.MDcancelBTN_Click);
            // 
            // ModifyBTN
            // 
            this.ModifyBTN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModifyBTN.Location = new System.Drawing.Point(412, 351);
            this.ModifyBTN.Name = "ModifyBTN";
            this.ModifyBTN.Size = new System.Drawing.Size(106, 35);
            this.ModifyBTN.TabIndex = 2;
            this.ModifyBTN.Text = "修改";
            this.ModifyBTN.UseVisualStyleBackColor = true;
            this.ModifyBTN.Click += new System.EventHandler(this.ModifyBTN_Click);
            // 
            // CreatePasswordPage
            // 
            this.CreatePasswordPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CreatePasswordPage.Controls.Add(this.CRMessageLab);
            this.CreatePasswordPage.Controls.Add(this.CRUserNameTB);
            this.CreatePasswordPage.Controls.Add(this.CRPassWordTB);
            this.CreatePasswordPage.Controls.Add(this.CRcancelBTN);
            this.CreatePasswordPage.Controls.Add(this.CreateBTN);
            this.CreatePasswordPage.Location = new System.Drawing.Point(4, 26);
            this.CreatePasswordPage.Name = "CreatePasswordPage";
            this.CreatePasswordPage.Padding = new System.Windows.Forms.Padding(3);
            this.CreatePasswordPage.Size = new System.Drawing.Size(1190, 578);
            this.CreatePasswordPage.TabIndex = 3;
            this.CreatePasswordPage.Text = "创建新用户";
            // 
            // CRMessageLab
            // 
            this.CRMessageLab.AutoSize = true;
            this.CRMessageLab.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CRMessageLab.Location = new System.Drawing.Point(433, 181);
            this.CRMessageLab.Name = "CRMessageLab";
            this.CRMessageLab.Size = new System.Drawing.Size(199, 19);
            this.CRMessageLab.TabIndex = 9;
            this.CRMessageLab.Text = "请输入新用户名和密码";
            // 
            // CRUserNameTB
            // 
            this.CRUserNameTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CRUserNameTB.Location = new System.Drawing.Point(437, 220);
            this.CRUserNameTB.MaxLength = 20;
            this.CRUserNameTB.Name = "CRUserNameTB";
            this.CRUserNameTB.Size = new System.Drawing.Size(294, 29);
            this.CRUserNameTB.TabIndex = 0;
            this.CRUserNameTB.Text = "请输入新用户名";
            this.CRUserNameTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CRUserNameTB_MouseClick);
            // 
            // CRPassWordTB
            // 
            this.CRPassWordTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CRPassWordTB.Location = new System.Drawing.Point(437, 272);
            this.CRPassWordTB.MaxLength = 20;
            this.CRPassWordTB.Name = "CRPassWordTB";
            this.CRPassWordTB.Size = new System.Drawing.Size(294, 29);
            this.CRPassWordTB.TabIndex = 1;
            this.CRPassWordTB.Text = "请输入密码";
            this.CRPassWordTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CRPassWordTB_MouseClick);
            this.CRPassWordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CRPassWordTB_KeyDown);
            // 
            // CRcancelBTN
            // 
            this.CRcancelBTN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CRcancelBTN.Location = new System.Drawing.Point(614, 333);
            this.CRcancelBTN.Name = "CRcancelBTN";
            this.CRcancelBTN.Size = new System.Drawing.Size(106, 35);
            this.CRcancelBTN.TabIndex = 3;
            this.CRcancelBTN.Text = "取消";
            this.CRcancelBTN.UseVisualStyleBackColor = true;
            this.CRcancelBTN.Click += new System.EventHandler(this.CRcancelBTN_Click);
            // 
            // CreateBTN
            // 
            this.CreateBTN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateBTN.Location = new System.Drawing.Point(455, 333);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(106, 35);
            this.CreateBTN.TabIndex = 2;
            this.CreateBTN.Text = "创建";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "校准值";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Width = 91;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "是否使用目标值";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 167;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "目标值";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Width = 91;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "通道";
            this.dataGridViewComboBoxColumn2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.Width = 72;
            // 
            // dataGridViewTextBoxColumn32
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn32.HeaderText = "编号";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Width = 72;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "校准值";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Width = 91;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "是否使用目标值";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 167;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "目标值";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Width = 91;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "通道";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.Width = 72;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn29.HeaderText = "编号";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Width = 72;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportMenu,
            this.SaveMenu,
            this.SaveasMenu,
            this.ExtiMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1350, 28);
            this.menu.TabIndex = 16;
            this.menu.Text = "menuStrip1";
            // 
            // ImportMenu
            // 
            this.ImportMenu.Name = "ImportMenu";
            this.ImportMenu.Size = new System.Drawing.Size(77, 24);
            this.ImportMenu.Text = "导入文件";
            this.ImportMenu.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(49, 24);
            this.SaveMenu.Text = "保存";
            this.SaveMenu.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // SaveasMenu
            // 
            this.SaveasMenu.Name = "SaveasMenu";
            this.SaveasMenu.Size = new System.Drawing.Size(63, 24);
            this.SaveasMenu.Text = "另存为";
            this.SaveasMenu.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // ExtiMenu
            // 
            this.ExtiMenu.Name = "ExtiMenu";
            this.ExtiMenu.Size = new System.Drawing.Size(49, 24);
            this.ExtiMenu.Text = "退出";
            this.ExtiMenu.Click += new System.EventHandler(this.CancleBTN_Click);
            // 
            // SetMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.SysSetTbc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.Name = "SetMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SetForm_Paint);
            this.SysSetTbc.ResumeLayout(false);
            this.SystemInfoPage.ResumeLayout(false);
            this.SystemConfigInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SysInfoDgv)).EndInit();
            this.DutInfoPage.ResumeLayout(false);
            this.DutInfoGrop.ResumeLayout(false);
            this.DutRightMenu.ResumeLayout(false);
            this.TestItemInfoPage.ResumeLayout(false);
            this.TestItemInfoGrop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestItemDgv)).EndInit();
            this.TestItemRigtMenu.ResumeLayout(false);
            this.MethodItemGrop.ResumeLayout(false);
            this.ModifyPasswordPage.ResumeLayout(false);
            this.ModifyPasswordPage.PerformLayout();
            this.CreatePasswordPage.ResumeLayout(false);
            this.CreatePasswordPage.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl SysSetTbc;
        private System.Windows.Forms.TabPage SystemInfoPage;
        private System.Windows.Forms.TabPage TestItemInfoPage;
        private System.Windows.Forms.TabPage ModifyPasswordPage;
        private System.Windows.Forms.TabPage CreatePasswordPage;
        private System.Windows.Forms.Button CreateBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MDConfirmPassWordTB;
        private System.Windows.Forms.TextBox MDPassWordTB;
        private System.Windows.Forms.Button ModifyBTN;
        private System.Windows.Forms.Label CRMessageLab;
        private System.Windows.Forms.TextBox CRUserNameTB;
        private System.Windows.Forms.TextBox CRPassWordTB;
        private System.Windows.Forms.Button MDcancelBTN;
        private System.Windows.Forms.Button CRcancelBTN;
        private System.Windows.Forms.Label MDUserNameLB;
        private System.Windows.Forms.ListBox TestMethodLB;
        private System.Windows.Forms.TabPage DutInfoPage;
        private System.Windows.Forms.GroupBox MethodItemGrop;

        private GroupBox SystemConfigInfo;
        private DataGridView SysInfoDgv;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;

        private DataGridViewTextBoxColumn SetupSnDgv;
        private DataGridViewTextBoxColumn SetupNameDgv;
        private DataGridViewTextBoxColumn SetupValueDgv;
        private TabControl DutInfoTbc;
        private ContextMenuStrip TestItemRigtMenu;
        private ToolStripMenuItem DeleteTestItem;
        private ToolStripMenuItem TestItemPrevious;
        private ToolStripMenuItem TestItemNext;
        private MenuStrip menu;
        private ToolStripMenuItem ImportMenu;
        private ToolStripMenuItem SaveasMenu;
        private ToolStripMenuItem SaveMenu;
        private ToolStripMenuItem ExtiMenu;
        private ListBox DutInfoDevList;
        private GroupBox DutInfoGrop;
        private ContextMenuStrip DutRightMenu;
        private ToolStripMenuItem AddDut;
        private ToolStripMenuItem DeleteDut;
        private GroupBox TestItemInfoGrop;
        private DataGridView TestItemDgv;
        private DataGridViewTextBoxColumn TestNum;
        private DataGridViewTextBoxColumn Method;
        private DataGridViewTextBoxColumn TestName;
        private DataGridViewTextBoxColumn UpLimit;
        private DataGridViewTextBoxColumn LowLimit;
        private DataGridViewTextBoxColumn RetestTimes;
        private DataGridViewTextBoxColumn MethodMsg;
        private DataGridViewTextBoxColumn ErrCode;
    }
}