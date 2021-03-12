using MainDen.Windows.API;
using System;
using System.Text.RegularExpressions;

namespace MainDen.Windows.Interceptor
{
    public class KeyboardState : ICloneable, IFormattable
    {
        public enum KeyStatus
        {
            None = 0,
            Down = 1,
            Up = 2,
            Hold = 3,
        }
        public enum KeyMode
        {
            Default = 0,
            Simple = 1,
        }
        [Flags]
        public enum KeyModifiers
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
        }
        public KeyboardState(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            KeyStatus status = KeyStatus.None,
            KeyModifiers modifiers = KeyModifiers.None,
            TimeSpan time = new TimeSpan())
        {
            _Key = key;
            _Status = status;
            _Modifiers = modifiers;
            _Time = time;
        }
        public KeyboardState(KeyboardState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _Status = state._Status;
            _Modifiers = state._Modifiers;
            _Time = state._Time;
        }
        private Keyboard.VirtualKeyStates _Key;
        private KeyStatus _Status;
        private KeyModifiers _Modifiers;
        private TimeSpan _Time;
        public Keyboard.VirtualKeyStates Key { get => _Key; }
        public KeyStatus Status { get => _Status; }
        public KeyModifiers Modifiers { get => _Modifiers; }
        public TimeSpan Time { get => _Time; }
        public bool IsUp { get => _Status == KeyStatus.Up; }
        public bool IsDown { get => _Status == KeyStatus.Down; }
        public bool IsHold { get => _Status == KeyStatus.Hold; }
        public bool IsPressed { get => IsDown || IsHold; }
        public bool LWin { get => _Modifiers.HasFlag(KeyModifiers.LWin); }
        public bool RWin { get => _Modifiers.HasFlag(KeyModifiers.RWin); }
        public bool Win
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LWin) && _Key != Keyboard.VirtualKeyStates.LWin ||
                    _Modifiers.HasFlag(KeyModifiers.RWin) && _Key != Keyboard.VirtualKeyStates.RWin;
            }
        }
        public bool LShiftKey { get => _Modifiers.HasFlag(KeyModifiers.LShiftKey); }
        public bool RShiftKey { get => _Modifiers.HasFlag(KeyModifiers.RShiftKey); }
        public bool ShiftKey
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LShiftKey) && _Key != Keyboard.VirtualKeyStates.LShiftKey ||
                    _Modifiers.HasFlag(KeyModifiers.RShiftKey) && _Key != Keyboard.VirtualKeyStates.RShiftKey;
            }
        }
        public bool LControlKey { get => _Modifiers.HasFlag(KeyModifiers.LControlKey); }
        public bool RControlKey { get => _Modifiers.HasFlag(KeyModifiers.RControlKey); }
        public bool ControlKey
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LControlKey) && _Key != Keyboard.VirtualKeyStates.LControlKey ||
                    _Modifiers.HasFlag(KeyModifiers.RControlKey) && _Key != Keyboard.VirtualKeyStates.RControlKey;
            }
        }
        public bool LMenu { get => _Modifiers.HasFlag(KeyModifiers.LMenu); }
        public bool RMenu { get => _Modifiers.HasFlag(KeyModifiers.RMenu); }
        public bool Menu
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LMenu) && _Key != Keyboard.VirtualKeyStates.LMenu ||
                    _Modifiers.HasFlag(KeyModifiers.RMenu) && _Key != Keyboard.VirtualKeyStates.RMenu;
            }
        }
        public void Set(KeyboardState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _Status = state._Status;
            _Modifiers = state._Modifiers;
            _Time = state._Time;
        }
        private void UpdateStatus()
        {
            if (_Status == KeyStatus.Down || _Status == KeyStatus.Hold)
                _Status = (Keyboard.GetAsyncKeyState(_Key) & 0x8000) != 0 ? KeyStatus.Hold : KeyStatus.Down;
        }
        private void UpdateModifier(KeyModifiers m, Keyboard.VirtualKeyStates vk)
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
            UpdateModifier(KeyModifiers.LWin, Keyboard.VirtualKeyStates.LWin);
            UpdateModifier(KeyModifiers.RWin, Keyboard.VirtualKeyStates.RWin);
            UpdateModifier(KeyModifiers.LShiftKey, Keyboard.VirtualKeyStates.LShiftKey);
            UpdateModifier(KeyModifiers.RShiftKey, Keyboard.VirtualKeyStates.RShiftKey);
            UpdateModifier(KeyModifiers.LControlKey, Keyboard.VirtualKeyStates.LControlKey);
            UpdateModifier(KeyModifiers.RControlKey, Keyboard.VirtualKeyStates.RControlKey);
            UpdateModifier(KeyModifiers.LMenu, Keyboard.VirtualKeyStates.LMenu);
            UpdateModifier(KeyModifiers.RMenu, Keyboard.VirtualKeyStates.RMenu);
        }
        public void Update()
        {
            UpdateStatus();
            UpdateModifiers();
        }
        public object Clone()
        {
            return new KeyboardState(this);
        }
        public bool Equals(KeyboardState state)
        {
            if (this == state)
                return true;
            if (state is null || _Key != state._Key || _Status != state._Status)
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
        public static KeyboardState Empty
        {
            get
            {
                return new KeyboardState();
            }
        }
        public static KeyboardState Parse(string s)
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
            KeyStatus staus;
            if (last >= 0 && Enum.TryParse(words[last], out staus))
                --last;
            else
                throw new FormatException();
            Keyboard.VirtualKeyStates key;
            if (last >= 0 && Enum.TryParse(words[last], out key))
                --last;
            else
                throw new FormatException();
            KeyModifiers modifiers = KeyModifiers.None;
            KeyModifiers modifier;
            for (int i = 0; i <= last; i++)
                if (Enum.TryParse(words[i], out modifier))
                    modifiers |= modifier;
                else
                    throw new FormatException();
            return new KeyboardState(key, staus, modifiers);
        }
        public static bool TryParse(string s, out KeyboardState result)
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
