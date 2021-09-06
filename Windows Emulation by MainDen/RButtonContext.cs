using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class RButtonContext : ButtonContext
    {
        public override void Up(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.RBUTTONUP, IntPtr.Zero, GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.RBUTTONDOWN, IntPtr.Zero, GetLParam(x, y));
        }
    }
}
