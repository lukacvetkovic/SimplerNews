using System.Collections.Generic;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IYoutubeChannelsService
    {
        List<YoutubeChannelDto> GetYoutubeChannels();
        //YoutubeChannelDto GetYoutubeChannel(int youtubeChannelId);
        int InsertOrUpdateYoutubeChannel(YoutubeChannelDto channelDto);
        bool DeleteYoutubeChannel(int youtubeChannelId);
    }
}