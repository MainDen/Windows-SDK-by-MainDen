using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class LayoutContext : BaseContext
    {
        public IntPtr LocaleIdentifier
        {
            get
            {
                return Keyboard.GetKeyboardLayout(Window.GetWindowThreadProcessId(WindowHandle, out _));
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
