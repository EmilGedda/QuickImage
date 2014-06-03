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
