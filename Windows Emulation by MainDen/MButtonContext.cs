using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class MButtonContext : ButtonContext
    {
        public override void Up(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.MBUTTONUP, IntPtr.Zero, GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.MBUTTONDOWN, IntPtr.Zero, GetLParam(x, y));
        }
    }
}
