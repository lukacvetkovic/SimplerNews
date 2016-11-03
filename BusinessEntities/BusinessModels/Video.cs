using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace BusinessEntities.BusinessModels
{
    public class Video
    {
        public ObjectId _id { get; set; }

        public string youtubeId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string youtubeChannelId { get; set; }

        public string youtubeChannelTitle { get; set; }

        public DateTime publishedAt { get; set; }

        public System.Collections.ArrayList tags { get; set; }

        public static Video fromJSON(Dictionary<string, object> data)
        {
            return new Video()
            {
                youtubeId = (string)data["id"],
                title = (string)((Dictionary<string, object>)data["snippet"])["title"],
                description = (string)((Dictionary<string, object>)data["snippet"])["description"],
                youtubeChannelId = (string)((Dictionary<string, object>)data["snippet"])["channelId"],
                youtubeChannelTitle = (string)((Dictionary<string, object>)data["snippet"])["channelTitle"],
                publishedAt = Convert.ToDateTime((string)((Dictionary<string, object>)data["snippet"])["publishedAt"]),
                tags = (System.Collections.ArrayList)((Dictionary<string, object>)data["snippet"])["tags"]
            };
        }

    }
}
