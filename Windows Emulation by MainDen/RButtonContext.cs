using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class RButtonContext : ButtonContext
    {
        public RButtonContext(BaseContext context) : base(context) { }

        public override void Up(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.RBUTTONUP, IntPtr.Zero, GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.RBUTTONDOWN, IntPtr.Zero, GetLParam(x, y));
        }
    }
}
