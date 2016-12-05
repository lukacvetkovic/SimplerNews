using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BusinessEntities.BusinessModels
{
    public class YoutubeChannelDetails
    {
        public string YoutubeChannelId { get; set; }

        public string UploadPlaylistId { get; set; }


        public static YoutubeChannelDetails FromJson(string json)
        {
            var serializer = new JavaScriptSerializer();

            var data = serializer.Deserialize<Dictionary<string, Object>>(json);

            var items = (System.Collections.ArrayList)data["items"];

            foreach (Dictionary<string, object> item in items)
            {
                if ((string)item["kind"] == "youtube#channel")
                {
                    string id = (string)item["id"];
                    string uploadPlaylistId = (string)((Dictionary<string, object>)((Dictionary<string, object>)item["contentDetails"])["relatedPlaylists"])["uploads"];

                    return new YoutubeChannelDetails()
                    {
                        YoutubeChannelId = id,
                        UploadPlaylistId = uploadPlaylistId
                    };
                }
            }

            return null;
        }
    }
}
