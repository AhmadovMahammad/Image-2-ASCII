namespace Image2ASCII
{
    public partial class AsciiConverterForm : Form
    {
        private readonly ImagePreprocessor _imagePreprocessor;

        public AsciiConverterForm()
        {
            InitializeComponent();
            _imagePreprocessor = new ImagePreprocessor();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image? image = null;

            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                if (pictureBox != null)
                {
                    pictureBox.Image = image;
                    //convertedImage.Image = _imagePreprocessor.GrayScale(image);
                }
            }
        }
    }
}
