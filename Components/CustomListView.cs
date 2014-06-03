#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QuickImage.Classes;

#endregion

namespace QuickImage.Components
{
	public sealed class CustomListView : ListView
	{
		private enum WMDefault
		{
			NCCALCSIZE = 0x83
		}

		private const int GWL_STYLE = -16;
		private const int WS_HSCROLL = 0x00100000;

		public CustomListView()
		{
			DoubleBuffered = true;
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)WMDefault.NCCALCSIZE)
			{
				int style = GetWindowLong(Handle, GWL_STYLE);
				if ((style & WS_HSCROLL) == WS_HSCROLL)
					SetWindowLong(Handle, GWL_STYLE, style & ~WS_HSCROLL);
			}
			base.WndProc(ref m);
		}

		private static int MakeLong(short lowPart, short highPart)
		{
			return (int)(((ushort)lowPart) | (uint)(highPart << 16));
		}

		public void SetSpacing(IWin32Window listview, short leftPadding, short topPadding)
		{
			const int LVM_FIRST = 0x1000;
			const int LVM_SETICONSPACING = LVM_FIRST + 53;
			NativeMethods.SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
		}

		private readonly Pen pBlack = new Pen(Color.Black);

		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			var item = (CustomListViewItem)Items[e.ItemIndex];

			if (item.ImageList == null) return;

			var img = item.ImageList.Images[item.ImageIndex];

			e.Graphics.DrawImage(img, item.Bounds.X, item.Bounds.Y);
			e.Graphics.DrawRectangle(pBlack, item.Bounds.X, item.Bounds.Y, img.Width, img.Height);

			if (item.Selected && item.SelectionOpacity < 255)
				item.SelectionOpacity += 5;
			if (!item.Selected && item.SelectionOpacity > 0)
				item.SelectionOpacity -= 5;

			Pen pBlue = new Pen(Color.FromArgb(item.SelectionOpacity, Color.DodgerBlue)) { Width = 3 };
			GraphicsPath rounded = RoundedRectangle.Create(item.Bounds.X - 1, item.Bounds.Y - 1, img.Width + 2, img.Height + 1, 5);
			e.Graphics.DrawPath(pBlue, rounded);

			base.OnDrawItem(e);

			if (item.SelectionOpacity > 0 && item.SelectionOpacity < 255)
				Invalidate();
		}

		private static int GetWindowLong(IntPtr hWnd, int nIndex)
		{
			return NativeMethods.GetWindowLong32(hWnd, nIndex);
		}

		private static void SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
		{
			NativeMethods.SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
		}
	}
}