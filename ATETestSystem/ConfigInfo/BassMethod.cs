using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATETestSystem
{
    class BassMethod
    {
        public BassMethod(Dictionary<string, TestFunc> Meth)
        {
            Meth.Add(nameof(MesCheckProcess), MesCheckProcess);
            Meth.Add(nameof(MesUpdateTestResut), MesUpdateTestResut);
            Meth.Add(nameof(SendMethod), SendMethod);
        }
        #region 检查产品流程是否OK
        public virtual bool MesCheckProcess(TestItemInfo Item, DutInfo Info)//检查产品流程是否OK
        {
            try
            {
                if (SysSetup.Mes.MesFlag) //只有再SFC打开才可以检查流程
                {
                    Thread.Sleep(100);
                    Info.LogMsg("Method:" + Item.Name);
                    string logTemp = SysSetup.Mes.CheckProcess();
                    Info.LogMsg.Invoke(Info.DutNumber + logTemp);
                    if (logTemp.Contains("OK"))
                    {
                        Item.Value = Item.UpLimit;
                        return true;
                    }
                    else
                    {
                        Info.LogMsg.Invoke("Method:" + Item.Name + logTemp);
                        return false;
                    }
                }
                else
                {
                    Info.LogMsg.Invoke("Method:" + "没有连接MES系统");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 更新产品MES流程
        public virtual bool MesUpdateTestResut(TestItemInfo Item, DutInfo Info)//更新产品MES流程
        {
            try
            {
                if (SysSetup.Mes.MesFlag) //只有再SFC打开才可以检查流程
                {
                    Thread.Sleep(100);
                    Info.LogMsg("Method:" + Item.Name);
                    Info.LogMsg.Invoke("Method:" + Item.Name);
                    string logTemp = SysSetup.Mes.UpdateSFdata(Info.TestData, Info.Result, Info.Errcode);
                    Info.LogMsg(Info.DutNumber + logTemp);
                    if (logTemp.Contains("OK"))
                    {
                        Item.Value = Item.UpLimit;
                        return true;
                    }
                    else
                    {
                        Info.LogMsg("Method:" + Item.Name + logTemp);
                        Item.Value = "Fail";
                        return false;
                    }
                }
                else
                {
                    Info.LogMsg("Method:" + "没有连接MES系统");
                    return true;
                }
            }
            catch
            {
                Item.Value = "Fail";
                return false;
            }
        }
        #endregion

        public virtual bool SendMethod(TestItemInfo Item, DutInfo Info)//发送指令，确认返回数据是否与配置数据一致，相同返回true 不同返回 false
        {
            switch (Info.DutNumber)
            {
                
            }
            return false;
        }
    }
}
