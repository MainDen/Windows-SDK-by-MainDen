using MainDen.Windows.API;

namespace MainDen.Windows.Emulation
{
    public class HWheelContext : WheelContext
    {
        public override void Roll(short x, short y, short delta)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.MOUSEHWHEEL, GetWParam(delta), GetLParam(x, y));
        }
    }
}
