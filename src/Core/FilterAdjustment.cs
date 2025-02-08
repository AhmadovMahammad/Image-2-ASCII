using Image2ASCII.src.Core.Models;
using System.Drawing.Imaging;

namespace Image2ASCII.src.Core;
public class FilterAdjustment
{
    public Bitmap AdjustGrayScale(Bitmap original, float ratio)
    {
        ratio = Math.Max(0, Math.Min(100, ratio));
        ratio /= 100f;

        return Adjust((Bitmap)original.Clone(), (RGB rgb) =>
        {
            // formula: New Color = (Original Color × (1 − α)) + Grayscale Color × α
            // Gray= 0.299R + 0.587G + 0.114B

            int grayValue = (int)(rgb.Red * 0.299 + rgb.Green * 0.587 + rgb.Blue * 0.114);

            byte red = (byte)(rgb.Red * (1 - ratio) + grayValue * ratio);
            byte green = (byte)(rgb.Green * (1 - ratio) + grayValue * ratio);
            byte blue = (byte)(rgb.Blue * (1 - ratio) + grayValue * ratio);

            return new RGB { Red = red, Green = green, Blue = blue };
        });
    }

    public Bitmap AdjustContrast(Bitmap original, float ratio)
    {
        ratio = Math.Max(-100, Math.Min(100, ratio));
        ratio = (100.0f + ratio) / 100.0f;

        return Adjust((Bitmap)original.Clone(), (RGB rgb) =>
        {
            float red = rgb.Red / 255.0f;
            float green = rgb.Green / 255.0f;
            float blue = rgb.Blue / 255.0f;

            red = ((red - 0.5f) * ratio + 0.5f) * 255.0f;
            green = ((green - 0.5f) * ratio + 0.5f) * 255.0f;
            blue = ((blue - 0.5f) * ratio + 0.5f) * 255.0f;

            return new RGB
            {
                Red = (byte)Math.Clamp(red, 0, 255),
                Green = (byte)Math.Clamp(green, 0, 255),
                Blue = (byte)Math.Clamp(blue, 0, 255)
            };
        });
    }

    public Bitmap AdjustBrightness(Bitmap original, float ratio)
    {
        ratio = Math.Max(-100, Math.Min(100, ratio));
        ratio = (100.0f + ratio) / 100.0f;

        return Adjust((Bitmap)original.Clone(), (RGB rgb) =>
        {
            float red = rgb.Red * ratio;
            float green = rgb.Green * ratio;
            float blue = rgb.Blue * ratio;

            return new RGB
            {
                Red = (byte)Math.Clamp(red, 0, 255),
                Green = (byte)Math.Clamp(green, 0, 255),
                Blue = (byte)Math.Clamp(blue, 0, 255)
            };
        });
    }

    public Bitmap AdjustInvert(Bitmap original, float ratio)
    {
        ratio = Math.Max(0, Math.Min(100, ratio));
        ratio = (100.0f + ratio) / 100.0f;

        return Adjust((Bitmap)original.Clone(), (RGB rgb) =>
        {
            // New Color = (Original Color × (1 − α)) + ((255 − Original Color) × α)
            byte invR = (byte)(255 - rgb.Red);
            byte invG = (byte)(255 - rgb.Green);
            byte invB = (byte)(255 - rgb.Blue);

            return new RGB
            {
                Red = (byte)(rgb.Red * (1 - ratio) + invR * ratio),
                Green = (byte)(rgb.Green * (1 - ratio) + invG * ratio),
                Blue = (byte)(rgb.Blue * (1 - ratio) + invB * ratio)
            };
        });
    }

    public Bitmap AdjustSepia(Bitmap newBitmap, float ratio)
    {
        ratio = Math.Max(0, Math.Min(100, ratio));
        ratio /= 100.0f;

        // New - R(Original - R x 0.393) + (Original - G x 0.769) + (Original - B x 0.189)
        // (Original_R x 0.349) +(Original_G x 0.686) +(Original_B x 0.168)
        // New_B = (Original_R x 0.272) +(Original_G x 0.534) +(Original_B x 0.131)

        return new Bitmap(800, 800);
    }

    private Bitmap Adjust(Bitmap bitmap, Func<RGB, RGB> function)
    {
        // locks the bitmap in memory to allow direct access to its pixel data.
        BitmapData data = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format32bppArgb);

        int height = bitmap.Height;
        int width = bitmap.Width;
        int stride = data.Stride;
        // Stride is the number of bytes in a single row of the image (including padding).
        // Sometimes, stride is greater than width * bytesPerPixel due to memory alignment.

        unsafe
        {
            // data.Scan0 is a pointer to the first byte of pixel data in the bitmap.
            // We cast it to byte* ptr, so ptr now points to the first pixel in the image.
            byte* ptr = (byte*)data.Scan0;

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + y * stride;
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;
                    // Each pixel takes 4 bytes (because we use Format32bppArgb).
                    // x * 4 gives the byte index of the x - th pixel inside the row.

                    // the default byte order in Format32bppArgb is BGRA(Blue, Green, Red, Alpha).
                    RGB output = function(new RGB
                    {
                        Blue = row[columnOffset],
                        Green = row[columnOffset + 1],
                        Red = row[columnOffset + 2],
                    });

                    row[columnOffset] = output.Blue;
                    row[columnOffset + 1] = output.Green;
                    row[columnOffset + 2] = output.Red;
                }
            });
        }

        bitmap.UnlockBits(data);
        return bitmap;
    }
}
