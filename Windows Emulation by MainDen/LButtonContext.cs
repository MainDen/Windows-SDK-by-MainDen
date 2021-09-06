using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class LButtonContext : ButtonContext
    {
        public override void Up(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.LBUTTONUP, IntPtr.Zero, GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.LBUTTONDOWN, IntPtr.Zero, GetLParam(x, y));
        }
    }
}
