using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BusinessEntities.BusinessModels
{
    public class YoutubeChannelDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string YoutubeChannelId { get; set; }

        public string UploadPlaylistId { get; set; }

    }
}
