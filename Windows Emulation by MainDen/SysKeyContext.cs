using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class SysKeyContext : KeyContext
    {
        public override void Up(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode) | Keyboard.ScanCodes.Pressed | Keyboard.ScanCodes.Transition;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.SYSKEYUP, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public override void Down(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode);
            Message.PostMessage(WindowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public override void Hold(Keyboard.VirtualKeyStates virtualKey, Keyboard.ScanCodes scanCode)
        {
            scanCode = GetClearScanCode(scanCode) | Keyboard.ScanCodes.Pressed;
            Message.PostMessage(WindowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }
    }
}
