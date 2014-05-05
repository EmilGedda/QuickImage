using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace QuickImage.Classes
{
    [Serializable]
    public partial class Printscreen
    {
        #region Private fields
        private string name;
        private Guid guid;
        private DateTime date;
        private string size;
        private string resolution;
        private Image thumb;
        private Imgur imgurImage;
        private string process;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Guid GUID
        {
            get { return guid; }
            private set { guid = value; }
        }

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public string Process
        {
            get { return process; }
            set { process = value; }
        }

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        public string Resolution
        {
            get { return resolution; }
            private set { resolution = value; }
        }

        public Image Thumb
        {
            get { return thumb; }
            private set { thumb = value; }
        }

        public Imgur ImgurImage
        {
            get { return imgurImage; }
            private set { imgurImage = value; }
        }
        #endregion

        public bool Uploaded { get { return ImgurImage != null; } }
        private string filePath { get { return Path.Combine(Options.SavePath, GUID.ToString()); } }

        public string Description
        {
            get
            {
                return string.Format("Name: {0}\nDate: {1}\nSize: {2}\nProcess: {3}\nResolution: {4}", Name, Date.ToString("g"), Size, Process, Resolution);
            }
        }

        private Printscreen()
        {
            Date = DateTime.Now;
            Name = Date.ToString("g");
            GUID = Guid.NewGuid();
        }

        public void Upload()
        {
            ImgurImage = Imgur.Upload(filePath);
        }

        #region Static methods
        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 2);
            return (Math.Sign(byteCount) * num) + suf[place];
        }
		#endregion
        public bool Save()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Path.Combine(Options.SavePath, GUID + ".qImg"), FileMode.Create, FileAccess.Write, FileShare.None))
                    formatter.Serialize(stream, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to save {0}!\nError: {1}", Path.GetFileNameWithoutExtension(filePath), ex.Message));
                return false;
            }
            return true;
        }
		public void Delete()
		{
			File.Delete(filePath);
			File.Delete(filePath + ".qImg");
		}


        public static bool operator ==(Printscreen p1, Printscreen p2)
        {
			if (ReferenceEquals(p1, p2))
				return true;
			
            if (((object)p1 == null) || ((object) p2 == null))
                return false;
            return p1.GUID == p2.GUID;
        }

        public static bool operator !=(Printscreen p1, Printscreen p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return GUID.GetHashCode();
        }
        public override bool Equals(object obj)
        {
	        if (obj == null)
		        return false;
            var printscreen = obj as Printscreen;
            return  printscreen != null && GUID.Equals(printscreen.GUID);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;        // x position of upper-left corner
            public readonly int Top;         // y position of upper-left corner
            public readonly int Right;       // x position of lower-right corner
            public readonly int Bottom;      // y position of lower-right corner
        }
    }
}
