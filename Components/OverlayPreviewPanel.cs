using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickImage.Classes;

namespace QuickImage.Components
{
	class OverlayPreviewPanel : Panel
	{
		private int thickness = 3;

		public int Thickness
		{
			get { return thickness; }
			set { thickness = value; }
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.White);
			const int margin = 10;
			GraphicsPath overlay = RoundedRectangle.Create(margin, margin, Width - 2*margin, Height - 2*margin);
			e.Graphics.DrawPath(new Pen(Color.Red) { Width = Thickness }, overlay);
		}
	}
}
