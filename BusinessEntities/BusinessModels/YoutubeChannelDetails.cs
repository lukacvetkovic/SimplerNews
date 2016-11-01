using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace BusinessEntities.BusinessModels
{
    public class YoutubeChannelDetails
    {
        public string YoutubeChannelId { get; set; }

        public string UploadPlaylistId { get; set; }


        public static YoutubeChannelDetails fromJSON(string json)
        {
            var serializer = new JavaScriptSerializer();

            var data = serializer.Deserialize<Dictionary<string, Object>>(json);

            var items = (Dictionary<string, object>)((System.Collections.ArrayList)data["items"])[0];

            string id = (string)items["id"];
            string uploadPlaylistId = (string)((Dictionary<string, object>)((Dictionary<string, object>)items["contentDetails"])["relatedPlaylists"])["uploads"];

            return new YoutubeChannelDetails() {
                YoutubeChannelId = id,
                UploadPlaylistId = uploadPlaylistId
            };
        }

    }
}
