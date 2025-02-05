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
            this.menuStrip = new MenuStrip();
            this.fileMenu = new ToolStripMenuItem();
            this.openMenuItem = new ToolStripMenuItem();
            this.separator = new ToolStripSeparator();
            this.exitMenuItem = new ToolStripMenuItem();

            this.mainPanel = new Panel();
            this.imagePanel = new Panel();
            this.pictureBox = new PictureBox();
            this.uploadButton = new Button();

            this.settingsPanel = new Panel();
            this.settingLabel = new Label();
            this.settingTrackBar = new TrackBar();
            this.settingValueLabel = new Label();

            this.buttonPanel = new Panel();
            this.copyButton = new Button();
            this.saveButton = new Button();
            this.resetButton = new Button();

            this.outputPanel = new Panel();
            this.outputTextBox = new RichTextBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingTrackBar)).BeginInit();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(_size.width, 30);
            this.menuStrip.TabIndex = 0;

            // File Menu
            this.fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openMenuItem, separator, exitMenuItem });
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new Size(46, 24);
            this.fileMenu.Text = "&File";

            // Open Menu Item
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new Size(150, 26);
            this.openMenuItem.Text = "&Open ...";

            // Separator
            this.separator.Name = "separator";
            this.separator.Size = new Size(147, 6);

            // Exit Menu Item
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new Size(150, 26);
            this.exitMenuItem.Text = "E&xit";

            // Main Panel
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(this.imagePanel);
            this.mainPanel.Controls.Add(this.settingsPanel);
            this.mainPanel.Controls.Add(this.buttonPanel);
            this.mainPanel.Controls.Add(this.outputPanel);

            // Image Panel (Left 30%)
            this.imagePanel.Location = new Point(10, 40);
            this.imagePanel.Size = new Size(350, 300);
            this.imagePanel.Controls.Add(this.pictureBox);
            this.imagePanel.Controls.Add(this.uploadButton);

            // PictureBox
            this.pictureBox.Location = new Point(0, 10);
            this.pictureBox.Size = new Size(300, 250);
            this.pictureBox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Upload Button
            this.uploadButton.Location = new Point(0, 270);
            this.uploadButton.Size = new Size(300, 30);
            this.uploadButton.Text = "Upload Image";
            this.uploadButton.Click += new EventHandler(this.openToolStripMenuItem_Click);

            // Settings Panel (Right 70%)
            this.settingsPanel.Location = new Point(370, 40);
            this.settingsPanel.Size = new Size(800, 300);
            this.settingsPanel.Controls.Add(this.settingLabel);
            this.settingsPanel.Controls.Add(this.settingTrackBar);
            this.settingsPanel.Controls.Add(this.settingValueLabel);

            // Setting Label
            this.settingLabel.Location = new Point(20, 20);
            this.settingLabel.Size = new Size(120, 30);
            this.settingLabel.Text = "Brightness:";

            // Setting TrackBar
            this.settingTrackBar.Location = new Point(150, 20);
            this.settingTrackBar.Size = new Size(500, 30);
            this.settingTrackBar.Minimum = 0;
            this.settingTrackBar.Maximum = 100;

            // Setting Value Label
            this.settingValueLabel.Location = new Point(670, 20);
            this.settingValueLabel.Size = new Size(50, 30);
            this.settingValueLabel.Text = "50%";

            // Button Panel (Middle)
            this.buttonPanel.Location = new Point(10, 360);
            this.buttonPanel.Size = new Size(1160, 50);
            this.buttonPanel.Controls.Add(this.copyButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.resetButton);

            // Copy Button
            this.copyButton.Location = new Point(0, 10);
            this.copyButton.Size = new Size(200, 30);
            this.copyButton.Text = "Copy to Clipboard";

            // Save Button
            this.saveButton.Location = new Point(210, 10);
            this.saveButton.Size = new Size(200, 30);
            this.saveButton.Text = "Save ASCII Art";

            // Reset Button
            this.resetButton.Location = new Point(420, 10);
            this.resetButton.Size = new Size(200, 30);
            this.resetButton.Text = "Reset Filters";

            // Output Panel (Bottom)
            this.outputPanel.Location = new Point(10, 420);
            this.outputPanel.Size = new Size(1160, 250);
            this.outputPanel.Controls.Add(this.outputTextBox);

            // Output TextBox
            this.outputTextBox.Dock = DockStyle.Fill;
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.WordWrap = true;

            // Form Configuration
            this.Controls.Add(menuStrip);
            this.Controls.Add(this.mainPanel);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new Size(1200, 700);
            this.MaximizeBox = false;
            this.AutoScroll = true;
            this.Font = new Font("FiraCode Nerd Font Mono Med", 8.25f);
            this.Text = "ASCII Art Generator";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingTrackBar)).EndInit();
            this.ResumeLayout(false);
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
        private Label settingLabel;
        private TrackBar settingTrackBar;
        private Label settingValueLabel;
        private Panel buttonPanel;
        private Button copyButton;
        private Button saveButton;
        private Button resetButton;
        private Panel outputPanel;
        private RichTextBox outputTextBox;
    }
}
