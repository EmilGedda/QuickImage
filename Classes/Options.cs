#region

using System.Drawing.Imaging;
using QuickImage.Properties;

#endregion

namespace QuickImage.Model
{
	// TODO: Implement singleton-pattern, so we can have some default values and serialization to a file.
	public class Options
	{
		public enum ImageType
		{
			PNG,
			JPEG
		}
		private static Options instance;

		public static Options Instance
		{
			get { return instance ?? new Options(); }
		}

		private Options()
		{
			instance = this;
		}
		public static ImageType Type { get; set; }
		public static int Compression { get; set; }

		public static string SavePath
		{
			get { return Settings.Default["SavePath"] as string; }
		}

		public static ImageFormat Format
		{
			get { return Type == ImageType.PNG ? ImageFormat.Png : ImageFormat.Jpeg; }
		}
	}
}