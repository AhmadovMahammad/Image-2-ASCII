namespace Image2ASCII.src.Helpers.Validators;
public static class FileValidator
{
    public static bool IsImage(this string filePath)
    {
        string[] validExtensions = [".jpg", ".jpeg", ".png", ".bmp"];
        string fileExtension = Path.GetExtension(filePath).ToLower();

        return validExtensions.Contains(fileExtension);
    }
}
