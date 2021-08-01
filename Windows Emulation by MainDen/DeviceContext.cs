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
            Window.GetWindowRect(windowHandle, out Window.RECT windowRect);
            int x = cropLeft;
            int y = cropTop;
            int width = Math.Max(0, windowRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, windowRect.Height - (cropTop + cropBottom));
            return Capture(windowHandle, x, y, width, height);
        }

        public IntPtr CaptureScreen()
        {
            return CaptureScreen(0, 0, 0, 0);
        }

        public IntPtr CaptureScreen(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            Window.GetWindowRect(windowHandle, out Window.RECT windowRect);
            int x = windowRect.Left + cropLeft;
            int y = windowRect.Top + cropTop;
            int width = Math.Max(0, windowRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, windowRect.Height - (cropTop + cropBottom));
            return Capture(IntPtr.Zero, x, y, width, height);
        }

        public static IntPtr CaptureDesktop()
        {
            return CaptureDesktop(0, 0, 0, 0);
        }

        public static IntPtr CaptureDesktop(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            IntPtr hDesktop = Window.GetWindowDC(IntPtr.Zero);
            int desktopWidth = GDI.GetDeviceCaps(hDesktop, GDI.DeviceCaps.HORZRES);
            int desktopHeight = GDI.GetDeviceCaps(hDesktop, GDI.DeviceCaps.VERTRES);
            Window.ReleaseDC(IntPtr.Zero, hDesktop);
            int x = cropLeft;
            int y = cropTop;
            int width = Math.Max(0, desktopWidth - (cropLeft + cropRight));
            int height = Math.Max(0, desktopHeight - (cropTop + cropBottom));
            return Capture(IntPtr.Zero, x, y, width, height);
        }

        public static IntPtr Capture(IntPtr windowHandle, int x, int y, int width, int height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));
            if (width == 0 || height == 0)
                return IntPtr.Zero;
            IntPtr hSource = Window.GetWindowDC(windowHandle);
            IntPtr hMemory = GDI.CreateCompatibleDC(hSource);
            IntPtr hBitmap = GDI.CreateCompatibleBitmap(hSource, width, height);
            IntPtr hPrimaryBitmap = GDI.SelectObject(hMemory, hBitmap);
            GDI.BitBlt(hMemory, 0, 0, width, height, hSource, x, y, GDI.RasterOperationCodes.SRCCOPY);
            GDI.SelectObject(hMemory, hPrimaryBitmap);
            GDI.DeleteDC(hMemory);
            Window.ReleaseDC(windowHandle, hSource);
            return hBitmap;
        }

        public static void DeleteObject(IntPtr hBitmap)
        {
            GDI.DeleteObject(hBitmap);
        }
    }
}
