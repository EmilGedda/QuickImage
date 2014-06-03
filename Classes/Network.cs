#region

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

#endregion

namespace QuickImage.Model
{
	public sealed class Network : IDisposable
	{
		private static readonly Network instance = new Network();

		private readonly WebClient webClient = new WebClient();

		private Network()
		{
			webClient.Headers.Add(HttpRequestHeader.Authorization, "Client-ID " + Constants.ClientID);
		}

		~Network()
		{
			Dispose();
		}

		public static Network Instance
		{
			get { return instance; }
		}

		public string GETRequest(string url)
		{
			return webClient.DownloadString(url);
		}

		public string POSTRequest(string url, NameValueCollection data)
		{
			return Encoding.UTF8.GetString(webClient.UploadValues(url, data));
		}

		public void Dispose()
		{
			webClient.Dispose();
			GC.SuppressFinalize(this);
		}

	}
}