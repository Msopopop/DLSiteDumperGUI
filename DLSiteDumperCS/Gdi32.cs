using System.Runtime.InteropServices;

public static class Gdi32
{
    public enum BitmapCompressionMode : uint
    {
        BI_RGB = 0,
        BI_RLE8 = 1,
        BI_RLE4 = 2,
        BI_BITFIELDS = 3,
        BI_JPEG = 4,
        BI_PNG = 5
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct BITMAPINFOHEADER
    {
        public uint  biSize;
        public int   biWidth;
        public int   biHeight;
        public ushort   biPlanes;
        public ushort   biBitCount;
        public BitmapCompressionMode  biCompression;
        public uint  biSizeImage;
        public int   biXPelsPerMeter;
        public int   biYPelsPerMeter;
        public uint  biClrUsed;
        public uint  biClrImportant;
    }

    [StructLayout( LayoutKind.Sequential, Pack = 2 )]
    public struct BITMAPFILEHEADER
    {
        public ushort bfType;
        public uint bfSize;
        public ushort bfReserved1;
        public ushort bfReserved2;
        public uint bfOffBits;
    }


}
