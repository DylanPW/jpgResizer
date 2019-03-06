using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpgResizer
{
    class TempController
    {
        /// <summary>
        /// create a tempfile 
        /// </summary>
        /// <returns></returns>
        public static string CreateTempFile()
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
        public static void CopyTmpFile(string tmpFile, string savelocation)
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
    }
}
