using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace QuickImage.Classes
{
	public partial class Printscreen
	{
		public static Printscreen CaptureScreen()
		{
			Bitmap printscreen = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
			Graphics graphics = Graphics.FromImage(printscreen);
			graphics.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, printscreen.Size);
			return Capture(printscreen, "Screen");
		}

		public static Printscreen CaptureWindow()
		{
			IntPtr activeWindow = GetForegroundWindow();
			RECT size;
			GetWindowRect(activeWindow, out size);
			Bitmap printscreen = new Bitmap(size.Right - size.Left, size.Bottom - size.Top);
			Graphics graphics = Graphics.FromImage(printscreen);
			graphics.CopyFromScreen(size.Left, size.Top, 0, 0, printscreen.Size);
			return Capture(printscreen, "Process");
		}

		private static Printscreen Capture(Image img, string process)
		{
			Printscreen printscreen = new Printscreen();
			switch (Options.Type)
			{
				case Options.ImageType.PNG:
					img.Save(printscreen.filePath, ImageFormat.Png);
					break;
				case Options.ImageType.JPEG:
					SaveJPEG(printscreen.filePath, img);
					break;

			}
			printscreen.Resolution = string.Format("{0}x{1}", img.Width, img.Height);
			printscreen.Size = BytesToString(new FileInfo(printscreen.filePath).Length);
			printscreen.Thumb = img.GetThumbnailImage(200, 112, null, IntPtr.Zero);
			printscreen.Process = process;
			return printscreen;
		}
		private static void SaveJPEG(string path, Image bmp)
		{
			Encoder encoder = Encoder.Quality;
			EncoderParameters encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = new EncoderParameter(encoder, Options.Compression);
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			ImageCodecInfo jpegEncoder = codecs.FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
			bmp.Save(path, jpegEncoder, encoderParameters);
		}
		public static bool LoadFromFile(string path, out Printscreen printscreen)
		{
			printscreen = null;
			try
			{
				IFormatter formatter = new BinaryFormatter();
				using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
					printscreen = formatter.Deserialize(stream) as Printscreen;
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Unable to load {0}!\nError: {1}", Path.GetFileNameWithoutExtension(path), ex.Message));
				File.Delete(path);
				File.Delete(path.Replace(".qImg", ""));
				return false;
			}
			return printscreen != null;
		}
	}
}
