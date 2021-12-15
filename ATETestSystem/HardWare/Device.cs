using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATETestSystem
{
    public abstract class Device//该类记录将数据转为byte类型后的设备信息
    {

        public DeviceInfo Dev;
        public TestInfo Logmessage;//使用此设备时需要显示的信息
        public List<byte> SendHead { get; set; }//发送数据的帧头
        public List<byte> SendTail { get; set; }//发送数据的帧尾
        public List<byte> RecHead { get; set; }//接收数据的帧头
        public List<byte> RecTail { get; set; }//接收数据的帧尾
        public List<byte[]> RecData { get; set; }//串口接收到的所有数据
        public Device()
        {
            SendHead = new List<byte>();
            SendTail = new List<byte>();
            RecHead = new List<byte>();
            RecTail = new List<byte>();
            RecData = new List<byte[]>();//串口接收到的所有数据
        }
        public void TransferData()
        {
            SendHead = StringToBytes(Dev.CmdType, Dev.CmdSendHead);
            if (Dev.CmdSendTail != "")
            {
                SendTail = StringToBytes(Dev.CmdType, Dev.CmdSendTail);
            }

            RecHead = StringToBytes(Dev.CmdType, Dev.CmdRecHead);
            if (Dev.CmdRecTail != "")
            {
                RecTail = StringToBytes(Dev.CmdType, Dev.CmdRecTail);
            }
            //RecTail.AddRange(new byte[] { 0x0a, 0x0d });

        }
        public List<byte[]> GetRecData(List<byte> allRecdata)//除去帧头帧尾后接收到的实际数据
        {
            List<byte[]> data = new List<byte[]>();//接收到的所有指令
            while (allRecdata.Count > RecHead.Count + RecTail.Count)//确认接收到的数据长度是否大于帧头的长度
            {
                int j = 0;
                for (j = 0; j < RecHead.Count; j++)//查找帧头
                {
                    if (RecHead[j] != allRecdata[j])
                    {
                        allRecdata.RemoveRange(0, j + 1); //与帧头不一致，移除不一致数据
                        break;
                    }
                }
                if (j == RecHead.Count)//确认是否找到帧头
                {
                    allRecdata.RemoveRange(0, j); //与帧头不一致，移除帧头数据
                    List<byte> CmdTemp = new List<byte>();
                    while (allRecdata.Count >= RecTail.Count)//确认接收到的数据长度是否大于帧尾的长度
                    {
                        for (j = 0; j < RecTail.Count; j++)
                        {
                            if (RecTail[j] != allRecdata[j])
                            {
                                for (int i = 0; i < j + 1; i++)
                                {
                                    CmdTemp.Add(allRecdata[i]);
                                }
                                allRecdata.RemoveRange(0, j + 1); //临时变量与帧头不一致，移除不一致数据
                                break;
                            }
                        }
                        if (j == RecTail.Count)//确认是否找到帧尾
                        {
                            allRecdata.RemoveRange(0, j); //找到帧尾后移除帧尾数据
                            data.Add(CmdTemp.ToArray());//将指令存入指令对列
                            break;
                        }
                    }
                }
            }
            return data;
        }
        public bool WaitDecodingFinish(List<byte> allRecdata, CmdInfo cmdinfo)//recData为""，表示发送完直接返回真，不用等待设备返回配置的关键字
        {
            try
            {
                RecData.Clear();
                double TimeOut = cmdinfo.CmdTimeOut;
                TimeOut = TimeOut == 0 ? 20 : (TimeOut * 1000) / 200;

                List<byte[]> CmdRecData = new List<byte[]>();
                for (int i = 0; i < cmdinfo.CmdRecdata.Count; i++)
                {
                    byte[] tempBytes = StringToBytes(cmdinfo.CmdType, cmdinfo.CmdRecdata[i]).ToArray();
                    if (tempBytes.Length == 0)
                    {
                        continue;
                    }
                    CmdRecData.Add(tempBytes);
                }
                if (CmdRecData.Count == 0)//配置文件确认是否需要等待设备返回对应数据，为0不需要对应数据
                {
                    return true;
                }

                while (TimeOut != 0)
                {
                    TimeOut--;
                    RecData = GetRecData(allRecdata);//获取符合协议的数据
                    if (RecData.Count > 0)//确认接收到的数据的数量是否大于0
                    {
                        for (int i = 0; i < RecData.Count; i++)
                        {
                            for (int k = 0; k < CmdRecData.Count; k++)
                            {
                                if (CmdRecData[k].Length == RecData[i].Length)//比对配置的返回数据和接收到的数据是否一致
                                {
                                    int j = 0;
                                    for (; j < CmdRecData[k].Length; j++)
                                    {
                                        if (RecData[i][j] != CmdRecData[k][j])
                                        {
                                            break;
                                        }
                                    }
                                    if (j == CmdRecData[k].Length)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(200);
                }
                return false;
            }
            catch (Exception e)
            {
                Logmessage(e.Message);
                return false;
            }
        }
        public List<byte> StringToBytes(string type, string hexString)//Hex数据转为byte
        {
            List<byte> arryByte = null;
            switch (type)
            {
                case "Byte":
                    {
                        var arrstr = hexString.Split(new[] { "0x", " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                        arryByte = new List<byte>();
                        for (int i = 0; i < arrstr.Length; i++)
                        {
                            byte intval = 0;
                            intval = byte.Parse(arrstr[i], NumberStyles.HexNumber);
                            arryByte.Add(intval);
                        }
                    }
                    break;
                case "String":
                    {
                        //hexString = System.Text.RegularExpressions.Regex.Escape(hexString);//将转义字符转为转义符串
                        hexString = System.Text.RegularExpressions.Regex.Unescape(hexString);//将转义字符串转为转义符
                        arryByte = Encoding.ASCII.GetBytes(hexString).ToList();
                    }
                    break;
            }
            return arryByte;
        }
        public abstract bool DevOpen();
        public abstract bool DevSendData(CmdInfo cmd);
        public abstract void DevClose();
    }

}
