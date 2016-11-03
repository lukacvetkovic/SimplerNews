using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using BusinessEntities.BusinessModels;
using DataModel.GenericRepository;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BusinessServices.Implementation
{
    public class VideosService
    {

        private readonly IMongoDbRepository _mongoDbRepository;

        public VideosService()
        {
            _mongoDbRepository = new MongoDbRepository();
        }

        public async Task<List<Video>> get()
        {
            return (await _mongoDbRepository.GetAll<Video>()).Entities.ToList();
        }

        public async Task<bool> getNewVideos()
        {
            var channels = await new YoutubeChannelsService().GetYoutubeChannels();

            foreach (YoutubeChannel channel in channels)
            {
                var details = channel.Details;

                if (details != null)
                {
                    var requestURL = "https://www.googleapis.com/youtube/v3/playlistItems?" +
                      "part=id,contentDetails&key=AIzaSyBSsdJSTQ3uvLOH1MgN6joX_cxfs4Tmflw&maxResults=50" +
                      "&playlistId=" + details.UploadPlaylistId;

                    var request = WebRequest.Create(requestURL);
                    var responseStream = request.GetResponse().GetResponseStream();

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        var jsonString = reader.ReadToEnd();

                        var serializer = new JavaScriptSerializer();

                        var data = serializer.Deserialize<Dictionary<string, Object>>(jsonString);

                        var videoData = ((System.Collections.ArrayList)data["items"]);
                        var videoIds = new List<string>();

                        foreach (Dictionary<string, object> video in videoData)
                        {
                            videoIds.Add((string)((Dictionary<string, object>)video["contentDetails"])["videoId"]);
                        }

                        var videos = await getVideos(videoIds, await getLatestVideoFrom(channel));

                        _mongoDbRepository.AddMany<Video>(videos.ToArray());
                    }
                }
            }

           
            return true;
        }

        async Task<List<Video>> getVideos(List<string> ids, Video lastVideo)
        {
            var requestURL = "https://www.googleapis.com/youtube/v3/videos" + 
                "?part=id,recordingDetails,snippet,statistics,topicDetails&key=AIzaSyBSsdJSTQ3uvLOH1MgN6joX_cxfs4Tmflw" +
                "&id=" + string.Join(",", ids);
        
            var request = WebRequest.Create(requestURL);
            var responseStream = request.GetResponse().GetResponseStream();

            using (StreamReader reader = new StreamReader(responseStream))
            {
                var jsonString = reader.ReadToEnd();

                var serializer = new JavaScriptSerializer();

                var data = serializer.Deserialize<Dictionary<string, object>>(jsonString);

                var videoData = (System.Collections.ArrayList)data["items"];

                var videos = new List<Video>();

                foreach (Dictionary<string, object> video in videoData)
                {
                    var videoObject = Video.fromJSON(video);

                    if (lastVideo == null || lastVideo.publishedAt < videoObject.publishedAt)
                    {
                        videos.Add(videoObject);
                    }
                    else
                    {
                        break;
                    }
                }

                return videos;
            }
        }

        async Task<Video> getLatestVideoFrom(YoutubeChannel channel)
        {
            if (channel.Details != null)
            {
                var filter = Builders<Video>.Filter.Where(p => p.youtubeChannelId == channel.Details.YoutubeChannelId);
                var sort = Builders<Video>.Sort.Descending(p => p.publishedAt);

                var video = await _mongoDbRepository.Find(filter, sort);

                return video.Entity;
            } 
            else
            {
                return null;
            }

        }

    }
}
