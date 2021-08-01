using System;
using System.Runtime.InteropServices;

namespace MainDen.Windows.API
{
    // Types | Constants
    public static partial class GDI
    {
        public enum DeviceCaps : int
        {
            DRIVERVERSION = 0,
            TECHNOLOGY = 2,
            HORZSIZE = 4,
            VERTSIZE = 6,
            HORZRES = 8,
            VERTRES = 10,
            BITSPIXEL = 12,
            PLANES = 14,
            NUMBRUSHES = 16,
            NUMPENS = 18,
            NUMMARKERS = 20,
            NUMFONTS = 22,
            NUMCOLORS = 24,
            PDEVICESIZE = 26,
            CURVECAPS = 28,
            LINECAPS = 30,
            POLYGONALCAPS = 32,
            TEXTCAPS = 34,
            CLIPCAPS = 36,
            RASTERCAPS = 38,
            ASPECTX = 40,
            ASPECTY = 42,
            ASPECTXY = 44,
            SHADEBLENDCAPS = 45,
            LOGPIXELSX = 88,
            LOGPIXELSY = 90,
            SIZEPALETTE = 104,
            NUMRESERVED = 106,
            COLORRES = 108,
            PHYSICALWIDTH = 110,
            PHYSICALHEIGHT = 111,
            PHYSICALOFFSETX = 112,
            PHYSICALOFFSETY = 113,
            SCALINGFACTORX = 114,
            SCALINGFACTORY = 115,
            VREFRESH = 116,
            DESKTOPVERTRES = 117,
            DESKTOPHORZRES = 118,
            BLTALIGNMENT = 119
        }
        public enum RasterOperationCodes : uint
        {
            BLACKNESS = 0x00000042,
            NOTSRCERASE = 0x001100A6,
            NOTSRCCOPY = 0x00330008,
            SRCERASE = 0x00440328,
            DSTINVERT = 0x00550009,
            PATINVERT = 0x005A0049,
            SRCINVERT = 0x00660046,
            SRCAND = 0x008800C6,
            MERGEPAINT = 0x00BB0226,
            MERGECOPY = 0x00C000CA,
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            WHITENESS = 0x00FF0062,
            NOMIRRORBITMAP = 0x80000000,
        }
    }
    // Methods
    public static partial class GDI
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, RasterOperationCodes dwRop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, DeviceCaps nIndex);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }
}
