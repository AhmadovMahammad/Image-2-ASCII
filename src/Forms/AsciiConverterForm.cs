using Image2ASCII.src.Core;
using Image2ASCII.src.Core.Models;
using System.Drawing.Imaging;

namespace Image2ASCII
{
    // todo: allow users to increase/decrease the number of characters.
    // todo: allow users to increase/decrease density.

    // Constructor & Initialization
    public partial class AsciiConverterForm : Form
    {
        private readonly ImagePreprocessor _imagePreprocessor = new ImagePreprocessor();
        private readonly FilterAdjustment _filterAdjustment = new FilterAdjustment();
        private readonly Dictionary<FilterKey, Bitmap> _filterDictionary = [];

        private Bitmap? _outputImage;
        private Bitmap? _originalImage;
        private Bitmap? _image;

        // Constructor & Initialization
        public AsciiConverterForm()
        {
            InitializeComponent();
            InitializeUI();
            InitializeBindings();
        }

        private void InitializeUI()
        {
            Font = new Font(_fontFamily, 8.25F);
            outputTextBox.Font = new Font(_fontFamily, 6.0F);
            pictureBox.Controls.Add(imagePreviewLabel);
            outputTextBox.SelectionAlignment = HorizontalAlignment.Center;
            ActiveControl = pictureBox;

            contrastTrackBar.ValueChanged += TrackBar_ValueChanged;
            grayScaleTrackBar.ValueChanged += TrackBar_ValueChanged;
            brightnessTrackBar.ValueChanged += TrackBar_ValueChanged;
            invertTrackBar.ValueChanged += TrackBar_ValueChanged;
            sepiaTrackBar.ValueChanged += TrackBar_ValueChanged;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void InitializeBindings()
        {
            List<TrackBar> trackBars = [contrastTrackBar, grayScaleTrackBar, brightnessTrackBar, invertTrackBar, sepiaTrackBar];

            new List<Button>() { copyButton, saveAsButton }.ForEach(button =>
            {
                Binding binding = new Binding("Enabled", outputTextBox, "Text");
                binding.Format += (sender, e) =>
                {
                    e.Value = !string.IsNullOrEmpty(outputTextBox.Text);
                };

                button.DataBindings.Add(binding);
            });

            trackBars.ForEach(trackbar =>
            {
                trackbar.ValueChanged += (sender, e) =>
                {
                    resetButton.Enabled = trackBars.Any(tb => tb.Value != 0);
                };
            });

            resetButton.Enabled = trackBars.Any(tb => tb.Value != 0);
        }

        // Image Loading & Processing
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
                _originalImage = new Bitmap(openFileDialog.FileName);
                _image = (Bitmap)_originalImage.Clone();

                if (pictureBox != null)
                {
                    pictureBox.Image = _image;
                    pictureBox.Tag = DateTime.Now;
                    //pictureBox.DataBindings["Image"]?.ReadValue();
                    HidePreviewLabelVisibility();
                }
            }
        }

        private FilterKey GetFilterKey()
        {
            int contrastValue = contrastTrackBar.Value;
            int grayScaleValue = grayScaleTrackBar.Value;
            int brightnessValue = brightnessTrackBar.Value;
            int invertValue = invertTrackBar.Value;
            int sepiaValue = sepiaTrackBar.Value;

            return new FilterKey(contrastValue, grayScaleValue, brightnessValue, invertValue, sepiaValue);
        }


