using System;
using System.Net;
using System.IO;
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
                channel.Details = await getChannelDetails(channel.Name);

                return await _mongoDbRepository.AddOne(channel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<YoutubeChannelDetails> getChannelDetails(string channelName)
        {
            var requestURL = "https://www.googleapis.com/youtube/v3/channels?" +
                   "part=contentDetails&key=AIzaSyBSsdJSTQ3uvLOH1MgN6joX_cxfs4Tmflw" +
                   "&forUsername=" + channelName;

            var request = WebRequest.Create(requestURL);
            var responseStream = request.GetResponse().GetResponseStream();

            using (StreamReader reader = new StreamReader(responseStream))
            {
                var jsonString = reader.ReadToEnd();

                return YoutubeChannelDetails.fromJSON(jsonString);
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
