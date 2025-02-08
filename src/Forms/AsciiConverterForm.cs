using Image2ASCII.src.Core;
using Image2ASCII.src.Core.Models;
using Image2ASCII.src.Helpers.Validators;
using System.Drawing.Imaging;

namespace Image2ASCII
{
    // todo: allow users to increase/decrease the number of characters.
    // todo: allow users to increase/decrease density.

    // Constructor & Initialization
    public partial class AsciiConverterForm : Form
    {
        private readonly ImagePreprocessor _imagePreprocessor = new();
        private readonly FilterAdjustment _filterAdjustment = new();
        private readonly Dictionary<FilterKey, Bitmap> _filterDictionary = [];
        private readonly List<TrackBar> _trackBars = [];

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
            _trackBars.AddRange([contrastTrackBar, grayScaleTrackBar, brightnessTrackBar, invertTrackBar, sepiaTrackBar]);

            Font = new Font(_fontFamily, 8.25F);
            outputTextBox.SelectionAlignment = HorizontalAlignment.Center;
            pictureBox.Controls.Add(imagePreviewLabel);

            // events
            resetButton.Enabled = _trackBars.Any(tb => tb.Value != 0);
            _trackBars.ForEach(tb => tb.ValueChanged += (sender, e) =>
            {
                TrackBar_ValueChanged(sender, e);
                resetButton.Enabled = _trackBars.Any(tb => tb.Value != 0);
            });

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void InitializeBindings()
        {
            new List<Button>() { copyButton, saveAsButton }.ForEach(button =>
            {
                Binding binding = new Binding("Enabled", outputTextBox, "Text");
                binding.Format += (sender, e) =>
                {
                    e.Value = !string.IsNullOrEmpty(outputTextBox.Text);
                };

                button.DataBindings.Add(binding);
            });
        }


        // Image Loading & Processing
        private void openToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(openFileDialog.FileName);
            }
        }

        private void uploadPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data is IDataObject dataObject && dataObject.GetDataPresent(DataFormats.FileDrop))
            {
                string[]? files = (string[]?)dataObject.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    e.Effect = files.Length switch
                    {
                        int count when count == 1 && files[0].IsImage() => DragDropEffects.Copy,
                        _ => DragDropEffects.None
                    };
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void uploadPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[]? files = (string[]?)e.Data!.GetData(DataFormats.FileDrop);
            if (files != null && files.Length == 1)
            {
                LoadImage(files[0]);
            }
        }

        private void LoadImage(string fileName)
        {
            _originalImage = new Bitmap(fileName);
            _image = (Bitmap)_originalImage.Clone();

            if (pictureBox != null)
            {
                pictureBox.Image = _image;
                imagePreviewLabel.Visible = false;

                _outputImage = _imagePreprocessor.GenerateAsciiArt(_image, out string output);
                outputTextBox.Text = output;
            }
        }


        // Filter Adjustments(TrackBar Events)
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

                if (_image == null) // when image is not uplaoded by user.
                {
                    trackBar.Value = 0;
                }
                else
                {
                    FilterKey filterKey = GetFilterKey();
                    if (!_filterDictionary.TryGetValue(filterKey, out Bitmap? value))
                    {
                        value = trackBar.Name switch
                        {
                            nameof(contrastTrackBar) => _filterAdjustment.AdjustContrast((Bitmap)_image.Clone(), filterKey.ContrastValue),
                            nameof(grayScaleTrackBar) => _filterAdjustment.AdjustGrayScale((Bitmap)_image.Clone(), filterKey.GrayScaleValue),
                            nameof(brightnessTrackBar) => _filterAdjustment.AdjustBrightness((Bitmap)_image.Clone(), filterKey.BrightnessValue),
                            nameof(invertTrackBar) => _filterAdjustment.AdjustInvert((Bitmap)_image.Clone(), filterKey.InvertValue),
                            nameof(sepiaTrackBar) => _filterAdjustment.AdjustSepia((Bitmap)_image.Clone(), filterKey.SepiaValue),
                            _ => _filterDictionary.Last().Value
                        };

                        _filterDictionary.Add(filterKey, value);
                    }

                    _image = value;
                    pictureBox.Image = _image;

                    _outputImage = _imagePreprocessor.GenerateAsciiArt(_image, out string output);
                    outputTextBox.Text = output;
                }
            }
        }

        private FilterKey GetFilterKey()
        {
            return new FilterKey
            (
                contrastTrackBar.Value,
                grayScaleTrackBar.Value,
                brightnessTrackBar.Value,
                invertTrackBar.Value,
                sepiaTrackBar.Value
            );
        }


        // Middle-Row Buttons Functionality
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
                        using FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                        using TextWriter writer = new StreamWriter(fileStream);

                        writer.Write(outputTextBox.Text);
                    }
                    else
                    {
                        ImageFormat format = extension switch
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


        // Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    }
}
