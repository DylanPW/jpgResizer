using System.IO;

namespace jpgResizer
{
    public static class GlobVars
    {
        public const string version = "0.4";
        public const string versionName = "Version ";
        public const int defaultSliderValues = 100;
        public static int resizeMode = 1;
        public static bool debugMode = false;
        public static string debugPath { get; set; }

        //Write a debug message to the file
        public static void DebugMessage(string debugCode, string debugMessage)
        {
            if (debugMode)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(debugPath, true))
                {
                    file.WriteLine(debugCode + " " + debugMessage);
                    file.Close();
                }
            }
        }
    }
}