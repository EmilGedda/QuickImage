using System;

namespace QuickImage
{
    [Serializable]
    public class Imgur
    {
        public string ID { get; private set; }
        public string DeleteLink { get; private set; }
        public string Link { get; private set; }

        private Imgur(string id, string deletelink, string link)
        {
            ID = id;
            DeleteLink = deletelink;
            Link = link;
        }

        public static Imgur Upload(string path)
        {
             /// TODO: Add http-logic
            return new Imgur("", "", "");
        }
    }

}
