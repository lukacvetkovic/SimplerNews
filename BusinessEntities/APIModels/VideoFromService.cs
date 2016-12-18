using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;

namespace BusinessEntities.APIModels
{
    public class Localized
    {
        public string description { get; set; }
        public string title { get; set; }
    }

    public class Default
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class High
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Maxres
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Medium
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Standard
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Thumbnails
    {
        public Default @default { get; set; }
        public High high { get; set; }
        public Maxres maxres { get; set; }
        public Medium medium { get; set; }
        public Standard standard { get; set; }
    }

    public class Snippet
    {
        public string categoryId { get; set; }
        public string channelId { get; set; }
        public string channelTitle { get; set; }
        public string defaultAudioLanguage { get; set; }
        public string description { get; set; }
        public string liveBroadcastContent { get; set; }
        public Localized localized { get; set; }
        public string publishedAt { get; set; }
        public List<string> tags { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string title { get; set; }
    }

    public class Statistics
    {
        public string commentCount { get; set; }
        public string dislikeCount { get; set; }
        public string favoriteCount { get; set; }
        public string likeCount { get; set; }
        public string viewCount { get; set; }
    }

    public class TopicDetails
    {
        public List<string> relevantTopicIds { get; set; }
    }

    public class Json
    {
        public string etag { get; set; }
        public string id { get; set; }
        public string kind { get; set; }
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }
        public TopicDetails topicDetails { get; set; }
    }

    public class VideoFromService
    {
        public string id { get; set; }
        public Json json { get; set; }

    }


}
