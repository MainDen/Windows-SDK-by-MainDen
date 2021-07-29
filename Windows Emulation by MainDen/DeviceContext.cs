using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class DeviceContext : BaseContext
    {
        public DeviceContext(BaseContext context) : base(context) { }

        public IntPtr CaptureWindow()
        {
            IntPtr hSource = Window.GetWindowDC(windowHandle);
            Window.GetWindowRect(windowHandle, out Window.RECT windowRect);
            int width = windowRect.Width;
            int height = windowRect.Height;
            IntPtr hDest = GDI.CreateCompatibleDC(hSource);
            IntPtr hBitmap = GDI.CreateCompatibleBitmap(hSource, width, height);
            IntPtr hOld = GDI.SelectObject(hDest, hBitmap);
            GDI.BitBlt(hDest, 0, 0, width, height, hSource, 0, 0, GDI.SRCCOPY);
            GDI.SelectObject(hDest, hOld);
            GDI.DeleteDC(hDest);
            Window.ReleaseDC(windowHandle, hSource);
            return hBitmap;
        }

        public static void DeleteObject(IntPtr hBitmap)
        {
            GDI.DeleteObject(hBitmap);
        }
    }
}
