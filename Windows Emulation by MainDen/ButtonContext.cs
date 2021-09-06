using System;

namespace MainDen.Windows.Emulation
{
    public abstract class ButtonContext : BaseContext
    {
        public abstract void Up(short x, short y);

        public abstract void Down(short x, short y);

        public static IntPtr GetLParam(short x, short y)
        {
            return (IntPtr)((y << 16) | (int)x);
        }
    }
}
