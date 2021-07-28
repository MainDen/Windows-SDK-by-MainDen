using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class WheelContext : BaseContext
    {
        public WheelContext(BaseContext context) : base(context) { }

        public virtual void Roll(short x, short y, short delta)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEWHEEL, GetWParam(delta), GetLParam(x, y));
        }

        public static IntPtr GetLParam(short x, short y)
        {
            return (IntPtr)((y << 16) | (int)x);
        }

        public static IntPtr GetWParam(short delta)
        {
            return (IntPtr)(delta << 16);
        }
    }
}
