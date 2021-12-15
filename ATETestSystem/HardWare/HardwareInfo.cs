﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Deployment.Application;
using System.Management;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace ATETestSystem
{

    public struct HIDD_VIDPID
    {
        public UInt16 VendorID;     // 供应商标识
        public UInt16 ProductID;    // 产品编号
    }

    public class HardwareInfo
    {


        //public List<HardwareData> Info;
        //public HardwareInfo()
        //{
        //    Info = new List<HardwareData>();
        //    Guid NewGuid = Guid.Empty;
        //    IntPtr MainIntPtr = SetupDiGetClassDevs(ref NewGuid, 0, IntPtr.Zero, DIGCF.DIGCF_ALLCLASSES | DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
        //    if (MainIntPtr.ToInt32() == -1)
        //    {
        //        return;
        //    }
        //    SP_DEVINFO_DATA Data = new SP_DEVINFO_DATA(Guid.Empty);
        //    StringBuilder Name = new StringBuilder(100);
        //    StringBuilder LoctionN = new StringBuilder(100);

        //    SP_DEVICE_INTERFACE_DATA interfaceInfo = new SP_DEVICE_INTERFACE_DATA();
        //    interfaceInfo.cbSize = Marshal.SizeOf(interfaceInfo);

        //    uint i = 0;
        //    while (SetupDiEnumDeviceInfo(MainIntPtr, i, Data))
        //    {
        //        SetupDiGetDeviceRegistryProperty(MainIntPtr, Data, SPDRP.SPDRP_LOCATION_INFORMATION, 0, LoctionN, (uint)LoctionN.Capacity, IntPtr.Zero);
        //        SetupDiGetDeviceRegistryProperty(MainIntPtr, Data, SPDRP.SPDRP_FRIENDLYNAME, 0, Name, (uint)Name.Capacity, IntPtr.Zero);
        //        Info.Add(new HardwareData(Data.classGuid, Name.ToString(), LoctionN.ToString(), Data.cbSize, Data.devInst, Data.reserved));
        //        i++;
        //    }
        //    SysSetup.AllDevice.Clear();
        //    for (int j = 0; j < Info.Count; j++)
        //    {
        //        if (Info[j].Name != "" && !SysSetup.AllDevice.Keys.Contains(Info[j].Name))
        //        {
        //            SysSetup.AllDevice.Add(Info[j].Name, Info[j].Location);
        //        }
        //    }
        //    SetupDiDestroyDeviceInfoList(MainIntPtr);
        //}

        //public void SetEnabled(bool p_Enabled)//启用和禁用设备
        //{
        //    Guid NewGuid = Guid.Empty;
        //    IntPtr MainIntPtr = SetupDiGetClassDevs(ref NewGuid, 0, IntPtr.Zero, DIGCF.DIGCF_ALLCLASSES | DIGCF.DIGCF_PRESENT);
        //    if (MainIntPtr.ToInt32() == -1) return;
        //    SP_DEVINFO_DATA DevinfoData = new SP_DEVINFO_DATA(Guid.Empty);
        //    StringBuilder DeviceName = new StringBuilder(1000);
        //    uint i = 0;
        //    while (SetupDiEnumDeviceInfo(MainIntPtr, i, DevinfoData))
        //    {
        //        SetupDiGetDeviceRegistryProperty(MainIntPtr, DevinfoData, SPDRP.SPDRP_DEVICEDESC, 0,
        //            DeviceName, (uint)DeviceName.Capacity, IntPtr.Zero);
        //        if (DevinfoData.classGuid.ToString() == "28a57f37-88bd-4753-baa0-b013aa31c51b")
        //        {
        //            SetHardwareEnabled(MainIntPtr, p_Enabled, DevinfoData);
        //            break;
        //        }
        //        i++;
        //    }
        //    SetupDiDestroyDeviceInfoList(MainIntPtr);
        //}
        //private void SetHardwareEnabled(IntPtr m_MainIntPtr, bool p_Enabled, SP_DEVINFO_DATA p_DevInfoData)//启用和禁用设备
        //{
        //    SP_PROPCHANGE_PARAMS Params = new SP_PROPCHANGE_PARAMS();
        //    Params.ClassInstallHeader.cbSize = Marshal.SizeOf(typeof(SP_CLASSINSTALL_HEADER));
        //    Params.ClassInstallHeader.InstallFunction = (int)DIF.DIF_PROPERTYCHANGE;
        //    Params.StateChange = (int)DICS.DICS_DISABLE;
        //    Params.Scope = (int)DICS.DICS_FLAG_CONFIGSPECIFIC;
        //    if (p_Enabled)
        //    {
        //        Params.StateChange = (int)DICS.DICS_ENABLE;
        //        Params.Scope = (int)DICS.DICS_FLAG_GLOBAL;
        //        IntPtr HardwareParamsIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Params));
        //        Marshal.StructureToPtr(Params, HardwareParamsIntPtr, true);
        //        IntPtr DevInfoDataIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(p_DevInfoData));
        //        if (SetupDiSetClassInstallParams(m_MainIntPtr, DevInfoDataIntPtr, HardwareParamsIntPtr, Marshal.SizeOf(typeof(SP_PROPCHANGE_PARAMS))))
        //        {
        //            SetupDiCallClassInstaller(DIF.DIF_PROPERTYCHANGE, m_MainIntPtr, DevInfoDataIntPtr);
        //        }
        //        Params.ClassInstallHeader.cbSize = Marshal.SizeOf(typeof(SP_CLASSINSTALL_HEADER));
        //        Params.ClassInstallHeader.InstallFunction = (int)DIF.DIF_PROPERTYCHANGE;
        //        Params.StateChange = (int)DICS.DICS_ENABLE;
        //        Params.Scope = (int)DICS.DICS_FLAG_CONFIGSPECIFIC;
        //        Params.HwProfile = 0;
        //    }
        //    IntPtr SetHardwareParamsIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Params));
        //    Marshal.StructureToPtr(Params, SetHardwareParamsIntPtr, true);
        //    IntPtr SetDevInfoDataIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(p_DevInfoData));
        //    Marshal.StructureToPtr(p_DevInfoData, SetDevInfoDataIntPtr, true);
        //    SetupDiSetClassInstallParams(SetDevInfoDataIntPtr, SetDevInfoDataIntPtr, SetHardwareParamsIntPtr, Marshal.SizeOf(typeof(SP_PROPCHANGE_PARAMS)));
        //}
        //public bool GetLocation(string location)//确认电脑是否有对应位置的设备连接
        //{
        //    for (int i = 0; i < Info.Count; i++)
        //    {
        //        if (Info[i].Name.Contains(location))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public bool GetName(string name)//确认电脑是否有对应名称的设备连接
        //{
        //    for (int i = 0; i < Info.Count; i++)
        //    {
        //        if (Info[i].Name.Contains(name))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public bool GetIP(string name)//确认电脑是否有对应名称的网络设备连接
        //{
        //    try
        //    {
        //        string HostName = Dns.GetHostName(); //得到主机名
        //        IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
        //        for (int i = 0; i < IpEntry.AddressList.Length; i++)
        //        {
        //            //从IP地址列表中筛选出IPv4类型的IP地址
        //            //AddressFamily.InterNetwork表示此IP为IPv4,
        //            //AddressFamily.InterNetworkV6表示此地址为IPv6类型
        //            //if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
        //            //{
        //            //    return true;
        //            //}
        //            if (IpEntry.AddressList[i].ToString().Contains(name))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("获取本机IP出错:" + ex.Message);
        //        return false;
        //    }
        //}

        public List<string> UsbDevice;
        public List<string> SerialDevice;
        public List<string> NetDevice;

        #region 使用Management类枚举设备管理器所有串口设备

        #region ManagementObjectSearcher 查找设备时键定义

        //ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);

        //硬件
        //Win32_Processor, // CPU 处理器 
        //Win32_PhysicalMemory, // 物理内存条 
        //Win32_Keyboard, // 键盘 
        //Win32_PointingDevice, // 点输入设备，包括鼠标。 
        //Win32_FloppyDrive, // 软盘驱动器 
        //Win32_DiskDrive, // 硬盘驱动器 
        //Win32_CDROMDrive, // 光盘驱动器 
        //Win32_BaseBoard, // 主板 
        //Win32_BIOS, // BIOS 芯片 
        //Win32_ParallelPort, // 并口 
        //Win32_SerialPort, // 串口 
        //Win32_SerialPortConfiguration, // 串口配置 
        //Win32_SoundDevice, // 多媒体设置，一般指声卡。 
        //Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP) 
        //Win32_USBController, // USB 控制器 
        //Win32_NetworkAdapter, // 网络适配器 
        //Win32_NetworkAdapterConfiguration, // 网络适配器设置 
        //Win32_Printer, // 打印机 
        //Win32_PrinterConfiguration, // 打印机设置 
        //Win32_PrintJob, // 打印机任务 
        //Win32_TCPIPPrinterPort, // 打印机端口 
        //Win32_POTSModem, // MODEM 
        //Win32_POTSModemToSerialPort, // MODEM 端口 
        //Win32_DesktopMonitor, // 显示器 
        //Win32_DisplayConfiguration, // 显卡 
        //Win32_DisplayControllerConfiguration, // 显卡设置 
        //Win32_VideoController, // 显卡细节。 
        //Win32_VideoSettings, // 显卡支持的显示模式。 

        //操作系统
        //Win32_TimeZone, // 时区 
        //Win32_SystemDriver, // 驱动程序 
        //Win32_DiskPartition, // 磁盘分区 
        //Win32_LogicalDisk, // 逻辑磁盘 
        //Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。 
        //Win32_LogicalMemoryConfiguration, // 逻辑内存配置 
        //Win32_PageFile, // 系统页文件信息 
        //Win32_PageFileSetting, // 页文件设置 
        //Win32_BootConfiguration, // 系统启动配置 
        //Win32_ComputerSystem, // 计算机信息简要 
        //Win32_OperatingSystem, // 操作系统信息 
        //Win32_StartupCommand, // 系统自动启动程序 
        //Win32_Service, // 系统安装的服务 
        //Win32_Group, // 系统管理组 
        //Win32_GroupUser, // 系统组帐号 
        //Win32_UserAccount, // 用户帐号 
        //Win32_Process, // 系统进程 
        //Win32_Thread, // 系统线程 
        //Win32_Share, // 共享 
        //Win32_NetworkClient, // 已安装的网络客户端 
        //Win32_NetworkProtocol, // 已安装的网络协议 

        //所有Key:
        //Win32_1394Controller
        //Win32_1394ControllerDevice
        //Win32_Account
        //Win32_AccountSID
        //Win32_ACE
        //Win32_ActionCheck
        //Win32_AllocatedResource
        //Win32_ApplicationCommandLine
        //Win32_ApplicationService
        //Win32_AssociatedBattery
        //Win32_AssociatedProcessorMemory
        //Win32_BaseBoard
        //Win32_BaseService
        //Win32_Battery
        //Win32_Binary
        //Win32_BindImageAction
        //Win32_BIOS
        //Win32_BootConfiguration
        //Win32_Bus
        //Win32_CacheMemory
        //Win32_CDROMDrive
        //Win32_CheckCheck
        //Win32_CIMLogicalDeviceCIMDataFile
        //Win32_ClassicCOMApplicationClasses
        //Win32_ClassicCOMClass
        //Win32_ClassicCOMClassSetting
        //Win32_ClassicCOMClassSettings
        //Win32_ClassInfoAction
        //Win32_ClientApplicationSetting
        //Win32_CodecFile
        //Win32_COMApplication
        //Win32_COMApplicationClasses
        //Win32_COMApplicationSettings
        //Win32_COMClass
        //Win32_ComClassAutoEmulator
        //Win32_ComClassEmulator
        //Win32_CommandLineAccess
        //Win32_ComponentCategory
        //Win32_ComputerSystem
        //Win32_ComputerSystemProcessor
        //Win32_ComputerSystemProduct
        //Win32_COMSetting
        //Win32_Condition
        //Win32_CreateFolderAction
        //Win32_CurrentProbe
        //Win32_DCOMApplication
        //Win32_DCOMApplicationAccessAllowedSetting
        //Win32_DCOMApplicationLaunchAllowedSetting
        //Win32_DCOMApplicationSetting
        //Win32_DependentService
        //Win32_Desktop
        //Win32_DesktopMonitor
        //Win32_DeviceBus
        //Win32_DeviceMemoryAddress
        //Win32_DeviceSettings
        //Win32_Directory
        //Win32_DirectorySpecification
        //Win32_DiskDrive
        //Win32_DiskDriveToDiskPartition
        //Win32_DiskPartition
        //Win32_DisplayConfiguration
        //Win32_DisplayControllerConfiguration
        //Win32_DMAChannel
        //Win32_DriverVXD
        //Win32_DuplicateFileAction
        //Win32_Environment
        //Win32_EnvironmentSpecification
        //Win32_ExtensionInfoAction
        //Win32_Fan
        //Win32_FileSpecification
        //Win32_FloppyController
        //Win32_FloppyDrive
        //Win32_FontInfoAction
        //Win32_Group
        //Win32_GroupUser
        //Win32_HeatPipe
        //Win32_IDEController
        //Win32_IDEControllerDevice
        //Win32_ImplementedCategory
        //Win32_InfraredDevice
        //Win32_IniFileSpecification
        //Win32_InstalledSoftwareElement
        //Win32_IRQResource
        //Win32_Keyboard
        //Win32_LaunchCondition
        //Win32_LoadOrderGroup
        //Win32_LoadOrderGroupServiceDependencies
        //Win32_LoadOrderGroupServiceMembers
        //Win32_LogicalDisk
        //Win32_LogicalDiskRootDirectory
        //Win32_LogicalDiskToPartition
        //Win32_LogicalFileAccess
        //Win32_LogicalFileAuditing
        //Win32_LogicalFileGroup
        //Win32_LogicalFileOwner
        //Win32_LogicalFileSecuritySetting
        //Win32_LogicalMemoryConfiguration
        //Win32_LogicalProgramGroup
        //Win32_LogicalProgramGroupDirectory
        //Win32_LogicalProgramGroupItem
        //Win32_LogicalProgramGroupItemDataFile
        //Win32_LogicalShareAccess
        //Win32_LogicalShareAuditing
        //Win32_LogicalShareSecuritySetting
        //Win32_ManagedSystemElementResource
        //Win32_MemoryArray
        //Win32_MemoryArrayLocation
        //Win32_MemoryDevice
        //Win32_MemoryDeviceArray
        //Win32_MemoryDeviceLocation
        //Win32_MethodParameterClass
        //Win32_MIMEInfoAction
        //Win32_MotherboardDevice
        //Win32_MoveFileAction
        //Win32_MSIResource
        //Win32_networkAdapter
        //Win32_networkAdapterConfiguration
        //Win32_networkAdapterSetting
        //Win32_networkClient
        //Win32_networkConnection
        //Win32_networkLoginProfile
        //Win32_networkProtocol
        //Win32_NTEventlogFile
        //Win32_NTLogEvent
        //Win32_NTLogEventComputer
        //Win32_NTLogEventLog
        //Win32_NTLogEventUser
        //Win32_ODBCAttribute
        //Win32_ODBCDataSourceAttribute
        //Win32_ODBCDataSourceSpecification
        //Win32_ODBCDriverAttribute
        //Win32_ODBCDriverSoftwareElement
        //Win32_ODBCDriverSpecification
        //Win32_ODBCSourceAttribute
        //Win32_ODBCTranslatorSpecification
        //Win32_OnBoardDevice
        //Win32_OperatingSystem
        //Win32_OperatingSystemQFE
        //Win32_OSRecoveryConfiguration
        //Win32_PageFile
        //Win32_PageFileElementSetting
        //Win32_PageFileSetting
        //Win32_PageFileUsage
        //Win32_ParallelPort
        //Win32_Patch
        //Win32_PatchFile
        //Win32_PatchPackage
        //Win32_PCMCIAController
        //Win32_Perf
        //Win32_PerfRawData
        //Win32_PerfRawData_ASP_ActiveServerPages
        //Win32_PerfRawData_ASPnet_114322_ASPnetAppsv114322
        //Win32_PerfRawData_ASPnet_114322_ASPnetv114322
        //Win32_PerfRawData_ASPnet_ASPnet
        //Win32_PerfRawData_ASPnet_ASPnetApplications
        //Win32_PerfRawData_IAS_IASAccountingClients
        //Win32_PerfRawData_IAS_IASAccountingServer
        //Win32_PerfRawData_IAS_IASAuthenticationClients
        //Win32_PerfRawData_IAS_IASAuthenticationServer
        //Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal
        //Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator
        //Win32_PerfRawData_MSFTPSVC_FTPService
        //Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods
        //Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice
        //Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager
        //Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition
        //Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager
        //Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases
        //Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics
        //Win32_PerfRawData_MSSQLSERVER_SQLServerLatches
        //Win32_PerfRawData_MSSQLSERVER_SQLServerLocks
        //Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager
        //Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents
        //Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist
        //Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader
        //Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge
        //Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot
        //Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics
        //Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable
        //Win32_PerfRawData_netFramework_netCLRExceptions
        //Win32_PerfRawData_netFramework_netCLRInterop
        //Win32_PerfRawData_netFramework_netCLRJit
        //Win32_PerfRawData_netFramework_netCLRLoading
        //Win32_PerfRawData_netFramework_netCLRLocksAndThreads
        //Win32_PerfRawData_netFramework_netCLRMemory
        //Win32_PerfRawData_netFramework_netCLRRemoting
        //Win32_PerfRawData_netFramework_netCLRSecurity
        //Win32_PerfRawData_Outlook_Outlook
        //Win32_PerfRawData_PerfDisk_PhysicalDisk
        //Win32_PerfRawData_Perfnet_Browser
        //Win32_PerfRawData_Perfnet_Redirector
        //Win32_PerfRawData_Perfnet_Server
        //Win32_PerfRawData_Perfnet_ServerWorkQueues
        //Win32_PerfRawData_PerfOS_Cache
        //Win32_PerfRawData_PerfOS_Memory
        //Win32_PerfRawData_PerfOS_Objects
        //Win32_PerfRawData_PerfOS_PagingFile
        //Win32_PerfRawData_PerfOS_Processor
        //Win32_PerfRawData_PerfOS_System
        //Win32_PerfRawData_PerfProc_FullImage_Costly
        //Win32_PerfRawData_PerfProc_Image_Costly
        //Win32_PerfRawData_PerfProc_JobObject
        //Win32_PerfRawData_PerfProc_JobObjectDetails
        //Win32_PerfRawData_PerfProc_Process
        //Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly
        //Win32_PerfRawData_PerfProc_Thread
        //Win32_PerfRawData_PerfProc_ThreadDetails_Costly
        //Win32_PerfRawData_RemoteAccess_RASPort
        //Win32_PerfRawData_RemoteAccess_RASTotal
        //Win32_PerfRawData_RSVP_ACSPerRSVPService
        //Win32_PerfRawData_Spooler_PrintQueue
        //Win32_PerfRawData_TapiSrv_Telephony
        //Win32_PerfRawData_Tcpip_ICMP
        //Win32_PerfRawData_Tcpip_IP
        //Win32_PerfRawData_Tcpip_NBTConnection
        //Win32_PerfRawData_Tcpip_networkInterface
        //Win32_PerfRawData_Tcpip_TCP
        //Win32_PerfRawData_Tcpip_UDP
        //Win32_PerfRawData_W3SVC_WebService
        //Win32_PhysicalMedia
        //Win32_PhysicalMemory
        //Win32_PhysicalMemoryArray
        //Win32_PhysicalMemoryLocation
        //Win32_PNPAllocatedResource
        //Win32_PnPDevice
        //Win32_PnPEntity
        //Win32_PointingDevice
        //Win32_PortableBattery
        //Win32_PortConnector
        //Win32_PortResource
        //Win32_POTSModem
        //Win32_POTSModemToSerialPort
        //Win32_PowerManagementEvent
        //Win32_Printer
        //Win32_PrinterConfiguration
        //Win32_PrinterController
        //Win32_PrinterDriverDll
        //Win32_PrinterSetting
        //Win32_PrinterShare
        //Win32_PrintJob
        //Win32_PrivilegesStatus
        //Win32_Process
        //Win32_Processor
        //Win32_ProcessStartup
        //Win32_Product
        //Win32_ProductCheck
        //Win32_ProductResource
        //Win32_ProductSoftwareFeatures
        //Win32_ProgIDSpecification
        //Win32_ProgramGroup
        //Win32_ProgramGroupContents
        //Win32_ProgramGroupOrItem
        //Win32_Property
        //Win32_ProtocolBinding
        //Win32_PublishComponentAction
        //Win32_QuickFixEngineering
        //Win32_Refrigeration
        //Win32_Registry
        //Win32_RegistryAction
        //Win32_RemoveFileAction
        //Win32_RemoveIniAction
        //Win32_ReserveCost
        //Win32_ScheduledJob
        //Win32_SCSIController
        //Win32_SCSIControllerDevice
        //Win32_SecurityDescriptor
        //Win32_SecuritySetting
        //Win32_SecuritySettingAccess
        //Win32_SecuritySettingAuditing
        //Win32_SecuritySettingGroup
        //Win32_SecuritySettingOfLogicalFile
        //Win32_SecuritySettingOfLogicalShare
        //Win32_SecuritySettingOfObject
        //Win32_SecuritySettingOwner
        //Win32_SelfRegModuleAction
        //Win32_SerialPort
        //Win32_SerialPortConfiguration
        //Win32_SerialPortSetting
        //Win32_Service
        //Win32_ServiceControl
        //Win32_ServiceSpecification
        //Win32_ServiceSpecificationService
        //Win32_SettingCheck
        //Win32_Share
        //Win32_ShareToDirectory
        //Win32_ShortcutAction
        //Win32_ShortcutFile
        //Win32_ShortcutSAP
        //Win32_SID
        //Win32_SMBIOSMemory
        //Win32_SoftwareElement
        //Win32_SoftwareElementAction
        //Win32_SoftwareElementCheck
        //Win32_SoftwareElementCondition
        //Win32_SoftwareElementResource
        //Win32_SoftwareFeature
        //Win32_SoftwareFeatureAction
        //Win32_SoftwareFeatureCheck
        //Win32_SoftwareFeatureParent
        //Win32_SoftwareFeatureSoftwareElements
        //Win32_SoundDevice
        //Win32_StartupCommand
        //Win32_SubDirectory
        //Win32_SystemAccount
        //Win32_SystemBIOS
        //Win32_SystemBootConfiguration
        //Win32_SystemDesktop
        //Win32_SystemDevices
        //Win32_SystemDriver
        //Win32_SystemDriverPNPEntity
        //Win32_SystemEnclosure
        //Win32_SystemLoadOrderGroups
        //Win32_SystemLogicalMemoryConfiguration
        //Win32_SystemMemoryResource
        //Win32_SystemnetworkConnections
        //Win32_SystemOperatingSystem
        //Win32_SystemPartitions
        //Win32_SystemProcesses
        //Win32_SystemProgramGroups
        //Win32_SystemResources
        //Win32_SystemServices
        //Win32_SystemSetting
        //Win32_SystemSlot
        //Win32_SystemSystemDriver
        //Win32_SystemTimeZone
        //Win32_SystemUsers
        //Win32_TapeDrive
        //Win32_TemperatureProbe
        //Win32_Thread
        //Win32_TimeZone
        //Win32_Trustee
        //Win32_TypeLibraryAction
        //Win32_UninterruptiblePowerSupply
        //Win32_USBController
        //Win32_USBControllerDevice
        //Win32_UserAccount
        //Win32_UserDesktop
        //Win32_VideoConfiguration
        //Win32_VideoController
        //Win32_VideoSettings
        //Win32_VoltageProbe
        //Win32_WMIElementSetting
        //Win32_WMISetting

        #endregion
        public HardwareInfo()
        {
            SerialDevice = new List<string>();
            UsbDevice = new List<string>();
            NetDevice = new List<string>();
            GetSerialName();
            GetUsbName();
            GetNetName();

            HIDevice hid=new HIDevice();
            hid.OpenDevice(0483, 5750);
            List<string> deviceList = new List<string>();
            hid.GetDeviceSerialList(6127,24601,ref deviceList);
            StringBuilder str=new StringBuilder();
            for (int i = 0; i < deviceList.Count; i++)
            {
                str.Append(deviceList[i] + "\r\n");
            }
        }
        public void GetSerialName()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + "Win32_PnPEntity"))
                {
                    ManagementObjectCollection hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null && hardInfo.Properties["Name"].Value.ToString().Contains("COM"))
                        {
                            string name = hardInfo.Properties["Name"].Value.ToString();
                            string ID = hardInfo.Properties["DeviceID"].Value.ToString();
                            SerialDevice.Add(name);
                        }
                    }
                    searcher.Dispose();
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
        }
        public void GetUsbName()
        {
            try
            {
                UsbDevice.Clear();
                StringBuilder nameBuilder = new StringBuilder();
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSWmi_PnPInstanceNames"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        string str = queryObj["InstanceName"].ToString();
                        if (str.Contains("USB") || str.Contains("HID"))
                        {
                            UsbDevice.Add(str);
                            nameBuilder.Append(str + "\r\n");
                        }
                    }
                    searcher.Dispose();
                }

                //StringBuilder aa = new StringBuilder();
                //using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + "Win32_USBControllerDevice"))
                //{
                //    foreach (var hardInfo in searcher.Get())
                //    {
                //        foreach (var VARIABLE in hardInfo.Properties)
                //        {

                //        }
                //        aa.Append(hardInfo.Properties["Dependent"].Value + "\r\n");
                //        //UsbDevice.Add(hardInfo.Properties["Dependent"].Value.ToString());
                //        UsbDevice.Add(hardInfo.Properties["Dependent"].Value.ToString());
                //    }
                //    searcher.Dispose();
                //}
                //ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
                //ManagementObjectCollection objCollection = objSearcher.Get();
                //foreach (ManagementObject obj in objCollection)
                //{
                //    foreach (PropertyData property in obj.Properties)
                //    {
                //        Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                //    }
                //}

            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
        }
        public void GetNetName()
        {
            try
            {
                NetDevice.Clear();
                IPHostEntry IPH = Dns.GetHostByName(Dns.GetHostName());
                IPAddress[] myIp = IPH.AddressList;
                foreach (IPAddress ips in myIp) NetDevice.Add(ips.ToString());

                //foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
                //{
                //    IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                //    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                //    {
                //        NetDevice.Add(addr.Address.ToString());
                //    }
                //}
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
        }

        //public void GetSerialName()
        //{
        //    try
        //    {
        //        var Name = SerialPort.GetPortNames();
        //        for (int i = 0; i < Name.Length; i++)
        //        {
        //            SerialDevice.Add(Name[i]);
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        Debug.WriteLine(exp.Message);
        //    }
        //}

        //public void GetHidDeviceList(ref List<string> deviceList)// 获取所有连接的hid的设备路径
        //{
        //    Guid hUSB = Guid.Empty;
        //    uint index = 0;
        //    deviceList.Clear();
        //    HidD_GetHidGuid(ref hUSB);// 取得hid设备全局id
        //    //取得一个包含所有HID接口信息集合的句柄
        //    IntPtr hidInfoSet = SetupDiGetClassDevs(ref hUSB, 0, IntPtr.Zero, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
        //    if (hidInfoSet != IntPtr.Zero)
        //    {
        //        SP_DEVICE_INTERFACE_DATA interfaceInfo = new SP_DEVICE_INTERFACE_DATA();
        //        interfaceInfo.cbSize = Marshal.SizeOf(interfaceInfo);
        //        //查询集合中每一个接口
        //        for (index = 0; index < 64; index++)
        //        {
        //            //得到第index个接口信息
        //            if (SetupDiEnumDeviceInterfaces(hidInfoSet, IntPtr.Zero, ref hUSB, index, ref interfaceInfo))
        //            {
        //                int buffsize = 0;
        //                // 取得接口详细信息:第一次读取错误,但可以取得信息缓冲区的大小
        //                SetupDiGetDeviceInterfaceDetail(hidInfoSet, ref interfaceInfo, IntPtr.Zero, buffsize, ref buffsize, null);
        //                //构建接收缓冲
        //                IntPtr pDetail = Marshal.AllocHGlobal(buffsize);
        //                SP_DEVICE_INTERFACE_DETAIL_DATA detail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
        //                detail.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DETAIL_DATA));
        //                Marshal.StructureToPtr(detail, pDetail, false);
        //                if (SetupDiGetDeviceInterfaceDetail(hidInfoSet, ref interfaceInfo, pDetail, buffsize, ref buffsize, null))
        //                {
        //                    deviceList.Add(Marshal.PtrToStringAuto((IntPtr)((int)pDetail + 4)));
        //                }
        //                Marshal.FreeHGlobal(pDetail);
        //            }
        //        }
        //    }
        //    SetupDiDestroyDeviceInfoList(hidInfoSet);
        //}
        #endregion
    }
}