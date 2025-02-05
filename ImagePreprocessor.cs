using System.Drawing.Imaging;

namespace Image2ASCII;
public class ImagePreprocessor
{
    private readonly Random _random;

    public ImagePreprocessor()
    {
        _random = new Random();
    }

    public Bitmap GrayScale(Bitmap original)
    {
        Bitmap grayscaleImage = new Bitmap(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixelColor = ((Bitmap)original).GetPixel(x, y);
                int grayValue = (int)(pixelColor.R * 0.299 + pixelColor.G * 0.587 + pixelColor.B * 0.114);

                grayscaleImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
            }
        }

        return grayscaleImage;
    }

    public Bitmap AdjustContrast(Bitmap original, float value)
    {
        value = (100.0f + value) / 100.0f;
        value *= value;

        Bitmap newBitmap = (Bitmap)original.Clone();
        BitmapData data = newBitmap.LockBits(
            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.ReadWrite,
            newBitmap.PixelFormat);

        int height = newBitmap.Height;
        int width = newBitmap.Width;
        int stride = data.Stride;

        unsafe
        {
            byte* ptr = (byte*)data.Scan0;

            Parallel.For(0, height, y =>
            {
                byte* row = ptr + (y * stride);
                for (int x = 0; x < width; x++)
                {
                    int columnOffset = x * 4;

                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    float red = R / 255.0f;
                    float green = G / 255.0f;
                    float blue = B / 255.0f;

                    red = (((red - 0.5f) * value) + 0.5f) * 255.0f;
                    green = (((green - 0.5f) * value) + 0.5f) * 255.0f;
                    blue = (((blue - 0.5f) * value) + 0.5f) * 255.0f;

                    row[columnOffset] = (byte)Math.Clamp(blue, 0, 255);
                    row[columnOffset + 1] = (byte)Math.Clamp(green, 0, 255);
                    row[columnOffset + 2] = (byte)Math.Clamp(red, 0, 255);
                }
            });
        }

        newBitmap.UnlockBits(data);
        return newBitmap;
    }

    public Bitmap AdjustContrast_v2(Bitmap original, float value) // slower than AdjustContrast but understandable
    {
        value = (100f + value) / 100f;
        value *= value;

        Bitmap newBitmap = (Bitmap)original.Clone();

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixelColor = original.GetPixel(x, y);

                float red = pixelColor.R / 255.0f;
                float green = pixelColor.G / 255.0f;
                float blue = pixelColor.B / 255.0f;

                red = (((red - 0.5f) * value) + 0.5f) * 255.0f;
                green = (((green - 0.5f) * value) + 0.5f) * 255.0f;
                blue = (((blue - 0.5f) * value) + 0.5f) * 255.0f;

                int iR = (int)Math.Clamp(red, 0, 255);
                int iG = (int)Math.Clamp(green, 0, 255);
                int iB = (int)Math.Clamp(blue, 0, 255);

                newBitmap.SetPixel(x, y, Color.FromArgb(iR, iG, iB));
            }
        };

        return newBitmap;
    }

    private SizeF GetGeneralSize()
    {
        SizeF generalsize = new SizeF(0, 0);

        for (int i = 32; i <= 126; i++) // ASCII characters from space to ~ (tilde), including only printable characters
        {
            char c = Convert.ToChar(i);

            // Create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            SizeF textSize = drawing.MeasureString(c.ToString(), SystemFonts.DefaultFont);

            // Update, if necessary, the max width and height
            if (textSize.Width > generalsize.Width) generalsize.Width = textSize.Width;
            if (textSize.Height > generalsize.Height) generalsize.Height = textSize.Height;

            // free all resources
            img.Dispose();
            drawing.Dispose();
        }

        generalsize.Width = (int)generalsize.Width;
        generalsize.Height = (int)generalsize.Height;

        // and that size defines a square to maintain image proportions
        if (generalsize.Width > generalsize.Height) generalsize.Height = generalsize.Width;
        else generalsize.Width = generalsize.Height;

        return generalsize;
    }

    // for testing purposes
    public Bitmap CreateRandomImage(int width, int height)
    {
        Bitmap image = new Bitmap(width, height);

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                int r = _random.Next(0, 256);
                int g = _random.Next(0, 256);
                int b = _random.Next(0, 256);

                image.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }

        return image;
    }
}
