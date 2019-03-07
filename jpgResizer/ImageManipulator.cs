using System;
using System.Collections.Generic;
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
        private static void GetResizeValuesPercentage(out int resizeX, out int resizeY, int oldX, int oldY, float percentage)
        {
            resizeX = (int)(oldX * percentage);
            resizeY = (int)(oldY * percentage);
        }


        private static void GetResizeValuesLongEdge(out int resizeX, out int resizeY, int oldX, int oldY, int longEdge)
        {
            bool horizontal;
            float ratio;
            if (oldX < oldY)
            {
                horizontal = false;
                ratio = oldY / oldX;
                resizeX = (int)(oldX / ratio);
                resizeY = longEdge;
            }
            else
            {
                horizontal = true;
                ratio = oldX / oldY;
                resizeX = longEdge;
                resizeY = (int)(oldX / ratio);
            }
        }

        public static void ProcessImage(string path, string savePath, Int64 quality, float percentage)
        {
            string output;
            int resizeX, resizeY;
            bool originSameAsLocation = false;
            
            // if the file does in fact still exist
            if (File.Exists(path))
            {
                var img = Image.FromFile(path, true);
                if (path == savePath)
                {
                    originSameAsLocation = true;
                }
                GetResizeValuesPercentage(out resizeX, out resizeY, img.Width, img.Height, percentage);

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

                MessageBox.Show("Image resized successfully!", "Success!");

            }
            else
            {
                MessageBox.Show("An Error Occured, please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
