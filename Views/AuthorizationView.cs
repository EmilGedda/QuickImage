#region

using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using QuickImage.Interface;
using QuickImage.Model;

#endregion

namespace QuickImage.Views
{
	public sealed partial class AuthorizationView : Form, IAuthorizationView
	{

		public AuthorizationView(IRequestHandler requestHandler)
		{
			using (var settings = new Settings{ PackLoadingDisabled = true})
				if (!CEF.Initialize(settings)) return;

			InitializeComponent();
			BrowserSettings bs = new BrowserSettings
			{
				DeveloperToolsDisabled = true,
				FullscreenEnabled = false,
				LocalStorageDisabled = true
			};

			webView = new WebView(Constants.AuthorizationURL, bs) { Dock = DockStyle.Fill };

			toolStripContainer1.ContentPanel.Controls.Add(webView);
			webView.RequestHandler = requestHandler;
		}

		public string Title
		{
			set { Text = value; }
		}

		public event EventHandler<EventArgs> Initialize;
		public event FormClosedEventHandler ViewClosed;
		public void Invoke(MethodInvoker method)
		{
			base.Invoke(method);
		}

		public new void ShowDialog()
		{
			base.ShowDialog();
		}
	}
}