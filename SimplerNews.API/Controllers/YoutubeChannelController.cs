using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessEntities.BusinessModels;
using BusinessServices;
using BusinessServices.Implementation;
using DataModel.GenericRepository;

namespace SimplerNews.API.Controllers
{
    public class YoutubeChannelController : ApiController
    {
        private readonly YoutubeChannelsService _youtubeChannelService;

        public YoutubeChannelController()
        {
            _youtubeChannelService = new YoutubeChannelsService();
        }

        [HttpGet]
        public async Task<List<YoutubeChannel>> Channels()
        {
            return await _youtubeChannelService.GetYoutubeChannels();
        }

        [HttpGet]
        public async Task<YoutubeChannel> Channels(string name)
        {
            return await _youtubeChannelService.GetYoutubeChannel(name);
        }

        [HttpPost]
        [ActionName("Channels")]
        public async Task<Result> ChannelsCreate(YoutubeChannel channel)
        {
            return await _youtubeChannelService.InsertYoutubeChannel(channel);
        }

        [HttpDelete]
        [ActionName("Channels")]
        public async Task<Result> ChannelsDelete(YoutubeChannel channel)
        {
            return await _youtubeChannelService.DeleteYoutubeChannel(channel);
        }
    }
}
