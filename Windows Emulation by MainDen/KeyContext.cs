using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class KeyContext : BaseContext
    {
        public virtual void Up(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey) | Keyboard.ScanCodes.Pressed | Keyboard.ScanCodes.Transition;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYUP, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public virtual void Down(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public virtual void Hold(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey) | Keyboard.ScanCodes.Pressed;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public static Keyboard.ScanCodes GetScanCode(Keyboard.VirtualKeyStates virtualKey)
        {
            if (Enum.TryParse((virtualKey & Keyboard.VirtualKeyStates.KeyCode).ToString(), out Keyboard.ScanCodes scanCode))
                return scanCode & (Keyboard.ScanCodes.ScanCode | Keyboard.ScanCodes.Extended | Keyboard.ScanCodes.Context);
            return Keyboard.ScanCodes.None;
        }

        public static IntPtr GetLParam(Keyboard.ScanCodes scanCode)
        {
            return (IntPtr)(((int)scanCode << 16) | 1);
        }
    }
}
