using MainDen.Windows.API;
using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interceptor
{
    public class MouseHooker : IDisposable
    {
        public delegate void EventHandler(object sender, MouseState state);
        public MouseHooker()
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
                    var hInstance = Proc.LoadLibrary("User32");
                    _mHHook = Hook.SetWindowsHookEx(Hook.HookType.WH_MOUSE_LL, _mProc, hInstance, 0);
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
        private IntPtr MouseHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            /* TODO: param.flags */
            Hook.MSLLHOOKSTRUCT param = (Hook.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.MSLLHOOKSTRUCT));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.LBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.LButton, param.x, param.y, 0, true, false, dateTime:new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.RBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.RButton, param.x, param.y, 0, true, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.MBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.MButton, param.x, param.y, 0, true, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.XBUTTONDOWN)
                MouseDown?.Invoke(this, new MouseState((param.mouseData & 0x10000) != 0 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2, param.x, param.y, 0, true, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.LBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.LButton, param.x, param.y, 0, false, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.RBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.RButton, param.x, param.y, 0, false, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.MBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.MButton, param.x, param.y, 0, false, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.XBUTTONUP)
                MouseUp?.Invoke(this, new MouseState(param.mouseData == 1 ? Keyboard.VirtualKeyStates.XButton1 : Keyboard.VirtualKeyStates.XButton2, param.x, param.y, 0, false, false, dateTime: new DateTime(param.time)));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEWHEEL)
                MouseWheel?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, param.x, param.y, (int)param.mouseData, true, false));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEHWHEEL)
                MouseHWheel?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, param.x, param.y, (int)param.mouseData, true, false));
            if (code >= 0 && wParam == (IntPtr)Message.WindowsMessage.MOUSEMOVE)
                MouseMove?.Invoke(this, new MouseState(Keyboard.VirtualKeyStates.None, param.x, param.y, 0, false, false));
            return Hook.CallNextHookEx(_mHHook, code, wParam, lParam);
        }
    }
}
