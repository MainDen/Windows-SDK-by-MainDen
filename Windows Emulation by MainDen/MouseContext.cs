using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class MouseContext : BaseContext
    {
        public MouseContext(BaseContext context) : base(context) { }

        public ButtonContext LButton => new LButtonContext(this);

        public ButtonContext RButton => new RButtonContext(this);

        public ButtonContext MButton => new MButtonContext(this);

        public ButtonContext XButton1 => new XButton1Context(this);

        public ButtonContext XButton2 => new XButton2Context(this);

        public WheelContext Wheel => new WheelContext(this);

        public WheelContext HWheel => new HWheelContext(this);

        public void Move(short x, short y)
        {
            Message.PostMessage(windowHandle, Message.WindowsMessage.MOUSEMOVE, IntPtr.Zero, GetLParam(x, y));
        }

        public Message.NCHITTEST.ReturnValues NonClientHitTest(short x, short y)
        {
            return (Message.NCHITTEST.ReturnValues)Message.SendMessage(windowHandle, Message.WindowsMessage.NCHITTEST, IntPtr.Zero, (IntPtr)((y << 16) | (int)x));
        }

        public void SetCursor(Message.NCHITTEST.ReturnValues nonClientHitTestResult, Message.WindowsMessage trigger)
        {
            Message.SendMessage(windowHandle, Message.WindowsMessage.SETCURSOR, windowHandle, (IntPtr)(((int)trigger << 16) | (int)nonClientHitTestResult));
        }

        public static IntPtr GetLParam(short x, short y)
        {
            return (IntPtr)((y << 16) | (int)x);
        }
    }
}
