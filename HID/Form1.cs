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
        #region HID WinAPI
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        //功能：获取一个指定类别或全部类别的所有已安装设备的信息.
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

        // SetupDiEnumDeviceInterfaces 函数枚举设备信息集中包含的设备接口。
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        //SetupDiGetDeviceInterfaceDetail 函数返回有关设备接口的详细信息
        [DllImport(@"setupapi.dll", SetLastError = true)]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);


        [DllImport(@"setupapi.dll", SetLastError = true)]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            IntPtr DeviceInterfaceDetailData,int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(string fileName, uint fileAccess, uint fileShare, FileMapProtection securityAttributes,
            uint creationDisposition, uint flags, IntPtr overlapped);

        [DllImport("kernel32.dll")]
        static extern bool WriteFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("hid.dll")]
        static extern void HidD_GetHidGuid(ref Guid Guid);

        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);

        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetAttributes(IntPtr DeviceObject, ref HIDD_ATTRIBUTES Attributes);

        [DllImport("hid.dll", SetLastError = true)]
        static extern uint HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_GetButtonCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_BUTTON_CAPS[] ButtonCaps, ref ushort ButtonCapsLength, IntPtr PreparsedData);

        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_GetValueCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_VALUE_CAPS[] ValueCaps, ref ushort ValueCapsLength, IntPtr PreparsedData);

        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_MaxUsageListLength(HIDP_REPORT_TYPE ReportType, ushort UsagePage, IntPtr PreparsedData);

        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_SetUsages(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, short Usages, ref int UsageLength, IntPtr PreparsedData, IntPtr Report, int ReportLength);

        [DllImport("hid.dll", SetLastError = true)]
        static extern int HidP_SetUsageValue(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, ushort Usage, ulong UsageValue, IntPtr PreparsedData, IntPtr Report, int ReportLength);

        //功能：销毁一个设备信息集合，并且释放所有关联的内存。
        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalFree(object hMem);

        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("hid.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool HidD_SetFeature(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        [DllImport("hid.dll", SetLastError = true)]
        static extern bool HidD_GetFeature(IntPtr DeviceObject, byte[] Buffer, uint BufferLength);

        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetManufacturerString(IntPtr DeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetProductString(IntPtr hidDeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetSerialNumberString(IntPtr hidDeviceObject, IntPtr pointerToBuffer, uint bufferLength);

        [DllImport("hid.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool HidD_GetIndexedString(IntPtr hidDeviceObject, uint StringIdex, IntPtr pointerToBuffer, uint bufferLength);

        CancellationTokenSource real_time_tokensource;

        bool debugMode = false;
        IntPtr HardwareDeviceInfo;  //设备信息
        int nbrDevices;             //设备数量
        int selectDev;              //选中的设备

        const int DIGCF_DEFAULT = 0x00000001;
        const int DIGCF_PRESENT = 0x00000002;
        const int DIGCF_ALLCLASSES = 0x00000004;
        const int DIGCF_PROFILE = 0x00000008;
        const int DIGCF_DEVICEINTERFACE = 0x00000010;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint GENERIC_EXECUTE = 0x20000000;
        const uint GENERIC_ALL = 0x10000000;

        const uint FILE_SHARE_READ = 0x00000001;
        const uint FILE_SHARE_WRITE = 0x00000002;
        const uint FILE_SHARE_DELETE = 0x00000004;

        const uint CREATE_NEW = 1;
        const uint CREATE_ALWAYS = 2;
        const uint OPEN_EXISTING = 3;
        const uint OPEN_ALWAYS = 4;
        const uint TRUNCATE_EXISTING = 5;

        const int HIDP_STATUS_SUCCESS = 1114112;
        const int DEVICE_PATH = 260;
        const int INVALID_HANDLE_VALUE = -1;

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

        enum HIDP_REPORT_TYPE : ushort
        {
            HidP_Input = 0x00,
            HidP_Output = 0x01,
            HidP_Feature = 0x02,
        }

        [StructLayout(LayoutKind.Sequential)]
        struct LIST_ENTRY
        {
            public IntPtr Flink;
            public IntPtr Blink;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct DEVICE_LIST_NODE
        {
            public LIST_ENTRY Hdr;
            public IntPtr NotificationHandle;
            public HID_DEVICE HidDeviceInfo;
            public bool DeviceOpened;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVICE_INTERFACE_DATA
        {
            public Int32 cbSize;
            public Guid interfaceClassGuid;
            public Int32 flags;
            private UIntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public int cbSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
            public string DevicePath;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid classGuid;
            public UInt32 devInst;
            public IntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HIDP_CAPS
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

        [StructLayout(LayoutKind.Sequential)]
        struct HIDD_ATTRIBUTES
        {
            public Int32 Size;
            public Int16 VendorID;
            public Int16 ProductID;
            public Int16 VersionNumber;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ButtonData
        {
            public Int32 UsageMin;
            public Int32 UsageMax;
            public Int32 MaxUsageLength;
            public Int16 Usages;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ValueData
        {
            public ushort Usage;
            public ushort Reserved;

            public ulong Value;
            public long ScaledValue;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct HID_DATA
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

        [StructLayout(LayoutKind.Sequential)]
        public struct HIDP_Range
        {
            public ushort UsageMin, UsageMax;
            public ushort StringMin, StringMax;
            public ushort DesignatorMin, DesignatorMax;
            public ushort DataIndexMin, DataIndexMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HIDP_NotRange
        {
            public ushort Usage, Reserved1;
            public ushort StringIndex, Reserved2;
            public ushort DesignatorIndex, Reserved3;
            public ushort DataIndex, Reserved4;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct HIDP_BUTTON_CAPS
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

        [StructLayout(LayoutKind.Explicit)]
        struct HIDP_VALUE_CAPS
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

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct HID_DEVICE
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

            public IntPtr[] InputReportBuffer;
            public HID_DATA[] InputData;
            public Int32 InputDataLength;
            public HIDP_BUTTON_CAPS[] InputButtonCaps;
            public HIDP_VALUE_CAPS[] InputValueCaps;

            public IntPtr[] OutputReportBuffer;
            public HID_DATA[] OutputData;
            public Int32 OutputDataLength;
            public HIDP_BUTTON_CAPS[] OutputButtonCaps;
            public HIDP_VALUE_CAPS[] OutputValueCaps;

            public IntPtr[] FeatureReportBuffer;
            public HID_DATA[] FeatureData;
            public Int32 FeatureDataLength;
            public HIDP_BUTTON_CAPS[] FeatureButtonCaps;
            public HIDP_VALUE_CAPS[] FeatureValueCaps;
        }

        #endregion

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
            Guid hidGuid = new Guid();
            SP_DEVICE_INTERFACE_DATA deviceInfoData = new SP_DEVICE_INTERFACE_DATA();
            HidD_GetHidGuid(ref hidGuid);

            SetupDiDestroyDeviceInfoList(HardwareDeviceInfo);// 打开设备的句柄。
            HardwareDeviceInfo = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));

            int iHIDD = 0;
            while (SetupDiEnumDeviceInterfaces(HardwareDeviceInfo, IntPtr.Zero, ref hidGuid, iHIDD, ref deviceInfoData))
            {
                iHIDD++;
            }
            pDevice = new HID_DEVICE[iHIDD];

            iHIDD = 0;
            int RequiredLength = 0;
            while (SetupDiEnumDeviceInterfaces(HardwareDeviceInfo, IntPtr.Zero, ref hidGuid, iHIDD, ref deviceInfoData))
            {
                SP_DEVICE_INTERFACE_DETAIL_DATA FunctionClassDeviceData = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                if (IntPtr.Size == 8)
                {
                    FunctionClassDeviceData.cbSize = 8;
                }
                else if (IntPtr.Size == 4)
                {
                    FunctionClassDeviceData.cbSize = 5;
                }
                RequiredLength = 0;
                // 分配一个设备数据结构函数来接收这个设备。
                SetupDiGetDeviceInterfaceDetail(HardwareDeviceInfo, ref deviceInfoData,
                    IntPtr.Zero, 0, ref RequiredLength, IntPtr.Zero);
                SetupDiGetDeviceInterfaceDetail(HardwareDeviceInfo, ref deviceInfoData, ref FunctionClassDeviceData,
                    RequiredLength, ref RequiredLength, IntPtr.Zero);//检索设备中的信息。
                OpenHidDevice(FunctionClassDeviceData.DevicePath, iHIDD);// 开始时使用通用查询功能的方式打开设备
                iHIDD++;
            }
            return iHIDD;
        }
        void OpenHidDevice(string DevicePath, int iHIDD)
        {
            //例程说明：
            //给定 HardwareDeviceInfo，表示插头的句柄和播放信息和 deviceInfoData，
            //代表特定的隐藏设备，打开该设备并填写给定的所有相关信息HID_DEVICE 结构。
            pDevice[iHIDD].DevicePath = DevicePath;

            // hid.dll api 不会将重叠结构传递给 deviceiocontrol,所以要使用它们，必须有一个非重叠的设备。
            // 如果请求是为了全名用重叠的设备我们将关闭下面的设备并获得一个重叠设备句柄
            CloseHandle(pDevice[iHIDD].HidDevice);
            pDevice[iHIDD].HidDevice = CreateFile(pDevice[iHIDD].DevicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, IntPtr.Zero);
            pDevice[iHIDD].Caps = new HIDP_CAPS();
            pDevice[iHIDD].Attributes = new HIDD_ATTRIBUTES();

            //
            // If the device was not opened as overlapped, then fill in the rest of the
            //  HidDevice structure.  However, if opened as overlapped, this handle cannot
            //  be used in the calls to the HidD_ exported functions since each of these
            //  functions does synchronous I/O.
            //
            HidD_FreePreparsedData(ref pDevice[iHIDD].Ppd);
            pDevice[iHIDD].Ppd = IntPtr.Zero;
            HidD_GetPreparsedData(pDevice[iHIDD].HidDevice, ref pDevice[iHIDD].Ppd);
            HidD_GetAttributes(pDevice[iHIDD].HidDevice, ref pDevice[iHIDD].Attributes);
            HidP_GetCaps(pDevice[iHIDD].Ppd, ref pDevice[iHIDD].Caps);

            //MessageBox.Show(GetLastError().ToString());

            //
            // At this point the client has a choice.  It may chose to look at the
            // Usage and Page of the top level collection found in the HIDP_CAPS
            // structure.  In this way --------*it could just use the usages it knows about.
            // If either HidP_GetUsages or HidP_GetUsageValue return an error then
            // that particular usage does not exist in the report.
            // This is most likely the preferred method as the application can only
            // use usages of which it already knows.
            // In this case the app need not even call GetButtonCaps or GetValueCaps.
            //
            // In this example, however, we will call FillDeviceInfo to look for all
            //    of the usages in the device.
            //
            //FillDeviceInfo(ref HidDevice);
        }

        //private ToolTip mainForm_toolTip;
        HID_DEVICE[] pDevice;
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
                    for (int i = 0; i < 128; i++)
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
                if (!Analytical_Set_Cmd(ref reportData, set_feature_textBox.Text, reportLength))
                {
                    return;
                }
                if (!HidD_SetFeature(pDevice[selectDev].HidDevice, reportData, (uint)reportLength))
                {
                    Fail_Info($"usb hid set feature fail:{GetLastError()}");
                }
                else
                {
                    string strReportData = BitConverter.ToString(reportData);//.Replace("-", "")
                    General_Info($"SF:{strReportData}:{reportLength}bytes");
                    if (!HidD_GetFeature(pDevice[selectDev].HidDevice, reportData, (uint)reportLength))
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
    }
}
