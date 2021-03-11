using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.API
{
    // Types | Constants
    public static partial class Mouse
    {
        [Flags]
        public enum MouseEventData : int
        {
            ZERO = 0x0000,
            XBUTTON1 = 0x0001,
            XBUTTON2 = 0x0002,
            WHEEL_DELTA = 0x0078
        }
        [Flags]
        public enum MouseEventFlags : uint
        {
            MOVE = 0x0001,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            XDOWN = 0x0080,
            XUP = 0x0100,
            WHEEL = 0x0800,
            HWHEEL = 0x01000,
            ABSOLUTE = 0x8000
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
    // Methods
    public static partial class Mouse
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlags dwFlags, int dx, int dy, MouseEventData dwData, UIntPtr dwExtraInfo);
    }
}
