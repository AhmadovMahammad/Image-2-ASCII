using System.Diagnostics.CodeAnalysis;

namespace Image2ASCII;
public readonly struct FilterKey
{
    public int ContrastValue { get; }
    public int GrayScaleValue { get; }
    public int BrightnessValue { get; }
    public int InvertValue { get; }
    public int SepiaValue { get; }

    public FilterKey(int contrast, int grayScale, int brightness, int invert, int sepiaValue)
    {
        ContrastValue = contrast;
        GrayScaleValue = grayScale;
        BrightnessValue = brightness;
        InvertValue = invert;
        SepiaValue = sepiaValue;
    }

    public override bool Equals(object? obj)
    {
        return obj is FilterKey filterKey &&
            filterKey.ContrastValue == ContrastValue &&
            filterKey.GrayScaleValue == GrayScaleValue &&
            filterKey.BrightnessValue == BrightnessValue &&
            filterKey.InvertValue == InvertValue &&
            filterKey.SepiaValue == SepiaValue;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ContrastValue, GrayScaleValue, BrightnessValue);
    }

    public static bool operator ==(FilterKey left, FilterKey right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FilterKey left, FilterKey right)
    {
        return !(left == right);
    }
}
