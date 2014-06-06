#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuickImage.Classes;

#endregion

namespace QuickImage.Views
{
	public sealed partial class OptionsView : Form
	{
		public OptionsView()
		{
			InitializeComponent();
			linkLabel1.Links.Add(new LinkLabel.Link());
			linkLabel1.Links[0].LinkData = "http://github.se/EmilGedda/QuickImage";
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;
			string key = Hotkey.ValidKeys.FirstOrDefault(x => x.Value == e.KeyData).Key;
			if (key != null)
				comboBox1.Text = key;
		}

		private void OptionsView_Load(object sender, EventArgs e)
		{

		}
	}
}