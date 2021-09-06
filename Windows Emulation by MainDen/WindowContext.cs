using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class WindowContext : BaseContext
    {
        public void Enable()
        {
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x01, (IntPtr)0xC000000F);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x02, (IntPtr)0x00);
        }

        public void Disable()
        {
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x00, (IntPtr)0xC000000F);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x01, (IntPtr)0x00);
        }

        public bool GetWindowRect(out Window.RECT rect)
        {
            return Window.GetWindowRect(WindowHandle, out rect);
        }

        public bool GetClientRect(out Window.RECT rect)
        {
            return Window.GetClientRect(WindowHandle, out rect);
        }
    }
}
