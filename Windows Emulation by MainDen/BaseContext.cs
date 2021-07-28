using System;

namespace MainDen.Windows.Emulation
{
    public abstract class BaseContext
    {
        public BaseContext()
        {
            windowHandle = IntPtr.Zero;
        }

        public BaseContext(BaseContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            windowHandle = context.WindowHandle;
        }

        protected readonly object lSettings = new object();

        protected IntPtr windowHandle;

        public IntPtr WindowHandle
        {
            get
            {
                lock (lSettings)
                    return windowHandle;
            }
            set
            {
                lock (lSettings)
                    windowHandle = value;
            }
        }
    }
}
