using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using BusinessEntities.Enums;
using BusinessServices.Interface;
using DataModel.GenericRepository;
using DataModel.NoSQLDatabase;

namespace BusinessServices.Implementation
{
    public class NewsServices : INewsServices
    {
        private readonly IMongoDbRepository _mongoDbRepository;

        public NewsServices()
        {
            _mongoDbRepository = new MongoDbRepository();
        }
        public async Task<bool> InsertNews(NewsEntity news)
        {
            try
            {
                news.Created = DateTime.Now;
                await _mongoDbRepository.AddOne(news);
            }
            catch (Exception)
            {

                throw;
            }

            return true;

        }

        public async Task<bool> InsertNewsList(NewsEntity[] newsList)
        {
            try
            {
                foreach (var newsEntity in newsList)
                {
                    newsEntity.Created = DateTime.Now;
                }
                await _mongoDbRepository.AddMany(newsList);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<List<NewsEntity>> GetAllNews()
        {
            try
            {
                var result = await _mongoDbRepository.GetAll<NewsEntity>();

                return result.Entities.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
