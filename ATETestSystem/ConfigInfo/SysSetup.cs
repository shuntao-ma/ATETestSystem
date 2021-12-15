using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ATETestSystem
{
    class SysSetup//该类读写外部配置文件
    {
        private const string SysTemSetupFilePath = "Config\\SysTemSetup.xml"; //XML文件数据的径
        public static SysInfo System;
        public static MesInfo Mes;
        public static List<DutInfo> Dut;
        public static List<TestItemInfo> TestItem;
        public static Dictionary<string, TestFunc> Method;

        public static Dictionary<string, string> AllDevice;//动态记录电脑上连接设备的名称和VID PID信息
        public static Dictionary<int, Device> MainDev;//int 代表设备编号，SerialDevice代表设备
        public static List<Dictionary<int, Device>> DutDev;//List代表多少个Dut,int 代表设备编号，SerialDevice代表设备


        public static void ReadSystemSetupFile(string Path = SysTemSetupFilePath) //初始化测试数据内容
        {
            System = new SysInfo();
            Mes = new MesInfo();
            Dut = new List<DutInfo>();
            TestItem = new List<TestItemInfo>();
            if (File.Exists(Path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(Path); //加载XML
                XmlElement User = xml.DocumentElement; //获得文件的根节点
                foreach (XmlNode node in User)
                {
                    switch (node.Name)
                    {
                        case nameof(SysInfo): ReadSystemSetup(node); break;
                        case nameof(MesInfo): ReadMes(node); break;
                        case nameof(DutInfo): ReadDut(node); break;
                        case nameof(TestItemInfo): ReadTestItem(node); break;
                    }
                }
            }
            else
            {
                DutInfo Dut = new DutInfo();
                SysSetup.Dut.Add(Dut);
                TestItemInfo ItemSetup = new TestItemInfo();
                TestItem.Add(ItemSetup);
                WriteSystemSetupFile(false, Path);
                MessageBox.Show("SystemSetup配置文件读取异常！");
            }
            Method = new Dictionary<string, TestFunc>();
            string projectName = MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + nameof(BassMethod);
            Type Types = Type.GetType(projectName);
            Object obj = Activator.CreateInstance(Types, BindingFlags.Default, null, new object[] { Method }, null, null);//实例化

            string DllPath = AppDomain.CurrentDomain.BaseDirectory + "Dll";
            if (!Directory.Exists(DllPath))
            {
                Directory.CreateDirectory(DllPath);
            }
            DllPath = DllPath + "\\TestMethod.dll";
            if (File.Exists(DllPath))
            {
                Assembly ass = Assembly.LoadFile(DllPath); //加载dll
                Types = ass.GetType("ProductTestMethod.ProductMethod"); //获取该类 命名空间 + 类名, Class1 是我的类名
                obj = Activator.CreateInstance(Types, BindingFlags.Default, null, new object[] { Method }, null, null);//实例化
            }
            AllDevice = new Dictionary<string, string>();
            MainDev = new Dictionary<int, Device>();
            DutDev = new List<Dictionary<int, Device>>();
        }
        public static void WriteSystemSetupFile(bool replace = false, string path = SysTemSetupFilePath)
        {
            try
            {
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "Config";
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    directoryInfo.Create();
                }
                XmlDocument xml = new XmlDocument();
                XmlNode node = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                xml.AppendChild(node);
                XmlNode root = xml.CreateElement(nameof(SysSetup));//创建根节点  
                xml.AppendChild(root);
                WriteSystemSetup(xml, root);
                WriteMes(xml, root);
                WriteDut(xml, root);
                WriteTestItem(xml, root);
                xml.Save(SysTemSetupFilePath);
                if (replace)
                {
                    if (MessageBox.Show("是否要替换现有配置资料", "保存配置文件", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        xml.Save(path);
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("取消保存");
                    }
                }
                else
                {
                    xml.Save(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void ReadDevice(List<DeviceInfo> Dev, XmlNode DevItem)//读取配置文件设备的配置信息
        {
            foreach (XmlNode ItemTemp in DevItem)
            {
                DeviceInfo devtemp = new DeviceInfo();
                devtemp.DevType = ItemTemp.Attributes[nameof(DeviceInfo.DevType)].Value;
                devtemp.DevNumber = Convert.ToInt32(ItemTemp.Attributes[nameof(DeviceInfo.DevNumber)].Value);
                devtemp.DevName = ItemTemp.Attributes[nameof(DeviceInfo.DevName)].Value;
                devtemp.CmdType = ItemTemp.Attributes[nameof(DeviceInfo.CmdType)].Value;
                devtemp.CmdSendHead = ItemTemp.Attributes[nameof(DeviceInfo.CmdSendHead)].Value;
                devtemp.CmdSendTail = ItemTemp.Attributes[nameof(DeviceInfo.CmdSendTail)].Value;
                devtemp.CmdRecHead = ItemTemp.Attributes[nameof(DeviceInfo.CmdRecHead)].Value;
                devtemp.CmdRecTail = ItemTemp.Attributes[nameof(DeviceInfo.CmdRecTail)].Value;
                foreach (XmlNode temp in ItemTemp)
                {
                    if (temp.Name == nameof(DeviceInfo.DevParam))
                    {
                        foreach (XmlAttribute att in temp.Attributes)
                        {
                            devtemp.DevParam.Add(att.Value); //记录设备初始化时的参数
                        }
                    }

                    if (temp.Name == nameof(DeviceInfo.CmdItem))
                    {
                        foreach (XmlNode subtemp in temp)
                        {
                            CmdInfo InfoTemp = new CmdInfo();
                            InfoTemp.DevType = devtemp.DevType;
                            InfoTemp.DevNumber = devtemp.DevNumber;
                            InfoTemp.CmdType = devtemp.CmdType;
                            InfoTemp.Cmd = subtemp.Attributes[nameof(CmdInfo.Cmd)].Value;
                            InfoTemp.CmdTimeOut = Convert.ToInt32(subtemp.Attributes[nameof(CmdInfo.CmdTimeOut)].Value);
                            foreach (XmlAttribute att in subtemp.SelectSingleNode("//" + nameof(CmdInfo.CmdPram)).Attributes)
                            {
                                InfoTemp.CmdPram.Add(att.Value); //记录设备初始化时完成后发送指令的参数
                            }
                            foreach (XmlAttribute att in subtemp.SelectSingleNode("//" + nameof(CmdInfo.CmdRecdata)).Attributes)
                            {
                                InfoTemp.CmdRecdata.Add(att.Value); //记录设备初始化时完成后发送指令后需要获取到的返回值
                            }
                            devtemp.CmdItem.Add(InfoTemp);
                        }
                    }
                }
                Dev.Add(devtemp);
            }
        }
        private static void WrieDevice(XmlDocument xml, XmlElement DutTemp, List<DeviceInfo> Dev, string name)//写入配置文件设备的配置信息
        {
            XmlElement ExdevTemp = xml.CreateElement(name);
            DutTemp.AppendChild(ExdevTemp);
            for (int j = 0; j < Dev.Count; j++)
            {
                XmlElement devTemp = xml.CreateElement(name + j);
                ExdevTemp.AppendChild(devTemp);
                devTemp.SetAttribute(nameof(DeviceInfo.DevType), Dev[j].DevType);
                devTemp.SetAttribute(nameof(DeviceInfo.DevNumber), Dev[j].DevNumber.ToString());
                devTemp.SetAttribute(nameof(DeviceInfo.DevName), Dev[j].DevName);
                devTemp.SetAttribute(nameof(DeviceInfo.CmdType), Dev[j].CmdType);
                devTemp.SetAttribute(nameof(DeviceInfo.CmdSendHead), Dev[j].CmdSendHead);
                devTemp.SetAttribute(nameof(DeviceInfo.CmdSendTail), Dev[j].CmdSendTail);
                devTemp.SetAttribute(nameof(DeviceInfo.CmdRecHead), Dev[j].CmdRecHead);
                devTemp.SetAttribute(nameof(DeviceInfo.CmdRecTail), Dev[j].CmdRecTail);

                XmlElement paramTemp = xml.CreateElement(nameof(DeviceInfo.DevParam));
                devTemp.AppendChild(paramTemp);
                for (int k = 0; k < Dev[j].DevParam.Count; k++)
                {
                    paramTemp.SetAttribute(nameof(DeviceInfo.DevParam) + k, Dev[j].DevParam[k]);
                }

                XmlElement InitItemTemp = xml.CreateElement(nameof(DeviceInfo.CmdItem));
                devTemp.AppendChild(InitItemTemp);
                for (int i = 0; i < Dev[j].CmdItem.Count; i++)
                {
                    XmlElement ItemTemp = xml.CreateElement(nameof(DeviceInfo.CmdItem)+i);
                    InitItemTemp.AppendChild(ItemTemp);
                    ItemTemp.SetAttribute(nameof(CmdInfo.DevType), Dev[j].CmdItem[i].Cmd);
                    ItemTemp.SetAttribute(nameof(CmdInfo.DevNumber), Dev[j].CmdItem[i].Cmd);
                    ItemTemp.SetAttribute(nameof(CmdInfo.CmdType), Dev[j].CmdItem[i].Cmd);
                    ItemTemp.SetAttribute(nameof(CmdInfo.Cmd), Dev[j].CmdItem[i].Cmd);
                    ItemTemp.SetAttribute(nameof(CmdInfo.CmdTimeOut), Dev[j].CmdItem[i].CmdTimeOut.ToString());
                    XmlElement ParamTemp = xml.CreateElement(nameof(CmdInfo.CmdPram));
                    for (int k = 0; k < Dev[j].CmdItem[i].CmdPram.Count; k++)
                    {
                        ParamTemp.SetAttribute(nameof(CmdInfo.CmdPram) + k, Dev[j].CmdItem[i].CmdPram[k]);
                    }
                    ItemTemp.AppendChild(ParamTemp);

                    XmlElement RecdataTemp = xml.CreateElement(nameof(CmdInfo.CmdRecdata));
                    for (int k = 0; k < Dev[j].CmdItem[i].CmdRecdata.Count; k++)
                    {
                        RecdataTemp.SetAttribute(nameof(CmdInfo.CmdRecdata) + k, Dev[j].CmdItem[i].CmdRecdata[k]);
                    }
                    ItemTemp.AppendChild(RecdataTemp);
                }
            }
        }
        private static void ReadSystemSetup(XmlNode node) //读取配置文件系统的配置信息
        {
            System.ProjectName = node.Attributes[nameof(SysInfo.ProjectName)].Value;
            Mes.StationName = node.Attributes[nameof(MesInfo.StationName)].Value;
            System.SN_Sample = node.Attributes[nameof(SysInfo.SN_Sample)].Value;
            System.KeyStartFlag = node.Attributes[nameof(SysInfo.KeyStartFlag)].Value == "Yes";
            System.ScanStartFlag = node.Attributes[nameof(SysInfo.ScanStartFlag)].Value == "Yes";
            System.SaveInfoFlag = node.Attributes[nameof(SysInfo.SaveInfoFlag)].Value == "Yes";
            System.FailStopFlag = node.Attributes[nameof(SysInfo.FailStopFlag)].Value == "Yes";
            System.LoopTestFlag = node.Attributes[nameof(SysInfo.LoopTestFlag)].Value == "Yes";
            System.Column = Convert.ToInt32(node.Attributes[nameof(SysInfo.Column)].Value);
            System.DutSortMethod = node.Attributes[nameof(SysInfo.DutSortMethod)].Value == "Yes";
            System.AutoAddrFlag = node.Attributes[nameof(SysInfo.AutoAddrFlag)].Value == "Yes";
            foreach (XmlNode SubItem in node)
            {
                if (SubItem.Name == nameof(SysInfo.DeviceInfo))
                {
                    ReadDevice(System.DeviceInfo, SubItem);
                }
            }
        }
        private static void WriteSystemSetup(XmlDocument xmlWrite, XmlNode node)//写入配置文件系统的配置信息
        {
            XmlElement SysXml = xmlWrite.CreateElement(nameof(SysInfo));
            SysXml.SetAttribute(nameof(SysInfo.DutSortMethod), System.DutSortMethod ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.ProjectName), System.ProjectName);
            SysXml.SetAttribute(nameof(MesInfo.StationName), Mes.StationName);
            SysXml.SetAttribute(nameof(SysInfo.SN_Sample), System.SN_Sample);
            SysXml.SetAttribute(nameof(SysInfo.KeyStartFlag), System.KeyStartFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.ScanStartFlag), System.ScanStartFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.SaveInfoFlag), System.SaveInfoFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.FailStopFlag), System.FailStopFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.LoopTestFlag), System.LoopTestFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.AutoAddrFlag), System.AutoAddrFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(SysInfo.Column), System.Column.ToString());
            WrieDevice(xmlWrite, SysXml, System.DeviceInfo, nameof(SysInfo.DeviceInfo));
            node.AppendChild(SysXml);
        }
        private static void ReadMes(XmlNode node) //读取配置文件Mes的配置信息
        {
            foreach (XmlNode nodeX in node)
            {
                Mes.MesFlag = nodeX.Attributes[nameof(MesInfo.MesFlag)].Value == "Yes";
                Mes.Barcode = nodeX.Attributes[nameof(MesInfo.Barcode)].Value;
                Mes.CustID = nodeX.Attributes[nameof(MesInfo.CustID)].Value;
                Mes.PartNo = nodeX.Attributes[nameof(MesInfo.PartNo)].Value;
                Mes.Moid = nodeX.Attributes[nameof(MesInfo.Moid)].Value;
                Mes.LineId = nodeX.Attributes[nameof(MesInfo.LineId)].Value;
                Mes.StationId = nodeX.Attributes[nameof(MesInfo.StationId)].Value;
                Mes.ProductGroup = nodeX.Attributes[nameof(MesInfo.ProductGroup)].Value;
                Mes.UserId = nodeX.Attributes[nameof(MesInfo.UserId)].Value;
                Mes.EquipID = Convert.ToInt32(nodeX.Attributes[nameof(MesInfo.EquipID)].Value);
                Mes.MesIP = nodeX.Attributes[nameof(MesInfo.MesIP)].Value;
            }
        }
        private static void WriteMes(XmlDocument xmlWrite, XmlNode node)//写入配置文件Mes的配置信息
        {
            XmlElement SysXml = xmlWrite.CreateElement(nameof(MesInfo));
            SysXml.SetAttribute(nameof(MesInfo.MesFlag), Mes.MesFlag ? "Yes" : "No");
            SysXml.SetAttribute(nameof(MesInfo.MesIP), Mes.MesIP);
            SysXml.SetAttribute(nameof(MesInfo.Barcode), Mes.Barcode);
            SysXml.SetAttribute(nameof(MesInfo.CustID), Mes.CustID);
            SysXml.SetAttribute(nameof(MesInfo.PartNo), Mes.PartNo);
            SysXml.SetAttribute(nameof(MesInfo.Moid), Mes.Moid);
            SysXml.SetAttribute(nameof(MesInfo.LineId), Mes.LineId);
            SysXml.SetAttribute(nameof(MesInfo.StationId), Mes.StationId);
            SysXml.SetAttribute(nameof(MesInfo.ProductGroup), Mes.ProductGroup);
            SysXml.SetAttribute(nameof(MesInfo.UserId), Mes.UserId);
            SysXml.SetAttribute(nameof(MesInfo.EquipID), Mes.EquipID.ToString());
            node.AppendChild(SysXml);
        }
        private static void ReadDut(XmlNode node)//读取配置文件每个测试窗口的配置信息
        {
            DutInfo DutTemp = new DutInfo();
            foreach (XmlNode Item in node)
            {
                DutTemp = new DutInfo();
                DutTemp.DutNumber = Convert.ToInt32(Item.Attributes[nameof(DutInfo.DutNumber)].Value);
                DutTemp.PassCount = Convert.ToInt32(Item.Attributes[nameof(DutInfo.PassCount)].Value);
                DutTemp.FailCount = Convert.ToInt32(Item.Attributes[nameof(DutInfo.FailCount)].Value);
                foreach (XmlNode SubItem in Item)
                {
                    if (SubItem.Name == nameof(DutInfo.DeviceInfo))
                    {
                        ReadDevice(DutTemp.DeviceInfo, SubItem);
                    }
                }
                Dut.Add(DutTemp);
            }
        }
        private static void WriteDut(XmlDocument Xml, XmlNode node)//写入配置文件每个测试窗口的配置信息
        {
            XmlElement DutXml = Xml.CreateElement(nameof(DutInfo));
            node.AppendChild(DutXml);
            for (int i = 0; i < Dut.Count; i++)
            {
                XmlElement DutTemp = Xml.CreateElement(nameof(DutInfo) + i);
                DutTemp.SetAttribute(nameof(DutInfo.DutNumber), Dut[i].DutNumber.ToString());
                DutTemp.SetAttribute(nameof(DutInfo.PassCount), Dut[i].PassCount.ToString());
                DutTemp.SetAttribute(nameof(DutInfo.FailCount), Dut[i].FailCount.ToString());
                DutXml.AppendChild(DutTemp);
                WrieDevice(Xml, DutTemp, Dut[i].DeviceInfo, nameof(DutInfo.DeviceInfo));
            }
        }
        private static void ReadTestItem(XmlNode node) //读取配置文件每个测试项目的配置信息
        {
            TestItemInfo ItemTemp = new TestItemInfo();
            foreach (XmlNode ItemsXmlTemp in node)
            {
                ItemTemp = new TestItemInfo();
                ItemTemp.Number = Convert.ToInt32(ItemsXmlTemp.Attributes[nameof(TestItemInfo.Number)].Value);
                ItemTemp.Method = ItemsXmlTemp.Attributes[nameof(TestItemInfo.Method)].Value;
                ItemTemp.Name = ItemsXmlTemp.Attributes[nameof(TestItemInfo.Name)].Value;
                ItemTemp.UpLimit = ItemsXmlTemp.Attributes[nameof(TestItemInfo.UpLimit)].Value;
                ItemTemp.LowLimit = ItemsXmlTemp.Attributes[nameof(TestItemInfo.LowLimit)].Value;
                ItemTemp.RetestTimes = Convert.ToInt32(ItemsXmlTemp.Attributes[nameof(TestItemInfo.RetestTimes)].Value);
                ItemTemp.MethodMsg = ItemsXmlTemp.Attributes[nameof(TestItemInfo.MethodMsg)].Value;

                ItemTemp.CmdInfo.DevType = ItemsXmlTemp.Attributes[nameof(DeviceInfo.DevType)].Value;
                ItemTemp.CmdInfo.DevNumber = Convert.ToInt32(ItemsXmlTemp.Attributes[nameof(DeviceInfo.DevNumber)].Value);
                ItemTemp.CmdInfo.CmdType = ItemsXmlTemp.Attributes[nameof(DeviceInfo.CmdType)].Value;
                ItemTemp.CmdInfo.Cmd = ItemsXmlTemp.Attributes[nameof(CmdInfo.Cmd)].Value;
                foreach (XmlAttribute att in ItemsXmlTemp.SelectSingleNode("//" + nameof(CmdInfo.CmdPram)).Attributes)
                {
                    ItemTemp.CmdInfo.CmdPram.Add(att.Value);
                }
                foreach (XmlAttribute att in ItemsXmlTemp.SelectSingleNode("//" + nameof(CmdInfo.CmdRecdata)).Attributes)
                {
                    ItemTemp.CmdInfo.CmdRecdata.Add(att.Value);
                }
                ItemTemp.CmdInfo.CmdTimeOut = Convert.ToInt32(ItemsXmlTemp.Attributes[nameof(CmdInfo.CmdTimeOut)].Value);
                ItemTemp.ErrCode = ItemsXmlTemp.Attributes[nameof(TestItemInfo.ErrCode)].Value;
                TestItem.Add(ItemTemp);
            }
        }
        private static void WriteTestItem(XmlDocument xml, XmlNode node)//写入配置文件每个测试项目的配置信息
        {
            XmlElement ItemXml = xml.CreateElement(nameof(TestItemInfo));
            node.AppendChild(ItemXml);
            for (int i = 0; i < TestItem.Count; i++)
            {
                XmlElement ItemTemp = xml.CreateElement(nameof(TestItemInfo) + i);
                ItemTemp.SetAttribute(nameof(TestItemInfo.Number), TestItem[i].Number.ToString());
                ItemTemp.SetAttribute(nameof(TestItemInfo.Method), TestItem[i].Method);
                ItemTemp.SetAttribute(nameof(TestItemInfo.Name), TestItem[i].Name);
                ItemTemp.SetAttribute(nameof(TestItemInfo.UpLimit), TestItem[i].UpLimit);
                ItemTemp.SetAttribute(nameof(TestItemInfo.LowLimit), TestItem[i].LowLimit);
                ItemTemp.SetAttribute(nameof(TestItemInfo.RetestTimes), TestItem[i].RetestTimes.ToString());
                ItemTemp.SetAttribute(nameof(TestItemInfo.MethodMsg), TestItem[i].MethodMsg);
                ItemTemp.SetAttribute(nameof(TestItemInfo.ErrCode), TestItem[i].ErrCode);

                ItemTemp.SetAttribute(nameof(CmdInfo.DevType), TestItem[i].CmdInfo.DevType);
                ItemTemp.SetAttribute(nameof(CmdInfo.DevNumber), TestItem[i].CmdInfo.DevNumber.ToString());
                ItemTemp.SetAttribute(nameof(CmdInfo.CmdType), TestItem[i].CmdInfo.CmdType);
                ItemTemp.SetAttribute(nameof(CmdInfo.Cmd), TestItem[i].CmdInfo.Cmd);
                XmlElement ParamTemp = xml.CreateElement(nameof(CmdInfo.CmdPram));
                for (int j = 0; j < TestItem[i].CmdInfo.CmdPram.Count; j++)
                {
                    ParamTemp.SetAttribute(nameof(CmdInfo.CmdPram) + j, TestItem[i].CmdInfo.CmdPram[j]);
                }
                ItemTemp.AppendChild(ParamTemp);

                XmlElement RecdataTemp = xml.CreateElement(nameof(CmdInfo.CmdRecdata));
                for (int j = 0; j < TestItem[i].CmdInfo.CmdRecdata.Count; j++)
                {
                    RecdataTemp.SetAttribute(nameof(CmdInfo.CmdRecdata) + j, TestItem[i].CmdInfo.CmdRecdata[j]);
                }
                ItemTemp.AppendChild(RecdataTemp);
                ItemTemp.SetAttribute(nameof(CmdInfo.CmdTimeOut), TestItem[i].CmdInfo.CmdTimeOut.ToString());
                ItemXml.AppendChild(ItemTemp);
            }
        }
    }
}
