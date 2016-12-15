using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.APIModels
{
    public class VideoAPIModel
    {
        public int Id { get; set; }
        public string YoutubeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string YoutubeChannelId { get; set; }
        public System.DateTime PublishedAt { get; set; }
        public string YoutubeLink { get; set; }
        public string VideoCategoryId { get; set; }
        public List<String> VideoTagList { get; set; }
    }
}
