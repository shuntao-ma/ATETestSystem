namespace HID
{
    partial class HIDForm
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.clear_log_button = new System.Windows.Forms.Button();
            this.save_log_button = new System.Windows.Forms.Button();
            this.debug1_button = new System.Windows.Forms.Button();
            this.find_talma_button = new System.Windows.Forms.Button();
            this.get_dev_info_button = new System.Windows.Forms.Button();
            this.update_dev_button = new System.Windows.Forms.Button();
            this.get_feature_button = new System.Windows.Forms.Button();
            this.set_feature_button = new System.Windows.Forms.Button();
            this.real_time_label = new System.Windows.Forms.Label();
            this.dev_vid_label = new System.Windows.Forms.Label();
            this.dev_pid_label = new System.Windows.Forms.Label();
            this.dev_output_len_label = new System.Windows.Forms.Label();
            this.dev_input_len_label = new System.Windows.Forms.Label();
            this.dev_feature_len_label = new System.Windows.Forms.Label();
            this.dev_version_label = new System.Windows.Forms.Label();
            this.devi_vendor_name_label = new System.Windows.Forms.Label();
            this.devi_product_name_label = new System.Windows.Forms.Label();
            this.devi_serial_number_label = new System.Windows.Forms.Label();
            this.designed_label = new System.Windows.Forms.Label();
            this.get_feature_textBox = new System.Windows.Forms.TextBox();
            this.set_feature_textBox = new System.Windows.Forms.TextBox();
            this.log_textBox = new System.Windows.Forms.RichTextBox();
            this.dev_comboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clear_log_button
            // 
            this.clear_log_button.Location = new System.Drawing.Point(27, 21);
            this.clear_log_button.Name = "clear_log_button";
            this.clear_log_button.Size = new System.Drawing.Size(92, 45);
            this.clear_log_button.TabIndex = 0;
            this.clear_log_button.Text = "clear_log_button";
            this.clear_log_button.UseVisualStyleBackColor = true;
            // 
            // save_log_button
            // 
            this.save_log_button.Location = new System.Drawing.Point(155, 21);
            this.save_log_button.Name = "save_log_button";
            this.save_log_button.Size = new System.Drawing.Size(92, 45);
            this.save_log_button.TabIndex = 0;
            this.save_log_button.Text = "save_log_button";
            this.save_log_button.UseVisualStyleBackColor = true;
            // 
            // debug1_button
            // 
            this.debug1_button.Location = new System.Drawing.Point(278, 21);
            this.debug1_button.Name = "debug1_button";
            this.debug1_button.Size = new System.Drawing.Size(92, 45);
            this.debug1_button.TabIndex = 0;
            this.debug1_button.Text = "debug1_button";
            this.debug1_button.UseVisualStyleBackColor = true;
            // 
            // find_talma_button
            // 
            this.find_talma_button.Location = new System.Drawing.Point(392, 21);
            this.find_talma_button.Name = "find_talma_button";
            this.find_talma_button.Size = new System.Drawing.Size(92, 45);
            this.find_talma_button.TabIndex = 0;
            this.find_talma_button.Text = "find_talma_button";
            this.find_talma_button.UseVisualStyleBackColor = true;
            // 
            // get_dev_info_button
            // 
            this.get_dev_info_button.Location = new System.Drawing.Point(508, 21);
            this.get_dev_info_button.Name = "get_dev_info_button";
            this.get_dev_info_button.Size = new System.Drawing.Size(92, 45);
            this.get_dev_info_button.TabIndex = 0;
            this.get_dev_info_button.Text = "get_dev_info_button";
            this.get_dev_info_button.UseVisualStyleBackColor = true;
            this.get_dev_info_button.Click += new System.EventHandler(this.get_dev_info_button_Click);
            // 
            // update_dev_button
            // 
            this.update_dev_button.Location = new System.Drawing.Point(27, 73);
            this.update_dev_button.Name = "update_dev_button";
            this.update_dev_button.Size = new System.Drawing.Size(92, 45);
            this.update_dev_button.TabIndex = 0;
            this.update_dev_button.Text = "update_dev_button";
            this.update_dev_button.UseVisualStyleBackColor = true;
            this.update_dev_button.Click += new System.EventHandler(this.update_dev_button_Click);
            // 
            // get_feature_button
            // 
            this.get_feature_button.Location = new System.Drawing.Point(155, 73);
            this.get_feature_button.Name = "get_feature_button";
            this.get_feature_button.Size = new System.Drawing.Size(92, 45);
            this.get_feature_button.TabIndex = 0;
            this.get_feature_button.Text = "get_feature_button";
            this.get_feature_button.UseVisualStyleBackColor = true;
            // 
            // set_feature_button
            // 
            this.set_feature_button.Location = new System.Drawing.Point(278, 73);
            this.set_feature_button.Name = "set_feature_button";
            this.set_feature_button.Size = new System.Drawing.Size(92, 45);
            this.set_feature_button.TabIndex = 0;
            this.set_feature_button.Text = "set_feature_button";
            this.set_feature_button.UseVisualStyleBackColor = true;
            // 
            // real_time_label
            // 
            this.real_time_label.AutoSize = true;
            this.real_time_label.Location = new System.Drawing.Point(30, 169);
            this.real_time_label.Name = "real_time_label";
            this.real_time_label.Size = new System.Drawing.Size(95, 12);
            this.real_time_label.TabIndex = 1;
            this.real_time_label.Text = "real_time_label";
            // 
            // dev_vid_label
            // 
            this.dev_vid_label.AutoSize = true;
            this.dev_vid_label.Location = new System.Drawing.Point(30, 213);
            this.dev_vid_label.Name = "dev_vid_label";
            this.dev_vid_label.Size = new System.Drawing.Size(83, 12);
            this.dev_vid_label.TabIndex = 1;
            this.dev_vid_label.Text = "dev_vid_label";
            // 
            // dev_pid_label
            // 
            this.dev_pid_label.AutoSize = true;
            this.dev_pid_label.Location = new System.Drawing.Point(30, 256);
            this.dev_pid_label.Name = "dev_pid_label";
            this.dev_pid_label.Size = new System.Drawing.Size(83, 12);
            this.dev_pid_label.TabIndex = 1;
            this.dev_pid_label.Text = "dev_pid_label";
            // 
            // dev_output_len_label
            // 
            this.dev_output_len_label.AutoSize = true;
            this.dev_output_len_label.Location = new System.Drawing.Point(30, 305);
            this.dev_output_len_label.Name = "dev_output_len_label";
            this.dev_output_len_label.Size = new System.Drawing.Size(125, 12);
            this.dev_output_len_label.TabIndex = 1;
            this.dev_output_len_label.Text = "dev_output_len_label";
            // 
            // dev_input_len_label
            // 
            this.dev_input_len_label.AutoSize = true;
            this.dev_input_len_label.Location = new System.Drawing.Point(30, 349);
            this.dev_input_len_label.Name = "dev_input_len_label";
            this.dev_input_len_label.Size = new System.Drawing.Size(119, 12);
            this.dev_input_len_label.TabIndex = 1;
            this.dev_input_len_label.Text = "dev_input_len_label";
            // 
            // dev_feature_len_label
            // 
            this.dev_feature_len_label.AutoSize = true;
            this.dev_feature_len_label.Location = new System.Drawing.Point(30, 401);
            this.dev_feature_len_label.Name = "dev_feature_len_label";
            this.dev_feature_len_label.Size = new System.Drawing.Size(131, 12);
            this.dev_feature_len_label.TabIndex = 1;
            this.dev_feature_len_label.Text = "dev_feature_len_label";
            // 
            // dev_version_label
            // 
            this.dev_version_label.AutoSize = true;
            this.dev_version_label.Location = new System.Drawing.Point(30, 442);
            this.dev_version_label.Name = "dev_version_label";
            this.dev_version_label.Size = new System.Drawing.Size(107, 12);
            this.dev_version_label.TabIndex = 1;
            this.dev_version_label.Text = "dev_version_label";
            // 
            // devi_vendor_name_label
            // 
            this.devi_vendor_name_label.AutoSize = true;
            this.devi_vendor_name_label.Location = new System.Drawing.Point(30, 485);
            this.devi_vendor_name_label.Name = "devi_vendor_name_label";
            this.devi_vendor_name_label.Size = new System.Drawing.Size(137, 12);
            this.devi_vendor_name_label.TabIndex = 1;
            this.devi_vendor_name_label.Text = "devi_vendor_name_label";
            // 
            // devi_product_name_label
            // 
            this.devi_product_name_label.AutoSize = true;
            this.devi_product_name_label.Location = new System.Drawing.Point(30, 527);
            this.devi_product_name_label.Name = "devi_product_name_label";
            this.devi_product_name_label.Size = new System.Drawing.Size(143, 12);
            this.devi_product_name_label.TabIndex = 1;
            this.devi_product_name_label.Text = "devi_product_name_label";
            // 
            // devi_serial_number_label
            // 
            this.devi_serial_number_label.AutoSize = true;
            this.devi_serial_number_label.Location = new System.Drawing.Point(183, 169);
            this.devi_serial_number_label.Name = "devi_serial_number_label";
            this.devi_serial_number_label.Size = new System.Drawing.Size(149, 12);
            this.devi_serial_number_label.TabIndex = 1;
            this.devi_serial_number_label.Text = "devi_serial_number_label";
            // 
            // designed_label
            // 
            this.designed_label.AutoSize = true;
            this.designed_label.Location = new System.Drawing.Point(183, 213);
            this.designed_label.Name = "designed_label";
            this.designed_label.Size = new System.Drawing.Size(89, 12);
            this.designed_label.TabIndex = 1;
            this.designed_label.Text = "designed_label";
            // 
            // get_feature_textBox
            // 
            this.get_feature_textBox.Location = new System.Drawing.Point(403, 181);
            this.get_feature_textBox.Multiline = true;
            this.get_feature_textBox.Name = "get_feature_textBox";
            this.get_feature_textBox.Size = new System.Drawing.Size(316, 21);
            this.get_feature_textBox.TabIndex = 2;
            this.get_feature_textBox.Text = "get_feature_textBox";
            // 
            // set_feature_textBox
            // 
            this.set_feature_textBox.Location = new System.Drawing.Point(403, 208);
            this.set_feature_textBox.Multiline = true;
            this.set_feature_textBox.Name = "set_feature_textBox";
            this.set_feature_textBox.Size = new System.Drawing.Size(316, 24);
            this.set_feature_textBox.TabIndex = 2;
            this.set_feature_textBox.Text = "set_feature_textBox";
            // 
            // log_textBox
            // 
            this.log_textBox.Location = new System.Drawing.Point(403, 238);
            this.log_textBox.Name = "log_textBox";
            this.log_textBox.Size = new System.Drawing.Size(406, 324);
            this.log_textBox.TabIndex = 3;
            this.log_textBox.Text = "log_textBox";
            // 
            // dev_comboBox
            // 
            this.dev_comboBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dev_comboBox.FormattingEnabled = true;
            this.dev_comboBox.Location = new System.Drawing.Point(27, 124);
            this.dev_comboBox.Name = "dev_comboBox";
            this.dev_comboBox.Size = new System.Drawing.Size(1111, 22);
            this.dev_comboBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "set_feature_button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 572);
            this.Controls.Add(this.dev_comboBox);
            this.Controls.Add(this.log_textBox);
            this.Controls.Add(this.set_feature_textBox);
            this.Controls.Add(this.get_feature_textBox);
            this.Controls.Add(this.designed_label);
            this.Controls.Add(this.devi_serial_number_label);
            this.Controls.Add(this.devi_product_name_label);
            this.Controls.Add(this.devi_vendor_name_label);
            this.Controls.Add(this.dev_version_label);
            this.Controls.Add(this.dev_feature_len_label);
            this.Controls.Add(this.dev_input_len_label);
            this.Controls.Add(this.dev_output_len_label);
            this.Controls.Add(this.dev_pid_label);
            this.Controls.Add(this.dev_vid_label);
            this.Controls.Add(this.real_time_label);
            this.Controls.Add(this.get_dev_info_button);
            this.Controls.Add(this.find_talma_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.set_feature_button);
            this.Controls.Add(this.debug1_button);
            this.Controls.Add(this.get_feature_button);
            this.Controls.Add(this.save_log_button);
            this.Controls.Add(this.update_dev_button);
            this.Controls.Add(this.clear_log_button);
            this.Name = "HIDForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button clear_log_button;
        private System.Windows.Forms.Button save_log_button;
        private System.Windows.Forms.Button debug1_button;
        private System.Windows.Forms.Button find_talma_button;
        private System.Windows.Forms.Button get_dev_info_button;
        private System.Windows.Forms.Button update_dev_button;
        private System.Windows.Forms.Button get_feature_button;
        private System.Windows.Forms.Button set_feature_button;
        private System.Windows.Forms.Label real_time_label;
        private System.Windows.Forms.Label dev_vid_label;
        private System.Windows.Forms.Label dev_pid_label;
        private System.Windows.Forms.Label dev_output_len_label;
        private System.Windows.Forms.Label dev_input_len_label;
        private System.Windows.Forms.Label dev_feature_len_label;
        private System.Windows.Forms.Label dev_version_label;
        private System.Windows.Forms.Label devi_vendor_name_label;
        private System.Windows.Forms.Label devi_product_name_label;
        private System.Windows.Forms.Label devi_serial_number_label;
        private System.Windows.Forms.Label designed_label;
        private System.Windows.Forms.TextBox get_feature_textBox;
        private System.Windows.Forms.TextBox set_feature_textBox;
        private System.Windows.Forms.RichTextBox log_textBox;
        private System.Windows.Forms.ComboBox dev_comboBox;
        private System.Windows.Forms.Button button1;
    }
}

