using MainDen.Windows.API;

namespace MainDen.Windows.Emulation
{
    public class HWheelContext : WheelContext
    {
        public HWheelContext(BaseContext context) : base(context) { }

        public override void Roll(short x, short y, short delta)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEHWHEEL, GetWParam(delta), GetLParam(x, y));
        }
    }
}
