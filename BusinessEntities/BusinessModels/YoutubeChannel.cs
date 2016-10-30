﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BusinessEntities.BusinessModels
{
    public class YoutubeChannel
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}