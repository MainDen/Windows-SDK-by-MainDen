using MainDen.Windows.API;
using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interceptor
{
    public class KeyboardHooker : IDisposable
    {
        public delegate void EventHandler(object sender, KeyboardState state);
        public KeyboardHooker()
        {
            _kProc = KeysHookProc;
            _key = 0;
        }
        public KeyboardHooker(Keyboard.VirtualKeyStates vkCode)
        {
            _kProc = KeyHookProc;
            _key = (int)vkCode;
        }
        public event EventHandler KeyAny;
        public event EventHandler KeyDown;
        public event EventHandler KeyHold;
        public event EventHandler KeyPress;
        public event EventHandler KeyUp;
        private readonly object lSettings = new object();
        private Hook.HookProc _kProc;
        private IntPtr _kHHook = IntPtr.Zero;
        private int _key;
        public bool SetHook()
        {
            lock (lSettings)
            {
                if (Unhook())
                {
                    var hInstance = Proc.LoadLibrary("User32");
                    _kHHook = Hook.SetWindowsHookEx(Hook.HookType.WH_KEYBOARD_LL, _kProc, hInstance, 0);
                    return _kHHook != IntPtr.Zero;
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
                if (_kHHook != IntPtr.Zero && Hook.UnhookWindowsHookEx(_kHHook))
                    _kHHook = IntPtr.Zero;
                return _kHHook == IntPtr.Zero;
            }
        }
        private IntPtr KeyHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            Hook.KBDLLHOOKSTRUCT param = (Hook.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.KBDLLHOOKSTRUCT));
            if (code >= 0 && (wParam == (IntPtr)Message.WindowsMessage.KEYDOWN || wParam == (IntPtr)Message.WindowsMessage.SYSKEYDOWN) && param.vkCode == _key)
            {
                KeyboardState ks = new KeyboardState((Keyboard.VirtualKeyStates)param.vkCode, true, dateTime: new DateTime(param.time));
                ks.Update();
                if (ks.Hold)
                    KeyHold?.Invoke(this, ks);
                else
                    KeyDown?.Invoke(this, ks);
                KeyPress?.Invoke(this, ks);
                KeyAny?.Invoke(this, ks);
            }
            if (code >= 0 && (wParam == (IntPtr)Message.WindowsMessage.KEYUP || wParam == (IntPtr)Message.WindowsMessage.SYSKEYUP) && param.vkCode == _key)
            {
                KeyboardState ks = new KeyboardState((Keyboard.VirtualKeyStates)param.vkCode, false, dateTime: new DateTime(param.time));
                ks.Update();
                KeyUp?.Invoke(this, ks);
                KeyAny?.Invoke(this, ks);
            }
            return Hook.CallNextHookEx(_kHHook, code, wParam, lParam);
        }
        private IntPtr KeysHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            Hook.KBDLLHOOKSTRUCT param = (Hook.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.KBDLLHOOKSTRUCT));
            if (code >= 0 && (wParam == (IntPtr)Message.WindowsMessage.KEYDOWN || wParam == (IntPtr)Message.WindowsMessage.SYSKEYDOWN))
            {
                KeyboardState ks = new KeyboardState((Keyboard.VirtualKeyStates)param.vkCode, true, dateTime: new DateTime(param.time));
                ks.Update();
                if (ks.Hold)
                    KeyHold?.Invoke(this, ks);
                else
                    KeyDown?.Invoke(this, ks);
                KeyPress?.Invoke(this, ks);
                KeyAny?.Invoke(this, ks);
            }
            if (code >= 0 && (wParam == (IntPtr)Message.WindowsMessage.KEYUP || wParam == (IntPtr)Message.WindowsMessage.SYSKEYUP))
            {
                KeyboardState ks = new KeyboardState((Keyboard.VirtualKeyStates)param.vkCode, false, dateTime: new DateTime(param.time));
                ks.Update();
                KeyUp?.Invoke(this, ks);
                KeyAny?.Invoke(this, ks);
            }
            return Hook.CallNextHookEx(_kHHook, code, wParam, lParam);
        }
    }
}
