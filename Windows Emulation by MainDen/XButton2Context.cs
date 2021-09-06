﻿using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class XButton2Context : ButtonContext
    {
        public override void Up(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.XBUTTONUP, (IntPtr)(0x02 << 16), GetLParam(x, y));
        }

        public override void Down(short x, short y)
        {
            Message.PostMessage(WindowHandle, Message.WindowsMessage.XBUTTONDOWN, (IntPtr)(0x02 << 16), GetLParam(x, y));
        }
    }
}
