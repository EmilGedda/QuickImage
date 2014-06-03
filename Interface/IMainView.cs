using System;
using System.Windows.Forms;

namespace QuickImage.Interface
{
	public interface IMainView : IView
	{
		ListView.ListViewItemCollection ImageViewItems { get; }
		ImageList.ImageCollection ThumbList { get; }
		//void PopulateListView(IEnumerable<Printscreen> printscreens);

		string Status { set; }
		string Description { set; }
		string Link { set; }
		string LinkButtonText { set; }

		event KeyEventHandler ImageViewKeyDown;
		event ListViewItemSelectionChangedEventHandler SelectedPrintscreenChanged;
		event EventHandler<EventArgs> ToggleOverlay;
		event EventHandler<EventArgs> OverlayButtonClicked;
		event EventHandler<EventArgs> OptionsButtonClicked;
	}
}