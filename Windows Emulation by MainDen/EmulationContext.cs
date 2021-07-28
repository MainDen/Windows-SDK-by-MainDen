namespace MainDen.Windows.Emulation
{
    public class EmulationContext : BaseContext
    {
        public EmulationContext() : base() { }

        public EmulationContext(BaseContext context) : base(context) { }

        public DeviceContext Device => new DeviceContext(this);

        public KeyboardContext Keyboard => new KeyboardContext(this);

        public MouseContext Mouse => new MouseContext(this);

        public WindowContext Window => new WindowContext(this);
    }
}
