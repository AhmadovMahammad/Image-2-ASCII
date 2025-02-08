using System.Windows.Forms;

namespace Image2ASCII
{
    partial class AsciiConverterForm
    {
        private System.ComponentModel.IContainer components = null;
        private readonly string _fontFamily = "FiraCode Nerd Font Mono Med";

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            separator = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            imagePanel = new Panel();
            pictureBox = new PictureBox();
            imagePreviewLabel = new Label();
            uploadPanel = new Panel();
            uploadLabel = new Label();
            settingsPanel = new Panel();
            contrastLabel = new Label();
            contrastTrackBar = new TrackBar();
            contrastValueLabel = new Label();
            grayScaleLabel = new Label();
            grayScaleTrackBar = new TrackBar();
            grayScaleValueLabel = new Label();
            brightnessLabel = new Label();
            brightnessTrackBar = new TrackBar();
            brightnessValueLabel = new Label();
            invertLabel = new Label();
            invertTrackBar = new TrackBar();
            invertValueLabel = new Label();
            sepiaLabel = new Label();
            sepiaTrackBar = new TrackBar();
            sepiaValueLabel = new Label();
            buttonPanel = new Panel();
            copyButton = new Button();
            saveAsButton = new Button();
            resetButton = new Button();
            outputPanel = new Panel();
            outputTextBox = new RichTextBox();
            menuStrip.SuspendLayout();
            mainPanel.SuspendLayout();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            uploadPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contrastTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grayScaleTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invertTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sepiaTrackBar).BeginInit();
            buttonPanel.SuspendLayout();
            outputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip.Location = new Point(5, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1195, 28);
            menuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openMenuItem, separator, exitMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(46, 24);
            fileMenu.Text = "&File";
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.Size = new Size(200, 26);
            openMenuItem.Text = "&Upload Image ...";
            openMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // separator
            // 
            separator.Name = "separator";
            separator.Size = new Size(197, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(200, 26);
            exitMenuItem.Text = "&Exit...";
            exitMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(imagePanel);
            mainPanel.Controls.Add(settingsPanel);
            mainPanel.Controls.Add(buttonPanel);
            mainPanel.Controls.Add(outputPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(5, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1195, 800);
            mainPanel.TabIndex = 1;
            // 
            // imagePanel
            // 
            imagePanel.Controls.Add(pictureBox);
            imagePanel.Controls.Add(imagePreviewLabel);
            imagePanel.Controls.Add(uploadPanel);
            imagePanel.Location = new Point(10, 40);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(350, 350);
            imagePanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(300, 250);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // imagePreviewLabel
            // 
            imagePreviewLabel.AllowDrop = true;
            imagePreviewLabel.BackColor = Color.Transparent;
            imagePreviewLabel.Location = new Point(3, 3);
            imagePreviewLabel.Name = "imagePreviewLabel";
            imagePreviewLabel.Size = new Size(300, 250);
            imagePreviewLabel.TabIndex = 0;
            imagePreviewLabel.Text = "No image";
            imagePreviewLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uploadPanel
            // 
            uploadPanel.AllowDrop = true;
            uploadPanel.BackColor = Color.Transparent;
            uploadPanel.BorderStyle = BorderStyle.FixedSingle;
            uploadPanel.Controls.Add(uploadLabel);
            uploadPanel.Cursor = Cursors.Hand;
            uploadPanel.Location = new Point(3, 263);
            uploadPanel.Name = "uploadPanel";
            uploadPanel.Size = new Size(300, 80);
            uploadPanel.TabIndex = 0;
            uploadPanel.DragDrop += uploadPanel_DragDrop;
            uploadPanel.DragEnter += uploadPanel_DragEnter;
            // 
            // uploadLabel
            // 
            uploadLabel.BackColor = Color.Transparent;
            uploadLabel.ForeColor = Color.Black;
            uploadLabel.Location = new Point(10, 10);
            uploadLabel.Name = "uploadLabel";
            uploadLabel.Size = new Size(280, 60);
            uploadLabel.TabIndex = 0;
            uploadLabel.Text = "Upload a file by dragging and dropping it here, or click here to select file";
            uploadLabel.TextAlign = ContentAlignment.TopCenter;
            uploadLabel.Click += openToolStripMenuItem_Click;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(contrastLabel);
            settingsPanel.Controls.Add(contrastTrackBar);
            settingsPanel.Controls.Add(contrastValueLabel);
            settingsPanel.Controls.Add(grayScaleLabel);
            settingsPanel.Controls.Add(grayScaleTrackBar);
            settingsPanel.Controls.Add(grayScaleValueLabel);
            settingsPanel.Controls.Add(brightnessLabel);
            settingsPanel.Controls.Add(brightnessTrackBar);
            settingsPanel.Controls.Add(brightnessValueLabel);
            settingsPanel.Controls.Add(invertLabel);
            settingsPanel.Controls.Add(invertTrackBar);
            settingsPanel.Controls.Add(invertValueLabel);
            settingsPanel.Controls.Add(sepiaLabel);
            settingsPanel.Controls.Add(sepiaTrackBar);
            settingsPanel.Controls.Add(sepiaValueLabel);
            settingsPanel.Location = new Point(370, 40);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(800, 300);
            settingsPanel.TabIndex = 1;
            // 
            // contrastLabel
            // 
            contrastLabel.Location = new Point(20, 3);
            contrastLabel.Name = "contrastLabel";
            contrastLabel.Size = new Size(120, 30);
            contrastLabel.TabIndex = 0;
            contrastLabel.Text = "Contrast:";
            contrastLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contrastTrackBar
            // 
            contrastTrackBar.Location = new Point(150, 3);
            contrastTrackBar.Maximum = 100;
            contrastTrackBar.Minimum = -100;
            contrastTrackBar.Name = "contrastTrackBar";
            contrastTrackBar.Size = new Size(500, 56);
            contrastTrackBar.TabIndex = 1;
            contrastTrackBar.TickFrequency = 8;
            contrastTrackBar.TickStyle = TickStyle.TopLeft;
            contrastTrackBar.Scroll += TrackBar_ValueChanged;
            // 
            // contrastValueLabel
            // 
            contrastValueLabel.Location = new Point(670, 3);
            contrastValueLabel.Name = "contrastValueLabel";
            contrastValueLabel.Size = new Size(120, 30);
            contrastValueLabel.TabIndex = 2;
            contrastValueLabel.Text = "0%";
            contrastValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grayScaleLabel
            // 
            grayScaleLabel.Location = new Point(20, 63);
            grayScaleLabel.Name = "grayScaleLabel";
            grayScaleLabel.Size = new Size(120, 30);
            grayScaleLabel.TabIndex = 0;
            grayScaleLabel.Text = "Gray Scale:";
            grayScaleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grayScaleTrackBar
            // 
            grayScaleTrackBar.Location = new Point(150, 63);
            grayScaleTrackBar.Maximum = 100;
            grayScaleTrackBar.Name = "grayScaleTrackBar";
            grayScaleTrackBar.Size = new Size(500, 56);
            grayScaleTrackBar.TabIndex = 1;
            grayScaleTrackBar.TickFrequency = 4;
            grayScaleTrackBar.TickStyle = TickStyle.TopLeft;
            grayScaleTrackBar.Scroll += TrackBar_ValueChanged;
            // 
            // grayScaleValueLabel
            // 
            grayScaleValueLabel.Location = new Point(670, 63);
            grayScaleValueLabel.Name = "grayScaleValueLabel";
            grayScaleValueLabel.Size = new Size(120, 30);
            grayScaleValueLabel.TabIndex = 2;
            grayScaleValueLabel.Text = "0%";
            grayScaleValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // brightnessLabel
            // 
            brightnessLabel.Location = new Point(20, 123);
            brightnessLabel.Name = "brightnessLabel";
            brightnessLabel.Size = new Size(120, 30);
            brightnessLabel.TabIndex = 0;
            brightnessLabel.Text = "Brightness:";
            brightnessLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // brightnessTrackBar
            // 
            brightnessTrackBar.Location = new Point(150, 123);
            brightnessTrackBar.Maximum = 100;
            brightnessTrackBar.Minimum = -100;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(500, 56);
            brightnessTrackBar.TabIndex = 1;
            brightnessTrackBar.TickFrequency = 8;
            brightnessTrackBar.TickStyle = TickStyle.TopLeft;
            brightnessTrackBar.Scroll += TrackBar_ValueChanged;
            // 
            // brightnessValueLabel
            // 
            brightnessValueLabel.Location = new Point(670, 123);
            brightnessValueLabel.Name = "brightnessValueLabel";
            brightnessValueLabel.Size = new Size(120, 30);
            brightnessValueLabel.TabIndex = 2;
            brightnessValueLabel.Text = "0%";
            brightnessValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // invertLabel
            // 
            invertLabel.Location = new Point(20, 183);
            invertLabel.Name = "invertLabel";
            invertLabel.Size = new Size(120, 30);
            invertLabel.TabIndex = 0;
            invertLabel.Text = "Invert:";
            invertLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // invertTrackBar
            // 
            invertTrackBar.Location = new Point(150, 183);
            invertTrackBar.Maximum = 100;
            invertTrackBar.Name = "invertTrackBar";
            invertTrackBar.Size = new Size(500, 56);
            invertTrackBar.TabIndex = 1;
            invertTrackBar.TickFrequency = 4;
            invertTrackBar.TickStyle = TickStyle.TopLeft;
            invertTrackBar.Scroll += TrackBar_ValueChanged;
            // 
            // invertValueLabel
            // 
            invertValueLabel.Location = new Point(670, 183);
            invertValueLabel.Name = "invertValueLabel";
            invertValueLabel.Size = new Size(120, 30);
            invertValueLabel.TabIndex = 2;
            invertValueLabel.Text = "0%";
            invertValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepiaLabel
            // 
            sepiaLabel.Location = new Point(20, 243);
            sepiaLabel.Name = "sepiaLabel";
            sepiaLabel.Size = new Size(120, 30);
            sepiaLabel.TabIndex = 0;
            sepiaLabel.Text = "Sepia:";
            sepiaLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepiaTrackBar
            // 
            sepiaTrackBar.Location = new Point(150, 243);
            sepiaTrackBar.Maximum = 100;
            sepiaTrackBar.Name = "sepiaTrackBar";
            sepiaTrackBar.Size = new Size(500, 56);
            sepiaTrackBar.TabIndex = 1;
            sepiaTrackBar.TickFrequency = 4;
            sepiaTrackBar.TickStyle = TickStyle.TopLeft;
            sepiaTrackBar.Scroll += TrackBar_ValueChanged;
            // 
            // sepiaValueLabel
            // 
            sepiaValueLabel.Location = new Point(670, 243);
            sepiaValueLabel.Name = "sepiaValueLabel";
            sepiaValueLabel.Size = new Size(120, 30);
            sepiaValueLabel.TabIndex = 2;
            sepiaValueLabel.Text = "0%";
            sepiaValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(copyButton);
            buttonPanel.Controls.Add(saveAsButton);
            buttonPanel.Controls.Add(resetButton);
            buttonPanel.Location = new Point(10, 410);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1160, 50);
            buttonPanel.TabIndex = 2;
            // 
            // copyButton
            // 
            copyButton.FlatStyle = FlatStyle.Flat;
            copyButton.Location = new Point(0, 10);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(200, 30);
            copyButton.TabIndex = 0;
            copyButton.Text = "Copy to Clipboard";
            copyButton.Click += copyButton_Click;
            // 
            // saveAsButton
            // 
            saveAsButton.FlatStyle = FlatStyle.Flat;
            saveAsButton.Location = new Point(210, 10);
            saveAsButton.Name = "saveAsButton";
            saveAsButton.Size = new Size(200, 30);
            saveAsButton.TabIndex = 1;
            saveAsButton.Text = "Save as ...";
            saveAsButton.Click += SaveAsButton_Click;
            // 
            // resetButton
            // 
            resetButton.FlatStyle = FlatStyle.Flat;
            resetButton.Location = new Point(420, 10);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(200, 30);
            resetButton.TabIndex = 2;
            resetButton.Text = "Reset Filters";
            resetButton.Click += resetButton_Click;
            // 
            // outputPanel
            // 
            outputPanel.Controls.Add(outputTextBox);
            outputPanel.Location = new Point(10, 470);
            outputPanel.Name = "outputPanel";
            outputPanel.Size = new Size(1160, 300);
            outputPanel.TabIndex = 3;
            // 
            // outputTextBox
            // 
            outputTextBox.Anchor = AnchorStyles.None;
            outputTextBox.Location = new Point(0, 0);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.Size = new Size(1160, 300);
            outputTextBox.TabIndex = 0;
            outputTextBox.Text = "";
            // 
            // AsciiConverterForm
            // 
            AutoScroll = true;
            ClientSize = new Size(1200, 800);
            Controls.Add(menuStrip);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AsciiConverterForm";
            Padding = new Padding(5, 0, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ASCII Art Generator";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            mainPanel.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            uploadPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contrastTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)grayScaleTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)invertTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)sepiaTrackBar).EndInit();
            buttonPanel.ResumeLayout(false);
            outputPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openMenuItem;
        private ToolStripSeparator separator;
        private ToolStripMenuItem exitMenuItem;

        // main
        private Panel mainPanel;

        // image panel
        private Panel imagePanel;
        private PictureBox pictureBox;
        private Panel uploadPanel;
        private Label uploadLabel;
        private Label imagePreviewLabel;

        // settings panel
        private Panel settingsPanel;

        private Label contrastLabel;
        private TrackBar contrastTrackBar;
        private Label contrastValueLabel;

        private Label grayScaleLabel;
        private TrackBar grayScaleTrackBar;
        private Label grayScaleValueLabel;

        private Label brightnessLabel;
        private TrackBar brightnessTrackBar;
        private Label brightnessValueLabel;

        private Label invertLabel;
        private TrackBar invertTrackBar;
        private Label invertValueLabel;

        private Label sepiaLabel;
        private TrackBar sepiaTrackBar;
        private Label sepiaValueLabel;

        // buttons panel
        private Panel buttonPanel;
        private Button copyButton;
        private Button saveAsButton;
        private Button resetButton;

        private Panel outputPanel;
        private RichTextBox outputTextBox;
    }
}
