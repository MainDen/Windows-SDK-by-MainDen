using MainDen.Windows.API;
using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interceptor
{
    public class MouseHook : IDisposable
    {
        public delegate void EventHandler(object sender, MouseState state);
        public MouseHook()
        {
            _mProc = MouseHookProc;
        }
        public event EventHandler MouseDown;
        public event EventHandler MouseUp;
        public event EventHandler MouseWheel;
        public event EventHandler MouseHWheel;
        public event EventHandler MouseMove;
        private readonly object lSettings = new object();
        private Hook.HookProc _mProc;
        private IntPtr _mHHook = IntPtr.Zero;
        public bool SetHook()
        {
            lock (lSettings)
            {
                if (Unhook())
                {
                    _mHHook = Hook.SetWindowsHookEx(Hook.HookType.WH_MOUSE_LL, _mProc, IntPtr.Zero, 0);
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
            /* TODO: param.flags */
            Hook.MSLLHOOKSTRUCT hs = (Hook.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.MSLLHOOKSTRUCT));
            Message.WindowsMessage wm = (Message.WindowsMessage)wParam;
            if (nCode >= 0)
            {
                Keyboard.VirtualKeyStates key;
                switch (wm)
                {
                    case Message.WindowsMessage.LBUTTONDOWN:
                    case Message.WindowsMessage.LBUTTONUP:
                        key = Keyboard.VirtualKeyStates.LButton;
                        break;
                    case Message.WindowsMessage.RBUTTONDOWN:
                    case Message.WindowsMessage.RBUTTONUP:
                        key = Keyboard.VirtualKeyStates.RButton;
                        break;
                    case Message.WindowsMessage.MBUTTONDOWN:
                    case Message.WindowsMessage.MBUTTONUP:
                        key = Keyboard.VirtualKeyStates.MButton;
                        break;
                    case Message.WindowsMessage.XBUTTONDOWN:
                    case Message.WindowsMessage.XBUTTONUP:
                        key = (hs.mouseData & 0x10000) != 0 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2;
                        break;
                    default:
                        key = Keyboard.VirtualKeyStates.None;
                        break;
                }
                bool press;
                switch (wm)
                {
                    case Message.WindowsMessage.LBUTTONDOWN:
                    case Message.WindowsMessage.RBUTTONDOWN:
                    case Message.WindowsMessage.MBUTTONDOWN:
                    case Message.WindowsMessage.XBUTTONDOWN:
                        press = true;
                        break;
                    case Message.WindowsMessage.LBUTTONUP:
                    case Message.WindowsMessage.RBUTTONUP:
                    case Message.WindowsMessage.MBUTTONUP:
                    case Message.WindowsMessage.XBUTTONUP:
                    default:
                        press = false;
                        break;
                }

            }
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.LBUTTONDOWN)
            {
                MouseState state = new MouseState(Keyboard.VirtualKeyStates.LButton, hs.x, hs.y, 0, true, false, time: TimeSpan.FromMilliseconds(hs.time));
                state.Update();
                MouseDown?.Invoke(this, state);
            }
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.RBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.RButton, hs.x, hs.y, 0, true, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.MBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.MButton, hs.x, hs.y, 0, true, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.XBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState((hs.mouseData & 0x10000) != 0 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2, hs.x, hs.y, 0, true, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.LBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.LButton, hs.x, hs.y, 0, false, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.RBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.RButton, hs.x, hs.y, 0, false, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.MBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.MButton, hs.x, hs.y, 0, false, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.XBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(hs.mouseData == 1 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2, hs.x, hs.y, 0, false, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEWHEEL)
                MouseWheel?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, hs.x, hs.y, (int)hs.mouseData, true, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEHWHEEL)
                MouseHWheel?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, hs.x, hs.y, (int)hs.mouseData, true, false, time: TimeSpan.FromMilliseconds(hs.time)));
            if (nCode >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEMOVE)
                MouseMove?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, hs.x, hs.y, 0, false, false, time: TimeSpan.FromMilliseconds(hs.time)));
            return Hook.CallNextHookEx(_mHHook, nCode, wParam, lParam);
        }
    }
}
