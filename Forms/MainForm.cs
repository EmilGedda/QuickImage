using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuickImage.Classes;
using QuickImage.Properties;

namespace QuickImage.Forms
{
    public sealed partial class MainForm : Form
    {
        private IList<Printscreen> Printscreens { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Printscreens = new List<Printscreen>();
            Text = string.Format("{0} - v{1}", ProductName, ProductVersion);
            Settings.Default["SavePath"] = Application.UserAppDataPath;
            Settings.Default.Save();
            LoadPrintScreens(Options.SavePath);
	        Printscreens.Add(Printscreen.CaptureScreen());
            if (Printscreens.Count > 0)
                PopulateListView();
        }

        private void PopulateListView()
        {
            for (int i = 0; i < Printscreens.Count; i++)
            {
                Printscreen p = Printscreens[i];
                thumbList.Images.Add(p.Thumb);
                ListViewItem item = new ListViewItem {ImageIndex = i, Text = p.GUID.ToString()};
	            imageView.Items.Add(item);
				
            }
        }

        private void LoadPrintScreens(string path)
        {
            foreach (string file in Directory.GetFiles(path).Where(x => x.Contains(".qImg")))
            {
                Printscreen p;
                if (Printscreen.LoadFromFile(file, out p))
                    Printscreens.Add(p);
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Printscreen printscreen in Printscreens)
                printscreen.Save();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void imageView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
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
        }

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (imageView.SelectedItems.Count <= 0) return;
			foreach (ListViewItem selectedItem in imageView.SelectedItems)
			{
				var printscreen = Printscreens.FirstOrDefault(x => x.GUID.ToString() == selectedItem.Text);
				if (printscreen == null) continue;
				printscreen.Delete();
				Printscreens.Remove(printscreen);
				imageView.Items.Remove(selectedItem);
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void imageView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Delete) return;
			foreach (ListViewItem selectedItem in imageView.SelectedItems)
			{
				var printscreen = Printscreens.FirstOrDefault(x => x.GUID.ToString() == selectedItem.Text);
				if (printscreen == null) continue;
				printscreen.Delete();
				Printscreens.Remove(printscreen);
				imageView.Items.Remove(selectedItem);
			}
		}
    }
}