        // Filter Adjustments(TrackBar Events)
        private void adjustContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                contrastTrackBar.Value = 0;
            }

            FilterKey filterKey = GetFilterKey();
            if (_image != null)
            {
                if (!_filterDictionary.TryGetValue(filterKey, out Bitmap? value))
                {
                    value = _filterAdjustment.AdjustContrast((Bitmap)_image.Clone(), filterKey.ContrastValue);
                    _filterDictionary.Add(filterKey, value);
                }

                _image = value;
                pictureBox.Image = _image;
            }
        }

        private void adjustGrayScaleTrackBar_Scroll(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                grayScaleTrackBar.Value = 0;
            }

            FilterKey filterKey = GetFilterKey();
            if (_image != null)
            {
                if (!_filterDictionary.TryGetValue(filterKey, out Bitmap? value))
                {
                    value = _filterAdjustment.AdjustGrayScale((Bitmap)_image.Clone(), filterKey.GrayScaleValue);
                    _filterDictionary.Add(filterKey, value);
                }

                _image = value;
                pictureBox.Image = _image;
            }
        }

        private void adjustBrightnessTrackbar_Scroll(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                brightnessTrackBar.Value = 0;
            }

            FilterKey filterKey = GetFilterKey();
            if (_image != null)
            {
                if (!_filterDictionary.TryGetValue(filterKey, out Bitmap? value))
                {
                    value = _filterAdjustment.AdjustBrightness((Bitmap)_image.Clone(), filterKey.BrightnessValue);
                    _filterDictionary.Add(filterKey, value);
                }

                _image = value;
                pictureBox.Image = _image;
            }
        }

        private void adjustInvertTrackbar_Scroll(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                invertTrackBar.Value = 0;
            }

            FilterKey filterKey = GetFilterKey();
            if (_image != null)
            {
                if (!_filterDictionary.TryGetValue(filterKey, out Bitmap? value))
                {
                    value = _filterAdjustment.AdjustInvert((Bitmap)_image.Clone(), invertTrackBar.Value);
                    _filterDictionary.Add(filterKey, value);
                }

                _image = value;
                pictureBox.Image = _image;
            }
        }

        private void adjustSepiaTrackbar_Scroll(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                sepiaTrackBar.Value = 0;
            }

            FilterKey filterKey = GetFilterKey();
            if (_image != null)
            {

            }
        }

        private void TrackBar_ValueChanged(object? sender, EventArgs e)
        {
            if (sender is TrackBar trackBar)
            {
                Label? label = trackBar.Name switch
                {
                    nameof(contrastTrackBar) => contrastValueLabel,
                    nameof(grayScaleTrackBar) => grayScaleValueLabel,
                    nameof(brightnessTrackBar) => brightnessValueLabel,
                    nameof(invertTrackBar) => invertValueLabel,
                    nameof(sepiaTrackBar) => sepiaValueLabel,
                    _ => null
                };

                if (label == null) return;
                label.Text = $"{trackBar.Value}%";

                if (_image != null)
                {
                    _outputImage = _imagePreprocessor.GenerateAsciiArt(_image, out string output);
                    outputTextBox.Text = output;
                }
            }
        }


        // ASCII Art Processing
        private void HidePreviewLabelVisibility()
        {
            if (_image != null)
            {
                imagePreviewLabel.Visible = false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            contrastTrackBar.Value = 0;
            grayScaleTrackBar.Value = 0;
            brightnessTrackBar.Value = 0;
            invertTrackBar.Value = 0;
            sepiaTrackBar.Value = 0;
            outputTextBox.Text = string.Empty;

            if (_originalImage != null)
            {
                _image = (Bitmap)_originalImage.Clone();
                pictureBox.Image = _image;
            }
        }


        // Copy & Save Functionality
        private async void copyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outputTextBox.Text)) return;

            Clipboard.SetText(outputTextBox.Text);
            copyButton.Text = "Copied";
            copyButton.Enabled = false;

            await Task.Delay(3000);

            copyButton.Text = "Copy to Clipboard";
            copyButton.Enabled = true;
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outputTextBox.Text)) return;

            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|TXT File|*.txt",
                Title = "Save Ascii Art Image",
                FileName = "AsciiArt.png"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                    if (extension == ".txt")
                    {
                        saveAsText(saveFileDialog.FileName);
                    }
                    else
                    {
                        ImageFormat format = ImageFormat.Png;

                        format = extension switch
                        {
                            ".jpg" => ImageFormat.Jpeg,
                            ".jpeg" => ImageFormat.Jpeg,
                            ".bmp" => ImageFormat.Bmp,
                            _ => ImageFormat.Png
                        };

                        _outputImage?.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsText(string fileName)
        {
            using FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            using TextWriter writer = new StreamWriter(fileStream);

            writer.Write(outputTextBox.Text);
        }


        // Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
