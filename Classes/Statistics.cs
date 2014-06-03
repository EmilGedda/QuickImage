using System;

namespace QuickImage.Classes
{
	[Serializable]
	internal class Statistics
	{
		#region Fields
		private static Statistics instance;
		private int printscreens;
		private int runs;
		private int uploads;
		#endregion

		#region Properties
		private Statistics()
		{
			instance = this;
		}

		public int Uploads
		{
			get { return uploads; }
			set { uploads = value; }
		}

		public int Printscreens
		{
			get { return printscreens; }
			set { printscreens = value; }
		}

		public int Runs
		{
			get { return runs; }
			set { runs = value; }
		}

		public static Statistics Instance
		{
			get { return instance ?? new Statistics(); }
		}
		#endregion


		public static void Upload()
		{
		}
	}
}