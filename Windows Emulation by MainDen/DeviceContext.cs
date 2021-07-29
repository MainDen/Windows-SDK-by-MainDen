using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class DeviceContext : BaseContext
    {
        public DeviceContext(BaseContext context) : base(context) { }

        public IntPtr CaptureWindow()
        {
            return CaptureWindow(0, 0, 0, 0);
        }

        public IntPtr CaptureWindow(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            IntPtr hSource = Window.GetWindowDC(windowHandle);
            Window.GetWindowRect(windowHandle, out Window.RECT windowRect);
            int width = Math.Max(0, windowRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, windowRect.Height - (cropTop + cropBottom));
            IntPtr hDest = GDI.CreateCompatibleDC(hSource);
            IntPtr hBitmap = GDI.CreateCompatibleBitmap(hSource, width, height);
            IntPtr hOld = GDI.SelectObject(hDest, hBitmap);
            GDI.BitBlt(hDest, 0, 0, width, height, hSource, cropLeft, cropTop, GDI.SRCCOPY);
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
