using System.Collections.Generic;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IVideosService
    {
        List<VideoDto> Get();
        bool GetNewVideos();
        List<VideoDto> GetVideos(List<string> ids, VideoDto lastVideo);
        VideoDto GetLatestVideoFrom(YoutubeChannelDto channel);

        int AddVideo(VideoDto videoDto);
    }
}