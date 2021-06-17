using MainDen.Windows.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainDen.Windows.Interception
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
            LShift = 0x0004,
            RShift = 0x0008,
            LCtrl = 0x0010,
            RCtrl = 0x0020,
            LAlt = 0x0040,
            RAlt = 0x0080,
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
        public bool LShift { get => _Modifiers.HasFlag(MouseModifiers.LShift); }
        public bool RShift { get => _Modifiers.HasFlag(MouseModifiers.RShift); }
        public bool Shift
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LShift) && _Key != Keyboard.VirtualKeyStates.LShift ||
                    _Modifiers.HasFlag(MouseModifiers.RShift) && _Key != Keyboard.VirtualKeyStates.RShift;
            }
        }
        public bool LCtrl { get => _Modifiers.HasFlag(MouseModifiers.LCtrl); }
        public bool RCtrl { get => _Modifiers.HasFlag(MouseModifiers.RCtrl); }
        public bool Ctrl
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LCtrl) && _Key != Keyboard.VirtualKeyStates.LCtrl ||
                    _Modifiers.HasFlag(MouseModifiers.RCtrl) && _Key != Keyboard.VirtualKeyStates.RCtrl;
            }
        }
        public bool LAlt { get => _Modifiers.HasFlag(MouseModifiers.LAlt); }
        public bool RAlt { get => _Modifiers.HasFlag(MouseModifiers.RAlt); }
        public bool Alt
        {
            get
            {
                return _Modifiers.HasFlag(MouseModifiers.LAlt) && _Key != Keyboard.VirtualKeyStates.LAlt ||
                    _Modifiers.HasFlag(MouseModifiers.RAlt) && _Key != Keyboard.VirtualKeyStates.RAlt;
            }
        }
        public bool LButton { get => _Modifiers.HasFlag(MouseModifiers.LButton); }
        public bool RButton { get => _Modifiers.HasFlag(MouseModifiers.RButton); }
        public bool MButton { get => _Modifiers.HasFlag(MouseModifiers.MButton); }
        public bool XButton1 { get => _Modifiers.HasFlag(MouseModifiers.XButton1); }
        public bool XButton2 { get => _Modifiers.HasFlag(MouseModifiers.XButton2); }
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
            UpdateModifier(MouseModifiers.LShift, Keyboard.VirtualKeyStates.LShift);
            UpdateModifier(MouseModifiers.RShift, Keyboard.VirtualKeyStates.RShift);
            UpdateModifier(MouseModifiers.LCtrl, Keyboard.VirtualKeyStates.LCtrl);
            UpdateModifier(MouseModifiers.RCtrl, Keyboard.VirtualKeyStates.RCtrl);
            UpdateModifier(MouseModifiers.LAlt, Keyboard.VirtualKeyStates.LAlt);
            UpdateModifier(MouseModifiers.RAlt, Keyboard.VirtualKeyStates.RAlt);
            UpdateModifier(MouseModifiers.LButton, Keyboard.VirtualKeyStates.LButton);
            UpdateModifier(MouseModifiers.RButton, Keyboard.VirtualKeyStates.RButton);
            UpdateModifier(MouseModifiers.MButton, Keyboard.VirtualKeyStates.MButton);
            UpdateModifier(MouseModifiers.XButton1, Keyboard.VirtualKeyStates.XButton1);
            UpdateModifier(MouseModifiers.XButton2, Keyboard.VirtualKeyStates.XButton2);
        }
        public object Clone()
        {
            return new MouseState(this);
        }
        public bool Equals(MouseState state)
        {
            if (this == state)
                return true;
            if (state is null ||
                (_Key != Keyboard.VirtualKeyStates.None &&
                state._Key != Keyboard.VirtualKeyStates.None &&
                _Key != state._Key) || _Status != state._Status)
                return false;
            if (_X != state._X || _Y != state._Y || _Wheel != state._Wheel || _HWheel != state._HWheel)
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
            if (LButton != state.LButton || RButton != state.RButton || MButton != state.MButton || XButton1 != state.XButton1 || XButton2 != state.XButton2)
                return false;
            return true;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "m + md: + :K [S]";
            string pattern = "((?'p'K|S|M|T|X|Y|W|HW|t|d)|(?'p'm)(?'s'[^m]*)m)(:(?'f'[^:]*):)?";
            List<string> simpleModifierList = new List<string>(9);
            List<MouseModifiers> modifierList = new List<MouseModifiers>(13);
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
                    if (LButton)
                        simpleModifierList.Add("LButton");
                    if (RButton)
                        simpleModifierList.Add("RButton");
                    if (MButton)
                        simpleModifierList.Add("MButton");
                    if (XButton1)
                        simpleModifierList.Add("XButton1");
                    if (XButton2)
                        simpleModifierList.Add("XButton2");
                    break;
                default:
                    if (LWin)
                        modifierList.Add(MouseModifiers.LWin);
                    if (RWin)
                        modifierList.Add(MouseModifiers.RWin);
                    if (LShift)
                        modifierList.Add(MouseModifiers.LShift);
                    if (RShift)
                        modifierList.Add(MouseModifiers.RShift);
                    if (LCtrl)
                        modifierList.Add(MouseModifiers.LCtrl);
                    if (RCtrl)
                        modifierList.Add(MouseModifiers.RCtrl);
                    if (LAlt)
                        modifierList.Add(MouseModifiers.LAlt);
                    if (RAlt)
                        modifierList.Add(MouseModifiers.RAlt);
                    if (LButton)
                        modifierList.Add(MouseModifiers.LButton);
                    if (RButton)
                        modifierList.Add(MouseModifiers.RButton);
                    if (MButton)
                        modifierList.Add(MouseModifiers.MButton);
                    if (XButton1)
                        modifierList.Add(MouseModifiers.XButton1);
                    if (XButton2)
                        modifierList.Add(MouseModifiers.XButton2);
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
                    case "M":
                        return _Modifiers.ToString(format);
                    case "X":
                        return _X.ToString(format);
                    case "Y":
                        return _Y.ToString(format);
                    case "W":
                        return _Wheel.ToString(format);
                    case "HW":
                        return _HWheel.ToString(format);
                    case "T":
                        return _Time.ToString(format);
                    case "t":
                        return format ?? "";
                    case "d":
                        if (_Modifiers != MouseModifiers.None)
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
        public static MouseState CreateCurrent(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            MouseStatus status = MouseStatus.None,
            int x = 0,
            int y = 0,
            int wheel = 0,
            int hWheel = 0,
            TimeSpan time = new TimeSpan())
        {
            MouseState state = new MouseState(key, status, MouseModifiers.None, x, y, wheel, hWheel, time);
            state.UpdateModifiers();
            return state;
        }
    }
}
