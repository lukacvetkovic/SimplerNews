using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BusinessEntities.BusinessModels
{
    public class NewsEntity
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoLink { get; set; }

        public string[] Categories { get; set; }

        public double Rating { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfLikes { get; set; }

        public int NumberOfDislikes { get; set; }

        public DateTime DateOfPublish { get; set; }

        public DateTime Created { get; set; }
    }
}
