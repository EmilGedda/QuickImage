using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickImage.Interface
{
	interface IAuthorizationView : IView
	{
		void Invoke(MethodInvoker method);
		void Close();
		void ShowDialog();
	}
}
