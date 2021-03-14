using MainDen.Windows.API;
using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interceptor
{
    public class KeyboardHook : IDisposable
    {
        public delegate void EventHandler(object sender, KeyboardState state);
        public KeyboardHook(Keyboard.VirtualKeyStates vkCode = Keyboard.VirtualKeyStates.None)
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
                    _kHHook = Hook.SetWindowsHookEx(Hook.HookType.WH_KEYBOARD_LL, _kProc, IntPtr.Zero, 0);
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
        private IntPtr KeyHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Hook.KBDLLHOOKSTRUCT hs = (Hook.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Hook.KBDLLHOOKSTRUCT));
            Message.WindowsMessage wm = (Message.WindowsMessage)wParam;
            if (nCode >= 0 && (_key == 0 || _key == hs.vkCode))
            {
                Keyboard.VirtualKeyStates key = (Keyboard.VirtualKeyStates)hs.vkCode;
                KeyboardState.KeyStatus status;
                switch (wm)
                {
                    case Message.WindowsMessage.KEYDOWN:
                    case Message.WindowsMessage.SYSKEYDOWN:
                        status = KeyboardState.KeyStatus.Down;
                        break;
                    case Message.WindowsMessage.KEYUP:
                    case Message.WindowsMessage.SYSKEYUP:
                        status = KeyboardState.KeyStatus.Up;
                        break;
                    default:
                        status = KeyboardState.KeyStatus.None;
                        break;
                }
                TimeSpan time = TimeSpan.FromMilliseconds(hs.time);
                KeyboardState ks = KeyboardState.CreateCurrent(key, status, time);
                switch (ks.Status)
                {
                    case KeyboardState.KeyStatus.Down:
                        KeyAny?.Invoke(this, ks);
                        KeyPress?.Invoke(this, ks);
                        KeyDown?.Invoke(this, ks);
                        break;
                    case KeyboardState.KeyStatus.Hold:
                        KeyAny?.Invoke(this, ks);
                        KeyPress?.Invoke(this, ks);
                        KeyHold?.Invoke(this, ks);
                        break;
                    case KeyboardState.KeyStatus.Up:
                        KeyAny?.Invoke(this, ks);
                        KeyUp?.Invoke(this, ks);
                        break;
                    default:
                        KeyAny?.Invoke(this, ks);
                        break;
                }
            }
            return Hook.CallNextHookEx(_kHHook, nCode, wParam, lParam);
        }
    }
}
