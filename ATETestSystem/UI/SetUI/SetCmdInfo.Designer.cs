namespace ATETestSystem
{
    partial class SetCmdInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DevInitItemCmdTypeLb = new System.Windows.Forms.Label();
            this.DevInitItemCmdLb = new System.Windows.Forms.Label();
            this.DevInitItemTimeOutLb = new System.Windows.Forms.Label();
            this.CmdType = new System.Windows.Forms.ComboBox();
            this.DevInitItemCmd = new System.Windows.Forms.TextBox();
            this.DevInitItemTimeOut = new System.Windows.Forms.TextBox();
            this.DevInitItemParamDgv = new System.Windows.Forms.DataGridView();
            this.ParameRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddInitItemParam = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteInitItemParam = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamNext = new System.Windows.Forms.ToolStripMenuItem();
            this.DevInitItemRecDataDgv = new System.Windows.Forms.DataGridView();
            this.RecDataRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRecData = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRecData = new System.Windows.Forms.ToolStripMenuItem();
            this.RecDataPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.RecDataNext = new System.Windows.Forms.ToolStripMenuItem();
            this.DevNumber = new System.Windows.Forms.ComboBox();
            this.DevNumberLb = new System.Windows.Forms.Label();
            this.DevType = new System.Windows.Forms.ComboBox();
            this.DevTypeLb = new System.Windows.Forms.Label();
            this.DevInitItemParamNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevInitItemParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevInitItemRecDataNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevInitItemRecData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DevInitItemParamDgv)).BeginInit();
            this.ParameRightMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevInitItemRecDataDgv)).BeginInit();
            this.RecDataRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DevInitItemCmdTypeLb
            // 
            this.DevInitItemCmdTypeLb.AutoSize = true;
            this.DevInitItemCmdTypeLb.Enabled = false;
            this.DevInitItemCmdTypeLb.Location = new System.Drawing.Point(1, 42);
            this.DevInitItemCmdTypeLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DevInitItemCmdTypeLb.Name = "DevInitItemCmdTypeLb";
            this.DevInitItemCmdTypeLb.Size = new System.Drawing.Size(64, 16);
            this.DevInitItemCmdTypeLb.TabIndex = 0;
            this.DevInitItemCmdTypeLb.Text = "CmdType";
            // 
            // DevInitItemCmdLb
            // 
            this.DevInitItemCmdLb.AutoSize = true;
            this.DevInitItemCmdLb.Location = new System.Drawing.Point(6, 71);
            this.DevInitItemCmdLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DevInitItemCmdLb.Name = "DevInitItemCmdLb";
            this.DevInitItemCmdLb.Size = new System.Drawing.Size(32, 16);
            this.DevInitItemCmdLb.TabIndex = 1;
            this.DevInitItemCmdLb.Text = "Cmd";
            // 
            // DevInitItemTimeOutLb
            // 
            this.DevInitItemTimeOutLb.AutoSize = true;
            this.DevInitItemTimeOutLb.Location = new System.Drawing.Point(144, 40);
            this.DevInitItemTimeOutLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DevInitItemTimeOutLb.Name = "DevInitItemTimeOutLb";
            this.DevInitItemTimeOutLb.Size = new System.Drawing.Size(88, 16);
            this.DevInitItemTimeOutLb.TabIndex = 1;
            this.DevInitItemTimeOutLb.Text = "CmdTimeOut";
            // 
            // CmdType
            // 
            this.CmdType.Enabled = false;
            this.CmdType.FormattingEnabled = true;
            this.CmdType.Items.AddRange(new object[] {
            "String",
            "Byte"});
            this.CmdType.Location = new System.Drawing.Point(64, 38);
            this.CmdType.Margin = new System.Windows.Forms.Padding(4);
            this.CmdType.Name = "CmdType";
            this.CmdType.Size = new System.Drawing.Size(78, 24);
            this.CmdType.TabIndex = 2;
            // 
            // DevInitItemCmd
            // 
            this.DevInitItemCmd.Location = new System.Drawing.Point(40, 68);
            this.DevInitItemCmd.Margin = new System.Windows.Forms.Padding(4);
            this.DevInitItemCmd.Name = "DevInitItemCmd";
            this.DevInitItemCmd.Size = new System.Drawing.Size(245, 26);
            this.DevInitItemCmd.TabIndex = 3;
            // 
            // DevInitItemTimeOut
            // 
            this.DevInitItemTimeOut.Location = new System.Drawing.Point(230, 37);
            this.DevInitItemTimeOut.Margin = new System.Windows.Forms.Padding(4);
            this.DevInitItemTimeOut.Name = "DevInitItemTimeOut";
            this.DevInitItemTimeOut.Size = new System.Drawing.Size(55, 26);
            this.DevInitItemTimeOut.TabIndex = 3;
            // 
            // DevInitItemParamDgv
            // 
            this.DevInitItemParamDgv.AllowUserToAddRows = false;
            this.DevInitItemParamDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DevInitItemParamDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DevInitItemParamDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevInitItemParamDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevInitItemParamNum,
            this.DevInitItemParam});
            this.DevInitItemParamDgv.ContextMenuStrip = this.ParameRightMenu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DevInitItemParamDgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.DevInitItemParamDgv.GridColor = System.Drawing.SystemColors.Control;
            this.DevInitItemParamDgv.Location = new System.Drawing.Point(9, 100);
            this.DevInitItemParamDgv.Margin = new System.Windows.Forms.Padding(5);
            this.DevInitItemParamDgv.MultiSelect = false;
            this.DevInitItemParamDgv.Name = "DevInitItemParamDgv";
            this.DevInitItemParamDgv.RowTemplate.Height = 23;
            this.DevInitItemParamDgv.Size = new System.Drawing.Size(330, 110);
            this.DevInitItemParamDgv.TabIndex = 5;
            this.DevInitItemParamDgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevInitItemParamDgv_CellEndEdit);
            this.DevInitItemParamDgv.Leave += new System.EventHandler(this.DevInitItemParamDgv_Leave);
            // 
            // ParameRightMenu
            // 
            this.ParameRightMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParameRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddInitItemParam,
            this.DeleteInitItemParam,
            this.ParamPrevious,
            this.ParamNext});
            this.ParameRightMenu.Name = "RigtMenu";
            this.ParameRightMenu.Size = new System.Drawing.Size(135, 100);
            // 
            // AddInitItemParam
            // 
            this.AddInitItemParam.Name = "AddInitItemParam";
            this.AddInitItemParam.Size = new System.Drawing.Size(134, 24);
            this.AddInitItemParam.Text = "添加参数";
            this.AddInitItemParam.Click += new System.EventHandler(this.AddInitItemParam_Click);
            // 
            // DeleteInitItemParam
            // 
            this.DeleteInitItemParam.Name = "DeleteInitItemParam";
            this.DeleteInitItemParam.Size = new System.Drawing.Size(134, 24);
            this.DeleteInitItemParam.Text = "删除参数";
            this.DeleteInitItemParam.Click += new System.EventHandler(this.DeleteInitItemParam_Click);
            // 
            // ParamPrevious
            // 
            this.ParamPrevious.Name = "ParamPrevious";
            this.ParamPrevious.Size = new System.Drawing.Size(134, 24);
            this.ParamPrevious.Text = "参数前移";
            this.ParamPrevious.Click += new System.EventHandler(this.ParamPrevious_Click);
            // 
            // ParamNext
            // 
            this.ParamNext.Name = "ParamNext";
            this.ParamNext.Size = new System.Drawing.Size(134, 24);
            this.ParamNext.Text = "参数后移";
            this.ParamNext.Click += new System.EventHandler(this.ParamNext_Click);
            // 
            // DevInitItemRecDataDgv
            // 
            this.DevInitItemRecDataDgv.AllowUserToAddRows = false;
            this.DevInitItemRecDataDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DevInitItemRecDataDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DevInitItemRecDataDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevInitItemRecDataDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevInitItemRecDataNumber,
            this.DevInitItemRecData});
            this.DevInitItemRecDataDgv.ContextMenuStrip = this.RecDataRightMenu;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DevInitItemRecDataDgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.DevInitItemRecDataDgv.GridColor = System.Drawing.SystemColors.Control;
            this.DevInitItemRecDataDgv.Location = new System.Drawing.Point(9, 215);
            this.DevInitItemRecDataDgv.Margin = new System.Windows.Forms.Padding(5);
            this.DevInitItemRecDataDgv.MultiSelect = false;
            this.DevInitItemRecDataDgv.Name = "DevInitItemRecDataDgv";
            this.DevInitItemRecDataDgv.RowTemplate.Height = 23;
            this.DevInitItemRecDataDgv.Size = new System.Drawing.Size(330, 110);
            this.DevInitItemRecDataDgv.TabIndex = 5;
            this.DevInitItemRecDataDgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevInitItemRecDataDgv_CellEndEdit);
            this.DevInitItemRecDataDgv.Leave += new System.EventHandler(this.DevInitItemRecDataDgv_Leave);
            // 
            // RecDataRightMenu
            // 
            this.RecDataRightMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RecDataRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRecData,
            this.DeleteRecData,
            this.RecDataPrevious,
            this.RecDataNext});
            this.RecDataRightMenu.Name = "RigtMenu";
            this.RecDataRightMenu.Size = new System.Drawing.Size(149, 100);
            // 
            // AddRecData
            // 
            this.AddRecData.Name = "AddRecData";
            this.AddRecData.Size = new System.Drawing.Size(148, 24);
            this.AddRecData.Text = "添加返回值";
            this.AddRecData.Click += new System.EventHandler(this.AddRecData_Click);
            // 
            // DeleteRecData
            // 
            this.DeleteRecData.Name = "DeleteRecData";
            this.DeleteRecData.Size = new System.Drawing.Size(148, 24);
            this.DeleteRecData.Text = "删除返回值";
            this.DeleteRecData.Click += new System.EventHandler(this.DeleteRecData_Click);
            // 
            // RecDataPrevious
            // 
            this.RecDataPrevious.Name = "RecDataPrevious";
            this.RecDataPrevious.Size = new System.Drawing.Size(148, 24);
            this.RecDataPrevious.Text = "返回值前移";
            this.RecDataPrevious.Click += new System.EventHandler(this.RecDataPrevious_Click);
            // 
            // RecDataNext
            // 
            this.RecDataNext.Name = "RecDataNext";
            this.RecDataNext.Size = new System.Drawing.Size(148, 24);
            this.RecDataNext.Text = "返回值后移";
            this.RecDataNext.Click += new System.EventHandler(this.RecDataNext_Click);
            // 
            // DevNumber
            // 
            this.DevNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevNumber.FormattingEnabled = true;
            this.DevNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.DevNumber.Location = new System.Drawing.Point(230, 8);
            this.DevNumber.Margin = new System.Windows.Forms.Padding(2);
            this.DevNumber.Name = "DevNumber";
            this.DevNumber.Size = new System.Drawing.Size(55, 24);
            this.DevNumber.TabIndex = 24;
            // 
            // DevNumberLb
            // 
            this.DevNumberLb.AutoSize = true;
            this.DevNumberLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevNumberLb.Location = new System.Drawing.Point(145, 11);
            this.DevNumberLb.Name = "DevNumberLb";
            this.DevNumberLb.Size = new System.Drawing.Size(80, 16);
            this.DevNumberLb.TabIndex = 23;
            this.DevNumberLb.Text = "DevNumber";
            // 
            // DevType
            // 
            this.DevType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevType.FormattingEnabled = true;
            this.DevType.Items.AddRange(new object[] {
            "Serial",
            "Net",
            "USB"});
            this.DevType.Location = new System.Drawing.Point(64, 8);
            this.DevType.Margin = new System.Windows.Forms.Padding(2);
            this.DevType.Name = "DevType";
            this.DevType.Size = new System.Drawing.Size(78, 24);
            this.DevType.TabIndex = 22;
            // 
            // DevTypeLb
            // 
            this.DevTypeLb.AutoSize = true;
            this.DevTypeLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevTypeLb.Location = new System.Drawing.Point(1, 11);
            this.DevTypeLb.Name = "DevTypeLb";
            this.DevTypeLb.Size = new System.Drawing.Size(64, 16);
            this.DevTypeLb.TabIndex = 21;
            this.DevTypeLb.Text = "DevType";
            // 
            // DevInitItemParamNum
            // 
            this.DevInitItemParamNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevInitItemParamNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.DevInitItemParamNum.HeaderText = "Number";
            this.DevInitItemParamNum.Name = "DevInitItemParamNum";
            this.DevInitItemParamNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevInitItemParamNum.Width = 62;
            // 
            // DevInitItemParam
            // 
            this.DevInitItemParam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevInitItemParam.DefaultCellStyle = dataGridViewCellStyle3;
            this.DevInitItemParam.HeaderText = "Param";
            this.DevInitItemParam.Name = "DevInitItemParam";
            this.DevInitItemParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevInitItemParam.Width = 54;
            // 
            // DevInitItemRecDataNumber
            // 
            this.DevInitItemRecDataNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevInitItemRecDataNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.DevInitItemRecDataNumber.HeaderText = "Number";
            this.DevInitItemRecDataNumber.Name = "DevInitItemRecDataNumber";
            this.DevInitItemRecDataNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevInitItemRecDataNumber.Width = 62;
            // 
            // DevInitItemRecData
            // 
            this.DevInitItemRecData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DevInitItemRecData.DefaultCellStyle = dataGridViewCellStyle7;
            this.DevInitItemRecData.HeaderText = "RecData";
            this.DevInitItemRecData.Name = "DevInitItemRecData";
            this.DevInitItemRecData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DevInitItemRecData.Width = 70;
            // 
            // SetCmdInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 330);
            this.Controls.Add(this.DevNumber);
            this.Controls.Add(this.DevNumberLb);
            this.Controls.Add(this.DevType);
            this.Controls.Add(this.DevTypeLb);
            this.Controls.Add(this.DevInitItemTimeOut);
            this.Controls.Add(this.DevInitItemCmd);
            this.Controls.Add(this.CmdType);
            this.Controls.Add(this.DevInitItemRecDataDgv);
            this.Controls.Add(this.DevInitItemParamDgv);
            this.Controls.Add(this.DevInitItemTimeOutLb);
            this.Controls.Add(this.DevInitItemCmdLb);
            this.Controls.Add(this.DevInitItemCmdTypeLb);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetCmdInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DevInitItem";
            this.Load += new System.EventHandler(this.SetCmdInfo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DevInitItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DevInitItemParamDgv)).EndInit();
            this.ParameRightMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DevInitItemRecDataDgv)).EndInit();
            this.RecDataRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DevInitItemCmdTypeLb;
        private System.Windows.Forms.Label DevInitItemCmdLb;
        private System.Windows.Forms.Label DevInitItemTimeOutLb;
        private System.Windows.Forms.ComboBox CmdType;
        private System.Windows.Forms.TextBox DevInitItemCmd;
        private System.Windows.Forms.TextBox DevInitItemTimeOut;
        private System.Windows.Forms.DataGridView DevInitItemParamDgv;
        private System.Windows.Forms.DataGridView DevInitItemRecDataDgv;
        private System.Windows.Forms.ContextMenuStrip ParameRightMenu;
        private System.Windows.Forms.ToolStripMenuItem AddInitItemParam;
        private System.Windows.Forms.ToolStripMenuItem DeleteInitItemParam;
        private System.Windows.Forms.ToolStripMenuItem ParamPrevious;
        private System.Windows.Forms.ToolStripMenuItem ParamNext;
        private System.Windows.Forms.ContextMenuStrip RecDataRightMenu;
        private System.Windows.Forms.ToolStripMenuItem AddRecData;
        private System.Windows.Forms.ToolStripMenuItem DeleteRecData;
        private System.Windows.Forms.ToolStripMenuItem RecDataPrevious;
        private System.Windows.Forms.ToolStripMenuItem RecDataNext;
        private System.Windows.Forms.ComboBox DevNumber;
        private System.Windows.Forms.Label DevNumberLb;
        private System.Windows.Forms.ComboBox DevType;
        private System.Windows.Forms.Label DevTypeLb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevInitItemParamNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevInitItemParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevInitItemRecDataNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevInitItemRecData;
    }
}