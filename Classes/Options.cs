using System.Drawing.Imaging;
using QuickImage.Properties;

namespace QuickImage.Classes
{
    public static class Options
    {
        public enum ImageType { PNG, JPEG }
        public static ImageType Type { get; set; }
        public static int Compression { get; set; }
        public static string SavePath { get { return Settings.Default["SavePath"] as string; } }
        public static ImageFormat Format
        {
            get { return Type == ImageType.PNG ? ImageFormat.Png : ImageFormat.Jpeg; }
        }
    }
}
