using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using QuickImage.Components;
using QuickImage.Interface;
using QuickImage.Model;
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
			this.mainView.SelectedPrintscreenChanged += OnSelectedPrintscreenChanged;
			this.mainView.ImageViewKeyDown += OnImageViewKeyDown;
			if (Settings.Default.FirstRun)
			{
				Settings.Default.SavePath = Application.UserAppDataPath;
				Settings.Default.FirstRun = false;
				Settings.Default.Save();

			}
			printscreens.Changed += PrintscreenCollectionChanged; //Assign after LoadPrintScreens to prevent unnecessary event-calling
			using(WebClient wc = new WebClient())
				//wc.DownloadDataAsync(new Uri());
			LoadPrintScreens(Settings.Default.SavePath);
		}
		private void OnImageViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Delete) return;
			var listView = (CustomListView) sender;
			foreach (ListViewItem selectedItem in listView.SelectedItems)
			{
				var printscreen = printscreens.FirstOrDefault(x => x.GUID.ToString() == selectedItem.Text);
				if (printscreen == null) continue;
				printscreen.Delete();
				printscreens.Remove(printscreen);
				listView.Items.Remove(selectedItem);
			}
			mainView.Link = string.Empty;
			mainView.LinkButtonText = "Copy Link";
		}

		private void OnSelectedPrintscreenChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			var item = e.Item;
			if (!item.Selected)
			{
				mainView.Link = string.Empty;
				mainView.LinkButtonText = "Copy Link";
				mainView.Description = string.Empty;
				return;
			}

			var printscreen = printscreens.FirstOrDefault(x => x.GUID.ToString() == item.Text);
			if (printscreen == null) return;
			mainView.Link = printscreen.Uploaded ? printscreen.ImgurImage.Link : "Not uploaded";
			mainView.LinkButtonText = printscreen.Uploaded ? "Copy Link" : "Upload";
			mainView.Description = printscreen.Description;
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
				CustomListViewItem item = new CustomListViewItem { ImageIndex = i, Text = printscreens[i].GUID.ToString() };
				mainView.ThumbList.Add(printscreens[i].Thumb);
				mainView.ImageViewItems.Add(item);
			}
		}
	}
}