#region

using System;
using System.Windows.Forms;
using QuickImage.Interface;
using QuickImage.Presenter;

#endregion

namespace QuickImage.Views
{
	public sealed partial class MainView : Form, IMainView
	{
		private PrintscreenPresenter presenter;

		public MainView()
		{
			InitializeComponent();
			presenter = new PrintscreenPresenter(this);
			Text = string.Format("{0} - v{1}", ProductName, ProductVersion); //YOLO
		}

		public ListView.ListViewItemCollection ImageViewItems
		{
			get { return imageView.Items; }
		}

		public ImageList.ImageCollection ThumbList
		{
			get { return thumbList.Images; }
		}

		public string Status
		{
			set { statusLabel.Text = value; }
		}

		public string Description
		{
			set { descriptionLabel.Text = value; }
		}

		public string Link
		{
			set { linkBox.Text = value; }
		}

		public string LinkButtonText
		{
			set { linkButton.Text = value; }
		}
		public string Title
		{
			set { Text = value; }
		}

		public event KeyEventHandler ImageViewKeyDown;
		public event ListViewItemSelectionChangedEventHandler SelectedPrintscreenChanged;
		public event EventHandler<EventArgs> ToggleOverlay;
		public event EventHandler<EventArgs> DeleteButtonClicked;
		public event EventHandler<EventArgs> OptionsButtonClicked;
		public event EventHandler<EventArgs> Initialize;
		public event FormClosedEventHandler ViewClosed;


		private void optionsButton_Click(object sender, EventArgs e)
		{
			if (OptionsButtonClicked != null)
				OptionsButtonClicked(sender, e);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (ViewClosed != null)
				ViewClosed(sender, e);
		}

		private void imageView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (SelectedPrintscreenChanged != null)
				SelectedPrintscreenChanged(sender, e);
			/*
			var item = e.Item;
			if (!item.Selected)
			{
				linkBox.Text = string.Empty;
				linkButton.Text = "Copy Link";
				return;
			}

			var printscreen = Printscreens.FirstOrDefault(x => x.GUID.ToString() == item.Text);
			if (printscreen == null) return;
			linkBox.Text = printscreen.Uploaded ? printscreen.ImgurImage.Link : "Not uploaded";
			linkButton.Text = printscreen.Uploaded ? "Copy Link" : "Upload";
			*/
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (DeleteButtonClicked != null)
				DeleteButtonClicked(sender, e);
			/*
						if (imageView.SelectedItems.Count <= 0) return;
						foreach (ListViewItem selectedItem in imageView.SelectedItems)
						{
							var printscreen = Printscreens.FirstOrDefault(x => x.GUID.ToString() == selectedItem.Text);
							if (printscreen == null) continue;
							printscreen.Delete();
							Printscreens.Remove(printscreen);
							imageView.Items.Remove(selectedItem);
						}
			*/
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void imageView_KeyDown(object sender, KeyEventArgs e)
		{
			if (ImageViewKeyDown != null)
				ImageViewKeyDown(sender, e);

/*
			if (e.KeyCode != Keys.Delete) return;
			foreach (ListViewItem selectedItem in imageView.SelectedItems)
			{
				var printscreen = Printscreens.FirstOrDefault(x => x.GUID.ToString() == selectedItem.Text);
				if (printscreen == null) continue;
				printscreen.Delete();
				Printscreens.Remove(printscreen);
				imageView.Items.Remove(selectedItem);
			}
*/
		}

		private void linkButton_Click(object sender, EventArgs e)
		{
			if (ToggleOverlay != null)
				ToggleOverlay(sender, e);
		}
	}
}