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

namespace jpgResizer
{
    public partial class MainForm : Form
    {
        // initialize variables in the form
        public MainForm()
        {
            InitializeComponent();
            resizePercentageBox.Value = 100;
            resizePercentageSlider.Value = 100;
            jpegQualitySlider.Value = 100;
            jpegQualityBox.Value = 100;
        }

        /// <summary>
        /// create a tempfile 
        /// </summary>
        /// <returns></returns>
        private static string CreateTempFile()
        {
            string fileName = string.Empty;

            try
            {
                // Get the full name of the newly created Temporary file. 
                // Note that the GetTempFileName() method actually creates
                // a 0-byte file and returns the name of the created file.
                fileName = Path.GetTempFileName();

                // Craete a FileInfo object to set the file's attributes
                FileInfo fileInfo = new FileInfo(fileName);

                // Set the Attribute property of this file to Temporary. 
                // Although this is not completely necessary, the .NET Framework is able 
                // to optimize the use of Temporary files by keeping them cached in memory.
                fileInfo.Attributes = FileAttributes.Temporary;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return fileName;
        }

        /// <summary>
        /// Copy the temp file
        /// </summary>
        /// <param name="tmpFile"></param>
        private static void CopyTmpFile(string tmpFile, string savelocation)
        {
            try
            {
                // Read from the temp file.
                var img = Image.FromFile(tmpFile, true);
                img.Save(savelocation);
                img.Dispose();
                DeleteTmpFile(tmpFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete the tempfile
        /// </summary>
        /// <param name="tmpFile"></param>
        private static void DeleteTmpFile(string tmpFile)
        {
            try
            {
                // Delete the temp file (if it exists)
                if (File.Exists(tmpFile))
                {
                    File.Delete(tmpFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Retrieves the image codec relevant to the format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
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
            // vars
            string path = openLocation.Text;
            string output;
            int resizeX, resizeY;
            bool originSameAsLocation = false;
            Int64 quality = (Int64)jpegQualityBox.Value;
            float percentage = (float)resizePercentageBox.Value / 100;

                // if the file does in fact still exist
                if (File.Exists(path))
                {
                    var img = Image.FromFile(path, true);
                    if (openLocation.Text == saveLocation.Text)
                    {
                        originSameAsLocation = true;
                    }
                    resizeX = (int) (img.Width * percentage);
                    resizeY = (int) (img.Height * percentage);

                    
                    using (Bitmap image = ResizeImage(img, resizeX, resizeY))
                    {
                        // FILENAMES
                        if (originSameAsLocation)
                        {
                            output = CreateTempFile();
                        }
                        else
                        {
                            output = saveLocation.Text;
                        }
                    
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        // Create an Encoder object based on the GUID for the Quality parameter.  
                        System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

                        // Create an EncoderParameters object. 
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);

                        EncoderParameter myEncoderParameter = new EncoderParameter(encoder, quality);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        image.Save(output, jpgEncoder, myEncoderParameters);

                        if (originSameAsLocation)
                        {
                            img.Dispose();
                            CopyTmpFile(output, saveLocation.Text);
                        }
                    }

                    MessageBox.Show("Image resized successfully!", "Success!");
                    
                }
                else
                {
                        MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
