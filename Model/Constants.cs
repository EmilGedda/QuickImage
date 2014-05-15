namespace QuickImage.Model
{
	internal static class Constants
	{
		public const string ClientID = "35a7b2109bdca19";
		public const string ClientSecret = "c35b957886b3d77f9ab4f4658ceb35fe44cdb5e1";
		public const string Authorization = "Authorization: " + ClientID + " " + ClientSecret;

		public const string AuthorizationURL =
			"https://api.imgur.com/oauth2/authorize?client_id=" + ClientID + "&response_type=pin";

		public const string UploadImageURL = "https://api.imgur.com/3/upload";
		public const string TokenRefreshURL = "https://api.imgur.com/oauth2/token";
	}
}