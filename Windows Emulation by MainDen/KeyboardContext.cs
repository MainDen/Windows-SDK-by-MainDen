using System;

namespace MainDen.Windows.Emulation
{
    public class KeyboardContext : BaseContext
    {
        public KeyboardContext(BaseContext context) : base(context) { }

        public KeyContext Key => new KeyContext(this);

        public KeyContext SysKey => new SysKeyContext(this);

        public CharContext Char => new CharContext(this);

        public LayoutContext Layout => new LayoutContext(this);

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
