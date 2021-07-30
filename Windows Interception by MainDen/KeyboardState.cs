using MainDen.Windows.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainDen.Windows.Interception
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
            LShift = 0x0004,
            RShift = 0x0008,
            LCtrl = 0x0010,
            RCtrl = 0x0020,
            LAlt = 0x0040,
            RAlt = 0x0080,
        }
        public KeyboardState(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            Keyboard.ScanCodes scanCode = Keyboard.ScanCodes.None,
            KeyStatus status = KeyStatus.None,
            KeyModifiers modifiers = KeyModifiers.None,
            TimeSpan time = new TimeSpan())
        {
            _Key = key;
            _ScanCode = scanCode;
            _Status = status;
            _Modifiers = modifiers;
            _Time = time;
        }
        public KeyboardState(KeyboardState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _ScanCode = state._ScanCode;
            _Status = state._Status;
            _Modifiers = state._Modifiers;
            _Time = state._Time;
        }
        private readonly Keyboard.VirtualKeyStates _Key;
        private readonly Keyboard.ScanCodes _ScanCode;
        private KeyStatus _Status;
        private KeyModifiers _Modifiers;
        private readonly TimeSpan _Time;
        public Keyboard.VirtualKeyStates Key { get => _Key; }
        public Keyboard.ScanCodes ScanCode { get => _ScanCode; }
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
        public bool LShift { get => _Modifiers.HasFlag(KeyModifiers.LShift); }
        public bool RShift { get => _Modifiers.HasFlag(KeyModifiers.RShift); }
        public bool Shift
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LShift) && _Key != Keyboard.VirtualKeyStates.LShift ||
                    _Modifiers.HasFlag(KeyModifiers.RShift) && _Key != Keyboard.VirtualKeyStates.RShift;
            }
        }
        public bool LCtrl { get => _Modifiers.HasFlag(KeyModifiers.LCtrl); }
        public bool RCtrl { get => _Modifiers.HasFlag(KeyModifiers.RCtrl); }
        public bool Ctrl
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LCtrl) && _Key != Keyboard.VirtualKeyStates.LCtrl ||
                    _Modifiers.HasFlag(KeyModifiers.RCtrl) && _Key != Keyboard.VirtualKeyStates.RCtrl;
            }
        }
        public bool LAlt { get => _Modifiers.HasFlag(KeyModifiers.LAlt); }
        public bool RAlt { get => _Modifiers.HasFlag(KeyModifiers.RAlt); }
        public bool Alt
        {
            get
            {
                return _Modifiers.HasFlag(KeyModifiers.LAlt) && _Key != Keyboard.VirtualKeyStates.LAlt ||
                    _Modifiers.HasFlag(KeyModifiers.RAlt) && _Key != Keyboard.VirtualKeyStates.RAlt;
            }
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
            UpdateModifier(KeyModifiers.LShift, Keyboard.VirtualKeyStates.LShift);
            UpdateModifier(KeyModifiers.RShift, Keyboard.VirtualKeyStates.RShift);
            UpdateModifier(KeyModifiers.LCtrl, Keyboard.VirtualKeyStates.LCtrl);
            UpdateModifier(KeyModifiers.RCtrl, Keyboard.VirtualKeyStates.RCtrl);
            UpdateModifier(KeyModifiers.LAlt, Keyboard.VirtualKeyStates.LAlt);
            UpdateModifier(KeyModifiers.RAlt, Keyboard.VirtualKeyStates.RAlt);
        }
        public object Clone()
        {
            return new KeyboardState(this);
        }
        public bool Equals(KeyboardState state)
        {
            if (this == state)
                return true;
            if (state is null ||
                (_Key != Keyboard.VirtualKeyStates.None &&
                state._Key != Keyboard.VirtualKeyStates.None &&
                _Key != state._Key) || _Status != state._Status)
                return false;
            switch (mode)
            {
                case KeyMode.Simple:
                    if (Win != state.Win || Shift != state.Shift || Ctrl != state.Ctrl || Alt != state.Alt)
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
            if (string.IsNullOrEmpty(format))
                format = "m + md: + :K [S]";
            string pattern = "((?'p'K|SC|S|M|T|t|d)|(?'p'm)(?'s'[^m]*)m)(:(?'f'[^:]*):)?";
            List<string> simpleModifierList = new List<string>(4);
            List<KeyModifiers> modifierList = new List<KeyModifiers>(8);
            KeyMode mode = Mode;
            switch (mode)
            {
                case KeyMode.Simple:
                    if (Win)
                        simpleModifierList.Add("Win");
                    if (Shift)
                        simpleModifierList.Add("Shift");
                    if (Ctrl)
                        simpleModifierList.Add("Ctrl");
                    if (Alt)
                        simpleModifierList.Add("Alt");
                    break;
                default:
                    if (LWin)
                        modifierList.Add(KeyModifiers.LWin);
                    if (RWin)
                        modifierList.Add(KeyModifiers.RWin);
                    if (LShift)
                        modifierList.Add(KeyModifiers.LShift);
                    if (RShift)
                        modifierList.Add(KeyModifiers.RShift);
                    if (LCtrl)
                        modifierList.Add(KeyModifiers.LCtrl);
                    if (RCtrl)
                        modifierList.Add(KeyModifiers.RCtrl);
                    if (LAlt)
                        modifierList.Add(KeyModifiers.LAlt);
                    if (RAlt)
                        modifierList.Add(KeyModifiers.RAlt);
                    break;
            }
            return Regex.Replace(format, pattern, match =>
            {
                string property = match.Groups["p"].Value;
                string format = match.Groups["f"].Value;
                if (format == "")
                    format = null;
                switch (property)
                {
                    case "K":
                        return _Key.ToString(format);
                    case "S":
                        return _Status.ToString(format);
                    case "SC":
                        return _ScanCode.ToString(format);
                    case "M":
                        return _Modifiers.ToString(format);
                    case "T":
                        return _Time.ToString(format);
                    case "t":
                        return format ?? "";
                    case "d":
                        if (_Modifiers != KeyModifiers.None)
                            return format ?? "";
                        return "";
                    case "m":
                        string separator = match.Groups["s"].Value;
                        switch (mode)
                        {
                            case KeyMode.Simple:
                                return string.Join(separator, simpleModifierList.ToArray());
                            default:
                                return string.Join(separator, modifierList.Select(m => m.ToString(format)).ToArray());
                        }
                    default:
                        throw new FormatException();
                }
            }, RegexOptions.Compiled);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
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
            return ToString(null, null);
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
            if (last >= 0 && Enum.TryParse(words[last], out KeyStatus staus))
                --last;
            else
                throw new FormatException();
            Keyboard.VirtualKeyStates key;
            Keyboard.ScanCodes scanCode;
            if (last >= 0)
            {
                var keyWord = words[last];
                if (Enum.TryParse(keyWord, out key))
                    --last;
                else
                    throw new FormatException();
                if (!Enum.TryParse(keyWord, out scanCode))
                    scanCode = Keyboard.ScanCodes.None;
            }
            else
                throw new FormatException();
            KeyModifiers modifiers = KeyModifiers.None;
            for (int i = 0; i <= last; i++)
                if (Enum.TryParse(words[i], out KeyModifiers modifier))
                    modifiers |= modifier;
                else
                    throw new FormatException();
            return new KeyboardState(key, scanCode, staus, modifiers);
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
        public static KeyboardState CreateCurrent(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            Keyboard.ScanCodes scanCode = Keyboard.ScanCodes.None,
            KeyStatus status = KeyStatus.None,
            TimeSpan time = new TimeSpan())
        {
            KeyboardState state = new KeyboardState(key, scanCode, status, KeyModifiers.None, time);
            state.UpdateStatus();
            state.UpdateModifiers();
            return state;
        }
    }
}
