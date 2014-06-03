#region

using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace QuickImage.Model
{
	[Serializable]
	public class Imgur
	{
		private string deleteHash;
		private string id;
		private string link;
		private int views;

		private Imgur()
		{
		}

		[JsonProperty("id")]
		public string ID
		{
			get { return id; }
			private set { id = value; }
		}

		[JsonProperty("deletehash")]
		public string DeleteHash
		{
			get { return deleteHash; }
			private set { deleteHash = value; }
		}

		[JsonProperty("link")]
		public string Link
		{
			get { return link; }
			private set { link = value; }
		}

		[JsonProperty("views")]
		public int Views
		{
			get { return views; }
			private set { views = value; }
		}

		public static Imgur Upload(string path)
		{
			var uploadCollection = new NameValueCollection
			{
				{"image", Convert.ToBase64String(File.ReadAllBytes(path))}
			};
			string response = Network.Instance.POSTRequest(Constants.UploadImageURL, uploadCollection);

			JObject first = JObject.Parse(response);
			return JsonConvert.DeserializeObject<Imgur>(first["data"].ToString());
		}
	}
}