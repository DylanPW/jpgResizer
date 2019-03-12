using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Policy;

namespace jpgResizer
{
    public partial class MainForm : Form
    {
        // initialize variables in the form
        public MainForm()
        {
            InitializeComponent();

            resizePercentageBox.Value = GlobVars.defaultSliderValues;
            resizePercentageSlider.Value = GlobVars.defaultSliderValues;
            jpegQualitySlider.Value = GlobVars.defaultSliderValues;
            jpegQualityBox.Value = GlobVars.defaultSliderValues;
            versionLabel.Text = GlobVars.versionName + GlobVars.version;
            longEdgeBox.Maximum = Decimal.MaxValue;

            sizeLabel.Text = GlobVars.resizeMode.ToString();

            debugButton.Enabled = false;

            sizeLabel.Text = "Original image size: ";
            resizeLabel.Text = "Resize image size: ";
        }

        /// <summary>
        /// Click event for the file open button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openButton_Click(object sender, EventArgs e)
        {
            // displays the open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            openFileDialog.Title = "Select an Image";

            // Show the title

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openLocation.Text = openFileDialog.FileName;
            }
            if (File.Exists(openFileDialog.FileName))
            {
                var img = Image.FromFile(openFileDialog.FileName);
                sizeLabel.Text = "Original image size: " + img.Width + "x" + img.Height;
                img.Dispose();
            }
        }

        /// <summary>
        /// Click event for the file save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "jpg Image|*.jpg";
            saveFileDialog.Title = "Save an Image";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                saveLocation.Text = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Click event for the resize button.
        /// Where all the magic happens
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resizeButton_Click(object sender, EventArgs e)
        {
            // variables to use
            string path = openLocation.Text;
            string savePath = saveLocation.Text;
            string debugPath = debugLocation.Text;
            Int64 quality = (Int64)jpegQualityBox.Value;
            float percentage = (float)resizePercentageBox.Value / 100;
            int longEdge = (int) longEdgeBox.Value;
            if (path != "" && savePath != "")
            {

                if (debugCheckbox.Checked && debugPath != "")
                {
                    GlobVars.debugPath = debugPath;
                    if (GlobVars.debugMode)
                    {
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(GlobVars.debugPath))
                        {
                            file.WriteLine("[INFO] Resizing Commencing!");
                            file.Close();
                        }
                    }
                }

                if (percentageRadioButton.Checked && !longEdgeRadioButton.Checked)
                {
                    ImageManipulator.ProcessImage(path, savePath, quality, percentage);
                }
                else if (!percentageRadioButton.Checked && longEdgeRadioButton.Checked)
                {
                    ImageManipulator.ProcessImageLongEdge(path, savePath, quality, longEdge);
                }
            }
            else
            {
                MessageBox.Show("You must select a source and destination file.", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // stuff to make the trackbar and box have the same values, probably not that important as box value is used anyway
        private void resizePercentageSlider_Scroll(object sender, EventArgs e)
        {
            resizePercentageBox.Value = resizePercentageSlider.Value;
        }

        private void jpegQualitySlider_Scroll(object sender, EventArgs e)
        {
            jpegQualityBox.Value = jpegQualitySlider.Value;
        }
        private void resizePercentageBox_ValueChanged(object sender, EventArgs e)
        {
            resizePercentageSlider.Value = (int)resizePercentageBox.Value;
        }

        private void jpegQualityBox_ValueChanged(object sender, EventArgs e)
        {
            jpegQualitySlider.Value = (int)jpegQualityBox.Value;
        }

        /// <summary>
        /// Radio button checked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void percentageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (percentageRadioButton.Checked)
            {
                resizePercentageSlider.Enabled = true;
                resizePercentageBox.Enabled = true;
                longEdgeBox.Enabled = false;
            }
            else if (longEdgeRadioButton.Checked)
            {
                resizePercentageSlider.Enabled = false;
                resizePercentageBox.Enabled = false;
                longEdgeBox.Enabled = true;
            }
        }

        /// <summary>
        /// Radio button checked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void longEdgeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (percentageRadioButton.Checked)
            {
                resizePercentageSlider.Enabled = true;
                resizePercentageBox.Enabled = true;
                longEdgeBox.Enabled = false;
                GlobVars.resizeMode = 1;
            }
            else if (longEdgeRadioButton.Checked)
            {
                resizePercentageSlider.Enabled = false;
                resizePercentageBox.Enabled = false;
                longEdgeBox.Enabled = true;
                GlobVars.resizeMode = 2;
            }
        }

        /// <summary>
        /// enable and disable the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void debugCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            GlobVars.debugMode = debugCheckbox.Checked;
            debugButton.Text = GlobVars.debugMode.ToString();
            if(debugCheckbox.Checked)
            {
                debugButton.Enabled = true;
            }
            else
            {
                debugButton.Enabled = false;
            }
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save Debug Log";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                debugLocation.Text = saveFileDialog.FileName;
            }
        }
    }
}
