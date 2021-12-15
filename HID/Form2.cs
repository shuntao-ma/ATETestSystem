using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HID
{
    public partial class HIDForm : Form
    {
        #region DataStruct

        private const int DIGCF_DEFAULT = 0x00000001;
        private const int DIGCF_PRESENT = 0x00000002;
        private const int DIGCF_ALLCLASSES = 0x00000004;
        private const int DIGCF_PROFILE = 0x00000008;
        private const int DIGCF_DEVICEINTERFACE = 0x00000010;

        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint GENERIC_EXECUTE = 0x20000000;
        private const uint GENERIC_ALL = 0x10000000;



        private const uint CREATE_NEW = 1;
        private const uint CREATE_ALWAYS = 2;
        private const uint OPEN_EXISTING = 3;
        private const uint OPEN_ALWAYS = 4;
        private const uint TRUNCATE_EXISTING = 5;
        private const int HIDP_STATUS_SUCCESS = 1114112;
        private const int DEVICE_PATH = 260;
        private IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);


        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint FILE_SHARE_DELETE = 0x00000004;

        public const uint FILE_FLAG_WRITE_THROUGH = 0x80000000;
        public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        public const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
        public const uint FILE_FLAG_RANDOM_ACCESS = 0x10000000;
        public const uint FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000;
        public const uint FILE_FLAG_DELETE_ON_CLOSE = 0x04000000;
        public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        public const uint FILE_FLAG_POSIX_SEMANTICS = 0x01000000;
        public const uint FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000;
        public const uint FILE_FLAG_OPEN_NO_RECALL = 0x00100000;
        public const uint FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000;

        #region HID_RETURN
        public enum HID_RETURN
        {
            SUCCESS = 0,
            NO_DEVICE_CONECTED,
            DEVICE_NOT_FIND,
            DEVICE_OPENED,
            WRITE_FAILD,
            READ_FAILD
        }

        #endregion

        #region DevBroadcastDeviceInterfaceBuffer
        [StructLayout(LayoutKind.Explicit)]
        class DevBroadcastDeviceInterfaceBuffer
        {
            [FieldOffset(0)]
            public Int32 dbch_size;
            [FieldOffset(4)]
            public Int32 dbch_devicetype;
            [FieldOffset(8)]
            public Int32 dbch_reserved;
            public DevBroadcastDeviceInterfaceBuffer(Int32 deviceType)
            {
                dbch_size = Marshal.SizeOf(typeof(DevBroadcastDeviceInterfaceBuffer));
                dbch_devicetype = deviceType;
                dbch_reserved = 0;
            }
        }

        #endregion

        #region DIGCF 控制由 SetupDiGetClassDevs 构建的设备信息集中包含的内容的标志
        public enum DIGCF
        {
            DIGCF_DEFAULT = 0x00000001, // only valid with DIGCF_DEVICEINTERFACE                 
            DIGCF_PRESENT = 0x00000002,
            DIGCF_ALLCLASSES = 0x00000004,
            DIGCF_PROFILE = 0x00000008,
            DIGCF_DEVICEINTERFACE = 0x00000010
        }

        #endregion

        #region DESIREDACCESS
        static class DESIREDACCESS// Type of access to the object. 
        {
            public const uint GENERIC_READ = 0x80000000;
            public const uint GENERIC_WRITE = 0x40000000;
            public const uint GENERIC_EXECUTE = 0x20000000;
            public const uint GENERIC_ALL = 0x10000000;
        }

        #endregion

        #region CREATIONDISPOSITION
        static class CREATIONDISPOSITION// Action to take on files that exist, and which action to take when files do not exist. 
        {
            public const uint CREATE_NEW = 1;
            public const uint CREATE_ALWAYS = 2;
            public const uint OPEN_EXISTING = 3;
            public const uint OPEN_ALWAYS = 4;
            public const uint TRUNCATE_EXISTING = 5;
        }

        #endregion



        #region DEV_BROADCAST_HDR
        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_HDR
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
        }
        #endregion

        #region DEV_BROADCAST_DEVICEINTERFACE
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEV_BROADCAST_DEVICEINTERFACE
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            public Guid dbcc_classguid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string dbcc_name;
        }
        #endregion

        #region SHAREMODE
        static class SHAREMODE
        {
            public const uint FILE_SHARE_READ = 0x00000001;
            public const uint FILE_SHARE_WRITE = 0x00000002;
            public const uint FILE_SHARE_DELETE = 0x00000004;
        }
        #endregion

        #region FileMapProtection
        enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }
        #endregion

        #region HIDP_REPORT_TYPE
        enum HIDP_REPORT_TYPE : ushort
        {
            HidP_Input = 0x00,
            HidP_Output = 0x01,
            HidP_Feature = 0x02,
        }
        #endregion

        #region LIST_ENTRY
        [StructLayout(LayoutKind.Sequential)]
        struct LIST_ENTRY
        {
            public IntPtr Flink;
            public IntPtr Blink;
        }
        #endregion

        #region DEVICE_LIST_NODE
        [StructLayout(LayoutKind.Sequential)]
        struct DEVICE_LIST_NODE
        {
            public LIST_ENTRY Hdr;
            public IntPtr NotificationHandle;
            public HID_DEVICE HidDeviceInfo;
            public bool DeviceOpened;
        }
        #endregion

        #region SP_DEVICE_INTERFACE_DATA
        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVICE_INTERFACE_DATA
        {
            public Int32 cbSize;
            public Guid interfaceClassGuid;
            public Int32 flags;
            private UIntPtr reserved;
        }
        #endregion

        #region SP_DEVICE_INTERFACE_DETAIL_DATA 结构包含设备接口的路径。
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public int cbSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
            public string DevicePath;
        }
        #endregion

        #region SP_DEVINFO_DATA
        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid classGuid;
            public UInt32 devInst;
            public IntPtr reserved;
        }
        #endregion

        #region HIDP_CAPS
        [StructLayout(LayoutKind.Sequential)]
        public struct HIDP_CAPS
        {
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 Usage;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 UsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 InputReportByteLength;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 OutputReportByteLength;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 FeatureReportByteLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public UInt16[] Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberLinkCollectionNodes;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputDataIndices;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputDataIndices;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureDataIndices;
        };

        #endregion

        #region HIDD_ATTRIBUTES
        [StructLayout(LayoutKind.Sequential)]
        public struct HIDD_ATTRIBUTES
        {
            public Int32 Size;
            public Int16 VendorID;
            public Int16 ProductID;
            public Int16 VersionNumber;
        }
        #endregion

        #region ButtonData
        [StructLayout(LayoutKind.Sequential)]
        public struct ButtonData
        {
            public Int32 UsageMin;
            public Int32 UsageMax;
            public Int32 MaxUsageLength;
            public Int16 Usages;
        }
        #endregion

        #region ValueData
        [StructLayout(LayoutKind.Sequential)]
        public struct ValueData
        {
            public ushort Usage;
            public ushort Reserved;
            public ulong Value;
            public long ScaledValue;
        }
        #endregion

        #region HID_DATA
        [StructLayout(LayoutKind.Explicit)]
        public struct HID_DATA
        {
            [FieldOffset(0)]
            public bool IsButtonData;
            [FieldOffset(1)]
            public byte Reserved;
            [FieldOffset(2)]
            public ushort UsagePage;
            [FieldOffset(4)]
            public Int32 Status;
            [FieldOffset(8)]
            public Int32 ReportID;
            [FieldOffset(16)]
            public bool IsDataSet;

            [FieldOffset(17)]
            public ButtonData ButtonData;
            [FieldOffset(17)]
            public ValueData ValueData;
        }
        #endregion

        #region HIDP_Range
        [StructLayout(LayoutKind.Sequential)]
        public struct HIDP_Range
        {
            public ushort UsageMin, UsageMax;
            public ushort StringMin, StringMax;
            public ushort DesignatorMin, DesignatorMax;
            public ushort DataIndexMin, DataIndexMax;
        }
        #endregion

        #region HIDP_NotRange
        [StructLayout(LayoutKind.Sequential)]
        public struct HIDP_NotRange
        {
            public ushort Usage, Reserved1;
            public ushort StringIndex, Reserved2;
            public ushort DesignatorIndex, Reserved3;
            public ushort DataIndex, Reserved4;
        }
        #endregion

        #region HIDP_BUTTON_CAPS
        [StructLayout(LayoutKind.Explicit)]
        public struct HIDP_BUTTON_CAPS
        {
            [FieldOffset(0)]
            public ushort UsagePage;
            [FieldOffset(2)]
            public byte ReportID;
            [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
            public bool IsAlias;
            [FieldOffset(4)]
            public short BitField;
            [FieldOffset(6)]
            public short LinkCollection;
            [FieldOffset(8)]
            public short LinkUsage;
            [FieldOffset(10)]
            public short LinkUsagePage;
            [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
            public bool IsRange;
            [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
            public bool IsStringRange;
            [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
            public bool IsDesignatorRange;
            [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
            public bool IsAbsolute;
            [FieldOffset(16), MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public int[] Reserved;

            [FieldOffset(56)]
            public HIDP_Range Range;
            [FieldOffset(56)]
            public HIDP_NotRange NotRange;
        }
        #endregion

        #region HIDP_VALUE_CAPS
        [StructLayout(LayoutKind.Explicit)]
        public struct HIDP_VALUE_CAPS
        {
            [FieldOffset(0)]
            public ushort UsagePage;
            [FieldOffset(2)]
            public byte ReportID;
            [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
            public bool IsAlias;
            [FieldOffset(4)]
            public ushort BitField;
            [FieldOffset(6)]
            public ushort LinkCollection;
            [FieldOffset(8)]
            public ushort LinkUsage;
            [FieldOffset(10)]
            public ushort LinkUsagePage;
            [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
            public bool IsRange;
            [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
            public bool IsStringRange;
            [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
            public bool IsDesignatorRange;
            [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
            public bool IsAbsolute;
            [FieldOffset(16), MarshalAs(UnmanagedType.U1)]
            public bool HasNull;
            [FieldOffset(17)]
            public byte Reserved;
            [FieldOffset(18)]
            public short BitSize;
            [FieldOffset(20)]
            public short ReportCount;
            [FieldOffset(22)]
            public ushort Reserved2a;
            [FieldOffset(24)]
            public ushort Reserved2b;
            [FieldOffset(26)]
            public ushort Reserved2c;
            [FieldOffset(28)]
            public ushort Reserved2d;
            [FieldOffset(30)]
            public ushort Reserved2e;
            [FieldOffset(32)]
            public int UnitsExp;
            [FieldOffset(36)]
            public int Units;
            [FieldOffset(40)]
            public int LogicalMin;
            [FieldOffset(44)]
            public int LogicalMax;
            [FieldOffset(48)]
            public int PhysicalMin;
            [FieldOffset(52)]
            public int PhysicalMax;
            [FieldOffset(56)]
            public HIDP_Range Range;
            [FieldOffset(56)]
            public HIDP_NotRange NotRange;
        }

        #endregion

        #region HID_DEVICE
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class HID_DEVICE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
            public string DevicePath;
            public IntPtr HidDevice;
            public bool OpenedForRead;
            public bool OpenedForWrite;
            public bool OpenedOverlapped;
            public bool OpenedExclusive;

            public IntPtr Ppd;
            public HIDP_CAPS Caps;
            public HIDD_ATTRIBUTES Attributes;

            public List<IntPtr> InputReportBuffer;
            public List<HID_DATA> InputData;
            public Int32 InputDataLength;
            public List<HIDP_BUTTON_CAPS> InputButtonCaps;
            public List<HIDP_VALUE_CAPS> InputValueCaps;

            public List<IntPtr> OutputReportBuffer;
            public List<HID_DATA> OutputData;
            public Int32 OutputDataLength;
            public List<HIDP_BUTTON_CAPS> OutputButtonCaps;
            public List<HIDP_VALUE_CAPS> OutputValueCaps;

            public List<IntPtr> FeatureReportBuffer;
            public List<HID_DATA> FeatureData;
            public Int32 FeatureDataLength;
            public List<HIDP_BUTTON_CAPS> FeatureButtonCaps;
            public List<HIDP_VALUE_CAPS> FeatureValueCaps;

            public HID_DEVICE()
            {
                DevicePath = "";
                HidDevice = new IntPtr(-1);
                OpenedForRead = false;
                OpenedForWrite = false;
                OpenedOverlapped = false;
                OpenedExclusive = false;

                Ppd = new IntPtr();
                Caps = new HIDP_CAPS();
                Attributes = new HIDD_ATTRIBUTES();

                InputReportBuffer = new List<IntPtr>();
                InputData = new List<HID_DATA>();
                InputDataLength = -1;
                InputButtonCaps = new List<HIDP_BUTTON_CAPS>();
                InputValueCaps = new List<HIDP_VALUE_CAPS>();

                OutputReportBuffer = new List<IntPtr>();
                OutputData = new List<HID_DATA>();
                OutputDataLength = -1;
                OutputButtonCaps = new List<HIDP_BUTTON_CAPS>();
                OutputValueCaps = new List<HIDP_VALUE_CAPS>();

                FeatureReportBuffer = new List<IntPtr>();
                FeatureData = new List<HID_DATA>();
                FeatureDataLength = -1;
                FeatureButtonCaps = new List<HIDP_BUTTON_CAPS>();
                FeatureValueCaps = new List<HIDP_VALUE_CAPS>();
            }
        }

        #endregion

        #endregion

        #region HID WinAPI

        //功能：获取一个指定类别或全部类别的所有已安装设备的信息.
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

        [DllImport("setupapi.dll", SetLastError = true)]
        static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, uint Enumerator, IntPtr HwndParent, DIGCF Flags);

        // SetupDiEnumDeviceInterfaces 枚举设备信息集中的全部接口。
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid,
            int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, IntPtr deviceInfoData, ref Guid interfaceClassGuid,
            UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        //SetupDiGetDeviceInterfaceDetail 返回有关设备接口的详细信息
        [DllImport(@"setupapi.dll", SetLastError = true)]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

        [DllImport(@"setupapi.dll", SetLastError = true)]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr deviceInfoSet, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            IntPtr deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, SP_DEVINFO_DATA deviceInfoData);

        //功能：销毁一个设备信息集合，并且释放所有关联的内存。
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        //HidD_GetSerialNumberString 返回用于标识物理设备的序列号。
        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetSerialNumberString(IntPtr hidDeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        [DllImport("hid.dll")]
        static extern Boolean HidD_GetSerialNumberString(IntPtr hidDeviceObject, IntPtr buffer, int bufferLength);

        //HidD_FreePreparsedData 释放为HID预解析数据而分配的资源。
        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

        //HidD_GetHidGuid 返回HID设备的接口GUID。
        [DllImport("hid.dll")]
        static extern void HidD_GetHidGuid(ref Guid Guid);

        //HidD_GetPreparsedData 返回HID设备的预解析数据。
        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, out IntPtr PreparsedData);

        //HidD_GetAttributes 返回HID设备的属性
        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetAttributes(IntPtr DeviceObject, ref HIDD_ATTRIBUTES Attributes);

        //HidP_GetCaps 返回HID设备集合的HIDP_CAPS结构。
        [DllImport("hid.dll", SetLastError = true)]
        static extern uint HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

        //HidP_GetButtonCaps 返回一个按钮功能数组，该数组描述指定类型HID报告的顶级集合中的所有 HID 控制按钮。
        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_GetButtonCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_BUTTON_CAPS[] ButtonCaps,
            ref ushort ButtonCapsLength, IntPtr PreparsedData);

        //HidP_GetValueCaps 返回一个值数组，该数组描述指定类型的HID设备中的所有控制值。
        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_GetValueCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_VALUE_CAPS[] ValueCaps,
            ref ushort ValueCapsLength, IntPtr PreparsedData);

        //HidP_MaxUsageListLength 返回指定类型的HID设备的最大HID使用数。
        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_MaxUsageListLength(HIDP_REPORT_TYPE ReportType, ushort UsagePage, IntPtr PreparsedData);

        //HidP_SetUsages 将HID设备中的指定的HID控制按钮设置为 ON (1)。
        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_SetUsages(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, short Usages,
            ref int UsageLength, IntPtr PreparsedData, IntPtr Report, int ReportLength);

        //HidP_SetUsageValue 指定的HID设备中设置HID的控制值。
        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_SetUsageValue(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection,
            ushort Usage, ulong UsageValue, IntPtr PreparsedData, IntPtr Report, int ReportLength);

        //HidD_SetOutputReport 将报告发送到指定句柄。
        [DllImport("hid.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool HidD_SetOutputReport(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        //HidD_GetInputReport 从指定句柄返回输入报告。
        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetInputReport(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        //HidD_SetFeature 将特征报告发送到指定句柄
        [DllImport("hid.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool HidD_SetFeature(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        //HidD_GetFeature 返回指定句柄的属性报告。
        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetFeature(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        //HidD_GetManufacturerString 返回标识制造商的字符串。
        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetManufacturerString(IntPtr DeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        //HidD_GetProductString 返回标识制造商产品的字符串。
        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetProductString(IntPtr hidDeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        //HidD_GetIndexedString 从句柄返回指定的字符串。
        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetIndexedString(IntPtr hidDeviceObject, uint StringIdex, IntPtr pointerToBuffer, uint bufferLength);


        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(string fileName, uint fileAccess, uint fileShare, FileMapProtection securityAttributes,
            uint creationDisposition, uint flags, IntPtr overlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(string fileName, uint desiredAccess, uint shareMode,
            uint securityAttributes, uint creationDisposition, uint flagsAndAttributes, uint templateFile);

        [DllImport("kernel32.dll")]
        static extern bool WriteFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalFree(object hMem);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("User32.dll", SetLastError = true)]
        static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]// Closes the specified device notification handle.
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        #endregion

        CancellationTokenSource real_time_tokensource;
        bool debugMode = false;
        IntPtr HardwareDeviceInfo;  //设备信息
        int nbrDevices;             //设备数量
        int selectDev;              //选中的设备
        List<HID_DEVICE> pDevice;
        private void HIDForm_Load(object sender, EventArgs e)
        {
            real_time_tokensource = new CancellationTokenSource();
            Show_Real_Time();
        }
        private void InvokeToMessage(Action action)
        {
            try
            {
                this.Invoke(action);
            }
            catch { }
        }
        private void InvokeToForm(Action action)
        {
            try
            {
                this.Invoke(action);
            }
            catch { }
        }
        private void Show_Real_Time()
        {
            Task.Factory.StartNew(() =>
            {
                while (!real_time_tokensource.IsCancellationRequested)
                {
                    InvokeToForm(() => real_time_label.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    Thread.Sleep(500);
                }
            });
        }
        private void General_Info(string info_message)
        {
            try
            {
                InvokeToMessage(() => log_textBox.AppendText(DateTime.Now.TimeOfDay.ToString() + "-" + "[INFO]" + info_message + Environment.NewLine));
                InvokeToMessage(() =>
                {
                    if (log_textBox.TextLength > 200000)
                    {
                        InvokeToMessage(() => log_textBox.Clear());
                    };
                });
                InvokeToMessage(() => { log_textBox.ScrollToCaret(); });
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
            }
        }
        private void Fail_Info(string info_message)
        {
            try
            {
                InvokeToMessage(() => log_textBox.AppendText(DateTime.Now.TimeOfDay.ToString() + "-" + "[FAIL]" + info_message + Environment.NewLine));
                InvokeToMessage(() =>
                {
                    if (log_textBox.TextLength > 200000)
                    {
                        InvokeToMessage(() => log_textBox.Clear());
                    };
                });
                InvokeToMessage(() => { log_textBox.ScrollToCaret(); });
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
            }
        }
        private void Debug_Info(string info_message)
        {
            if (debugMode)
            {
                try
                {
                    InvokeToMessage(() => log_textBox.AppendText(DateTime.Now.TimeOfDay.ToString() + "-" + "[DBG]" + info_message + Environment.NewLine));
                    InvokeToMessage(() =>
                    {
                        if (log_textBox.TextLength > 200000)
                        {
                            InvokeToMessage(() => log_textBox.Clear());
                        };
                    });
                    InvokeToMessage(() => { log_textBox.ScrollToCaret(); });
                }
                catch (Exception er)
                {
                    MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
                }
            }
        }
        private void Error_Info(string message)
        {
            try
            {
                InvokeToMessage(() =>
                {
                    string log = string.Empty;
                    log = DateTime.Now.TimeOfDay.ToString() + "[ERR]-" + message + Environment.NewLine;
                    log_textBox.AppendText(log);
                    if (log_textBox.TextLength > 200000)
                    {
                        InvokeToMessage(() => log_textBox.Clear());
                    }
                    log_textBox.ScrollToCaret();
                    Application.DoEvents();
                });
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
            }
        }
        private string Analysis_Line(string msg)
        {
            int x = msg.LastIndexOf(" ");
            int y = msg.Length;
            return msg.Substring(x + 1, y - (x + 1));
        }

        int FindKnownHidDevices()
        {
            pDevice = new List<HID_DEVICE>();
            Guid hidGuid = new Guid();
            HidD_GetHidGuid(ref hidGuid);
            SetupDiDestroyDeviceInfoList(HardwareDeviceInfo);// 打开设备的句柄。
            HardwareDeviceInfo = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

            int iHIDD = 0;
            if (HardwareDeviceInfo != IntPtr.Zero)
            {
                SP_DEVICE_INTERFACE_DATA deviceInfoData = new SP_DEVICE_INTERFACE_DATA();
                deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));
                while (SetupDiEnumDeviceInterfaces(HardwareDeviceInfo, IntPtr.Zero, ref hidGuid, iHIDD, ref deviceInfoData))
                {
                    iHIDD++;
                    SP_DEVICE_INTERFACE_DETAIL_DATA FunctionClassDeviceData = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                    if (IntPtr.Size == 8)
                    {
                        FunctionClassDeviceData.cbSize = 8;
                    }
                    else if (IntPtr.Size == 4)
                    {
                        FunctionClassDeviceData.cbSize = 5;
                    }
                    int RequiredLength = 0;
                    // 分配一个设备数据结构函数来接收这个设备。
                    SetupDiGetDeviceInterfaceDetail(HardwareDeviceInfo, ref deviceInfoData,
                        IntPtr.Zero, 0, ref RequiredLength, IntPtr.Zero);

                    SetupDiGetDeviceInterfaceDetail(HardwareDeviceInfo, ref deviceInfoData, ref FunctionClassDeviceData,
                        RequiredLength, ref RequiredLength, IntPtr.Zero); //检索设备中的信息。

                    HID_DEVICE DevTemp = new HID_DEVICE();
                    DevTemp.DevicePath = FunctionClassDeviceData.DevicePath;

                    CloseHandle(DevTemp.HidDevice);
                    DevTemp.HidDevice = CreateFile(DevTemp.DevicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE,
                        0, OPEN_EXISTING, 0, IntPtr.Zero);
                    DevTemp.Attributes = new HIDD_ATTRIBUTES();

                    //HidD_FreePreparsedData(DevTemp.Ppd);
                    DevTemp.Ppd = IntPtr.Zero;
                    HidD_GetPreparsedData(DevTemp.HidDevice, out DevTemp.Ppd);
                    HidD_GetAttributes(DevTemp.HidDevice, ref DevTemp.Attributes);
                    HidP_GetCaps(DevTemp.Ppd, ref DevTemp.Caps);
                    pDevice.Add(DevTemp);
                }
            }
            return iHIDD;
        }
        private void update_dev_button_Click(object sender, EventArgs e)
        {
            try
            {
                dev_comboBox.Items.Clear();
                selectDev = 0;
                nbrDevices = FindKnownHidDevices();
                Debug_Info($"Number of devices: {nbrDevices}");
                for (int i = 0; i < nbrDevices; i++)
                {
                    if (!string.IsNullOrEmpty(pDevice[i].DevicePath))
                        dev_comboBox.Items.Add($"({i}) VID:{pDevice[i].Attributes.VendorID.ToString("X4")}  PID:{pDevice[i].Attributes.ProductID.ToString("X4")}  DevicePath:{pDevice[i].DevicePath.ToString()}");
                }
                if (nbrDevices > 0)
                {
                    dev_comboBox.SelectedIndex = 0;
                }
                dev_vid_label.Text = $"0000";
                dev_pid_label.Text = $"0000";
                dev_input_len_label.Text = $"00";
                dev_output_len_label.Text = $"00";
                dev_feature_len_label.Text = $"00";
                dev_version_label.Text = $"00";
                devi_vendor_name_label.Text = $"NA";
                devi_product_name_label.Text = $"NA";
                devi_serial_number_label.Text = $"NA";
                //mainForm_toolTip.SetToolTip(devi_vendor_name_label, "NA");
                //mainForm_toolTip.SetToolTip(devi_product_name_label, "NA");
                //mainForm_toolTip.SetToolTip(devi_serial_number_label, "NA");
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
            }
        }
        private void dev_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectDev == dev_comboBox.SelectedIndex)
                return;
            selectDev = dev_comboBox.SelectedIndex;
            set_feature_textBox.MaxLength = pDevice[selectDev].Caps.FeatureReportByteLength;
            get_feature_textBox.MaxLength = pDevice[selectDev].Caps.FeatureReportByteLength;
            dev_vid_label.Text = $"0000";
            dev_pid_label.Text = $"0000";
            dev_input_len_label.Text = $"00";
            dev_output_len_label.Text = $"00";
            dev_feature_len_label.Text = $"00";
            dev_version_label.Text = $"00";
            devi_vendor_name_label.Text = $"NA";
            devi_product_name_label.Text = $"NA";
            devi_serial_number_label.Text = $"NA";
            //mainForm_toolTip.SetToolTip(devi_vendor_name_label, "NA");
            //mainForm_toolTip.SetToolTip(devi_product_name_label, "NA");
            //mainForm_toolTip.SetToolTip(devi_serial_number_label, "NA");
            Debug_Info($"Select device: {selectDev}");
        }
        private void get_dev_info_button_Click(object sender, EventArgs e)
        {
            if (nbrDevices > 0)
            {
                try
                {
                    dev_vid_label.Text = $"{pDevice[selectDev].Attributes.VendorID.ToString("X4")}";
                    dev_pid_label.Text = $"{pDevice[selectDev].Attributes.ProductID.ToString("X4")}";
                    dev_input_len_label.Text = $"{pDevice[selectDev].Caps.InputReportByteLength}";
                    dev_output_len_label.Text = $"{pDevice[selectDev].Caps.OutputReportByteLength}";
                    dev_feature_len_label.Text = $"{pDevice[selectDev].Caps.FeatureReportByteLength}";
                    dev_version_label.Text = $"{pDevice[selectDev].Attributes.VersionNumber}";

                    uint bufferLength = 126;
                    var pointerToBuffer = Marshal.AllocHGlobal(126);
                    Marshal.FreeHGlobal(pointerToBuffer);
                    if (!HidD_GetManufacturerString(pDevice[selectDev].HidDevice, pointerToBuffer, bufferLength))
                    {
                        devi_vendor_name_label.Text = $"NA";
                        Debug_Info($"USB hid get manufacturer fail:{GetLastError()}");
                    }
                    else
                    {
                        devi_vendor_name_label.Text = Marshal.PtrToStringUni(pointerToBuffer);
                        //mainForm_toolTip.SetToolTip(devi_vendor_name_label, devi_vendor_name_label.Text);
                    }
                    if (!HidD_GetProductString(pDevice[selectDev].HidDevice, pointerToBuffer, bufferLength))
                    {
                        devi_product_name_label.Text = $"NA";
                        Debug_Info($"USB hid get product fail:{GetLastError()}");
                    }
                    else
                    {
                        devi_product_name_label.Text = Marshal.PtrToStringUni(pointerToBuffer);
                        //mainForm_toolTip.SetToolTip(devi_product_name_label, devi_product_name_label.Text);
                    }
                    if (!HidD_GetSerialNumberString(pDevice[selectDev].HidDevice, pointerToBuffer, bufferLength))
                    {
                        devi_serial_number_label.Text = $"NA";
                        Debug_Info($"USB hid get serial number fail:{GetLastError()}");
                    }
                    else
                    {
                        devi_serial_number_label.Text = Marshal.PtrToStringUni(pointerToBuffer);
                        //mainForm_toolTip.SetToolTip(devi_serial_number_label, devi_serial_number_label.Text);
                    }
                    uint index = 0;
                    for (int i = 0; i < 64; i++)
                    {
                        if (!HidD_GetIndexedString(pDevice[selectDev].HidDevice, index, pointerToBuffer, bufferLength))
                        {
                            break;
                        }
                        else
                        {
                            General_Info($"Index{i}:{Marshal.PtrToStringUni(pointerToBuffer)}");
                        }
                        index++;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select device first.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool Analytical_Set_Cmd(ref byte[] byteData, string strData, int length)
        {
            try
            {
                if (string.IsNullOrEmpty(strData))
                {
                    MessageBox.Show("Invalid commands.", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (length == 0)
                {
                    MessageBox.Show("Invalid command length.", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (strData.Length % 2 != 0)
                {
                    MessageBox.Show("Command format fail.", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                foreach (char c in strData)
                {
                    if (!(Uri.IsHexDigit(c)))
                    {
                        MessageBox.Show($"Invalid character.{c}", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                int dataLength = strData.Length / 2;
                Array.Clear(byteData, 0x00, byteData.Length);
                for (int i = 0; i < dataLength; i++)
                {
                    byteData[i] = Byte.Parse(strData.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
                return false;
            }
        }
        private void set_feature_button_Click(object sender, EventArgs e)
        {
            if (nbrDevices > 0)
            {
                int reportLength = pDevice[selectDev].Caps.FeatureReportByteLength;
                byte[] reportData = new byte[reportLength];
                //if (!Analytical_Set_Cmd(ref reportData, set_feature_textBox.Text, reportLength))
                //{
                //    return;
                //}

                byte[] data = new byte[64];
                data[0] = 0x02;
                data[1] = 0x0a;
                data[2] = 0x06;
                data[3] = 0x01;
                data[4] = 0x0d;
                data[5] = 0x0a;

                if (!HidD_SetFeature(pDevice[selectDev].HidDevice, data, (uint)64))
                {
                    Fail_Info($"usb hid set feature fail:{GetLastError()}");
                }
                else
                {
                    string strReportData = BitConverter.ToString(reportData);//.Replace("-", "")
                    General_Info($"SF:{strReportData}:{reportLength}bytes");
                    if (!HidD_GetFeature(pDevice[selectDev].HidDevice, data, (uint)64))
                    {
                        Fail_Info($"USB hid get feature fail:{GetLastError()}");
                    }
                    else
                    {
                        strReportData = BitConverter.ToString(reportData);//.Replace("-", "")
                        get_feature_textBox.Text = BitConverter.ToString(reportData).Replace("-", "");
                        General_Info($"GF:{strReportData}:{reportLength}bytes");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select device first.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void get_feature_button_Click(object sender, EventArgs e)
        {
            if (nbrDevices > 0)
            {
                int reportLength = pDevice[selectDev].Caps.FeatureReportByteLength;
                byte[] reportData = new byte[reportLength];
                if (!Analytical_Set_Cmd(ref reportData, get_feature_textBox.Text, reportLength))
                {
                    return;
                }
                if (!HidD_GetFeature(pDevice[selectDev].HidDevice, reportData, (uint)reportLength))
                {
                    Fail_Info($"USB hid get feature fail:{GetLastError()}");
                }
                else
                {
                    string strReportData = BitConverter.ToString(reportData);
                    get_feature_textBox.Text = BitConverter.ToString(reportData).Replace("-", "");
                    General_Info($"GF:{strReportData}:{reportLength}bytes");
                }
            }
            else
            {
                MessageBox.Show("Please select device first.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void save_log_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(log_textBox.Text))
                    return;
                using (SaveFileDialog Save_log = new SaveFileDialog())
                {
                    Save_log.DefaultExt = "txt";
                    Save_log.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
                    Save_log.FileName = $"log_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}";
                    Save_log.Title = "Save Log";
                    if (Save_log.ShowDialog() == DialogResult.Cancel)
                        return;
                    string FileName = Save_log.FileName;
                    if (FileName.Length > 0)
                    {
                        using (StreamWriter writer = new StreamWriter(Save_log.FileName))
                        {
                            writer.Write(this.log_textBox.Text);
                        }
                        MessageBox.Show("Save log success.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERROR:{Analysis_Line(er.StackTrace.ToString())}:{er.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error_Info(Analysis_Line(er.StackTrace.ToString()) + ":" + er.Message);
            }

        }
        private void clear_log_button_Click(object sender, EventArgs e)
        {
            log_textBox.Clear();
        }
        private void designed_label_DoubleClick(object sender, EventArgs e)
        {
            if (debugMode)
            {
                debugMode = false;
                designed_label.BackColor = Color.LightGray;
                General_Info("Exit debug mode");
            }
            else
            {
                debugMode = true;
                designed_label.BackColor = Color.Goldenrod;
                Debug_Info("Enter debug mode");
            }
        }
        private void set_feature_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                set_feature_button.PerformClick();
            }
        }
        private void get_feature_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_feature_button.PerformClick();
            }
        }
        private void find_talma_button_Click(object sender, EventArgs e)
        {
            update_dev_button.PerformClick();
            if (nbrDevices <= 0)
            {
                return;
            }
            bool getResult = false;
            for (int i = 0; i < nbrDevices; i++)
            {
                if (pDevice[i].Attributes.VendorID == 0x045E && pDevice[i].Attributes.ProductID == 0x083E && pDevice[i].Caps.FeatureReportByteLength == 64)
                {
                    getResult = true;
                    dev_comboBox.SelectedIndex = i;
                    get_dev_info_button.PerformClick();
                }
            }
            if (!getResult)
            {
                MessageBox.Show("Can not fined Talma device.", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void debug1_button_Click(object sender, EventArgs e)
        {
        }
        public HIDForm()
        {
            InitializeComponent();
            designed_label.DoubleClick += designed_label_DoubleClick;
            this.Load += HIDForm_Load;
            dev_comboBox.SelectedIndexChanged += dev_comboBox_SelectedIndexChanged;
            get_dev_info_button.Click += get_dev_info_button_Click;
            set_feature_button.Click += set_feature_button_Click;
            set_feature_textBox.KeyDown += set_feature_textBox_KeyDown;
            get_feature_textBox.KeyDown += get_feature_textBox_KeyDown;
            find_talma_button.Click += find_talma_button_Click;
            debug1_button.Click += debug1_button_Click;
            get_feature_button.Click += get_feature_button_Click;
            save_log_button.Click += save_log_button_Click;
            clear_log_button.Click += clear_log_button_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[64];
            data[0] = 0x02;
            data[1] = 0x0a;
            data[2] = 0x06;
            data[3] = 0x05;
            data[4] = 0x0d;
            data[5] = 0x0a;

            byte[] data1 = new byte[126];

            HidD_SetOutputReport(pDevice[selectDev].HidDevice, data, 64);
            HidD_GetInputReport(pDevice[selectDev].HidDevice, data1, 126);
        }
    }
}
