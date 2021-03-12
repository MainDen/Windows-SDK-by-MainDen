using MainDen.Windows.API;
using System;
using System.Text.RegularExpressions;

namespace MainDen.Windows.Interceptor
{
    public class MouseState : ICloneable, IFormattable
    {
        public enum MouseStatus
        {
            None = 0,
            Down = 1,
            Up = 2,
            Wheel = 3,
            Move = 4,
        }
        public enum KeyMode
        {
            Default = 0,
            Simple = 1,
        }
        [Flags]
        public enum MouseModifiers
        {
            None = 0x0000,
            LWin = 0x0001,
            RWin = 0x0002,
            LShiftKey = 0x0004,
            RShiftKey = 0x0008,
            LControlKey = 0x0010,
            RControlKey = 0x0020,
            LMenu = 0x0040,
            RMenu = 0x0080,
            LButton = 0x0100,
            RButton = 0x0200,
            MButton = 0x0400,
            XButton1 = 0x0800,
            XButton2 = 0x1000,
        }
        public MouseState(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            MouseStatus status = MouseStatus.None,
            MouseModifiers modifiers = MouseModifiers.None,
            int x = 0,
            int y = 0,
            int wheel = 0,
            int hWheel = 0,
            TimeSpan time = new TimeSpan())
        {
            _Key = key;
            _Status = status;
            _Modifiers = modifiers;
            _X = x;
            _Y = y;
            _Wheel = wheel;
            _HWheel = hWheel;
            _Time = time;
        }
        public MouseState(MouseState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _Status = state._Status;
            _Modifiers = state._Modifiers;
            _X = state._X;
            _Y = state._Y;
            _Wheel = state._Wheel;
            _HWheel = state._HWheel;
            _Time = state._Time;
        }
        private Keyboard.VirtualKeyStates _Key;
        private MouseStatus _Status;
        private MouseModifiers _Modifiers;
        private int _X;
        private int _Y;
        private int _Wheel;
        private int _HWheel;
        private TimeSpan _Time;
        public Keyboard.VirtualKeyStates Key { get => _Key; }
        public MouseStatus Status { get => _Status; }
        public MouseModifiers Modifiers { get => _Modifiers; }
        public int X { get => _X; }
        public int Y { get => _Y; }
        public int Wheel { get => _Wheel; }
        public int HWheel { get => _HWheel; }
        public TimeSpan Time { get => _Time; }
        public bool IsUp { get => _Status == MouseStatus.Up; }
        public bool IsDown { get => _Status == MouseStatus.Down; }
        public bool IsWheel { get => _Status == MouseStatus.Wheel; }
        public bool IsMove { get => _Status == MouseStatus.Move; }
        public bool LWin { get => _Modifiers.HasFlag(MouseModifiers.LWin); }
        public bool RWin { get => _Modifiers.HasFlag(MouseModifiers.RWin); }
        public bool Win
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LWin) && _Key != Keyboard.VirtualKeyStates.LWin ||
                    _Modifiers.HasFlag(MouseModifiers.RWin) && _Key != Keyboard.VirtualKeyStates.RWin;
            }
        }
        public bool LShiftKey { get => _Modifiers.HasFlag(MouseModifiers.LShiftKey); }
        public bool RShiftKey { get => _Modifiers.HasFlag(MouseModifiers.RShiftKey); }
        public bool ShiftKey
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LShiftKey) && _Key != Keyboard.VirtualKeyStates.LShiftKey ||
                    _Modifiers.HasFlag(MouseModifiers.RShiftKey) && _Key != Keyboard.VirtualKeyStates.RShiftKey;
            }
        }
        public bool LControlKey { get => _Modifiers.HasFlag(MouseModifiers.LControlKey); }
        public bool RControlKey { get => _Modifiers.HasFlag(MouseModifiers.RControlKey); }
        public bool ControlKey
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LControlKey) && _Key != Keyboard.VirtualKeyStates.LControlKey ||
                    _Modifiers.HasFlag(MouseModifiers.RControlKey) && _Key != Keyboard.VirtualKeyStates.RControlKey;
            }
        }
        public bool LMenu { get => _Modifiers.HasFlag(MouseModifiers.LMenu); }
        public bool RMenu { get => _Modifiers.HasFlag(MouseModifiers.RMenu); }
        public bool Menu
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LMenu) && _Key != Keyboard.VirtualKeyStates.LMenu ||
                    _Modifiers.HasFlag(MouseModifiers.RMenu) && _Key != Keyboard.VirtualKeyStates.RMenu;
            }
        }
        public bool LButton { get => _Modifiers.HasFlag(MouseModifiers.LButton); }
        public bool RButton { get => _Modifiers.HasFlag(MouseModifiers.RButton); }
        public bool MButton { get => _Modifiers.HasFlag(MouseModifiers.MButton); }
        public bool XButton1 { get => _Modifiers.HasFlag(MouseModifiers.XButton1); }
        public bool XButton2 { get => _Modifiers.HasFlag(MouseModifiers.XButton2); }
        public void Set(MouseState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _Status = state._Status;
            _Modifiers = state._Modifiers;
            _X = state._X;
            _Y = state._Y;
            _Wheel = state._Wheel;
            _HWheel = state._HWheel;
            _Time = state._Time;
        }
        private void UpdateModifier(MouseModifiers m, Keyboard.VirtualKeyStates vk)
        {
            if (_Key != vk)
            {
                if ((Keyboard.GetAsyncKeyState(vk) & 0x8000) != 0)
                    _Modifiers |= m;
                else
                    _Modifiers &= ~m;
                return;
            }
            else
                _Modifiers &= ~m;
        }
        private void UpdateModifiers()
        {
            UpdateModifier(MouseModifiers.LWin, Keyboard.VirtualKeyStates.LWin);
            UpdateModifier(MouseModifiers.RWin, Keyboard.VirtualKeyStates.RWin);
            UpdateModifier(MouseModifiers.LShiftKey, Keyboard.VirtualKeyStates.LShiftKey);
            UpdateModifier(MouseModifiers.RShiftKey, Keyboard.VirtualKeyStates.RShiftKey);
            UpdateModifier(MouseModifiers.LControlKey, Keyboard.VirtualKeyStates.LControlKey);
            UpdateModifier(MouseModifiers.RControlKey, Keyboard.VirtualKeyStates.RControlKey);
            UpdateModifier(MouseModifiers.LMenu, Keyboard.VirtualKeyStates.LMenu);
            UpdateModifier(MouseModifiers.RMenu, Keyboard.VirtualKeyStates.RMenu);
            UpdateModifier(MouseModifiers.LButton, Keyboard.VirtualKeyStates.LButton);
            UpdateModifier(MouseModifiers.RButton, Keyboard.VirtualKeyStates.RButton);
            UpdateModifier(MouseModifiers.MButton, Keyboard.VirtualKeyStates.MButton);
            UpdateModifier(MouseModifiers.XButton1, Keyboard.VirtualKeyStates.XButton1);
            UpdateModifier(MouseModifiers.XButton2, Keyboard.VirtualKeyStates.XButton2);
        }
        public void Update()
        {
            UpdateModifiers();
        }
        public object Clone()
        {
            return new MouseState(this);
        }
        public bool Equals(MouseState state)
        {
            if (this == state)
                return true;
            if (state is null || _Key != state._Key || _Status != state._Status)
                return false;
            if (_X != state._X || _Y != state._Y || _Wheel != state._Wheel || _HWheel != state._HWheel)
                return false;
            switch (mode)
            {
                case KeyMode.Simple:
                    if (Win != state.Win || ShiftKey != state.ShiftKey || ControlKey != state.ControlKey || Menu != state.Menu)
                        return false;
                    break;
                case KeyMode.Default:
                default:
                    if (_Modifiers != state._Modifiers)
                        return false;
                    break;
            }
            if (LButton != state.LButton || RButton != state.RButton || MButton != state.MButton || XButton1 != state.XButton1 || XButton2 != state.XButton2)
                return false;
            return true;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format is null)
                throw new ArgumentNullException(nameof(format));
            string res = "";
            string modifiers = "";
            switch (mode)
            {
                case KeyMode.Simple:
                    if (Win)
                        modifiers += "Win + ";
                    if (ShiftKey)
                        modifiers += "ShiftKey + ";
                    if (ControlKey)
                        modifiers += "ControlKey + ";
                    if (Menu)
                        modifiers += "Menu + ";
                    break;
                default:
                    if (LWin)
                        modifiers += "LWin + ";
                    if (RWin)
                        modifiers += "RWin + ";
                    if (LShiftKey)
                        modifiers += "LShiftKey + ";
                    if (RShiftKey)
                        modifiers += "RShiftKey + ";
                    if (LControlKey)
                        modifiers += "LControlKey + ";
                    if (RControlKey)
                        modifiers += "RControlKey + ";
                    if (LMenu)
                        modifiers += "LMenu + ";
                    if (RMenu)
                        modifiers += "RMenu + ";
                    break;
            }
            if (LButton)
                modifiers += "LButton + ";
            if (RButton)
                modifiers += "RButton + ";
            if (MButton)
                modifiers += "MButton + ";
            if (XButton1)
                modifiers += "XButton1 + ";
            if (XButton2)
                modifiers += "XButton2 + ";
            string stauts = _Status.ToString();
            if (format.StartsWith("m + "))
                res += modifiers;
            res += _Key.ToString();
            if (format.EndsWith(" [s]"))
                res += $" [{stauts}]";
            return res;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object o)
        {
            KeyboardState state = o as KeyboardState;
            return Equals(state);
        }
        public override string ToString()
        {
            return ToString("m + k + [s]", null);
        }
        private static volatile KeyMode mode = KeyMode.Default;
        public static KeyMode Mode { get => mode; set => mode = value; }
        public static MouseState Empty
        {
            get
            {
                return new MouseState();
            }
        }
        public static MouseState Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            MatchCollection matches = Regex.Matches(s, @"(\w)+");
            int count = matches.Count;
            if (count == 0)
                throw new FormatException();
            string[] words = new string[matches.Count];
            for (int i = 0; i < count; ++i)
                words[i] = matches[i].Value;
            int last = count - 1;
            MouseStatus staus;
            if (last >= 0 && Enum.TryParse(words[last], out staus))
                --last;
            else
                throw new FormatException();
            Keyboard.VirtualKeyStates key;
            if (last >= 0 && Enum.TryParse(words[last], out key))
                --last;
            else
                throw new FormatException();
            MouseModifiers modifiers = MouseModifiers.None;
            MouseModifiers modifier;
            for (int i = 0; i <= last; i++)
                if (Enum.TryParse(words[i], out modifier))
                    modifiers |= modifier;
                else
                    throw new FormatException();
            return new MouseState(key, staus, modifiers);
        }
        public static bool TryParse(string s, out MouseState result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
