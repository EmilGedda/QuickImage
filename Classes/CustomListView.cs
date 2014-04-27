#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace QuickImage.Classes
{
    public class CustomListView : ListView
    {
        private const int GWL_STYLE = -16;
        private const int WS_HSCROLL = 0x00100000;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WMDefaults.WM_NCCALCSIZE:
                    int style = GetWindowLong(Handle, GWL_STYLE);
                    if ((style & WS_HSCROLL) == WS_HSCROLL)
                        SetWindowLong(Handle, GWL_STYLE, style & ~WS_HSCROLL);
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            foreach (ListViewItem item in Items)
               item.Selected = false;
            
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            var item = e.Item;
            if (item.ImageList == null) return;

            var img = item.ImageList.Images[item.ImageIndex];
            e.Graphics.DrawImage(img, item.Bounds.X, item.Bounds.Y);
            if (e.Item.Selected)
            {
                Pen p = new Pen(Color.DodgerBlue) {Width = 3};
                e.Graphics.DrawRectangle(p, item.Bounds.X, item.Bounds.Y, img.Width, img.Height);
            }
            else
            {
				Pen p = new Pen(Color.Black);
				e.Graphics.DrawRectangle(p, item.Bounds.X, item.Bounds.Y, img.Width, img.Height);
            }
            base.OnDrawItem(e);
        }

        private static int GetWindowLong(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return (int) GetWindowLong32(hWnd, nIndex);
            return (int) (long) GetWindowLongPtr64(hWnd, nIndex);
        }

        private static int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
                return (int) SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            return (int) (long) SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        public enum WMDefaults
        {
            WM_DRAWITEM = 0x002B,
            WM_REFLECT = 0x2000,
            WM_NCCALCSIZE = 0x83
        }


        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}