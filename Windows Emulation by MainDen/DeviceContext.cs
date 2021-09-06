using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Emulation
{
    public class DeviceContext : BaseContext
    {
        public IntPtr CaptureClient()
        {
            return CaptureClient(0, 0, 0, 0);
        }

        public IntPtr CaptureClient(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            Window.GetClientRect(WindowHandle, out Window.RECT clientRect);
            int x = cropLeft;
            int y = cropTop;
            int width = Math.Max(0, clientRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, clientRect.Height - (cropTop + cropBottom));
            return Capture(WindowHandle, x, y, width, height);
        }

        public IntPtr CaptureDevice()
        {
            return CaptureDevice(0, 0, 0, 0);
        }

        public IntPtr CaptureDevice(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            IntPtr hDesktop = Window.GetWindowDC(WindowHandle);
            int x = cropLeft;
            int y = cropTop;
            int width = Math.Max(0, GDI.GetDeviceCaps(hDesktop, GDI.DeviceCaps.HORZRES) - (cropLeft + cropRight));
            int height = Math.Max(0, GDI.GetDeviceCaps(hDesktop, GDI.DeviceCaps.VERTRES) - (cropTop + cropBottom));
            Window.ReleaseDC(WindowHandle, hDesktop);
            return Capture(WindowHandle, x, y, width, height);
        }

        public IntPtr CaptureWindow()
        {
            return CaptureWindow(0, 0, 0, 0);
        }

        public IntPtr CaptureWindow(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            Window.GetWindowRect(WindowHandle, out Window.RECT windowRect);
            int x = cropLeft;
            int y = cropTop;
            int width = Math.Max(0, windowRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, windowRect.Height - (cropTop + cropBottom));
            return Capture(WindowHandle, x, y, width, height);
        }

        public IntPtr CaptureClientFromScreen()
        {
            return CaptureClientFromScreen(0, 0, 0, 0);
        }

        public IntPtr CaptureClientFromScreen(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            Window.GetWindowRect(WindowHandle, out Window.RECT clientRect);
            int x = clientRect.Left + cropLeft;
            int y = clientRect.Top + cropTop;
            int width = Math.Max(0, clientRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, clientRect.Height - (cropTop + cropBottom));
            return Capture(IntPtr.Zero, x, y, width, height);
        }

        public IntPtr CaptureWindowFromScreen()
        {
            return CaptureWindowFromScreen(0, 0, 0, 0);
        }

        public IntPtr CaptureWindowFromScreen(int cropLeft, int cropTop, int cropRight, int cropBottom)
        {
            Window.GetWindowRect(WindowHandle, out Window.RECT windowRect);
            int x = windowRect.Left + cropLeft;
            int y = windowRect.Top + cropTop;
            int width = Math.Max(0, windowRect.Width - (cropLeft + cropRight));
            int height = Math.Max(0, windowRect.Height - (cropTop + cropBottom));
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
