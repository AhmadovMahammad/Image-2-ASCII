using System.Drawing.Imaging;

namespace Image2ASCII;
public class ImagePreprocessor
{
    private readonly Random _random;

    public ImagePreprocessor()
    {
        _random = new Random();
    }

    public Bitmap GrayScale(Image original)
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

    public Bitmap AdjustContrast(Image original, float value)
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

        unsafe
        {
            for (int y = 0; y < height; ++y)
            {
                byte* row = (byte*)data.Scan0 + (y * data.Stride);
                int columnOffset = 0;

                for (int x = 0; x < width; ++x)
                {
                    byte B = row[columnOffset];
                    byte G = row[columnOffset + 1];
                    byte R = row[columnOffset + 2];

                    float Red = R / 255.0f;
                    float Green = G / 255.0f;
                    float Blue = B / 255.0f;
                    Red = (((Red - 0.5f) * value) + 0.5f) * 255.0f;
                    Green = (((Green - 0.5f) * value) + 0.5f) * 255.0f;
                    Blue = (((Blue - 0.5f) * value) + 0.5f) * 255.0f;

                    int iR = (int)Red;
                    iR = iR > 255 ? 255 : iR;
                    iR = iR < 0 ? 0 : iR;
                    int iG = (int)Green;
                    iG = iG > 255 ? 255 : iG;
                    iG = iG < 0 ? 0 : iG;
                    int iB = (int)Blue;
                    iB = iB > 255 ? 255 : iB;
                    iB = iB < 0 ? 0 : iB;

                    row[columnOffset] = (byte)iB;
                    row[columnOffset + 1] = (byte)iG;
                    row[columnOffset + 2] = (byte)iR;

                    columnOffset += 4;
                }
            }
        }

        newBitmap.UnlockBits(data);
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
