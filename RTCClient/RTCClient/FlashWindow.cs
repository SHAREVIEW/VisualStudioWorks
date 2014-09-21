using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RTCClient
{
    class FlashWindow
    {
        [DllImport("user32.dll")]
        static extern Int16 FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt16 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt16 uCount;
            public UInt32 dwTimeout;
        }

        //Stop flashing. The system restores the window to its original state.
        public const UInt32 FLASHW_STOP = 0;
        //Flash the window caption.
        public const UInt32 FLASHW_CAPTION = 1;
        //Flash the taskbar button.
        public const UInt32 FLASHW_TRAY = 2;
        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        public const UInt32 FLASHW_ALL = 3;
        //Flash continuously, until the FLASHW_STOP flag is set.
        public const UInt32 FLASHW_TIMER = 4;
        //Flash continuously until the window comes to the foreground.
        public const UInt32 FLASHW_TIMERNOFG = 12;

        /// <summary>
        /// Flashes a window
        /// </summary>
        /// <param name="hWnd">The handle to the window to flash</param>
        /// <returns>whether or not the window needed flashing</returns>
        public static bool FlashWindowEx(IntPtr hWnd, UInt32 flag)
        {
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = (ushort)Marshal.SizeOf(fInfo);
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = flag;
            fInfo.uCount = UInt16.MaxValue;
            fInfo.dwTimeout = 0;

            return (FlashWindowEx(ref fInfo) == 0);
        }

    }
}
