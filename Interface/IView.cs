using System;
using System.Windows.Forms;

namespace QuickImage.Interface
{
	public interface IView
	{
		string Title { set; }
		event EventHandler<EventArgs> Initialize;
		event FormClosedEventHandler ViewClosed;
	}
}
