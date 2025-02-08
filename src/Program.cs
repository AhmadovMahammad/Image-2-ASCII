namespace Image2ASCII.src
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AsciiConverterForm());
        }
    }
}