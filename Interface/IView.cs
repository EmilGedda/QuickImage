using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
