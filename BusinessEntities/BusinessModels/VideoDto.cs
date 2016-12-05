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
    public class VideoDto
    {
        public int Id { get; set; }

        public string YoutubeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string YoutubeChannelId { get; set; }

        public string YoutubeChannelTitle { get; set; }

        public DateTime PublishedAt { get; set; }

        public System.Collections.ArrayList Tags { get; set; }

        public static VideoDto FromJson(Dictionary<string, object> data)
        {
            return new VideoDto()
            {
                YoutubeId = (string)data["id"],
                Title = (string)((Dictionary<string, object>)data["snippet"])["title"],
                Description = (string)((Dictionary<string, object>)data["snippet"])["description"],
                YoutubeChannelId = (string)((Dictionary<string, object>)data["snippet"])["channelId"],
                YoutubeChannelTitle = (string)((Dictionary<string, object>)data["snippet"])["channelTitle"],
                PublishedAt = Convert.ToDateTime((string)((Dictionary<string, object>)data["snippet"])["publishedAt"]),
                Tags = (System.Collections.ArrayList)((Dictionary<string, object>)data["snippet"])["tags"]
            };
        }

    }
}
