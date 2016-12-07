using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using System.Web.Script.Serialization;
using AutoMapper;
using BusinessServices.Interface;
using DataModel.SQLDatabase;
using DataModel.UnitOfWork;

namespace BusinessServices.Implementation
{
    public class VideosService : IVideosService
    {

        private readonly UnitOfWork _unitOfWork;

        public VideosService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<VideoDto> Get()
        {
            var videos = _unitOfWork.VideoRepository.GetAll().ToList();

            if (videos.Any())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Video, VideoDto>());

                List<VideoDto> dtoList = Mapper.Map<List<VideoDto>>(videos);

                return dtoList;

            }

            return null;
        }
        public bool GetNewVideos()
        {
            var channels = _unitOfWork.YoutubeChannelRepository.GetAll().ToList();

            Mapper.Initialize(cfg => cfg.CreateMap<YoutubeChannel, YoutubeChannelDto>());

            List<YoutubeChannelDto> channelsDtos = Mapper.Map<List<YoutubeChannelDto>>(channels);

            foreach (YoutubeChannelDto channel in channelsDtos)
            {


                var requestURL = "https://www.googleapis.com/youtube/v3/playlistItems?" +
                  "part=id,contentDetails&key=AIzaSyBSsdJSTQ3uvLOH1MgN6joX_cxfs4Tmflw&maxResults=50" +
                  "&playlistId=" + channel.UploadPlaylistId;

                var request = WebRequest.Create(requestURL);
                var responseStream = request.GetResponse().GetResponseStream();

                if (responseStream != null)
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

                        var videos = GetVideos(videoIds, GetLatestVideoFrom(channel));

                        foreach (var videoDto in videos)
                        {
                            _unitOfWork.VideoRepository.Insert(new Video() { Description = videoDto.Description, PublishedAt = videoDto.PublishedAt, Title = videoDto.Title, YoutubeChannelId = videoDto.YoutubeChannelId, YoutubeChannelTitle = videoDto.YoutubeChannelTitle, YoutubeId = videoDto.YoutubeId });
                        }
                        _unitOfWork.Save();

                    }
            }


            return true;
        }

        public List<VideoDto> GetVideos(List<string> ids, VideoDto lastVideo)
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

                var videos = new List<VideoDto>();

                foreach (Dictionary<string, object> video in videoData)
                {
                    var videoObject = VideoDto.FromJson(video);

                    if (lastVideo == null || lastVideo.PublishedAt < videoObject.PublishedAt)
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

        public VideoDto GetLatestVideoFrom(YoutubeChannelDto channel)
        {

            var video =
                _unitOfWork.VideoRepository.GetMany(p => p.YoutubeChannelId == channel.YoutubeChannelId)
                    .OrderByDescending(q => q.Id)
                    .FirstOrDefault();
            if (video != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Video, VideoDto>());

                VideoDto dto = Mapper.Map<VideoDto>(video);

                return dto;
            }

            return null;

        }

        public int AddVideo(VideoDto videoDto)
        {
            throw new NotImplementedException();
        }
    }
}
