using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class MouseContext : BaseContext
    {
        public ButtonContext LButton => new LButtonContext { WindowHandle = WindowHandle };

        public ButtonContext RButton => new RButtonContext { WindowHandle = WindowHandle };

        public ButtonContext MButton => new MButtonContext { WindowHandle = WindowHandle };

        public ButtonContext XButton1 => new XButton1Context { WindowHandle = WindowHandle };

        public ButtonContext XButton2 => new XButton2Context { WindowHandle = WindowHandle };

        public WheelContext Wheel => new WheelContext { WindowHandle = WindowHandle };

        public WheelContext HWheel => new HWheelContext { WindowHandle = WindowHandle };

        public void Move(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.MOUSEMOVE, IntPtr.Zero, GetLParam(x, y));
        }

        public Message.NCHITTEST.ReturnValues NonClientHitTest(short x, short y)
        {
            return (Message.NCHITTEST.ReturnValues)Message.SendMessage(WindowHandle, Message.WindowsMessage.NCHITTEST, IntPtr.Zero, (IntPtr)((y << 16) | (int)x));
        }

        public void SetCursor(Message.NCHITTEST.ReturnValues nonClientHitTestResult, Message.WindowsMessage trigger)
        {
            Message.SendMessage(WindowHandle, Message.WindowsMessage.SETCURSOR, WindowHandle, (IntPtr)(((int)trigger << 16) | (int)nonClientHitTestResult));
        }

        public static IntPtr GetLParam(short x, short y)
        {
            return (IntPtr)((y << 16) | (int)x);
        }
    }
}
