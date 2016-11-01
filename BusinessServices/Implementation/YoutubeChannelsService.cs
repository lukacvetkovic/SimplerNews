using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using DataModel.GenericRepository;
using DataModel.NoSQLDatabase;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BusinessServices.Implementation
{
    public class YoutubeChannelsService
    {

        private readonly IMongoDbRepository _mongoDbRepository;

        public YoutubeChannelsService()
        {
            _mongoDbRepository = new MongoDbRepository();
        }

        public async Task<List<YoutubeChannel>> GetYoutubeChannels()
        {
            try
            {
                var result = await _mongoDbRepository.GetAll<YoutubeChannel>();

                return result.Entities.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string name)
        {
            try
            {
                var filter = Builders<YoutubeChannel>.Filter.Where(p => p.Name == name);
                var result = await _mongoDbRepository.GetOne<YoutubeChannel> (filter);

                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> InsertYoutubeChannel(YoutubeChannel channel)
        {
            try
            {
                return await _mongoDbRepository.AddOne(channel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> EdditYoutubeChannel(string id, YoutubeChannel channel)
        {
            try
            {
                var filter = Builders<YoutubeChannel>.Filter.Where(p => p._id == ObjectId.Parse(id));

                return await _mongoDbRepository.Replace(filter, channel);
            }
            catch (Exception)
            {
                throw;
            }
        }
            
        public async Task<Result> DeleteYoutubeChannel(string id)
        {
            try
            {
                var filter = Builders<YoutubeChannel>.Filter.Where(p => p._id == ObjectId.Parse(id));
                return await _mongoDbRepository.DeleteOne<YoutubeChannel>(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
