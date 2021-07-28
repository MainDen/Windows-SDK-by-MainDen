using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class XButton1Context : ButtonContext
    {
        public XButton1Context(BaseContext context) : base(context) { }

        public override void Up(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x01 << 16), GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x01 << 16), GetLParam(x, y));
        }
    }
}
