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


        public List<VideoDto> GetNewVideos(int? youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos)
        {
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
                        VideoCategory = new VideoCategoryDto() { Id = video.VideoCategory.Id, YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId, VideoCategoryName = video.VideoCategory.VideoCategoryName },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink
                    };

                    //TODO calculate likes, dislikes,...
                    videoList.Add(videoDto);
                }
            }

            return videoList;
        }

        public List<VideoDto> GetHotVideos(int numberOfVideos)
        {
            List<VideoDto> videoList = new List<VideoDto>();

            var videosFromDb = _unitOfWork.VideoRepository.GetMany(p => p.PublishedAt > DateTime.Now.AddDays(-2)).ToList();
            if (videosFromDb.Any())
            {
                foreach (var video in videosFromDb)
                {
                    VideoDto videoDto = new VideoDto()
                    {
                        YoutubeChannelId = video.YoutubeChannelId,
                        Description = video.Description,
                        VideoCategory = new VideoCategoryDto() { Id = video.VideoCategory.Id, YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId, VideoCategoryName = video.VideoCategory.VideoCategoryName },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink
                    };

                    //TODO calculate likes, dislikes,... and take numberofvideos

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
                        VideoCategory = new VideoCategoryDto() { Id = video.VideoCategory.Id, YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId, VideoCategoryName = video.VideoCategory.VideoCategoryName },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink
                    };

                    //TODO calculate likes, dislikes,...
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
                        VideoCategory = new VideoCategoryDto() { Id = video.VideoCategory.Id, YoutbeVideoCategoryId = video.VideoCategory.YoutbeVideoCategoryId, VideoCategoryName = video.VideoCategory.VideoCategoryName },
                        Id = video.Id,
                        PublishedAt = video.PublishedAt,
                        YoutubeId = video.YoutubeId,
                        Title = video.Title,
                        VideoTagList = video.VideoTag.ToList().Select(p => p.Tag).ToList(),
                        YoutubeLink = video.YoutubeLink
                    };

                    //TODO calculate likes, dislikes,...
                    videoList.Add(videoDto);
                }
            }

            return videoList;
        }

        public int AddVideo(VideoAPIModel videoDto)
        {
            using (var scope = new TransactionScope())
            {
                var video = new Video();

                video.YoutubeChannelId = _unitOfWork.YoutubeChannelRepository.GetSingle(p => p.YoutubeChannelId == videoDto.YoutubeChannelId).Id;
                video.Description = videoDto.Description;
                video.PublishedAt = videoDto.PublishedAt;
                video.Title = videoDto.Title;
                video.VideoCategoryId = _unitOfWork.VideoCategoryRepository.GetSingle(p => p.YoutbeVideoCategoryId == videoDto.VideoCategoryId).Id;
                video.VideoTag = videoDto.VideoTagList.Select(p => new VideoTag() { Tag = p }).ToList();
                video.YoutubeId = videoDto.YoutubeId;
                video.YoutubeLink = videoDto.YoutubeLink;
                ;
                _unitOfWork.VideoRepository.Insert(video);
                _unitOfWork.Save();
                scope.Complete();
                return video.Id;
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

        public void AddBulkVideos(List<VideoAPIModel> videos)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var videoDto in videos)
                {

                    var video = new Video();

                    video.YoutubeChannelId = _unitOfWork.YoutubeChannelRepository.GetSingle(p => p.YoutubeChannelId == videoDto.YoutubeChannelId).Id;
                    video.Description = videoDto.Description;
                    video.PublishedAt = videoDto.PublishedAt;
                    video.Title = videoDto.Title;
                    video.VideoCategoryId = _unitOfWork.VideoCategoryRepository.GetSingle(p => p.YoutbeVideoCategoryId == videoDto.VideoCategoryId).Id;
                    video.VideoTag = videoDto.VideoTagList.Select(p => new VideoTag() { Tag = p }).ToList();
                    video.YoutubeId = videoDto.YoutubeId;
                    video.YoutubeLink = videoDto.YoutubeLink;
                    ;
                    _unitOfWork.VideoRepository.Insert(video);

                }

                _unitOfWork.Save();
                scope.Complete();
            }
        }
    }
}
