using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using BusinessEntities.Enums;
using BusinessServices.Interface;
using DataModel.NoSQLDatabase;

namespace BusinessServices.Implementation
{
    public class NewsServices : INewsServices
    {
        private readonly MongoDbHelper _mongoDbHelper;

        public NewsServices()
        {
            _mongoDbHelper=MongoDbHelper.GetInstanceInstance;
        }
        public async void InsertNews(NewsEntity news)
        {
            await _mongoDbHelper.InsertData(news,MongoCollections.News);
        }
    }
}
