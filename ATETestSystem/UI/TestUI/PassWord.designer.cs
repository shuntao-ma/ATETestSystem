namespace ATETestSystem
{
    partial class PassWord
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
            this.OKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.PassWordTB = new System.Windows.Forms.TextBox();
            this.MessageLab = new System.Windows.Forms.Label();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKBtn.Location = new System.Drawing.Point(144, 155);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(100, 31);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "确认";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.Location = new System.Drawing.Point(291, 155);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 31);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // PassWordTB
            // 
            this.PassWordTB.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassWordTB.Location = new System.Drawing.Point(126, 107);
            this.PassWordTB.MaxLength = 20;
            this.PassWordTB.Name = "PassWordTB";
            this.PassWordTB.Size = new System.Drawing.Size(294, 31);
            this.PassWordTB.TabIndex = 1;
            this.PassWordTB.Text = "密码";
            this.PassWordTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PassWordTB_MouseClick);
            this.PassWordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PassWordTB_KeyDown);
            this.PassWordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PassWordTB_KeyPress);
            // 
            // MessageLab
            // 
            this.MessageLab.AutoSize = true;
            this.MessageLab.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageLab.Location = new System.Drawing.Point(122, 20);
            this.MessageLab.Name = "MessageLab";
            this.MessageLab.Size = new System.Drawing.Size(180, 19);
            this.MessageLab.TabIndex = 6;
            this.MessageLab.Text = "请输入用户名和密码";
            // 
            // UserNameTB
            // 
            this.UserNameTB.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameTB.Location = new System.Drawing.Point(126, 55);
            this.UserNameTB.MaxLength = 20;
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(294, 31);
            this.UserNameTB.TabIndex = 0;
            this.UserNameTB.Text = "用户名";
            this.UserNameTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserNameTB_MouseClick);
            this.UserNameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameTB_KeyDown);
            // 
            // PassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 204);
            this.Controls.Add(this.MessageLab);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.PassWordTB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OKBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PassWord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox PassWordTB;
        private System.Windows.Forms.Label MessageLab;
        private System.Windows.Forms.TextBox UserNameTB;
    }
}