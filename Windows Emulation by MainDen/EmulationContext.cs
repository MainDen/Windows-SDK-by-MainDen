namespace MainDen.Windows.Emulation
{
    public class EmulationContext : BaseContext
    {
        public DeviceContext Device => new DeviceContext { WindowHandle = WindowHandle };

        public KeyboardContext Keyboard => new KeyboardContext { WindowHandle = WindowHandle };

        public MouseContext Mouse => new MouseContext { WindowHandle = WindowHandle };

        public WindowContext Window => new WindowContext { WindowHandle = WindowHandle };
    }
}
