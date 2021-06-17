using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class EmulationContext : IDisposable
    {
        private IntPtr _hWindow;

        public EmulationContext(IntPtr hWindow)
        {
            _hWindow = hWindow;
        }

        public void KeyDown(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyDown(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void KeyUp(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyUp(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void KeyHold(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyHold(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void SysKeyDown(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyDown(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void SysKeyUp(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyUp(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void SysKeyHold(Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyHold(virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public void KeyDown(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            KeyDown(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void KeyUp(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            KeyUp(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void KeyHold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            KeyHold(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyDown(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyDown(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyUp(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyUp(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyHold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyHold(_hWindow, virtualKey, scanCode, repeatCount);
        }

        public void LButtonDown(short x, short y)
        {
            LButtonDown(_hWindow, x, y);
        }

        public void LButtonUp(short x, short y)
        {
            LButtonUp(_hWindow, x, y);
        }

        public void RButtonDown(short x, short y)
        {
            RButtonDown(_hWindow, x, y);
        }

        public void RButtonUp(short x, short y)
        {
            RButtonUp(_hWindow, x, y);
        }

        public void XButton1Down(short x, short y)
        {
            XButton1Down(_hWindow, x, y);
        }

        public void XButton1Up(short x, short y)
        {
            XButton1Up(_hWindow, x, y);
        }

        public void XButton2Down(short x, short y)
        {
            XButton2Down(_hWindow, x, y);
        }

        public void XButton2Up(short x, short y)
        {
            XButton2Up(_hWindow, x, y);
        }

        public void MouseMove(short x, short y)
        {
            MouseMove(_hWindow, x, y);
        }

        public void MouseWheel(short x, short y, short wheelDelta)
        {
            MouseWheel(_hWindow, x, y, wheelDelta);
        }

        public void MouseHWheel(short x, short y, short wheelDelta)
        {
            MouseHWheel(_hWindow, x, y, wheelDelta);
        }

        public static void KeyDown(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended
                ) << 16) | repeatCount));
        }

        public static void KeyUp(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.KEYUP, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                Keyboard.ScanCodes.Pressed |
                Keyboard.ScanCodes.Transition
                ) << 16) | repeatCount));
        }

        public static void KeyHold(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                Keyboard.ScanCodes.Pressed
                ) << 16) | repeatCount));
        }

        public static void SysKeyDown(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context
                ) << 16) | repeatCount));
        }

        public static void SysKeyUp(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.SYSKEYUP, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context |
                Keyboard.ScanCodes.Pressed |
                Keyboard.ScanCodes.Transition
                ) << 16) | repeatCount));
        }

        public static void SysKeyHold(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context |
                Keyboard.ScanCodes.Pressed
                ) << 16) | repeatCount));
        }

        public static Keyboard.ScanCodes GetScanCode(Keyboard.VirtualKeyStates virtualKey)
        {
            Keyboard.ScanCodes scanCode;
            if (!Enum.TryParse((virtualKey & Keyboard.VirtualKeyStates.KeyCode).ToString(), out scanCode))
                scanCode = 0;
            return scanCode;
        }

        public static void KeyDown(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyDown(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void KeyUp(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyUp(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void KeyHold(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyHold(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyDown(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyDown(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyUp(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyUp(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyHold(IntPtr hWindow, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyHold(hWindow, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void LButtonDown(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.LBUTTONDOWN, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void LButtonUp(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.LBUTTONUP, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void RButtonDown(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.RBUTTONDOWN, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void RButtonUp(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.RBUTTONUP, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton1Down(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x01 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton1Up(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x01 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton2Down(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x02 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton2Up(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x02 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseMove(IntPtr hWindow, short x, short y)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.MOUSEMOVE, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseWheel(IntPtr hWindow, short x, short y, short wheelDelta)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.MOUSEWHEEL, (IntPtr)(wheelDelta << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseHWheel(IntPtr hWindow, short x, short y, short wheelDelta)
        {
            Message.PostMessage(hWindow, Message.WindowsMessage.MOUSEHWHEEL, (IntPtr)(wheelDelta << 16), (IntPtr)(y << 16 | (int)x));
        }

        public void Dispose()
        {
        }
    }
}
