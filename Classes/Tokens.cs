#region

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using Newtonsoft.Json;

#endregion

namespace QuickImage.Model
{
	[Serializable]
	public class Tokens
	{
		private string accessToken;
		private DateTime expirationDate;
		private string refreshToken;

		public string AccessToken
		{
			get
			{
				if (hasExpired)
					RefreshTokens();
				return accessToken;
			}
			set { accessToken = value; }
		}

		private bool hasExpired
		{
			get { return expirationDate < DateTime.Now; }
		}

		private void RefreshTokens()
		{
			NameValueCollection uploadCollection = new NameValueCollection
			{
				{"refresh_token", refreshToken},
				{"client_id", Constants.ClientID},
				{"client_secret", Constants.ClientSecret},
				{"grant_type", "refresh_token"}
			};

			string response;

			Network.Instance.TryPOSTRequest(Constants.TokenRefreshURL, uploadCollection, out response);
			
				MessageBox.Show("Unable to refresh your account tokens!");
			Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
			expirationDate = DateTime.Now.AddSeconds(Convert.ToInt32(data["expires_in"]));
			AccessToken = (string) data["access_token"];
			refreshToken = (string) data["refresh_ token"];
		}
	}
}