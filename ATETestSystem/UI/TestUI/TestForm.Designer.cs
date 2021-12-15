namespace ATETestSystem
{
    partial class TestForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TestStatusStrip = new System.Windows.Forms.StatusStrip();
            this.TestProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TestDutTable = new System.Windows.Forms.TabControl();
            this.TestPage = new System.Windows.Forms.TabPage();
            this.TestDataGridView = new System.Windows.Forms.DataGridView();
            this.TestInfoPage = new System.Windows.Forms.TabPage();
            this.DevCheckedInfo = new System.Windows.Forms.CheckedListBox();
            this.TestLog = new System.Windows.Forms.RichTextBox();
            this.PassBtn = new System.Windows.Forms.Button();
            this.FailBtn = new System.Windows.Forms.Button();
            this.ResPictureBox = new System.Windows.Forms.PictureBox();
            this.DutNumberLab = new System.Windows.Forms.Label();
            this.TestTimesLab = new System.Windows.Forms.Label();
            this.PassCountLab = new System.Windows.Forms.Label();
            this.FailCountLab = new System.Windows.Forms.Label();
            this.MethodsInfoLab = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.TestNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestStatusStrip.SuspendLayout();
            this.TestDutTable.SuspendLayout();
            this.TestPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).BeginInit();
            this.TestInfoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TestStatusStrip
            // 
            this.TestStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestProgressBar});
            this.TestStatusStrip.Location = new System.Drawing.Point(0, 489);
            this.TestStatusStrip.Name = "TestStatusStrip";
            this.TestStatusStrip.Size = new System.Drawing.Size(712, 22);
            this.TestStatusStrip.TabIndex = 57;
            this.TestStatusStrip.Text = "statusStrip1";
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.AutoSize = false;
            this.TestProgressBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TestProgressBar.ForeColor = System.Drawing.Color.Blue;
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.TestProgressBar.Size = new System.Drawing.Size(300, 16);
            this.TestProgressBar.Step = 5;
            // 
            // TestDutTable
            // 
            this.TestDutTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestDutTable.Controls.Add(this.TestPage);
            this.TestDutTable.Controls.Add(this.TestInfoPage);
            this.TestDutTable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestDutTable.Location = new System.Drawing.Point(1, 70);
            this.TestDutTable.Name = "TestDutTable";
            this.TestDutTable.SelectedIndex = 0;
            this.TestDutTable.Size = new System.Drawing.Size(708, 351);
            this.TestDutTable.TabIndex = 58;
            this.TestDutTable.SelectedIndexChanged += new System.EventHandler(this.TestDutTable_SelectedIndexChanged);
            // 
            // TestPage
            // 
            this.TestPage.Controls.Add(this.TestDataGridView);
            this.TestPage.Location = new System.Drawing.Point(4, 24);
            this.TestPage.Name = "TestPage";
            this.TestPage.Padding = new System.Windows.Forms.Padding(3);
            this.TestPage.Size = new System.Drawing.Size(700, 323);
            this.TestPage.TabIndex = 0;
            this.TestPage.Text = "TestWindow";
            this.TestPage.UseVisualStyleBackColor = true;
            // 
            // TestDataGridView
            // 
            this.TestDataGridView.AllowUserToAddRows = false;
            this.TestDataGridView.AllowUserToResizeRows = false;
            this.TestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TestDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TestDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestNumber,
            this.TestName,
            this.UpLimit,
            this.Value,
            this.LowLimit,
            this.Result});
            this.TestDataGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TestDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.TestDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TestDataGridView.Name = "TestDataGridView";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TestDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.TestDataGridView.RowHeadersVisible = false;
            this.TestDataGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TestDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.TestDataGridView.RowTemplate.Height = 30;
            this.TestDataGridView.RowTemplate.ReadOnly = true;
            this.TestDataGridView.Size = new System.Drawing.Size(694, 317);
            this.TestDataGridView.TabIndex = 3;
            this.TestDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TestDataGridView_MouseClick);
            // 
            // TestInfoPage
            // 
            this.TestInfoPage.Controls.Add(this.DevCheckedInfo);
            this.TestInfoPage.Controls.Add(this.TestLog);
            this.TestInfoPage.Location = new System.Drawing.Point(4, 24);
            this.TestInfoPage.Name = "TestInfoPage";
            this.TestInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.TestInfoPage.Size = new System.Drawing.Size(700, 323);
            this.TestInfoPage.TabIndex = 1;
            this.TestInfoPage.Text = "TestInfo";
            this.TestInfoPage.UseVisualStyleBackColor = true;
            // 
            // DevCheckedInfo
            // 
            this.DevCheckedInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DevCheckedInfo.FormattingEnabled = true;
            this.DevCheckedInfo.Location = new System.Drawing.Point(6, 6);
            this.DevCheckedInfo.Name = "DevCheckedInfo";
            this.DevCheckedInfo.Size = new System.Drawing.Size(154, 310);
            this.DevCheckedInfo.TabIndex = 78;
            // 
            // TestLog
            // 
            this.TestLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestLog.Location = new System.Drawing.Point(166, 3);
            this.TestLog.Name = "TestLog";
            this.TestLog.Size = new System.Drawing.Size(528, 311);
            this.TestLog.TabIndex = 75;
            this.TestLog.Text = "";
            // 
            // PassBtn
            // 
            this.PassBtn.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassBtn.Location = new System.Drawing.Point(1, 451);
            this.PassBtn.Name = "PassBtn";
            this.PassBtn.Size = new System.Drawing.Size(250, 35);
            this.PassBtn.TabIndex = 67;
            this.PassBtn.Text = "Pass";
            this.PassBtn.UseVisualStyleBackColor = true;
            // 
            // FailBtn
            // 
            this.FailBtn.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FailBtn.Location = new System.Drawing.Point(411, 451);
            this.FailBtn.Name = "FailBtn";
            this.FailBtn.Size = new System.Drawing.Size(250, 35);
            this.FailBtn.TabIndex = 68;
            this.FailBtn.Text = "Fail";
            this.FailBtn.UseVisualStyleBackColor = true;
            // 
            // ResPictureBox
            // 
            this.ResPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ResPictureBox.Location = new System.Drawing.Point(523, 4);
            this.ResPictureBox.Name = "ResPictureBox";
            this.ResPictureBox.Size = new System.Drawing.Size(183, 84);
            this.ResPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ResPictureBox.TabIndex = 71;
            this.ResPictureBox.TabStop = false;
            // 
            // DutNumberLab
            // 
            this.DutNumberLab.AutoSize = true;
            this.DutNumberLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DutNumberLab.Location = new System.Drawing.Point(8, 13);
            this.DutNumberLab.Name = "DutNumberLab";
            this.DutNumberLab.Size = new System.Drawing.Size(64, 16);
            this.DutNumberLab.TabIndex = 72;
            this.DutNumberLab.Text = "Number:";
            // 
            // TestTimesLab
            // 
            this.TestTimesLab.AutoSize = true;
            this.TestTimesLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestTimesLab.Location = new System.Drawing.Point(103, 13);
            this.TestTimesLab.Name = "TestTimesLab";
            this.TestTimesLab.Size = new System.Drawing.Size(56, 16);
            this.TestTimesLab.TabIndex = 72;
            this.TestTimesLab.Text = "Times:";
            // 
            // PassCountLab
            // 
            this.PassCountLab.AutoSize = true;
            this.PassCountLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassCountLab.Location = new System.Drawing.Point(8, 38);
            this.PassCountLab.Name = "PassCountLab";
            this.PassCountLab.Size = new System.Drawing.Size(48, 16);
            this.PassCountLab.TabIndex = 72;
            this.PassCountLab.Text = "Pass:";
            // 
            // FailCountLab
            // 
            this.FailCountLab.AutoSize = true;
            this.FailCountLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FailCountLab.Location = new System.Drawing.Point(103, 38);
            this.FailCountLab.Name = "FailCountLab";
            this.FailCountLab.Size = new System.Drawing.Size(48, 16);
            this.FailCountLab.TabIndex = 72;
            this.FailCountLab.Text = "Fail:";
            // 
            // MethodsInfoLab
            // 
            this.MethodsInfoLab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MethodsInfoLab.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MethodsInfoLab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MethodsInfoLab.Location = new System.Drawing.Point(6, 424);
            this.MethodsInfoLab.Name = "MethodsInfoLab";
            this.MethodsInfoLab.Size = new System.Drawing.Size(698, 24);
            this.MethodsInfoLab.TabIndex = 74;
            this.MethodsInfoLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestButton
            // 
            this.TestButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestButton.Enabled = false;
            this.TestButton.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestButton.Location = new System.Drawing.Point(1, 451);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(708, 35);
            this.TestButton.TabIndex = 73;
            this.TestButton.Text = "点击开始测试";
            this.TestButton.UseVisualStyleBackColor = true;
            // 
            // TestNumber
            // 
            this.TestNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.TestNumber.HeaderText = "Num";
            this.TestNumber.Name = "TestNumber";
            this.TestNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestNumber.Width = 34;
            // 
            // TestName
            // 
            this.TestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestName.DefaultCellStyle = dataGridViewCellStyle3;
            this.TestName.HeaderText = "Name";
            this.TestName.Name = "TestName";
            this.TestName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestName.Width = 41;
            // 
            // UpLimit
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpLimit.DefaultCellStyle = dataGridViewCellStyle4;
            this.UpLimit.HeaderText = "UpLimit";
            this.UpLimit.Name = "UpLimit";
            this.UpLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Value.DefaultCellStyle = dataGridViewCellStyle5;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LowLimit
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LowLimit.DefaultCellStyle = dataGridViewCellStyle6;
            this.LowLimit.HeaderText = "LowLimit";
            this.LowLimit.Name = "LowLimit";
            this.LowLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Result
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Result.DefaultCellStyle = dataGridViewCellStyle7;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(712, 511);
            this.ControlBox = false;
            this.Controls.Add(this.ResPictureBox);
            this.Controls.Add(this.FailBtn);
            this.Controls.Add(this.PassBtn);
            this.Controls.Add(this.MethodsInfoLab);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.FailCountLab);
            this.Controls.Add(this.PassCountLab);
            this.Controls.Add(this.TestTimesLab);
            this.Controls.Add(this.DutNumberLab);
            this.Controls.Add(this.TestDutTable);
            this.Controls.Add(this.TestStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TestForm_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.TestForm_Resize);
            this.TestStatusStrip.ResumeLayout(false);
            this.TestStatusStrip.PerformLayout();
            this.TestDutTable.ResumeLayout(false);
            this.TestPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).EndInit();
            this.TestInfoPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip TestStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar TestProgressBar;
        private System.Windows.Forms.TabControl TestDutTable;
        private System.Windows.Forms.TabPage TestPage;
        private System.Windows.Forms.Button PassBtn;
        private System.Windows.Forms.Button FailBtn;
        private System.Windows.Forms.TabPage TestInfoPage;
        private System.Windows.Forms.PictureBox ResPictureBox;
        private System.Windows.Forms.Label DutNumberLab;
        private System.Windows.Forms.Label TestTimesLab;
        private System.Windows.Forms.Label PassCountLab;
        private System.Windows.Forms.Label FailCountLab;
        private System.Windows.Forms.Label MethodsInfoLab;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.RichTextBox TestLog;
        private System.Windows.Forms.CheckedListBox DevCheckedInfo;
        private System.Windows.Forms.DataGridView TestDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
    }
}