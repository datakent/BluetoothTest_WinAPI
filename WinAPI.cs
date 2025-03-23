using System;
using System.Runtime.InteropServices;

namespace Utils
{
    public static class WinAPI
    {
        //https://learn.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-socket
        public const int AF_BTH = 32;        // Bluetooth Address Family
        public const int SOCK_STREAM = 1;    // Stream socket
        public const int IPPROTO_GGP = 3;    // Protocol placeholder

        //Address Family, Socket Type, Protocol
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int socket(int af, int type, int protocol);

        [DllImport("Ws2_32.dll")]
        public static extern int connect(int s, [MarshalAs(UnmanagedType.LPArray)] byte[] name, int namelen);

        [DllImport("ws2_32.dll")]
        public static extern int getpeername(int s, byte[] addr, ref int addrlen);

        [DllImport("ws2_32.dll")]
        public static extern int send(int s, byte[] buf, int len, int flags);

        [DllImport("ws2_32.dll")]
        public static extern int closesocket(int s);

        //---------------------------------------------------------------------------

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            private ushort year;
            private short month;
            private short dayOfWeek;
            private short day;
            private short hour;
            private short minute;
            private short second;
            private short millisecond;

            public static SYSTEMTIME FromByteArray(byte[] array, int offset)
            {
                SYSTEMTIME st = new SYSTEMTIME
                {
                    year = BitConverter.ToUInt16(array, offset),
                    month = BitConverter.ToInt16(array, offset + 2),
                    day = BitConverter.ToInt16(array, offset + 6),
                    hour = BitConverter.ToInt16(array, offset + 8),
                    minute = BitConverter.ToInt16(array, offset + 10),
                    second = BitConverter.ToInt16(array, offset + 12)
                };

                return st;
            }
            public static SYSTEMTIME FromDateTime(DateTime dt)
            {
                SYSTEMTIME st = new SYSTEMTIME
                {
                    year = (ushort)dt.Year,
                    month = (short)dt.Month,
                    dayOfWeek = (short)dt.DayOfWeek,
                    day = (short)dt.Day,
                    hour = (short)dt.Hour,
                    minute = (short)dt.Minute,
                    second = (short)dt.Second,
                    millisecond = (short)dt.Millisecond
                };

                return st;
            }

            public DateTime ToDateTime(DateTimeKind kind)
            {
                if (year == 0 && month == 0 && day == 0 && hour == 0 && minute == 0 && second == 0)
                {
                    return DateTime.MinValue;
                }
                return new DateTime(year, month, day, hour, minute, second, millisecond, kind);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct BLUETOOTH_DEVICE_INFO
        {
            internal int dwSize;
            internal ulong Address;
            internal uint ulClassofDevice;
            [MarshalAs(UnmanagedType.Bool)]
            internal bool fConnected;
            [MarshalAs(UnmanagedType.Bool)]
            internal bool fRemembered;
            [MarshalAs(UnmanagedType.Bool)]
            internal bool fAuthenticated;
            internal SYSTEMTIME stLastSeen;
            internal SYSTEMTIME stLastUsed;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 248)]
            internal string szName;

            public static BLUETOOTH_DEVICE_INFO Create()
            {
                BLUETOOTH_DEVICE_INFO info = new BLUETOOTH_DEVICE_INFO();
                info.dwSize = Marshal.SizeOf(info);
                return info;
            }

            public BLUETOOTH_DEVICE_INFO(ulong address)
            {
                dwSize = 560;
                Address = address;
                ulClassofDevice = 0;
                fConnected = false;
                fRemembered = false;
                fAuthenticated = false;

                stLastSeen = new SYSTEMTIME();
                stLastUsed = new SYSTEMTIME();

                szName = "";
            }
        }

        [DllImport("BluetoothAPIs.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int BluetoothGetDeviceInfo(IntPtr hRadio, ref BLUETOOTH_DEVICE_INFO deviceInfo);


        [StructLayout(LayoutKind.Sequential)]
        public struct WSADATA
        {
            public short wVersion;
            public short wHighVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
            public string szDescription;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public string szSystemStatus;
            public short iMaxSockets;
            public short iMaxUdpDg;
            public IntPtr lpVendorInfo;
        }

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int WSAStartup(ushort wVersionRequested, out WSADATA lpWSAData);


        //---------------------------------------------------------------------------------------



    }
}
