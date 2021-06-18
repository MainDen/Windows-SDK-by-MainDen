using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class EmulationContext : ICloneable
    {
        public EmulationContext(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public EmulationContext(EmulationContext emulationContext)
        {
            lock (emulationContext.lSettings)
                windowHandle = emulationContext.windowHandle;
        }

        private readonly object lSettings = new object();

        private IntPtr windowHandle;
        public IntPtr WindowHandle
        {
            get
            {
                lock (lSettings)
                    return windowHandle;
            }
            set
            {
                lock (lSettings)
                    windowHandle = value;
            }
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
            KeyDown(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void KeyUp(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            KeyUp(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void KeyHold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            KeyHold(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyDown(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyDown(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyUp(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyUp(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void SysKeyHold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            SysKeyHold(windowHandle, virtualKey, scanCode, repeatCount);
        }

        public void LButtonDown(short x, short y)
        {
            LButtonDown(windowHandle, x, y);
        }

        public void LButtonUp(short x, short y)
        {
            LButtonUp(windowHandle, x, y);
        }

        public void RButtonDown(short x, short y)
        {
            RButtonDown(windowHandle, x, y);
        }

        public void RButtonUp(short x, short y)
        {
            RButtonUp(windowHandle, x, y);
        }

        public void XButton1Down(short x, short y)
        {
            XButton1Down(windowHandle, x, y);
        }

        public void XButton1Up(short x, short y)
        {
            XButton1Up(windowHandle, x, y);
        }

        public void XButton2Down(short x, short y)
        {
            XButton2Down(windowHandle, x, y);
        }

        public void XButton2Up(short x, short y)
        {
            XButton2Up(windowHandle, x, y);
        }

        public void MouseMove(short x, short y)
        {
            MouseMove(windowHandle, x, y);
        }

        public void MouseWheel(short x, short y, short wheelDelta)
        {
            MouseWheel(windowHandle, x, y, wheelDelta);
        }

        public void MouseHWheel(short x, short y, short wheelDelta)
        {
            MouseHWheel(windowHandle, x, y, wheelDelta);
        }

        public void SetCursor(Message.NCHITTEST.ReturnValues nonClientHitTestResult, Message.WindowsMessage trigger)
        {
            SetCursor(windowHandle, nonClientHitTestResult, trigger);
        }

        public Message.NCHITTEST.ReturnValues NonClientHitTest(short x, short y)
        {
            return NonClientHitTest(windowHandle, x, y);
        }

        public void EnableWindow()
        {
            EnableWindow(windowHandle);
        }

        public void DisableWindow()
        {
            DisableWindow(windowHandle);
        }

        public static Keyboard.ScanCodes GetScanCode(Keyboard.VirtualKeyStates virtualKey)
        {
            Keyboard.ScanCodes scanCode;
            if (!Enum.TryParse((virtualKey & Keyboard.VirtualKeyStates.KeyCode).ToString(), out scanCode))
                scanCode = 0;
            return scanCode;
        }

        public static void KeyDown(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended
                ) << 16) | repeatCount));
        }

        public static void KeyUp(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYUP, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                Keyboard.ScanCodes.Pressed |
                Keyboard.ScanCodes.Transition
                ) << 16) | repeatCount));
        }

        public static void KeyHold(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                Keyboard.ScanCodes.Pressed
                ) << 16) | repeatCount));
        }

        public static void SysKeyDown(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context
                ) << 16) | repeatCount));
        }

        public static void SysKeyUp(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYUP, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context |
                Keyboard.ScanCodes.Pressed |
                Keyboard.ScanCodes.Transition
                ) << 16) | repeatCount));
        }

        public static void SysKeyHold(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode, ushort repeatCount = 1)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey,
                (IntPtr)(((int)(
                scanCode & Keyboard.ScanCodes.ScanCode |
                scanCode & Keyboard.ScanCodes.Extended |
                scanCode & Keyboard.ScanCodes.Context |
                Keyboard.ScanCodes.Pressed
                ) << 16) | repeatCount));
        }

        public static void KeyDown(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyDown(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void KeyUp(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyUp(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void KeyHold(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            KeyHold(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyDown(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyDown(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyUp(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyUp(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void SysKeyHold(IntPtr windowHandle, Keyboard.VirtualKeyStates virtualKey, ushort repeatCount = 1)
        {
            SysKeyHold(windowHandle, virtualKey, GetScanCode(virtualKey), repeatCount);
        }

        public static void LButtonDown(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.LBUTTONDOWN, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void LButtonUp(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.LBUTTONUP, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void RButtonDown(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.RBUTTONDOWN, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void RButtonUp(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.RBUTTONUP, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton1Down(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x01 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton1Up(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x01 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton2Down(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x02 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void XButton2Up(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x02 << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseMove(IntPtr windowHandle, short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEMOVE, IntPtr.Zero, (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseWheel(IntPtr windowHandle, short x, short y, short wheelDelta)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEWHEEL, (IntPtr)(wheelDelta << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void MouseHWheel(IntPtr windowHandle, short x, short y, short wheelDelta)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEHWHEEL, (IntPtr)(wheelDelta << 16), (IntPtr)(y << 16 | (int)x));
        }

        public static void SetCursor(IntPtr windowHandle, Message.NCHITTEST.ReturnValues nonClientHitTestResult, Message.WindowsMessage trigger)
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.SETCURSOR, windowHandle, (IntPtr)(((int)trigger << 16) | (int)nonClientHitTestResult));
        }

        public static Message.NCHITTEST.ReturnValues NonClientHitTest(IntPtr windowHandle, short x, short y)
        {
            return (Message.NCHITTEST.ReturnValues)Message.SendMessage(windowHandle, Message.WindowsMessage.NCHITTEST, IntPtr.Zero, (IntPtr)((y << 16) | (int)x));
        }

        public static void EnableWindow(IntPtr windowHandle)
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x01, (IntPtr)0xC000000F);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x02, (IntPtr)0x00);
        }

        public static void DisableWindow(IntPtr windowHandle)
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x00, (IntPtr)0xC000000F);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x01, (IntPtr)0x00);
        }

        public object Clone()
        {
            return new EmulationContext(this);
        }
    }
}
