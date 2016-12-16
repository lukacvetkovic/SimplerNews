using System;
using System.Collections.Generic;
using BusinessEntities.APIModels;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IVideosService
    {
        List<VideoDto> GetNewVideos(int? youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos);
        List<VideoDto> GetHotVideos(int numberOfVideos);
        List<VideoDto> GetPersonalizedVideos(string aspNetUserId, int numberOfVideos);
        List<VideoDto> GetVidesByCategory(int categoryId, int numberOfVideos);

        int AddVideo(VideoAPIModel videoDto);
        bool RemoveVideo(int videoId);
        void AddBulkVideos(List<VideoAPIModel> videos);
    }
}