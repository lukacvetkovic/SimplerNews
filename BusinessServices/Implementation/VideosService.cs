using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using BusinessEntities.BusinessModels;
using System.Web.Script.Serialization;
using AutoMapper;
using BusinessEntities.APIModels;
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


        public List<VideoDto> GetVideosForChannel(int youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos)
        {
            List<VideoDto> videoList = new List<VideoDto>();

            if (youtubeChannelId <= 0)
            {
                return videoList;
            }

            var videosFromDb =
                    _unitOfWork.VideoRepository.GetAll()
                        .Where(v => v.YoutubeChannelId == youtubeChannelId && v.PublishedAt >= from && v.PublishedAt <= to)
                        .Where(q => q.Description.Contains(search) || q.Title.Contains(search) || q.VideoTag.Count(x => x.Tag.Contains(search)) > 0)
                        .OrderByDescending(p => p.PublishedAt)
                        .Take(numberOfVideos)
                        .ToList();

            if (videosFromDb.Any())
            {
                foreach (var video in videosFromDb)
                {
                    VideoDto videoDto = new VideoDto()
                    {
                        YoutubeChannelId = video.YoutubeChannelId,
                        Description = video.Description,
                        VideoCategory =
                            new VideoCategoryDto()
                            {
                                Id = video.VideoCategory.Id,
                                YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId,
                                VideoCategoryName = video.VideoCategory.VideoCategoryName
                            },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink,
                        NumberOfDislikes = video.NumberOfDislikes ?? 0,
                        NumberOfViews = video.NumberOfViews ?? 0,
                        NumberOfLikes = video.NumberOfLikes ?? 0,
                        Etag = video.Etag,
                        NumberOfComments = video.NumberOfComments ?? 0,
                        Kind = video.Kind
                    };

                    videoList.Add(videoDto);
                }

            }

            return videoList;
        }

        public List<VideoDto> GetHotVideos(int numberOfVideos)
        {
            List<VideoDto> videoList = new List<VideoDto>();

            var videosFromDb = _unitOfWork.VideoRepository.GetMany(p => p.PublishedAt > DateTime.Now.AddDays(-2)).ToList().Take(numberOfVideos);
            if (videosFromDb.Any())
            {
                foreach (var video in videosFromDb)
                {
                    VideoDto videoDto = new VideoDto()
                    {
                        YoutubeChannelId = video.YoutubeChannelId,
                        Description = video.Description,
                        VideoCategory =
                            new VideoCategoryDto()
                            {
                                Id = video.VideoCategory.Id,
                                YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId,
                                VideoCategoryName = video.VideoCategory.VideoCategoryName
                            },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink,
                        NumberOfDislikes = video.NumberOfDislikes ?? 0,
                        NumberOfViews = video.NumberOfViews ?? 0,
                        NumberOfLikes = video.NumberOfLikes ?? 0,
                        Etag = video.Etag,
                        NumberOfComments = video.NumberOfComments ?? 0,
                        Kind = video.Kind
                    };


                    videoList.Add(videoDto);
                }
            }

            return videoList.OrderByDescending(p => p.NumberOfViews).ToList();
        }

        public List<VideoDto> GetPersonalizedVideos(string aspNetUserId, int numberOfVideos)
        {

            //TODO treba pamet stavit
            List<VideoDto> videoList = new List<VideoDto>();

            var videosFromDb = _unitOfWork.VideoRepository.GetAll().OrderByDescending(p => p.PublishedAt).Take(numberOfVideos).ToList();
            if (videosFromDb.Any())
            {
                foreach (var video in videosFromDb)
                {
                    VideoDto videoDto = new VideoDto()
                    {
                        YoutubeChannelId = video.YoutubeChannelId,
                        Description = video.Description,
                        VideoCategory =
                            new VideoCategoryDto()
                            {
                                Id = video.VideoCategory.Id,
                                YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId,
                                VideoCategoryName = video.VideoCategory.VideoCategoryName
                            },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink,
                        NumberOfDislikes = video.NumberOfDislikes ?? 0,
                        NumberOfViews = video.NumberOfViews ?? 0,
                        NumberOfLikes = video.NumberOfLikes ?? 0,
                        Etag = video.Etag,
                        NumberOfComments = video.NumberOfComments ?? 0,
                        Kind = video.Kind
                    };

                    videoList.Add(videoDto);
                }
            }

            return videoList;
        }

        public List<VideoDto> GetVidesByCategory(int categoryId, int numberOfVideos)
        {
            List<VideoDto> videoList = new List<VideoDto>();

            var videosFromDb = _unitOfWork.VideoRepository.GetMany(p => p.VideoCategoryId == categoryId).OrderByDescending(p => p.PublishedAt).Take(numberOfVideos).ToList();
            if (videosFromDb.Any())
            {
                foreach (var video in videosFromDb)
                {
                    VideoDto videoDto = new VideoDto()
                    {
                        YoutubeChannelId = video.YoutubeChannelId,
                        Description = video.Description,
                        VideoCategory =
                            new VideoCategoryDto()
                            {
                                Id = video.VideoCategory.Id,
                                YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId,
                                VideoCategoryName = video.VideoCategory.VideoCategoryName
                            },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink,
                        NumberOfDislikes = video.NumberOfDislikes ?? 0,
                        NumberOfViews = video.NumberOfViews ?? 0,
                        NumberOfLikes = video.NumberOfLikes ?? 0,
                        Etag = video.Etag,
                        NumberOfComments = video.NumberOfComments ?? 0,
                        Kind = video.Kind
                    };

                    videoList.Add(videoDto);
                }
            }

            return videoList;
        }

        public int AddVideo(VideoFromService videoDto)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var channel = _unitOfWork.YoutubeChannelRepository.GetFirst(
                        p => p.YoutubeChannelId == videoDto.json.snippet.channelId);

                    var category = _unitOfWork.VideoCategoryRepository.GetFirst(
                                p => p.YoutbeVideoCategoryId == videoDto.json.snippet.categoryId);
                    if (channel == null || category == null)
                    {
                        scope.Complete();
                        return -1;
                    }

                    var video = new Video
                    {
                        YoutubeChannelId = channel.Id,
                        Description = videoDto.json.snippet.description,
                        PublishedAt = DateTime.Parse(videoDto.json.snippet.publishedAt),
                        Title = videoDto.json.snippet.title,
                        VideoCategoryId = category.Id,
                        VideoTag = videoDto.json.snippet?.tags.Select(p => new VideoTag() { Tag = p }).ToList(),
                        YoutubeId = videoDto.json.id,
                        YoutubeLink = null,
                        NumberOfDislikes = Convert.ToInt32(videoDto.json?.statistics?.dislikeCount),
                        Etag = videoDto.json.etag,
                        Id = -1,
                        NumberOfViews = Convert.ToInt32(videoDto.json?.statistics?.viewCount),
                        NumberOfLikes = Convert.ToInt32(videoDto.json?.statistics?.likeCount),
                        Kind = videoDto.json.kind,
                        NumberOfComments = Convert.ToInt32(videoDto.json?.statistics?.commentCount)
                    };

                    _unitOfWork.VideoRepository.Insert(video);
                    _unitOfWork.Save();
                    scope.Complete();
                    return video.Id;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public bool RemoveVideo(int videoId)
        {
            var success = false;
            if (videoId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var video = _unitOfWork.VideoRepository.GetByID(videoId);
                    if (video != null)
                    {

                        _unitOfWork.VideoRepository.Delete(video);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public void AddBulkVideos(List<VideoFromService> videos)
        {

            foreach (var videoDto in videos)
            {
                try
                {
                    AddVideo(videoDto);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
