#region

using System;
using System.Windows.Forms;
using QuickImage.Components;
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
			imageView.SetSpacing(imageView, 210, 120);
		}

		#region Properties
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
			set { descriptionsBox.Text = value; }
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
		#endregion

		#region Events
		public event KeyEventHandler ImageViewKeyDown;
		public event ListViewItemSelectionChangedEventHandler SelectedPrintscreenChanged;
		public event EventHandler<EventArgs> ToggleOverlay;
		public event EventHandler<EventArgs> OverlayButtonClicked;
		public event EventHandler<EventArgs> OptionsButtonClicked;
		public event EventHandler<EventArgs> Initialize;
		public event FormClosedEventHandler ViewClosed;


		private void optionsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show(imageView.SelectedItems.Count.ToString());
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
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (OverlayButtonClicked != null)
				OverlayButtonClicked(sender, e);
		}

		private void imageView_KeyDown(object sender, KeyEventArgs e)
		{
			if (ImageViewKeyDown != null)
				ImageViewKeyDown(sender, e);
		}

		private void linkButton_Click(object sender, EventArgs e)
		{
			
			if (ToggleOverlay != null)
				ToggleOverlay(sender, e);
		}
		#endregion
	}
}