using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Interceptor
{
    public class MouseState : ICloneable
    {
        public MouseState()
        {
            _Key = Keyboard.VirtualKeyStates.None;
            _X = 0;
            _Y = 0;
            _W = 0;
            _Pressed = false;
            _Hold = false;
            _LWin = false;
            _RWin = false;
            _LShiftKey = false;
            _RShiftKey = false;
            _LControlKey = false;
            _RControlKey = false;
            _LMenu = false;
            _RMenu = false;
            _Time = new TimeSpan();
        }
        public MouseState(
            Keyboard.VirtualKeyStates key = Keyboard.VirtualKeyStates.None,
            int x = 0,
            int y = 0,
            int w = 0,
            bool pressed = false,
            bool hold = false,
            bool lWin = false,
            bool rWin = false,
            bool lShiftKey = false,
            bool rShiftKey = false,
            bool lControlKey = false,
            bool rControlKey = false,
            bool lMenu = false,
            bool rMenu = false,
            TimeSpan time = new TimeSpan())
        {
            _Key = key;
            _X = x;
            _Y = y;
            _W = w;
            _Pressed = pressed;
            _Hold = hold;
            _LWin = lWin;
            _RWin = rWin;
            _LShiftKey = lShiftKey;
            _RShiftKey = rShiftKey;
            _LControlKey = lControlKey;
            _RControlKey = rControlKey;
            _LMenu = lMenu;
            _RMenu = rMenu;
            _Time = time;
        }
        public MouseState(MouseState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _X = state._X;
            _Y = state._Y;
            _W = state._W;
            _Pressed = state._Pressed;
            _Hold = state._Hold;
            _LWin = state._LWin;
            _RWin = state._RWin;
            _LShiftKey = state._LShiftKey;
            _RShiftKey = state._RShiftKey;
            _LControlKey = state._LControlKey;
            _RControlKey = state._RControlKey;
            _LMenu = state._LMenu;
            _RMenu = state._RMenu;
            _Time = state._Time;
        }
        private Keyboard.VirtualKeyStates _Key;
        private int _X;
        private int _Y;
        private int _W;
        private bool _Pressed;
        private bool _Hold;
        private bool _LWin;
        private bool _RWin;
        private bool _LShiftKey;
        private bool _RShiftKey;
        private bool _LControlKey;
        private bool _RControlKey;
        private bool _LMenu;
        private bool _RMenu;
        private TimeSpan _Time;
        public Keyboard.VirtualKeyStates Key { get => _Key; }
        public int X { get => _X; }
        public int Y { get => _Y; }
        public int W { get => _W; }
        public bool Pressed { get => _Pressed; }
        public bool Hold { get => _Hold; }
        public bool LWin { get => _LWin; }
        public bool RWin { get => _RWin; }
        public bool Win { get => _LWin || _RWin; }
        public bool LShiftKey { get => _LShiftKey; }
        public bool RShiftKey { get => _RShiftKey; }
        public bool ShiftKey { get => _LShiftKey || _RShiftKey; }
        public bool LControlKey { get => _LControlKey; }
        public bool RControlKey { get => _RControlKey; }
        public bool ControlKey { get => _LControlKey || _RControlKey; }
        public bool LMenu { get => _LMenu; }
        public bool RMenu { get => _RMenu; }
        public bool Menu { get => _LMenu || _RMenu; }
        public TimeSpan Time { get => _Time; }
        public void Set(MouseState state)
        {
            if (state is null)
                throw new ArgumentNullException(nameof(state));
            _Key = state._Key;
            _X = state._X;
            _Y = state._Y;
            _W = state._W;
            _Pressed = state._Pressed;
            _Hold = state._Hold;
            _LWin = state._LWin;
            _RWin = state._RWin;
            _LShiftKey = state._LShiftKey;
            _RShiftKey = state._RShiftKey;
            _LControlKey = state._LControlKey;
            _RControlKey = state._RControlKey;
            _LMenu = state._LMenu;
            _RMenu = state._RMenu;
            _Time = state._Time;
        }
        private void UpdateHold()
        {
            if (_Pressed)
                _Hold = (Keyboard.GetAsyncKeyState(_Key) & 0x8000) != 0;
        }
        private void UpdateModifiers()
        {
            if (_Key != Keyboard.VirtualKeyStates.LWin)
                _LWin = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.LWin) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.RWin)
                _RWin = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.RWin) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.LShiftKey)
                _LShiftKey = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.LShiftKey) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.RShiftKey)
                _RShiftKey = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.RShiftKey) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.LControlKey)
                _LControlKey = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.LControlKey) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.RControlKey)
                _RControlKey = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.RControlKey) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.LMenu)
                _LMenu = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.LMenu) & 0x8000) != 0;
            if (_Key != Keyboard.VirtualKeyStates.RMenu)
                _RMenu = (Keyboard.GetAsyncKeyState(Keyboard.VirtualKeyStates.RMenu) & 0x8000) != 0;
        }
        public void Update()
        {
            UpdateHold();
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
            if (state is null || _Key != state._Key || _Pressed != state._Pressed || _Hold != state._Hold)
                return false;
            if (_Simple && (Win != state.Win || ShiftKey != state.ShiftKey || ControlKey != state.ControlKey || Menu != state.Menu))
                return false;
            else if (!_Simple && (_LWin != state._LWin || _RWin != state._RWin || _LShiftKey != state._LShiftKey || _RShiftKey != state._RShiftKey ||
                _LControlKey != state._LControlKey || _RControlKey != state._RControlKey || _LMenu != state._LMenu || _RMenu != state._RMenu))
                return false;
            return true;
        }
        public string ToString(string format)
        {
            if (format is null)
                throw new ArgumentNullException(nameof(format));
            string FORMAT = format.ToUpper();
            switch (FORMAT)
            {
                case "KEY":
                case "KEY []":
                case "MOD + KEY":
                case "MOD + KEY []":
                    break;
                default:
                    return ToString();
            }
            string res = "";
            if (FORMAT == "MOD + KEY" || FORMAT == "MOD + KEY []")
                if (_Simple)
                {
                    if (_Key != Keyboard.VirtualKeyStates.LWin && _Key != Keyboard.VirtualKeyStates.RWin && Win)
                        res += "Win + ";
                    if (_Key != Keyboard.VirtualKeyStates.LShiftKey && _Key != Keyboard.VirtualKeyStates.RShiftKey && ShiftKey)
                        res += "ShiftKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.LControlKey && _Key != Keyboard.VirtualKeyStates.RControlKey && ControlKey)
                        res += "ControlKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.LMenu && _Key != Keyboard.VirtualKeyStates.RMenu && Menu)
                        res += "Menu + ";
                }
                else
                {
                    if (_Key != Keyboard.VirtualKeyStates.LWin && _LWin)
                        res += "LWin + ";
                    if (_Key != Keyboard.VirtualKeyStates.RWin && _RWin)
                        res += "RWin + ";
                    if (_Key != Keyboard.VirtualKeyStates.LShiftKey && _LShiftKey)
                        res += "LShiftKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.RShiftKey && _RShiftKey)
                        res += "RShiftKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.LControlKey && _LControlKey)
                        res += "LControlKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.RControlKey && _RControlKey)
                        res += "RControlKey + ";
                    if (_Key != Keyboard.VirtualKeyStates.LMenu && _LMenu)
                        res += "LMenu + ";
                    if (_Key != Keyboard.VirtualKeyStates.RMenu && _RMenu)
                        res += "RMenu + ";
                }
            res += _Key.ToString();
            if (FORMAT == "MOD + KEY []" || FORMAT == "KEY []")
                if (_Hold)
                    res += " [Hold]";
                else if (_Pressed)
                    res += " [Down]";
                else
                    res += " [Up]";
            return res;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object o)
        {
            if (this == o)
                return true;
            MouseState state = o as MouseState;
            return Equals(state);
        }
        public override string ToString()
        {
            string res = "";
            if (_Simple)
            {
                if (_Key != Keyboard.VirtualKeyStates.LWin && _Key != Keyboard.VirtualKeyStates.RWin && Win)
                    res += "Win + ";
                if (_Key != Keyboard.VirtualKeyStates.LShiftKey && _Key != Keyboard.VirtualKeyStates.RShiftKey && ShiftKey)
                    res += "ShiftKey + ";
                if (_Key != Keyboard.VirtualKeyStates.LControlKey && _Key != Keyboard.VirtualKeyStates.RControlKey && ControlKey)
                    res += "ControlKey + ";
                if (_Key != Keyboard.VirtualKeyStates.LMenu && _Key != Keyboard.VirtualKeyStates.RMenu && Menu)
                    res += "Menu + ";
            }
            else
            {
                if (_Key != Keyboard.VirtualKeyStates.LWin && _LWin)
                    res += "LWin + ";
                if (_Key != Keyboard.VirtualKeyStates.RWin && _RWin)
                    res += "RWin + ";
                if (_Key != Keyboard.VirtualKeyStates.LShiftKey && _LShiftKey)
                    res += "LShiftKey + ";
                if (_Key != Keyboard.VirtualKeyStates.RShiftKey && _RShiftKey)
                    res += "RShiftKey + ";
                if (_Key != Keyboard.VirtualKeyStates.LControlKey && _LControlKey)
                    res += "LControlKey + ";
                if (_Key != Keyboard.VirtualKeyStates.RControlKey && _RControlKey)
                    res += "RControlKey + ";
                if (_Key != Keyboard.VirtualKeyStates.LMenu && _LMenu)
                    res += "LMenu + ";
                if (_Key != Keyboard.VirtualKeyStates.RMenu && _RMenu)
                    res += "RMenu + ";
            }
            res += _Key.ToString();
            if (_Hold)
                res += " [Hold]";
            else if (_Pressed)
                res += " [Down]";
            else
                res += " [Up]";
            return res;
        }
        private static volatile bool _Simple = false;
        public static bool Simple { get => _Simple; set => _Simple = value; }
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
            string[] strs = s.Split(new[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (strs.Length == 0)
                throw new FormatException();
            MouseState k = Empty;
            int last = strs.Length - 1;
            if (!Enum.TryParse(strs[last--], out k._Key))
                if (last > 0 && !Enum.TryParse(strs[last--], out k._Key))
                    k._Key = Keyboard.VirtualKeyStates.None;
                else
                    throw new FormatException();
            for (int i = 0; i <= last; i++)
            {
                switch (strs[i])
                {
                    case "LWin":
                        k._LWin = true;
                        break;
                    case "RWin":
                        k._RWin = true;
                        break;
                    case "LShiftKey":
                        k._LShiftKey = true;
                        break;
                    case "RShiftKey":
                        k._RShiftKey = true;
                        break;
                    case "LControlKey":
                        k._LControlKey = true;
                        break;
                    case "RControlKey":
                        k._RControlKey = true;
                        break;
                    case "LMenu":
                        k._LMenu = true;
                        break;
                    case "RMenu":
                        k._RMenu = true;
                        break;
                }
            }
            switch (strs[strs.Length - 1])
            {
                case "[Hold]":
                    k._Hold = true;
                    k._Pressed = true;
                    break;
                case "[Up]":
                    k._Hold = false;
                    k._Pressed = false;
                    break;
                default:
                    k._Hold = false;
                    k._Pressed = true;
                    break;
            }
            return k;
        }
        public static bool TryParse(string s, out MouseState result)
        {
            result = null;
            if (s is null)
                return false;
            string[] strs = s.Split(new[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (strs.Length == 0)
                return false;
            MouseState k = Empty;
            int last = strs.Length - 1;
            if (!Enum.TryParse(strs[last--], out k._Key))
                if (last > 0 && !Enum.TryParse(strs[last--], out k._Key))
                    k._Key = Keyboard.VirtualKeyStates.None;
                else
                    return false;
            for (int i = 0; i <= last; i++)
            {
                switch (strs[i])
                {
                    case "LWin":
                        k._LWin = true;
                        break;
                    case "RWin":
                        k._RWin = true;
                        break;
                    case "LShiftKey":
                        k._LShiftKey = true;
                        break;
                    case "RShiftKey":
                        k._RShiftKey = true;
                        break;
                    case "LControlKey":
                        k._LControlKey = true;
                        break;
                    case "RControlKey":
                        k._RControlKey = true;
                        break;
                    case "LMenu":
                        k._LMenu = true;
                        break;
                    case "RMenu":
                        k._RMenu = true;
                        break;
                }
            }
            switch (strs[strs.Length - 1])
            {
                case "[Hold]":
                    k._Hold = true;
                    k._Pressed = true;
                    break;
                case "[Up]":
                    k._Hold = false;
                    k._Pressed = false;
                    break;
                default:
                    k._Hold = false;
                    k._Pressed = true;
                    break;
            }
            result = k;
            return true;
        }
    }
}
