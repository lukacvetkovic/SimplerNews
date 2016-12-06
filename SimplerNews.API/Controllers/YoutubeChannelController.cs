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
        public IHttpActionResult Index()
        {
            return Ok(_youtubeChannelService.GetYoutubeChannels());
        }

        // GET: YoutubeChannel/Details/5
        [HttpGet]
        [Route("api/YoutubeChannel")]
        public IHttpActionResult Details(string name)
        {
            var channel = _youtubeChannelService.GetYoutubeChannel(name);

            if (channel != null)
            {
                return Ok(channel);
            }
            return BadRequest();
        }

        // GET: YoutubeChannel/Create
        [HttpPost]
        [Route("api/YoutubeChannel")]
        public IHttpActionResult Create(YoutubeChannelDto channel)
        {
            var result = _youtubeChannelService.InsertYoutubeChannel(channel);

            if (result != 0)
            {
                return Ok(channel);
            }
            return BadRequest();
        }

        // GET: YoutubeChannel/Edit/5
        [HttpPut]
        [Route("api/YoutubeChannel/{id}")]
        public IHttpActionResult Edit(int id, YoutubeChannelDto channel)
        {
            var result = _youtubeChannelService.EdditYoutubeChannel(id, channel);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
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
