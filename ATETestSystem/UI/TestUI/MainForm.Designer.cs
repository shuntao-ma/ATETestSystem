namespace ATETestSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.SetupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DevParamSetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DevPortSetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoopTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.MainRunMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainSp = new System.Windows.Forms.SplitContainer();
            this.DutText = new System.Windows.Forms.TextBox();
            this.DutLab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VerLab = new System.Windows.Forms.Label();
            this.StationIdLab = new System.Windows.Forms.Label();
            this.SnText = new System.Windows.Forms.TextBox();
            this.MoidLab = new System.Windows.Forms.Label();
            this.PartNoLab = new System.Windows.Forms.Label();
            this.LineId = new System.Windows.Forms.Label();
            this.UserIDLab = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSp)).BeginInit();
            this.MainSp.Panel1.SuspendLayout();
            this.MainSp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1291, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // SetupMenu
            // 
            this.SetupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DevParamSetMenu,
            this.DevPortSetMenu,
            this.LoopTestMenu,
            this.ExitMenu});
            this.SetupMenu.Name = "SetupMenu";
            this.SetupMenu.Size = new System.Drawing.Size(49, 24);
            this.SetupMenu.Text = "设置";
            // 
            // DevParamSetMenu
            // 
            this.DevParamSetMenu.Name = "DevParamSetMenu";
            this.DevParamSetMenu.Size = new System.Drawing.Size(162, 24);
            this.DevParamSetMenu.Text = "参数设置";
            this.DevParamSetMenu.Click += new System.EventHandler(this.DevParamSetMenu_Click);
            // 
            // DevPortSetMenu
            // 
            this.DevPortSetMenu.Name = "DevPortSetMenu";
            this.DevPortSetMenu.Size = new System.Drawing.Size(162, 24);
            this.DevPortSetMenu.Text = "端口配置";
            this.DevPortSetMenu.Click += new System.EventHandler(this.DevPortSetMenu_Click);
            // 
            // LoopTestMenu
            // 
            this.LoopTestMenu.Name = "LoopTestMenu";
            this.LoopTestMenu.Size = new System.Drawing.Size(162, 24);
            this.LoopTestMenu.Text = "开始循环测试";
            this.LoopTestMenu.Click += new System.EventHandler(this.LoopTestMenu_Click);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(162, 24);
            this.ExitMenu.Text = "退出";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(70, 24);
            this.helpMenu.Text = "帮助(&H)";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.contentsToolStripMenuItem.Text = "目录(&C)";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.indexToolStripMenuItem.Text = "索引(&I)";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.searchToolStripMenuItem.Text = "搜索(&S)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(179, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.aboutToolStripMenuItem.Text = "关于(&A) ... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainRunMsg});
            this.statusStrip.Location = new System.Drawing.Point(0, 808);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1291, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // MainRunMsg
            // 
            this.MainRunMsg.Name = "MainRunMsg";
            this.MainRunMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // MainSp
            // 
            this.MainSp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSp.Location = new System.Drawing.Point(0, 25);
            this.MainSp.Name = "MainSp";
            this.MainSp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSp.Panel1
            // 
            this.MainSp.Panel1.BackColor = System.Drawing.Color.Silver;
            this.MainSp.Panel1.Controls.Add(this.DutText);
            this.MainSp.Panel1.Controls.Add(this.DutLab);
            this.MainSp.Panel1.Controls.Add(this.label1);
            this.MainSp.Panel1.Controls.Add(this.VerLab);
            this.MainSp.Panel1.Controls.Add(this.StationIdLab);
            this.MainSp.Panel1.Controls.Add(this.SnText);
            this.MainSp.Panel1.Controls.Add(this.MoidLab);
            this.MainSp.Panel1.Controls.Add(this.PartNoLab);
            this.MainSp.Panel1.Controls.Add(this.LineId);
            this.MainSp.Panel1.Controls.Add(this.UserIDLab);
            this.MainSp.Panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainSp.Size = new System.Drawing.Size(1291, 783);
            this.MainSp.SplitterDistance = 86;
            this.MainSp.TabIndex = 5;
            // 
            // DutText
            // 
            this.DutText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutText.Location = new System.Drawing.Point(399, 10);
            this.DutText.MaxLength = 80;
            this.DutText.Multiline = true;
            this.DutText.Name = "DutText";
            this.DutText.Size = new System.Drawing.Size(53, 25);
            this.DutText.TabIndex = 61;
            this.DutText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DutText_KeyUp);
            // 
            // DutLab
            // 
            this.DutLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DutLab.AutoSize = true;
            this.DutLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutLab.Location = new System.Drawing.Point(361, 10);
            this.DutLab.Name = "DutLab";
            this.DutLab.Size = new System.Drawing.Size(32, 16);
            this.DutLab.TabIndex = 62;
            this.DutLab.Text = "Dut";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "SN";
            // 
            // VerLab
            // 
            this.VerLab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VerLab.AutoSize = true;
            this.VerLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerLab.Location = new System.Drawing.Point(704, 40);
            this.VerLab.Name = "VerLab";
            this.VerLab.Size = new System.Drawing.Size(40, 16);
            this.VerLab.TabIndex = 54;
            this.VerLab.Text = "Ver:";
            // 
            // StationIdLab
            // 
            this.StationIdLab.AutoSize = true;
            this.StationIdLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StationIdLab.Location = new System.Drawing.Point(444, 40);
            this.StationIdLab.Name = "StationIdLab";
            this.StationIdLab.Size = new System.Drawing.Size(88, 16);
            this.StationIdLab.TabIndex = 59;
            this.StationIdLab.Text = "StationID:";
            // 
            // SnText
            // 
            this.SnText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SnText.Location = new System.Drawing.Point(37, 9);
            this.SnText.MaxLength = 80;
            this.SnText.Name = "SnText";
            this.SnText.Size = new System.Drawing.Size(318, 26);
            this.SnText.TabIndex = 53;
            this.SnText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SnText_KeyUp);
            // 
            // MoidLab
            // 
            this.MoidLab.AutoSize = true;
            this.MoidLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MoidLab.Location = new System.Drawing.Point(173, 40);
            this.MoidLab.Name = "MoidLab";
            this.MoidLab.Size = new System.Drawing.Size(48, 16);
            this.MoidLab.TabIndex = 58;
            this.MoidLab.Text = "Moid:";
            // 
            // PartNoLab
            // 
            this.PartNoLab.AutoSize = true;
            this.PartNoLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNoLab.Location = new System.Drawing.Point(12, 40);
            this.PartNoLab.Name = "PartNoLab";
            this.PartNoLab.Size = new System.Drawing.Size(64, 16);
            this.PartNoLab.TabIndex = 55;
            this.PartNoLab.Text = "PartNo:";
            // 
            // LineId
            // 
            this.LineId.AutoSize = true;
            this.LineId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LineId.Location = new System.Drawing.Point(319, 40);
            this.LineId.Name = "LineId";
            this.LineId.Size = new System.Drawing.Size(64, 16);
            this.LineId.TabIndex = 57;
            this.LineId.Text = "LineId:";
            // 
            // UserIDLab
            // 
            this.UserIDLab.AutoSize = true;
            this.UserIDLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserIDLab.Location = new System.Drawing.Point(582, 40);
            this.UserIDLab.Name = "UserIDLab";
            this.UserIDLab.Size = new System.Drawing.Size(64, 16);
            this.UserIDLab.TabIndex = 56;
            this.UserIDLab.Text = "UserID:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 830);
            this.Controls.Add(this.MainSp);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.MainSp.Panel1.ResumeLayout(false);
            this.MainSp.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSp)).EndInit();
            this.MainSp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel MainRunMsg;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSp;
        private System.Windows.Forms.TextBox DutText;
        private System.Windows.Forms.Label DutLab;
        private System.Windows.Forms.Label VerLab;
        private System.Windows.Forms.TextBox SnText;
        private System.Windows.Forms.Label PartNoLab;
        private System.Windows.Forms.Label UserIDLab;
        private System.Windows.Forms.Label LineId;
        private System.Windows.Forms.Label MoidLab;
        private System.Windows.Forms.Label StationIdLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem SetupMenu;
        private System.Windows.Forms.ToolStripMenuItem DevParamSetMenu;
        private System.Windows.Forms.ToolStripMenuItem DevPortSetMenu;
        private System.Windows.Forms.ToolStripMenuItem LoopTestMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
    }
}



