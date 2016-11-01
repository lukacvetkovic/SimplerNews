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

        // GET: YoutubeChannel
        [HttpGet]
        [Route("api/YoutubeChannel")]
        public async Task<IHttpActionResult> Index()
        {
            return Ok(await _youtubeChannelService.GetYoutubeChannels());
        }

        // GET: YoutubeChannel/Details/5
        [HttpGet]
        [Route("api/YoutubeChannel")]
        public async Task<IHttpActionResult> Details(string name)
        {
            var channel = await _youtubeChannelService.GetYoutubeChannel(name);

            if (channel != null)
            {
                return Ok(channel);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: YoutubeChannel/Create
        [HttpPost]
        [Route("api/YoutubeChannel")]
        public async Task<IHttpActionResult> Create(YoutubeChannel channel)
        {
            var result = await _youtubeChannelService.InsertYoutubeChannel(channel);

            if (result.Success)
            {
                return Ok(channel);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: YoutubeChannel/Edit/5
        [HttpPut]
        [Route("api/YoutubeChannel/{id}")]
        public async Task<IHttpActionResult> Edit(string id, YoutubeChannel channel)
        {
            var result = await _youtubeChannelService.EdditYoutubeChannel(id, channel);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: YoutubeChannel/Delete/5
        [HttpDelete]
        [Route("api/YoutubeChannel/{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var result = await _youtubeChannelService.DeleteYoutubeChannel(id);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
