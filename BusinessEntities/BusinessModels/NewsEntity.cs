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

        public String Link{ get; set; }

        public String NewsType { get; set; }
    }
}
