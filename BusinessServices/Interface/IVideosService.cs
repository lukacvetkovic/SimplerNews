using System;
using System.Collections.Generic;
using BusinessEntities.APIModels;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IVideosService
    {
        //List<VideoDto> GetVideosForChannel(int youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos);
        List<VideoDto> GetHotVideos(int numberOfVideos, string token);
        List<VideoDto> GetPersonalizedVideos(string token, int numberOfVideos);
        //List<VideoDto> GetVidesByCategory(int categoryId, int numberOfVideos);

        int AddVideo(VideoFromService videoDto);
        bool RemoveVideo(int videoId);
        void AddBulkVideos(List<VideoFromService> videos);
    }
}