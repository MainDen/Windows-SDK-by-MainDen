﻿using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.API
{
    // Types | Constants
    public static partial class Keyboard
    {
        public static class LayoutHandle
        {
            public static readonly IntPtr Previous = (IntPtr)0;
            public static readonly IntPtr Next = (IntPtr)1;
        }
        [Flags]
        public enum EventFlags
        {
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
        }
        [Flags]
        public enum LayoutFlags : uint
        {
            Activate = 0x00000001,
            SubstitudeOk = 0x00000002,
            Reorder = 0x00000008,
            ReplaceLang = 0x00000010,
            NoteLLShell = 0x00000080,
            SetForProcess = 0x00000100,
            ShiftLock = 0x00010000,
            Reset = 0x40000000
        }
        [Flags]
        public enum KeyModifiers : int
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        public enum LanguageIdentifier : uint
        {
            SystemDefault = 0x0800,
            UserDefault = 0x0400,
            Belarusian = 0x0423,
            Chinese = 0x0C04,
            Franch = 0x080C,
            German = 0x0C07,
            Japanese = 0x0411,
            Kazak = 0x043F,
            Russian = 0x0419,
            Ukrainian = 0x0422,
            USEnglish = 0x0409
        }
        public enum ScanCodes : int
        {
            Modifiers = -65536,
            None = 0x00,
            LButton = 0x7E,
            RButton = 0x7D,
            Cancel = 0x00,
            MButton = 0x00,
            XButton1 = 0x00,
            XButton2 = 0x00,
            BackSpace = 0x0E,
            Back = 0x00,
            Tab = 0x0F,
            LineFeed = 0x00,
            Clear = 0x4C,
            Return = 0x1C,
            Enter = 0x1C,
            Shift = 0x00,
            Ctrl = 0x00,
            Control = 0x00,
            Menu = 0x00,
            Alt = 0x00,
            Pause = 0x00,
            Capital = 0x0F,
            CapsLock = 0x0F,
            Kana = 0x00,
            ImeKana = 0x00,
            ImeHanguel = 0x00,
            KanaMode = 0x00,
            Hanguel = 0x00,
            HanguelMode = 0x00,
            Hangul = 0x00,
            ImeHangul = 0x00,
            HangulMode = 0x00,
            ImeOn = 0x00,
            ImeJunja = 0x00,
            Junja = 0x00,
            JunjaMode = 0x00,
            Final = 0x00,
            ImeFinal = 0x00,
            FinalMode = 0x00,
            Hanja = 0x00,
            HanjaMode = 0x00,
            ImeHanja = 0x00,
            Kanji = 0x00,
            KanjiMode = 0x00,
            ImeKanji = 0x00,
            ImeOff = 0x00,
            Escape = 0x01,
            ImeConvert = 0x00,
            ImeNonConvert = 0x00,
            ImeAceept = 0x00,
            ImeModeChange = 0x00,
            Space = 0x39,
            PageUp = 0x49,
            Prior = 0x00,
            Next = 0x00,
            PageDown = 0x51,
            End = 0x4F,
            Home = 0x47,
            Left = 0x4B,
            Up = 0x48,
            Right = 0x4D,
            Down = 0x50,
            Select = 0x6D,
            Print = 0x00,
            Execute = 0x00,
            PrintScreen = 0x37,
            Snapshot = 0x37,
            Insert = 0x52,
            Delete = 0x53,
            Help = 0x3B,
            D0 = 0x0B,
            D1 = 0x02,
            D2 = 0x03,
            D3 = 0x04,
            D4 = 0x05,
            D5 = 0x06,
            D6 = 0x07,
            D7 = 0x08,
            D8 = 0x09,
            D9 = 0x0A,
            A = 0x1E,
            B = 0x30,
            C = 0x2E,
            D = 0x20,
            E = 0x12,
            F = 0x21,
            G = 0x22,
            H = 0x23,
            I = 0x17,
            J = 0x24,
            K = 0x25,
            L = 0x26,
            M = 0x32,
            N = 0x31,
            O = 0x18,
            P = 0x19,
            Q = 0x10,
            R = 0x13,
            S = 0x1F,
            T = 0x14,
            U = 0x16,
            V = 0x2F,
            W = 0x11,
            X = 0x2D,
            Y = 0x15,
            Z = 0x2C,
            LWin = 0x5B,
            LeftWin = 0x5B,
            RightWin = 0x5C,
            RWin = 0x5C,
            Apps = 0x5D,
            Sleep = 0x5F,
            NumPad0 = 0x52,
            NumPad1 = 0x4F,
            NumPad2 = 0x50,
            NumPad3 = 0x51,
            NumPad4 = 0x4B,
            NumPad5 = 0x4C,
            NumPad6 = 0x4D,
            NumPad7 = 0x47,
            NumPad8 = 0x48,
            NumPad9 = 0x49,
            Multiply = 0x37,
            Add = 0x4E,
            Separator = 0x00,
            Subtract = 0x4A,
            Decimal = 0x53,
            Divide = 0x35,
            F1 = 0x3B,
            F2 = 0x3C,
            F3 = 0x3D,
            F4 = 0x3E,
            F5 = 0x3F,
            F6 = 0x40,
            F7 = 0x41,
            F8 = 0x42,
            F9 = 0x43,
            F10 = 0x44,
            F11 = 0x57,
            F12 = 0x58,
            F13 = 0x5B,
            F14 = 0x5C,
            F15 = 0x5D,
            F16 = 0x63,
            F17 = 0x64,
            F18 = 0x65,
            F19 = 0x66,
            F20 = 0x67,
            F21 = 0x68,
            F22 = 0x69,
            F23 = 0x6A,
            F24 = 0x6B,
            NumLock = 0x45,
            ScrollLock = 0x46,
            Scroll = 0x46,
            ImeProcessed = 0x00,
            LeftShift = 0x2A,
            LShift = 0x2A,
            RShift = 0x36,
            RightShift = 0x36,
            LeftCtrl = 0x1D,
            LControl = 0x1D,
            LCtrl = 0x1D,
            LeftControl = 0x1D,
            RightCtrl = 0x1D,
            RControl = 0x1D,
            RCtrl = 0x1D,
            RightControl = 0x1D,
            LeftAlt = 0x38,
            LMenu = 0x38,
            LAlt = 0x38,
            LeftMenu = 0x38,
            RightAlt = 0x38,
            RAlt = 0x38,
            RMenu = 0x38,
            RightMenu = 0x38,
            BrowserBack = 0x6A,
            BrowserForward = 0x69,
            BrowserRefresh = 0x67,
            BrowserStop = 0x68,
            BrowserSearch = 0x65,
            BrowserFavorites = 0x66,
            BrowserHome = 0x32,
            VolumeMute = 0x20,
            VolumeDown = 0x2E,
            VolumeUp = 0x30,
            MediaNextTrack = 0x19,
            MediaPreviousTrack = 0x10,
            MediaStop = 0x24,
            MediaPlayPause = 0x22,
            LaunchMail = 0x6C,
            LaunchMediaSelect = 0x6D,
            LaunchApplication1 = 0x21,
            LaunchApplication2 = 0x6B,
            OemSemicolon = 0x27,
            OemСolon = 0x27,
            Oem1 = 0x27,
            OemPlus = 0x0D,
            OemComma = 0x33,
            OemMinus = 0x0C,
            OemPeriod = 0x34,
            OemDot = 0x34,
            Oem2 = 0x35,
            OemSlash = 0x35,
            OemQuestion = 0x35,
            OemBackquote = 0x29,
            OemBacktick = 0x29,
            Oem3 = 0x29,
            OemGrave = 0x29,
            OemTilde = 0x29,
            Oem4 = 0x1A,
            OemOpenBracket = 0x1A,
            OemLeftBracket = 0x1A,
            OemOpenSquareBracket = 0x1A,
            OemLeftSquareBracket = 0x1A,
            OemOpenBrace = 0x1A,
            OemLeftBrace = 0x1A,
            OemOpenCurlyBracket = 0x1A,
            OemLeftCurlyBracket = 0x1A,
            OemBackslash = 0x2B,
            OemVerticalBar = 0x2B,
            OemPipeline = 0x2B,
            OemPipe = 0x2B,
            Oem5 = 0x2B,
            OemCloseBracket = 0x1B,
            OemRightBracket = 0x1B,
            OemCloseSquareBracket = 0x1B,
            Oem6 = 0x1B,
            OemRightSquareBracket = 0x1B,
            OemCloseBrace = 0x1B,
            OemRightBrace = 0x1B,
            OemCloseCurlyBracket = 0x1B,
            OemRightCurlyBracket = 0x1B,
            OemQuote = 0x28,
            OemSingleQuote = 0x28,
            Oem7 = 0x28,
            OemDoubleQuote = 0x28,
            Oem8 = 0x00,
            Oem102 = 0x00,
            ImeProcess = 0x00,
            Packet = 0x00,
            Attn = 0x00,
            CrSel = 0x72,
            ExSel = 0x74,
            EraseEof = 0x6D,
            Play = 0x00,
            Zoom = 0x00,
            NoName = 0x00,
            PA1 = 0x00,
            OemClear = 0x00,
            KeyCode = 65535,
            ShiftModifier = 65536,
            ControlModifier = 131072,
            AltModifier = 262144,
        }
        public enum VirtualKeyStates : int
        {
            Modifiers = -65536,
            None = 0,
            LButton = 1,
            RButton = 2,
            Cancel = 3,
            MButton = 4,
            XButton1 = 5,
            XButton2 = 6,
            BackSpace = 8,
            Back = 8,
            Tab = 9,
            LineFeed = 10,
            Clear = 12,
            Return = 13,
            Enter = 13,
            Shift = 16,
            Ctrl = 17,
            Control = 17,
            Menu = 18,
            Alt = 18,
            Pause = 19,
            Capital = 20,
            CapsLock = 20,
            Kana = 21,
            ImeKana = 21,
            ImeHanguel = 21,
            KanaMode = 21,
            Hanguel = 21,
            HanguelMode = 21,
            Hangul = 21,
            ImeHangul = 21,
            HangulMode = 21,
            ImeOn = 22,
            ImeJunja = 23,
            Junja = 23,
            JunjaMode = 23,
            Final = 24,
            ImeFinal = 24,
            FinalMode = 24,
            Hanja = 25,
            HanjaMode = 25,
            ImeHanja = 25,
            Kanji = 25,
            KanjiMode = 25,
            ImeKanji = 25,
            ImeOff = 26,
            Escape = 27,
            ImeConvert = 28,
            ImeNonConvert = 29,
            ImeAceept = 30,
            ImeModeChange = 31,
            Space = 32,
            PageUp = 33,
            Prior = 33,
            Next = 34,
            PageDown = 34,
            End = 35,
            Home = 36,
            Left = 37,
            Up = 38,
            Right = 39,
            Down = 40,
            Select = 41,
            Print = 42,
            Execute = 43,
            PrintScreen = 44,
            Snapshot = 44,
            Insert = 45,
            Delete = 46,
            Help = 47,
            D0 = 48,
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57,
            A = 65,
            B = 66,
            C = 67,
            D = 68,
            E = 69,
            F = 70,
            G = 71,
            H = 72,
            I = 73,
            J = 74,
            K = 75,
            L = 76,
            M = 77,
            N = 78,
            O = 79,
            P = 80,
            Q = 81,
            R = 82,
            S = 83,
            T = 84,
            U = 85,
            V = 86,
            W = 87,
            X = 88,
            Y = 89,
            Z = 90,
            LWin = 91,
            LeftWin = 91,
            RightWin = 92,
            RWin = 92,
            Apps = 93,
            Sleep = 95,
            NumPad0 = 96,
            NumPad1 = 97,
            NumPad2 = 98,
            NumPad3 = 99,
            NumPad4 = 100,
            NumPad5 = 101,
            NumPad6 = 102,
            NumPad7 = 103,
            NumPad8 = 104,
            NumPad9 = 105,
            Multiply = 106,
            Add = 107,
            Separator = 108,
            Subtract = 109,
            Decimal = 110,
            Divide = 111,
            F1 = 112,
            F2 = 113,
            F3 = 114,
            F4 = 115,
            F5 = 116,
            F6 = 117,
            F7 = 118,
            F8 = 119,
            F9 = 120,
            F10 = 121,
            F11 = 122,
            F12 = 123,
            F13 = 124,
            F14 = 125,
            F15 = 126,
            F16 = 127,
            F17 = 128,
            F18 = 129,
            F19 = 130,
            F20 = 131,
            F21 = 132,
            F22 = 133,
            F23 = 134,
            F24 = 135,
            NumLock = 144,
            ScrollLock = 145,
            Scroll = 145,
            ImeProcessed = 155,
            LeftShift = 160,
            LShift = 160,
            RShift = 161,
            RightShift = 161,
            LeftCtrl = 162,
            LControl = 162,
            LCtrl = 162,
            LeftControl = 162,
            RightCtrl = 163,
            RControl = 163,
            RCtrl = 163,
            RightControl = 163,
            LeftAlt = 164,
            LMenu = 164,
            LAlt = 164,
            LeftMenu = 164,
            RightAlt = 165,
            RAlt = 165,
            RMenu = 165,
            RightMenu = 165,
            BrowserBack = 166,
            BrowserForward = 167,
            BrowserRefresh = 168,
            BrowserStop = 169,
            BrowserSearch = 170,
            BrowserFavorites = 171,
            BrowserHome = 172,
            VolumeMute = 173,
            VolumeDown = 174,
            VolumeUp = 175,
            MediaNextTrack = 176,
            MediaPreviousTrack = 177,
            MediaStop = 178,
            MediaPlayPause = 179,
            LaunchMail = 180,
            LaunchMediaSelect = 181,
            LaunchApplication1 = 182,
            LaunchApplication2 = 183,
            OemSemicolon = 186,
            OemСolon = 186,
            Oem1 = 186,
            OemPlus = 187,
            OemComma = 188,
            OemMinus = 189,
            OemPeriod = 190,
            OemDot = 190,
            Oem2 = 191,
            OemSlash = 191,
            OemQuestion = 191,
            OemBackquote = 192,
            OemBacktick = 192,
            Oem3 = 192,
            OemGrave = 192,
            OemTilde = 192,
            Oem4 = 219,
            OemOpenBracket = 219,
            OemLeftBracket = 219,
            OemOpenSquareBracket = 219,
            OemLeftSquareBracket = 219,
            OemOpenBrace = 219,
            OemLeftBrace = 219,
            OemOpenCurlyBracket = 219,
            OemLeftCurlyBracket = 219,
            OemBackslash = 220,
            OemVerticalBar = 220,
            OemPipeline = 220,
            OemPipe = 220,
            Oem5 = 220,
            OemCloseBracket = 221,
            OemRightBracket = 221,
            OemCloseSquareBracket = 221,
            Oem6 = 221,
            OemRightSquareBracket = 221,
            OemCloseBrace = 221,
            OemRightBrace = 221,
            OemCloseCurlyBracket = 221,
            OemRightCurlyBracket = 221,
            OemQuote = 222,
            OemSingleQuote = 222,
            Oem7 = 222,
            OemDoubleQuote = 222,
            Oem8 = 223,
            Oem102 = 226,
            ImeProcess = 229,
            Packet = 231,
            Attn = 246,
            CrSel = 247,
            ExSel = 248,
            EraseEof = 249,
            Play = 250,
            Zoom = 251,
            NoName = 252,
            PA1 = 253,
            OemClear = 254,
            KeyCode = 65535,
            ShiftModifier = 65536,
            ControlModifier = 131072,
            AltModifier = 262144,
        }
    }
    // Methods
    public static partial class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr ActivateKeyboardLayout(IntPtr hKL, LayoutFlags Flags);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(VirtualKeyStates vKey);
        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint threadId);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("USER32.dll")]
        public static extern short GetKeyState(VirtualKeyStates nVirtKey);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, EventFlags dwFlags, UIntPtr dwExtraInfo);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr LoadKeyboardLayout(string pwszKLId, LayoutFlags Flags);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnloadKeyboardLayout(IntPtr hKL);
    }
}
