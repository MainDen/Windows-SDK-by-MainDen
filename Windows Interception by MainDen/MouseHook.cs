using MainDen.Windows.API;
using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interception
{
    public class MouseHook : IDisposable
    {
        public delegate void EventHandler(object sender, MouseState state);
        public delegate bool CallNextHookPredicate(object sender, MouseState state);
        public MouseHook()
        {
        }
        public event EventHandler MouseAny;
        public event EventHandler MouseDown;
        public event EventHandler MouseUp;
        public event EventHandler MouseWheel;
        public event EventHandler MouseMove;
        public event CallNextHookPredicate CallNextHook;
        private readonly object lSettings = new object();
        private IntPtr _mHHook = IntPtr.Zero;
        public bool SetHook()
        {
            lock (lSettings)
            {
                if (Unhook())
                {
                    _mHHook = Hook.SetWindowsHookEx(Hook.HookType.WH_MOUSE_LL, MouseHookProc, IntPtr.Zero, 0);
                    return _mHHook != IntPtr.Zero;
                }
                return false;
            }
        }
        public void Dispose()
        {
            Unhook();
        }
        public bool Unhook()
        {
            lock (lSettings)
            {
                if (_mHHook != IntPtr.Zero && Hook.UnhookWindowsHookEx(_mHHook))
                    _mHHook = IntPtr.Zero;
                return _mHHook == IntPtr.Zero;
            }
        }
        private IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Hook.MSLLHOOKSTRUCT hs = (Hook.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.MSLLHOOKSTRUCT));
            Message.WindowsMessage wm = (Message.WindowsMessage)wParam;
            if (nCode >= 0)
            {
                Keyboard.VirtualKeyStates key;
                switch (wm)
                {
                    case Message.WindowsMessage.LBUTTONDOWN:
                    case Message.WindowsMessage.NCLBUTTONDOWN:
                    case Message.WindowsMessage.LBUTTONUP:
                    case Message.WindowsMessage.NCLBUTTONUP:
                        key = Keyboard.VirtualKeyStates.LButton;
                        break;
                    case Message.WindowsMessage.RBUTTONDOWN:
                    case Message.WindowsMessage.NCRBUTTONDOWN:
                    case Message.WindowsMessage.RBUTTONUP:
                    case Message.WindowsMessage.NCRBUTTONUP:
                        key = Keyboard.VirtualKeyStates.RButton;
                        break;
                    case Message.WindowsMessage.MBUTTONDOWN:
                    case Message.WindowsMessage.NCMBUTTONDOWN:
                    case Message.WindowsMessage.MBUTTONUP:
                    case Message.WindowsMessage.NCMBUTTONUP:
                        key = Keyboard.VirtualKeyStates.MButton;
                        break;
                    case Message.WindowsMessage.XBUTTONDOWN:
                    case Message.WindowsMessage.NCXBUTTONDOWN:
                    case Message.WindowsMessage.XBUTTONUP:
                    case Message.WindowsMessage.NCXBUTTONUP:
                        key = (hs.mouseData & 0x10000) != 0 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2;
                        break;
                    default:
                        key = Keyboard.VirtualKeyStates.None;
                        break;
                }
                MouseState.MouseStatus status;
                switch (wm)
                {
                    case Message.WindowsMessage.LBUTTONDOWN:
                    case Message.WindowsMessage.NCLBUTTONDOWN:
                    case Message.WindowsMessage.RBUTTONDOWN:
                    case Message.WindowsMessage.NCRBUTTONDOWN:
                    case Message.WindowsMessage.MBUTTONDOWN:
                    case Message.WindowsMessage.NCMBUTTONDOWN:
                    case Message.WindowsMessage.XBUTTONDOWN:
                    case Message.WindowsMessage.NCXBUTTONDOWN:
                        status = MouseState.MouseStatus.Down;
                        break;
                    case Message.WindowsMessage.LBUTTONUP:
                    case Message.WindowsMessage.NCLBUTTONUP:
                    case Message.WindowsMessage.RBUTTONUP:
                    case Message.WindowsMessage.NCRBUTTONUP:
                    case Message.WindowsMessage.MBUTTONUP:
                    case Message.WindowsMessage.NCMBUTTONUP:
                    case Message.WindowsMessage.XBUTTONUP:
                    case Message.WindowsMessage.NCXBUTTONUP:
                        status = MouseState.MouseStatus.Up;
                        break;
                    case Message.WindowsMessage.MOUSEWHEEL:
                    case Message.WindowsMessage.MOUSEHWHEEL:
                        status = MouseState.MouseStatus.Wheel;
                        break;
                    case Message.WindowsMessage.MOUSEMOVE:
                    case Message.WindowsMessage.NCMOUSEMOVE:
                        status = MouseState.MouseStatus.Move;
                        break;
                    default:
                        status = MouseState.MouseStatus.None;
                        break;
                }
                int wheel;
                int hWheel;
                switch (wm)
                {
                    case Message.WindowsMessage.MOUSEWHEEL:
                        wheel = (short)(hs.mouseData >> 16);
                        hWheel = 0;
                        break;
                    case Message.WindowsMessage.MOUSEHWHEEL:
                        wheel = 0;
                        hWheel = (short)(hs.mouseData >> 16);
                        break;
                    default:
                        wheel = 0;
                        hWheel = 0;
                        break;
                }
                MouseState ms = MouseState.CreateCurrent(key, status, hs.x, hs.y, wheel, hWheel, TimeSpan.FromMilliseconds(hs.time));
                switch (ms.Status)
                {
                    case MouseState.MouseStatus.Down:
                        MouseAny?.Invoke(this, ms);
                        MouseDown?.Invoke(this, ms);
                        break;
                    case MouseState.MouseStatus.Up:
                        MouseAny?.Invoke(this, ms);
                        MouseUp?.Invoke(this, ms);
                        break;
                    case MouseState.MouseStatus.Wheel:
                        MouseAny?.Invoke(this, ms);
                        MouseWheel?.Invoke(this, ms);
                        break;
                    case MouseState.MouseStatus.Move:
                        MouseAny?.Invoke(this, ms);
                        MouseMove?.Invoke(this, ms);
                        break;
                    default:
                        MouseAny?.Invoke(this, ms);
                        break;
                }
                if (CallNextHook is null || CallNextHook(this, ms))
                    return Hook.CallNextHookEx(_mHHook, nCode, wParam, lParam);
                else
                    return _mHHook;
            }
            return Hook.CallNextHookEx(_mHHook, nCode, wParam, lParam);
        }
    }
}
