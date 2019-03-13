using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpgResizer
{
    class ImageManipulator
    {
        
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
        public static ImageCodecInfo GetEncoder(ImageFormat format)
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
        /// Resize image by a percentage
        /// </summary>
        /// <param name="resizeX"></param>
        /// <param name="resizeY"></param>
        /// <param name="oldX"></param>
        /// <param name="oldY"></param>
        /// <param name="percentage"></param>
        public static void GetResizeValuesPercentage(out int resizeX, out int resizeY, int oldX, int oldY, float percentage)
        {
            GlobVars.DebugMessage("[INFO]", "Calculating new values...");
            resizeX = (int)(oldX * percentage);
            resizeY = (int)(oldY * percentage);
            GlobVars.DebugMessage("[INFO]", string.Format("Percentage is {0}%", percentage));
            GlobVars.DebugMessage("[INFO]", string.Format("Old X is {0}", oldX));
            GlobVars.DebugMessage("[INFO]", string.Format("Old Y is {0}", oldY));
            GlobVars.DebugMessage("[INFO]", string.Format("New X is {0}", resizeX));
            GlobVars.DebugMessage("[INFO]", string.Format("New Y is {0}", resizeY));
        }

        /// <summary>
        /// resize image by long edge
        /// </summary>
        /// <param name="resizeX"></param>
        /// <param name="resizeY"></param>
        /// <param name="oldX"></param>
        /// <param name="oldY"></param>
        /// <param name="longEdge"></param>
        /// 
        public static void GetResizeValuesLongEdge(out int resizeX, out int resizeY, int oldX, int oldY, int longEdge)
        {
            bool horizontal;
            double ratio;
            GlobVars.DebugMessage("[INFO]", "Calculating new values...");
            if (oldX < oldY)
            {
                horizontal = false;
                ratio = (double)oldY / (double)longEdge;
                resizeX = (int)(oldX / ratio);
                resizeY = longEdge;
                GlobVars.DebugMessage("[INFO]", string.Format("Image is Portrait"));
                GlobVars.DebugMessage("[INFO]", string.Format("Ratio is {0:0.0000}", ratio));
                GlobVars.DebugMessage("[INFO]", string.Format("Old X is {0}", oldX));
                GlobVars.DebugMessage("[INFO]", string.Format("Old Y is {0}", oldY));
                GlobVars.DebugMessage("[INFO]", string.Format("New X is {0}", resizeX));
                GlobVars.DebugMessage("[INFO]", string.Format("New Y is {0}", resizeY));
            }
            else
            {
                horizontal = true;
                ratio = (double)oldX / (double)longEdge;
                resizeX = longEdge;
                resizeY = (int)(oldY / ratio);
                GlobVars.DebugMessage("[INFO]", string.Format("Image is landscape"));
                GlobVars.DebugMessage("[INFO]", string.Format("Ratio is {0:0.0000}", ratio));
                GlobVars.DebugMessage("[INFO]", string.Format("Old X is {0}", oldX));
                GlobVars.DebugMessage("[INFO]", string.Format("Old Y is {0}", oldY));
                GlobVars.DebugMessage("[INFO]", string.Format("New X is {0}", resizeX));
                GlobVars.DebugMessage("[INFO]", string.Format("New Y is {0}", resizeY));
            }
        }

        /// <summary>
        /// process image by percentage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="savePath"></param>
        /// <param name="quality"></param>
        /// <param name="percentage"></param>
    
        public static void ProcessImage(string path, string savePath, Int64 quality, float percentage)
        {
            string output;
            int resizeX, resizeY;
            bool originSameAsLocation = false;
            
            // if the file does in fact still exist
            if (File.Exists(path))
            {
                var img = Image.FromFile(path, true);
                GlobVars.DebugMessage("[INFO]", "Loaded Image!");
                if (path == savePath)
                {
                    originSameAsLocation = true;
                }
                
                GetResizeValuesPercentage(out resizeX, out resizeY, img.Width, img.Height, percentage);

                GlobVars.DebugMessage("[INFO]", "Re-Encoding file...");
                using (Bitmap image = ImageManipulator.ResizeImage(img, resizeX, resizeY))
                {
                    // FILENAMES
                    if (originSameAsLocation)
                    {
                        output = TempController.CreateTempFile();
                    }
                    else
                    {
                        output = savePath;
                    }

                    ImageCodecInfo jpgEncoder = ImageManipulator.GetEncoder(ImageFormat.Jpeg);
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
                        TempController.CopyTmpFile(output, savePath);
                    }
                    else
                    {
                        img.Dispose();
                    }
                }
                GlobVars.DebugMessage("[INFO]", "Image resized successfully!");
                MessageBox.Show("Image resized successfully!", "Success!");

            }
            else
            {
                GlobVars.DebugMessage("[ERROR]", "An error occured.");
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ProcessImageLongEdge(string path, string savePath, Int64 quality, int longEdge)
        {
            string output;
            int resizeX, resizeY;
            bool originSameAsLocation = false;

            // if the file does in fact still exist
            if (File.Exists(path))
            {
                var img = Image.FromFile(path, true);
                GlobVars.DebugMessage("[INFO]", "Loaded Image!");
                if (path == savePath)
                {
                    originSameAsLocation = true;
                }
                GetResizeValuesLongEdge(out resizeX, out resizeY, img.Width, img.Height, longEdge);

                GlobVars.DebugMessage("[INFO]", "Re-Encoding file...");
                using (Bitmap image = ImageManipulator.ResizeImage(img, resizeX, resizeY))
                {
                    // FILENAMES
                    if (originSameAsLocation)
                    {
                        output = TempController.CreateTempFile();
                    }
                    else
                    {
                        output = savePath;
                    }

                    ImageCodecInfo jpgEncoder = ImageManipulator.GetEncoder(ImageFormat.Jpeg);
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
                        TempController.CopyTmpFile(output, savePath);
                    }
                    else
                    {
                        img.Dispose();
                    }
                }
                GlobVars.DebugMessage("[INFO]", "Image resized successfully!");
                MessageBox.Show("Image resized successfully!", "Success!");
            }
            else
            {
                GlobVars.DebugMessage("[ERROR]", "An error occured.");
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
