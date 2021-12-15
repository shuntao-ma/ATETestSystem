using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;
using System.Xml;

namespace ATETestSystem
{
    partial class PassWord : Form
    {
        public int Permission;
        private string UserSetupFilePath = AppDomain.CurrentDomain.BaseDirectory + "Config\\UserSetup.xml"; //Ini文件数据的径
        private List<UserSetup> UserItem;
        public PassWord()
        {
            Permission = -1;
            UserItem = new List<UserSetup>();
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(UserSetupFilePath); //加载XML
                XmlElement User = xml.DocumentElement; //获得文件的根节点
                foreach (XmlNode Item in User)
                {
                    UserSetup user = new UserSetup(Item);
                    UserItem.Add(user);
                }
            }
            catch (Exception e)
            {
                xml = new XmlDocument();
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Config";
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    directoryInfo.Create();
                }
                UserItem.Clear();
                UserSetup user = new UserSetup();
                UserItem.Add(user);

                XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                xml.AppendChild(node);
                XmlNode root = xml.CreateElement(nameof(UserSetup));//创建根节点 
                xml.AppendChild(root);

                XmlElement ItemTemp = xml.CreateElement(nameof(UserSetup) + 0);
                ItemTemp.SetAttribute(nameof(UserSetup.Name), UserItem[0].Name);
                ItemTemp.SetAttribute(nameof(UserSetup.PassWord), UserItem[0].PassWord);
                root.AppendChild(ItemTemp);//给节点添加属性
                xml.Save(UserSetupFilePath);
            }
            InitializeComponent();
            UserNameTB.Text = "请输入用户名";
            PassWordTB.Text = "请输入密码!";
            UserNameTB.Select();
            UserNameTB.Focus();
        }
        private void UserNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !UserNameTB.Text.Contains("请输入"))
            {
                PassWordTB.Select();
                PassWordTB.Focus();
                PassWordTB.Clear();
                PassWordTB.PasswordChar = '*';
            }
        }
        private void UserNameTB_MouseClick(object sender, MouseEventArgs e)
        {
            UserNameTB.Clear();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (PassWordTB.Text != String.Empty && UserNameTB.Text != String.Empty)
            {
                CheckUsernameAndPassword();
            }
            else
            {
                MessageLab.Text = "用户名或者密码不能为空";
                UserNameTB.Select();
                UserNameTB.Focus();
            }
        }
        private void PassWordTB_MouseClick(object sender, MouseEventArgs e)
        {
            PassWordTB.PasswordChar = '*';
            PassWordTB.Clear();
        }
        private void PassWordTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            PassWordTB.PasswordChar = '*';
        }
        private void PassWordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !PassWordTB.Text.Contains("请输入"))
            {
                OKBtn.Focus();
            }
        }
        private void CheckUsernameAndPassword()
        {
            string passWordmd5 = GetMD5(PassWordTB.Text);
            for (int i = 0; i < UserItem.Count; i++)
            {
                if (UserNameTB.Text == UserItem[i].Name && UserItem[i].PassWord == passWordmd5)
                {
                    switch (UserNameTB.Text)
                    {
                        case "Admin": Permission = 0;break;
                        default: Permission = 1;break;
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            MessageLab.Text = "用户名或者密码输入错误，请重新输入";
            PassWordTB.Select();
            PassWordTB.Focus();
        }
        private string GetMD5(string str)  //获取字符串的MD5值
        {
            //创建MD5对象
            MD5 md5 = MD5.Create();
            //开始加密
            //需要将字符串转换成字节数组
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] MD5Buffer = md5.ComputeHash(buffer);
            //将字符数组转换成字符串
            //字符数组-------字符串
            //第一种：将字节数组中每个元素按照指定的编码格式解析成字符串
            //MD5str = Encoding.Default.GetString(MD5Buffer);//此实例中无法将字符数组转换为字符串
            //第二种：直接将数组ToString()
            //将字节数组中的每个元素ToString()
            string MD5str = string.Empty;
            for (int i = 0; i < MD5Buffer.Length; i++)
            {
                MD5str += MD5Buffer[i].ToString("x2");//转换成32进制
            }
            return MD5str;
        }
    }
 
    #region 用户类
    class UserSetup
    {
        public string Name;
        public string PassWord;
        public UserSetup()
        {
            Name = "123456";
            PassWord = "e10adc3949ba59abbe56e057f20f883e";
        }
        public UserSetup(XmlNode node)
        {
            Name = node.Attributes[nameof(Name)].Value;
            PassWord = node.Attributes[nameof(PassWord)].Value;
        }
    }
    #endregion
}
