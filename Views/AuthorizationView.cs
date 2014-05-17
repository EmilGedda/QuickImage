#region

using System.Net;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using QuickImage.Model;

#endregion

namespace QuickImage.Views
{
	public sealed partial class AuthorizationView : Form, IRequestHandler
	{
		public AuthorizationView()
		{
			PIN = "nope";
			var settings = new Settings
			{
				PackLoadingDisabled = true
			};

			InitializeComponent();
			Text = "Application authentication";
			BrowserSettings bs = new BrowserSettings
			{
				DeveloperToolsDisabled = true,
				FullscreenEnabled = false,
				LocalStorageDisabled = true
			};
			if (!CEF.Initialize(settings)) return;
			webView = new WebView(Constants.AuthorizationURL, bs) {Dock = DockStyle.Fill};

			toolStripContainer1.ContentPanel.Controls.Add(webView);
			webView.RequestHandler = this;
		}

		public string PIN { get; set; }

		public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm, string scheme,
			ref string username, ref string password)
		{
			return false;
		}

		public bool GetDownloadHandler(IWebBrowser browser, string mimeType, string fileName, long contentLength,
			ref IDownloadHandler handler)
		{
			return false;
		}

		public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, NavigationType naigationvType, bool isRedirect)
		{
			string url = request.Url;
			string pin = "";
			if (url.Contains("access_denied"))
				Invoke((MethodInvoker) Close);
			if (!url.Contains("pin=")) return false;
			PIN = url.Split('=')[1];
			Invoke((MethodInvoker) Close);
			return false;
		}

		public bool OnBeforeResourceLoad(IWebBrowser browser, IRequestResponse requestResponse)
		{
			return false;
		}

		public void OnResourceResponse(IWebBrowser browser, string url, int status, string statusText, string mimeType,
			WebHeaderCollection headers)
		{
		}
	}
}