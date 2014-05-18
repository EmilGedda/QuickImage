using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using QuickImage.Interface;
using QuickImage.Views;

namespace QuickImage.Presenter
{
	class AuthorizationPresenter : IRequestHandler
	{
		private readonly IAuthorizationView view;
		private string pin;
		public AuthorizationPresenter()
		{
			view = new AuthorizationView(this);
		}

		public string GetPIN()
		{
			view.ShowDialog();
			return pin;
		}

		public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, NavigationType naigationvType, bool isRedirect)
		{
			string url = request.Url;
			if (url.Contains("access_denied"))
				view.Invoke(view.Close);
			if (!url.Contains("pin=")) return false;
			pin = url.Split('=')[1];
			view.Invoke(view.Close);
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

		public bool GetDownloadHandler(IWebBrowser browser, string mimeType, string fileName, long contentLength,
			ref IDownloadHandler handler)
		{
			return false;
		}

		public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm, string scheme,
			ref string username, ref string password)
		{
			return false;
		}
	}
}
