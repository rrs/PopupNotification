using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace PopupNotification
{
    internal static class Win32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        public const int WDA_EXCLUDEFROMCAPTURE = 0x00000011;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        public static void HideWindowFromCapture(Window window)
        {
            var hwnd = new WindowInteropHelper(window).EnsureHandle();
            SetWindowDisplayAffinity(hwnd, WDA_EXCLUDEFROMCAPTURE);
        }
    }
}
