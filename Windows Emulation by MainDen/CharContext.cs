using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class CharContext : BaseContext
    {
        public CharContext(BaseContext context) : base(context) { }

        public void Up(char ch)
        {
            var scanCode = GetScanCode(ch) | Keyboard.ScanCodes.Pressed | Keyboard.ScanCodes.Transition;
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYUP, (IntPtr)ch, GetLParam(scanCode));
        }

        public void Down(char ch)
        {
            var scanCode = GetScanCode(ch);
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)ch, GetLParam(scanCode));
        }

        public void Hold(char ch)
        {
            var scanCode = GetScanCode(ch) | Keyboard.ScanCodes.Pressed;
            Message.PostMessage(windowHandle, Message.WindowsMessage.KEYDOWN, (IntPtr)ch, GetLParam(scanCode));
        }

        public static Keyboard.ScanCodes GetScanCode(char ch)
        {
            if (Enum.TryParse(ch.ToString(), out Keyboard.ScanCodes scanCode))
                return scanCode & (Keyboard.ScanCodes.ScanCode | Keyboard.ScanCodes.Extended | Keyboard.ScanCodes.Context);
            return Keyboard.ScanCodes.None;
        }

        public static IntPtr GetLParam(Keyboard.ScanCodes scanCode)
        {
            return (IntPtr)(((int)scanCode << 16) | 1);
        }
    }
}
