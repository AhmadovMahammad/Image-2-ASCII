using System.Text;

namespace Image2ASCII;
public partial class ImagePreprocessor
{
    private readonly List<WeightedChar> _weightedChars;
    private SizeF _commonSize = new SizeF(10, 10);

    public ImagePreprocessor()
    {
        _weightedChars = GenerateFontWeights();
        _weightedChars = [.. _weightedChars.OrderBy(m => m.Weight)];
    }

    public SizeF CommonSize
    {
        get => _commonSize;
        set => _commonSize = value;
    }

    public List<WeightedChar> GenerateFontWeights()
    {
        List<WeightedChar> weightedChars = [];
        CommonSize = GetCharacterSize();

        //for (int i = 32; i <= 126; i++)
        foreach (char c in new char[] { '@', '#', 'S', '%', '?', '*', '+', ';', ':', ',', '.', '\'' })
        {
            //char c = (char)i;
            if (!char.IsControl(c))
            {
                double weight = GetWeight(c, CommonSize);
                weightedChars.Add(new WeightedChar
                {
                    Character = c.ToString(),
                    Weight = weight
                });
            }
        }

        return weightedChars;
    }

    public SizeF GetCharacterSize()
    {
        SizeF commonSize = new SizeF(0, 0);

        // ASCII printable characters
        for (int i = 32; i <= 126; i++)
        {
            char c = (char)i;

            // create a dummy image just to get a graphic object, so we can use its measure method.
            using Image img = new Bitmap(1, 1);
            using Graphics graphics = Graphics.FromImage(img);

            SizeF characterSize = graphics.MeasureString(c.ToString(), Constants.Font);

            if (characterSize.Width > commonSize.Width) commonSize.Width = characterSize.Width;
            if (characterSize.Height > commonSize.Height) commonSize.Height = characterSize.Height;
        }

        commonSize.Width = (int)commonSize.Width;
        commonSize.Height = (int)commonSize.Height;

        // and that size defines a square to maintain image proportions
        if (commonSize.Width > commonSize.Height) commonSize.Height = commonSize.Width;
        else commonSize.Width = commonSize.Height;

        return commonSize;
    }

    private double GetWeight(char c, SizeF size)
    {
        Bitmap charImage = DrawText(c.ToString(), Color.Black, Color.White, size);

        double totalSum = 0;
        for (int y = 0; y < charImage.Height; y++)
        {
            for (int x = 0; x < charImage.Width; x++)
            {
                Color pixel = charImage.GetPixel(x, y);
                totalSum += (pixel.R + pixel.G + pixel.B) / 3;
            }
        }

        return totalSum / (size.Height * size.Width);
    }

    private Bitmap DrawText(string text, Color textColor, Color backColor, SizeF size)
    {
        Bitmap img = new Bitmap((int)size.Width, (int)size.Height);
        using Graphics drawing = Graphics.FromImage(img);
        drawing.Clear(backColor);

        using Brush textBrush = new SolidBrush(textColor);
        SizeF textSize = drawing.MeasureString(text, Constants.Font);
        drawing.DrawString(text, Constants.Font, textBrush, (size.Width - textSize.Width) / 2, 0);

        return img;
    }

    public Bitmap ResizeImage(Bitmap original, SizeF characterSize)
    {
        int newWidth = (int)(original.Width / characterSize.Width);
        int newHeight = (int)(original.Height / characterSize.Height);

        if (newWidth <= 0 || newHeight <= 0)
        {
            return original;
        }

        Bitmap resizedImage = new Bitmap(newWidth, newHeight);
        using Graphics graphics = Graphics.FromImage(resizedImage);

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(original, new Rectangle(0, 0, newWidth, newHeight));

        return resizedImage;
    }

    public string GenerateAsciiArt(Bitmap image)
    {
        SizeF charSize = GetCharacterSize();
        Bitmap resizedImage = ResizeImage(image, charSize);
        StringBuilder asciiArt = new();

        for (int y = 0; y < resizedImage.Height; y++)
        {
            for (int x = 0; x < resizedImage.Width; x++)
            {
                Color pixelColor = resizedImage.GetPixel(x, y);
                int grayScale = (int)(pixelColor.R * 0.299 + pixelColor.G * 0.587 + pixelColor.B * 0.114);
                int yield = grayScale * (_weightedChars.Count - 1);

                string asciiChar = _weightedChars[yield / 255].Character;
                asciiArt.Append(asciiChar);
            }
            asciiArt.AppendLine();
        }

        return asciiArt.ToString();
    }

    public Bitmap GenerateBitmap(string asciiArt, SizeF charSize)
    {
        string[] lines = asciiArt.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int width = lines.Max(line => line.Length);
        int height = lines.Length;

        int imageWidth = (int)(width * charSize.Width);
        int imageHeight = (int)(height * charSize.Height);

        Bitmap image = new Bitmap(imageWidth, imageHeight);
        using Graphics graphics = Graphics.FromImage(image);

        graphics.Clear(Color.White);
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        using SolidBrush brush = new(Color.Black);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                graphics.DrawString(lines[y][x].ToString(), Constants.Font, brush, x * charSize.Width, y * charSize.Height);
            }
        }

        return image;
    }
}