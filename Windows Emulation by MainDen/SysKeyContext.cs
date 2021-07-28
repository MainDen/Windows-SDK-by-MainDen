using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class SysKeyContext : KeyContext
    {
        public SysKeyContext(BaseContext context) : base(context) { }

        public override void Up(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey) | Keyboard.ScanCodes.Pressed | Keyboard.ScanCodes.Transition;
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYUP, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public override void Down(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }

        public override void Hold(Keyboard.VirtualKeyStates virtualKey)
        {
            var scanCode = GetScanCode(virtualKey) | Keyboard.ScanCodes.Pressed;
            Message.PostMessage(windowHandle, Message.WindowsMessage.SYSKEYDOWN, (IntPtr)virtualKey, GetLParam(scanCode));
        }
    }
}
