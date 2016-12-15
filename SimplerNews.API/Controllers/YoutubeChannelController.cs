using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessEntities.BusinessModels;
using BusinessServices;
using BusinessServices.Implementation;
using BusinessServices.Interface;
using DataModel.GenericRepository;

namespace SimplerNews.API.Controllers
{
    public class YoutubeChannelController : ApiController
    {

        private readonly IYoutubeChannelsService _youtubeChannelService;

        public YoutubeChannelController()
        {
            _youtubeChannelService = new YoutubeChannelsService();
        }

        // GET: YoutubeChannel
        [HttpGet]
        [Route("api/YoutubeChannel")]
        public List<YoutubeChannelDto> GetYoutubeChannels()
        {
            return _youtubeChannelService.GetYoutubeChannels();
        }


        // GET: YoutubeChannel/Create
        [HttpPost]
        [Route("api/YoutubeChannel/InsertOrUpdate")]
        public IHttpActionResult InsertOrUpdate(YoutubeChannelDto channel)
        {
            var result = _youtubeChannelService.InsertOrUpdateYoutubeChannel(channel);

            if (result != 0)
            {
                return Ok(channel);
            }
            return BadRequest();
        }


        // GET: YoutubeChannel/Create
        [HttpPost]
        [Route("api/YoutubeChannel/InsertOrUpdateBulk")]
        public IHttpActionResult InsertOrUpdateBulk(List<YoutubeChannelDto> channels)
        {
            try
            {
                foreach (var channel in channels)
                {
                    _youtubeChannelService.InsertOrUpdateYoutubeChannel(channel);
                }

                return Ok(true);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        // GET: YoutubeChannel/Delete/5
        [HttpDelete]
        [Route("api/YoutubeChannel/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var result = _youtubeChannelService.DeleteYoutubeChannel(id);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
