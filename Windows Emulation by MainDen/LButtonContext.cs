using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class LButtonContext : ButtonContext
    {
        public LButtonContext(BaseContext context) : base(context) { }

        public override void Up(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.LBUTTONUP, IntPtr.Zero, GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.LBUTTONDOWN, IntPtr.Zero, GetLParam(x, y));
        }
    }
}
