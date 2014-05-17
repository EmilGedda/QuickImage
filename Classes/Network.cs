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
		private static Network _instance;

		private readonly WebClient webClient = new WebClient();

		private Network()
		{
			webClient.Headers.Add(HttpRequestHeader.Authorization, "Client-ID " + Constants.ClientID);
			_instance = this;
		}

		~Network()
		{
			Dispose();
		}

		public static Network Instance
		{
			get { return _instance ?? new Network(); }
		}

		public bool TryGETRequest(string url, out string response)
		{
			response = "";
			bool success = true;
			try
			{
				response = webClient.DownloadString(url);
			}
			catch (Exception e)
			{
				success = false;
			}
			return success;
		}

		public bool TryPOSTRequest(string url, NameValueCollection data, out string response)
		{
			response = "";
			bool success = true;
			try
			{
				response = Encoding.UTF8.GetString(webClient.UploadValues(url, data));
			}
			catch (Exception e)
			{
				success = false;
			}
			return success;
		}

		public void Dispose()
		{
			webClient.Dispose();
			GC.SuppressFinalize(this);
		}

	}
}