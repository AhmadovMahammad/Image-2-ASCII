using System.Drawing.Imaging;

namespace Image2ASCII.src.Core;
public class FilterAdjustment
{
    public Bitmap AdjustGrayScale(Bitmap original, float ratio)
    {
        // New Color = (Original Color × (1 − α)) + (Gray × α)
        // Gray= 0.299R + 0.587G + 0.114B

        ratio /= 100f;

        Bitmap newBitmap = (Bitmap)original.Clone();
        BitmapData data = newBitmap.LockBits(
            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);
        // locks the bitmap in memory to allow direct access to its pixel data.

        int height = newBitmap.Height;
        int width = newBitmap.Width;
        int stride = data.Stride;
        // Stride is the number of bytes in a single row of the image (including padding).
        // Sometimes, stride is greater than width * bytesPerPixel due to memory alignment.

        unsafe
        {
            byte* ptr = (byte*)data.Scan0;
            // data.Scan0 is a pointer to the first byte of pixel data in the bitmap.
            // We cast it to byte* ptr, so ptr now points to the first pixel in the image.

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + y * stride;
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;
                    // Each pixel takes 4 bytes (because we use Format32bppArgb).
                    // x * 4 gives the byte index of the x - th pixel inside the row.

                    // the default byte order in Format32bppArgb is BGRA(Blue, Green, Red, Alpha).
                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    int grayValue = (int)(R * 0.299 + G * 0.587 + B * 0.114);

                    // formula: New Color = (Original Color × (1 − α)) + Grayscale Color × α
                    row[columnOffset] = (byte)(B * (1 - ratio) + grayValue * ratio);
                    row[columnOffset + 1] = (byte)(G * (1 - ratio) + grayValue * ratio); ;
                    row[columnOffset + 2] = (byte)(R * (1 - ratio) + grayValue * ratio); ;
                }
            });
        }

        newBitmap.UnlockBits(data);
        return newBitmap;
    }
    public Bitmap AdjustContrast(Bitmap original, float ratio)
    {
        ratio = (100.0f + ratio) / 100.0f;

        Bitmap newBitmap = (Bitmap)original.Clone();
        BitmapData data = newBitmap.LockBits(
            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);

        int height = newBitmap.Height;
        int width = newBitmap.Width;
        int stride = data.Stride;

        unsafe
        {
            byte* ptr = (byte*)data.Scan0;

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + y * stride;
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;

                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    float red = R / 255.0f;
                    float green = G / 255.0f;
                    float blue = B / 255.0f;

                    red = ((red - 0.5f) * ratio + 0.5f) * 255.0f;
                    green = ((green - 0.5f) * ratio + 0.5f) * 255.0f;
                    blue = ((blue - 0.5f) * ratio + 0.5f) * 255.0f;

                    row[columnOffset] = (byte)Math.Clamp(blue, 0, 255);
                    row[columnOffset + 1] = (byte)Math.Clamp(green, 0, 255);
                    row[columnOffset + 2] = (byte)Math.Clamp(red, 0, 255);
                }
            });
        }

        newBitmap.UnlockBits(data);
        return newBitmap;
    }
    public Bitmap AdjustBrightness(Bitmap original, float ratio)
    {
        ratio = (100.0f + ratio) / 100.0f;

        Bitmap newBitmap = (Bitmap)original.Clone();
        BitmapData data = newBitmap.LockBits(
            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);

        int height = newBitmap.Height;
        int width = newBitmap.Width;
        int stride = data.Stride;

        unsafe
        {
            byte* ptr = (byte*)data.Scan0;

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + y * stride;
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;

                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    float red = R * ratio;
                    float green = G * ratio;
                    float blue = B * ratio;

                    row[columnOffset] = (byte)Math.Clamp(blue, 0, 255);
                    row[columnOffset + 1] = (byte)Math.Clamp(green, 0, 255);
                    row[columnOffset + 2] = (byte)Math.Clamp(red, 0, 255);
                }
            });
        }

        newBitmap.UnlockBits(data);
        return newBitmap;
    }
    public Bitmap AdjustInvert(Bitmap original, float ratio)
    {
        // New Color = (Original Color × (1 − α)) + ((255 − Original Color) × α)
        ratio = Math.Max(0, Math.Min(100, ratio));
        ratio = (100.0f + ratio) / 100.0f;

        Bitmap newBitmap = (Bitmap)original.Clone();
        BitmapData data = newBitmap.LockBits(
            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);

        int height = newBitmap.Height;
        int width = newBitmap.Width;
        int stride = data.Stride;

        unsafe
        {
            byte* ptr = (byte*)data.Scan0;

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + y * stride;
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;

                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    byte invB = (byte)(255 - B);
                    byte invG = (byte)(255 - G);
                    byte invR = (byte)(255 - R);

                    row[columnOffset] = (byte)(B * (1 - ratio) + invB * ratio);
                    row[columnOffset + 1] = (byte)(G * (1 - ratio) + invG * ratio);
                    row[columnOffset + 2] = (byte)(R * (1 - ratio) + invR * ratio);
                }
            });
        }

        newBitmap.UnlockBits(data);
        return newBitmap;
    }
    public Bitmap AdjustSepia(Bitmap newBitmap)
    {
        // New - R(Original - R x 0.393) + (Original - G x 0.769) + (Original - B x 0.189)
        // (Original_R x 0.349) +(Original_G x 0.686) +(Original_B x 0.168)
        // New_B = (Original_R x 0.272) +(Original_G x 0.534) +(Original_B x 0.131)

        return new Bitmap(800, 800);
    }
}
