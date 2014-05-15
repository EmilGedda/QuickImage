using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuickImage.Interface;
using QuickImage.Model;
using QuickImage.Views;
using QuickImage.Properties;

namespace QuickImage.Presenter
{
	public sealed class PrintscreenPresenter
	{
		private readonly PrintscreenCollection printscreens = new PrintscreenCollection();

		private readonly IMainView mainView;

		public PrintscreenPresenter(IMainView mainView)
		{
			this.mainView = mainView;
			this.mainView.ViewClosed += MainViewClosed;

			if (Settings.Default.FirstRun)
			{
				Settings.Default.SavePath = Application.UserAppDataPath;
				Settings.Default.FirstRun = false;
				Settings.Default.Save();

			}

			LoadPrintScreens(Settings.Default.SavePath);

			printscreens.Changed += PrintscreenCollectionChanged; //Assign after LoadPrintScreens to prevent unnecessary event-calling
		}
		private void LoadPrintScreens(string path)
		{
			foreach (string file in Directory.GetFiles(path).Where(x => x.Contains(".qImg")))
			{
				Printscreen p;
				if (Printscreen.LoadFromFile(file, out p))
					printscreens.Add(p);
				else if (file != null)
				{
					File.Delete(file);
					File.Delete(Path.Combine(Path.GetFullPath(file), Path.GetFileNameWithoutExtension(file)));
				}
			}
		}

		private void MainViewClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Printscreen printscreen in printscreens)
				printscreen.Save();
		}
		private void PrintscreenCollectionChanged(object sender, ListChangedEventArgs e)
		{
			var s = (BindingList<Printscreen>)sender;
			mainView.ThumbList.Clear();
			mainView.ImageViewItems.Clear();
			for (int i = 0; i < s.Count; i++)
			{
				ListViewItem item = new ListViewItem { ImageIndex = i, Text = printscreens[i].GUID.ToString() };
				mainView.ThumbList.Add(printscreens[i].Thumb);
				mainView.ImageViewItems.Add(item);
			}
		}
	}
}