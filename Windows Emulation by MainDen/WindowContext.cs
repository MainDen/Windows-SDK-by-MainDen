using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class WindowContext : BaseContext
    {
        public WindowContext(BaseContext context) : base(context) { }

        public void Enable()
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x01, (IntPtr)0xC000000F);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x02, (IntPtr)0x00);
        }

        public void Disable()
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x00, (IntPtr)0xC000000F);
            Message.SendMessage(windowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x01, (IntPtr)0x00);
        }

        public bool GetRectangle(out Window.RECT rect)
        {
            return Window.GetWindowRect(windowHandle, out rect);
        }

        public bool GetClientRectangle(out Window.RECT rect)
        {
            return Window.GetClientRect(windowHandle, out rect);
        }
    }
}
