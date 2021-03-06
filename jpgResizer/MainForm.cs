﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Policy;


namespace jpgResizer
{
    public partial class MainForm : Form
    {
        //TODO: Put these somewhere more useful
        private bool fileLoaded = false;
        private int originX = 0;
        private int originY = 0;

        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };


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

            this.AllowDrop = true;
            this.DragOver += new DragEventHandler(MainForm_DragOver);
            this.DragDrop += new DragEventHandler(MainForm_DragDrop);

            sizeLabel.Text = "Original image res: ";
            resizeLabel.Text = "Resize image res: ";
        }

        /// <summary>
        /// resize preview function
        /// </summary>
        private void resizePreview()
        {
            if (fileLoaded)
            {
                int resizeX = 0, resizeY = 0;
                // RESIZE MODES:
                // PERCENTAGE = 1
                // LONG EDGE = 2
                if (GlobVars.resizeMode == 1)
                {
                    ImageManipulator.GetResizeValuesPercentage(out resizeX, out resizeY, originX, originY, (float)resizePercentageBox.Value / 100);
                }
                else if (GlobVars.resizeMode == 2)
                {
                    ImageManipulator.GetResizeValuesLongEdge(out resizeX, out resizeY, originX, originY, (int)longEdgeBox.Value);
                }
                resizeLabel.Text = "Resize image res: " + resizeX + "x" + resizeY;
            }
        }


        /// <summary>
        /// Generate a preview of the original image size
        /// </summary>
        /// <param name="filePath"></param>
        private void originalPreview(string filePath)
        {
            if (File.Exists(filePath))
            {
                var img = Image.FromFile(filePath);
                originX = img.Width;
                originY = img.Height;
                sizeLabel.Text = "Original image res: " + originX + "x" + originY;
                fileLoaded = true;
                resizePreview();
                img.Dispose();
            }

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
            originalPreview(openFileDialog.FileName);
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

        /// <summary>
        /// stuff to make the trackbar and box have the same values, probably not that important as box value is used anyway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resizePercentageSlider_Scroll(object sender, EventArgs e)
        {
            resizePercentageBox.Value = resizePercentageSlider.Value;
        }
        private void resizePercentageBox_ValueChanged(object sender, EventArgs e)
        {
            resizePercentageSlider.Value = (int)resizePercentageBox.Value;
            resizePreview();
        }
        private void longEdgeBox_ValueChanged(object sender, EventArgs e)
        {
            resizePreview();
        }

        private void jpegQualitySlider_Scroll(object sender, EventArgs e)
        {
            jpegQualityBox.Value = jpegQualitySlider.Value;
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

        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
                
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Any())
            {
                if (ImageExtensions.Contains(Path.GetExtension(files.First()).ToUpperInvariant()))
                {
                    originalPreview((files.First()));
                    openLocation.Text = files.First();
                } else {
                    MessageBox.Show("Invalid File Type!", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
