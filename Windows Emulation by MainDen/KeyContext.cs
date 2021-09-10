using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class KeyContext : BaseContext
    {
        public virtual void Up(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode) | Keyboard.ScanCodes.Pressed | Keyboard.ScanCodes.Transition;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYUP, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public void Up(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            Up(virtualKey, scanCode);
        }

        public virtual void Down(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode);
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public void Down(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            Down(virtualKey, scanCode);
        }

        public virtual void Hold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode) | Keyboard.ScanCodes.Pressed;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public void Hold(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            Hold(virtualKey, scanCode);
        }

        public static Keyboard.ScanCodes GetScanCode(Keyboard.VirtualKeyStates virtualKey)
        {
            if (Enum.TryParse((virtualKey & Keyboard.VirtualKeyStates.KeyCode).ToString(), out Keyboard.ScanCodes scanCode))
                return scanCode;
            return Keyboard.ScanCodes.None;
        }

        public static Keyboard.ScanCodes GetClearScanCode(Keyboard.ScanCodes scanCode)
        {
            return scanCode & (Keyboard.ScanCodes.ScanCode | Keyboard.ScanCodes.Extended | Keyboard.ScanCodes.Context);
        }

        public static IntPtr GetLParam(Keyboard.ScanCodes scanCode)
        {
            return (IntPtr)(((int)scanCode << 16) | 1);
        }
    }
}
