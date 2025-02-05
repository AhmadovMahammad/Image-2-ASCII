using System.Windows.Forms;

namespace Image2ASCII
{
    partial class AsciiConverterForm
    {
        private System.ComponentModel.IContainer components = null;
        private readonly (int width, int height) _size = (1200, 700);

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
            uploadButton = new Button();
            settingsPanel = new Panel();
            settingLabel_1 = new Label();
            settingTrackBar_1 = new TrackBar();
            settingValueLabel_1 = new Label();
            settingLabel_2 = new Label();
            settingTrackBar_2 = new TrackBar();
            settingValueLabel_2 = new Label();
            buttonPanel = new Panel();
            copyButton = new Button();
            saveAsciiArtButton = new Button();
            saveAsPngButton = new Button();
            resetButton = new Button();
            outputPanel = new Panel();
            outputTextBox = new RichTextBox();
            menuStrip.SuspendLayout();
            mainPanel.SuspendLayout();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingTrackBar_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingTrackBar_2).BeginInit();
            buttonPanel.SuspendLayout();
            outputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip.Location = new Point(5, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1195, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openMenuItem, separator, exitMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.Size = new Size(115, 22);
            openMenuItem.Text = "&Open ...";
            // 
            // separator
            // 
            separator.Name = "separator";
            separator.Size = new Size(112, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(115, 22);
            exitMenuItem.Text = "E&xit";
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
            mainPanel.Size = new Size(1195, 700);
            mainPanel.TabIndex = 1;
            // 
            // imagePanel
            // 
            imagePanel.Controls.Add(pictureBox);
            imagePanel.Controls.Add(uploadButton);
            imagePanel.Location = new Point(10, 40);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(350, 300);
            imagePanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(300, 250);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(3, 263);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(300, 30);
            uploadButton.TabIndex = 1;
            uploadButton.Text = "Upload Image";
            uploadButton.Click += openToolStripMenuItem_Click;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(settingLabel_1);
            settingsPanel.Controls.Add(settingTrackBar_1);
            settingsPanel.Controls.Add(settingValueLabel_1);
            settingsPanel.Controls.Add(settingLabel_2);
            settingsPanel.Controls.Add(settingTrackBar_2);
            settingsPanel.Controls.Add(settingValueLabel_2);
            settingsPanel.Location = new Point(370, 40);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(800, 300);
            settingsPanel.TabIndex = 1;
            // 
            // settingLabel_1
            // 
            settingLabel_1.Location = new Point(20, 20);
            settingLabel_1.Name = "settingLabel_1";
            settingLabel_1.Size = new Size(120, 30);
            settingLabel_1.TabIndex = 0;
            settingLabel_1.Text = "Contrast:";
            settingLabel_1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // settingTrackBar_1
            // 
            settingTrackBar_1.Location = new Point(150, 20);
            settingTrackBar_1.Maximum = 100;
            settingTrackBar_1.Minimum = -100;
            settingTrackBar_1.Name = "settingTrackBar_1";
            settingTrackBar_1.Size = new Size(500, 45);
            settingTrackBar_1.TabIndex = 1;
            settingTrackBar_1.TickFrequency = 5;
            settingTrackBar_1.TickStyle = TickStyle.TopLeft;
            settingTrackBar_1.Scroll += brightnessTrackBar_Scroll;
            // 
            // settingValueLabel_1
            // 
            settingValueLabel_1.Location = new Point(670, 20);
            settingValueLabel_1.Name = "settingValueLabel_1";
            settingValueLabel_1.Size = new Size(120, 30);
            settingValueLabel_1.TabIndex = 2;
            settingValueLabel_1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // settingLabel_2
            // 
            settingLabel_2.Location = new Point(20, 60);
            settingLabel_2.Name = "settingLabel_2";
            settingLabel_2.Size = new Size(120, 30);
            settingLabel_2.TabIndex = 0;
            settingLabel_2.Text = "Gray Scale:";
            settingLabel_2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // settingTrackBar_2
            // 
            settingTrackBar_2.Location = new Point(150, 60);
            settingTrackBar_2.Maximum = 100;
            settingTrackBar_2.Name = "settingTrackBar_2";
            settingTrackBar_2.Size = new Size(500, 45);
            settingTrackBar_2.TabIndex = 1;
            settingTrackBar_2.TickFrequency = 5;
            settingTrackBar_2.TickStyle = TickStyle.TopLeft;
            settingTrackBar_2.Scroll += grayScaleTrackBar_Scroll;
            // 
            // settingValueLabel_2
            // 
            settingValueLabel_2.Location = new Point(670, 60);
            settingValueLabel_2.Name = "settingValueLabel_2";
            settingValueLabel_2.Size = new Size(120, 30);
            settingValueLabel_2.TabIndex = 2;
            settingValueLabel_2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(copyButton);
            buttonPanel.Controls.Add(saveAsciiArtButton);
            buttonPanel.Controls.Add(saveAsPngButton);
            buttonPanel.Controls.Add(resetButton);
            buttonPanel.Location = new Point(10, 360);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1160, 50);
            buttonPanel.TabIndex = 2;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(0, 10);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(200, 30);
            copyButton.TabIndex = 0;
            copyButton.Text = "Copy to Clipboard";
            // 
            // saveAsciiArtButton
            // 
            saveAsciiArtButton.Location = new Point(210, 10);
            saveAsciiArtButton.Name = "saveAsciiArtButton";
            saveAsciiArtButton.Size = new Size(200, 30);
            saveAsciiArtButton.TabIndex = 1;
            saveAsciiArtButton.Text = "Save ASCII Art";
            // 
            // saveAsPngButton
            // 
            saveAsPngButton.Location = new Point(420, 10);
            saveAsPngButton.Name = "saveAsPngButton";
            saveAsPngButton.Size = new Size(200, 30);
            saveAsPngButton.TabIndex = 1;
            saveAsPngButton.Text = "Save as PNG";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(630, 10);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(200, 30);
            resetButton.TabIndex = 2;
            resetButton.Text = "Reset Filters";
            resetButton.Click += resetButton_Click;
            // 
            // outputPanel
            // 
            outputPanel.Controls.Add(outputTextBox);
            outputPanel.Location = new Point(10, 420);
            outputPanel.Name = "outputPanel";
            outputPanel.Size = new Size(1160, 250);
            outputPanel.TabIndex = 3;
            // 
            // outputTextBox
            // 
            outputTextBox.Dock = DockStyle.Fill;
            outputTextBox.Location = new Point(0, 0);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.Size = new Size(1160, 250);
            outputTextBox.TabIndex = 0;
            outputTextBox.Text = "";
            // 
            // AsciiConverterForm
            // 
            AutoScroll = true;
            ClientSize = new Size(1200, 700);
            Controls.Add(menuStrip);
            Controls.Add(mainPanel);
            Font = new Font("FiraCode Nerd Font Mono Med", 8.25F);
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
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingTrackBar_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingTrackBar_2).EndInit();
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
        private Panel mainPanel;
        private Panel imagePanel;
        private PictureBox pictureBox;
        private Button uploadButton;
        private Panel settingsPanel;

        private Label settingLabel_1;
        private TrackBar settingTrackBar_1;
        private Label settingValueLabel_1;

        private Label settingLabel_2;
        private TrackBar settingTrackBar_2;
        private Label settingValueLabel_2;

        private Panel buttonPanel;
        private Button copyButton;
        private Button saveAsciiArtButton;
        private Button saveAsPngButton;
        private Button resetButton;
        private Panel outputPanel;
        private RichTextBox outputTextBox;
    }
}
