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
        public string Etag { get; set; }
        public string Kind { get; set; }
        public string YoutubeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YoutubeChannelId { get; set; }
        public System.DateTime PublishedAt { get; set; }
        public string YoutubeLink { get; set; }
        public int NumberOfViews { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public int NumberOfComments { get; set; }
        public VideoCategoryDto VideoCategory { get; set; }
        public List<String> VideoTagList { get; set; }

    }
}
