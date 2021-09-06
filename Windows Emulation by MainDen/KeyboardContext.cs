using System;

namespace MainDen.Windows.Emulation
{
    public class KeyboardContext : BaseContext
    {
        public KeyContext Key => new KeyContext { WindowHandle = WindowHandle };

        public KeyContext SysKey => new SysKeyContext { WindowHandle = WindowHandle };

        public CharContext Char => new CharContext { WindowHandle = WindowHandle };

        public LayoutContext Layout => new LayoutContext { WindowHandle = WindowHandle };

        public void TypeText(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            var context = Char;

            foreach (var ch in text)
                context.Down(ch);
        }
    }
}
