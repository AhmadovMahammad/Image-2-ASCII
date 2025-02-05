namespace Image2ASCII
{
    public partial class AsciiConverterForm : Form
    {
        private readonly ImagePreprocessor _imagePreprocessor;
        private readonly Dictionary<int, Bitmap> _contrastDictionary = new();
        private readonly Dictionary<int, Bitmap> _grayScaleDictionary = new();
        private Bitmap? _image;

        // todo: when image is loaded and if there are already changed filters, we should apply them to the image
        // todo: add new filters and group them in a panel
        // todo: add a button to save the image as PNG
        // todo: add strategy pattern to add different kind of grayscale filters

        public AsciiConverterForm()
        {
            InitializeComponent();
            _imagePreprocessor = new ImagePreprocessor();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image = new Bitmap(openFileDialog.FileName);
                if (pictureBox != null)
                {
                    pictureBox.Image = _image;
                }
            }
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            int contrastValue = settingTrackBar_1.Value;
            settingValueLabel_1.Text = $"{contrastValue}%";

            if (_image != null)
            {
                if (!_contrastDictionary.TryGetValue(contrastValue, out Bitmap? value))
                {
                    value = _imagePreprocessor.AdjustContrast(_image, contrastValue);
                    _contrastDictionary.Add(contrastValue, value);
                }

                _image = value;
                pictureBox.Image = _image;
            }
        }

        private void grayScaleTrackBar_Scroll(object sender, EventArgs e)
        {
            int grayScaleValue = settingTrackBar_2.Value;
            settingValueLabel_2.Text = $"{grayScaleValue}%";

            if (_image != null)
            {
                _image = _imagePreprocessor.GrayScale(_image);
                pictureBox.Image = _image;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            settingTrackBar_1.Value = 0;
            settingTrackBar_2.Value = 0;
            
            settingValueLabel_1.Text = "0%";
            settingValueLabel_2.Text = "0%";

            _image = null;
            pictureBox.Image = null;
        }
    }
}
