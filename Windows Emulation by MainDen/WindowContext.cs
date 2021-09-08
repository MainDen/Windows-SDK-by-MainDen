using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class WindowContext : BaseContext
    {
        public void Enable()
        {
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x01, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x01, (IntPtr)0xC000000F);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x02, (IntPtr)0x00);
        }

        public void Disable()
        {
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATE, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.ACTIVATEAPP, (IntPtr)0x00, (IntPtr)0x00);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_SETCONTEXT, (IntPtr)0x00, (IntPtr)0xC000000F);
            Message.SendMessage(WindowHandle, Message.WindowsMessage.IME_NOTIFY, (IntPtr)0x01, (IntPtr)0x00);
        }

        public bool GetWindowRect(out Window.RECT rect)
        {
            return Window.GetWindowRect(WindowHandle, out rect);
        }

        public bool GetClientRect(out Window.RECT rect)
        {
            return Window.GetClientRect(WindowHandle, out rect);
        }

        public bool Move(int x, int y)
        {
            var flags = Window.SetWindowPosFlags.NoSize | Window.SetWindowPosFlags.NoZOrder;
            return Window.SetWindowPos(WindowHandle, IntPtr.Zero, x, y, 0, 0, flags);
        }

        public bool Resize(int width, int height)
        {
            var flags = Window.SetWindowPosFlags.NoMove | Window.SetWindowPosFlags.NoZOrder;
            return Window.SetWindowPos(WindowHandle, IntPtr.Zero, 0, 0, width, height, flags);
        }

        public bool TopMost
        {
            set
            {
                var flags = Window.SetWindowPosFlags.NoMove | Window.SetWindowPosFlags.NoSize;
                if (value)
                    Window.SetWindowPos(WindowHandle, Window.InsertAfter.TopMost, 0, 0, 0, 0, flags);
                else
                    Window.SetWindowPos(WindowHandle, Window.InsertAfter.NoTopMost, 0, 0, 0, 0, flags);
            }
        }

        public bool Visible
        {
            set
            {
                var flags = Window.SetWindowPosFlags.NoMove | Window.SetWindowPosFlags.NoSize | Window.SetWindowPosFlags.NoZOrder;
                if (value)
                    Window.SetWindowPos(WindowHandle, IntPtr.Zero, 0, 0, 0, 0, flags | Window.SetWindowPosFlags.ShowWindow);
                else
                    Window.SetWindowPos(WindowHandle, IntPtr.Zero, 0, 0, 0, 0, flags | Window.SetWindowPosFlags.HideWindow);
            }
        }
    }
}
