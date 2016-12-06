using System.Collections.Generic;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IYoutubeChannelsService
    {
        List<YoutubeChannelDto> GetYoutubeChannels();
        YoutubeChannelDto GetYoutubeChannel(string name);
        int InsertYoutubeChannel(YoutubeChannelDto channelDto);
        YoutubeChannelDetails GetChannelDetails(string channelName);
        bool EdditYoutubeChannel(int id, YoutubeChannelDto channelDto);
        bool DeleteYoutubeChannel(int channelId);
    }
}