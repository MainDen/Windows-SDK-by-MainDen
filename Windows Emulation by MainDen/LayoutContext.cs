using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class LayoutContext : BaseContext
    {
        public LayoutContext(BaseContext context) : base(context) { }

        public IntPtr Handle
        {
            get
            {
                return Keyboard.GetKeyboardLayout(Window.GetWindowThreadProcessId(windowHandle, out _));
            }
            set
            {
                var flags = Keyboard.LayoutFlags.Activate | Keyboard.LayoutFlags.ReplaceLang | Keyboard.LayoutFlags.SetForProcess;
                Keyboard.ActivateKeyboardLayout(value, flags);
            }
        }

        public IntPtr Next()
        {
            var flags = Keyboard.LayoutFlags.Activate | Keyboard.LayoutFlags.ReplaceLang | Keyboard.LayoutFlags.SetForProcess;
            return Keyboard.ActivateKeyboardLayout(Keyboard.LayoutHandle.Next, flags);
        }

        public IntPtr Previous()
        {
            var flags = Keyboard.LayoutFlags.Activate | Keyboard.LayoutFlags.ReplaceLang | Keyboard.LayoutFlags.SetForProcess;
            return Keyboard.ActivateKeyboardLayout(Keyboard.LayoutHandle.Previous, flags);
        }
    }
}
