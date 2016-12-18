using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessEntities.APIModels;
using BusinessEntities.BusinessModels;
using BusinessServices;
using BusinessServices.Implementation;
using BusinessServices.Interface;
using DataModel.GenericRepository;
using Microsoft.AspNet.Identity;


namespace SimplerNews.API.Controllers
{
    public class VideoController : ApiController
    {

        private readonly IVideosService _videosService;

        public VideoController()
        {
            _videosService = new VideosService();
        }


        [HttpGet]
        [Route("api/Video/VideosForChanneč")]
        public List<VideoDto> Videos(int youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos)
        {
            return _videosService.GetVideosForChannel(youtubeChannelId, from, to, search, numberOfVideos);
        }


        [HttpGet]
        [Route("api/Video/HotVideos")]
        public List<VideoDto> GetHotVideos(int numberOfVideos)
        {
            return _videosService.GetHotVideos(numberOfVideos);
        }


        [HttpGet]
        [Route("api/Video/PersonalizedVideos")]
        public List<VideoDto> GetPersonalizedVideos(int numberOfVideos)
        {
            var id = User.Identity.GetUserId();
            return _videosService.GetPersonalizedVideos(id, numberOfVideos);
        }

        [HttpPut]
        [Route("api/Video/Insert")]
        public IHttpActionResult InsertVideo(VideoFromService video)
        {
            var result = _videosService.AddVideo(video);

            if (result != 0)
            {
                return Ok(video);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Video/InsertBulk")]
        public IHttpActionResult InsertVideo(List<VideoFromService> videos)
        {
            try
            {
                _videosService.AddBulkVideos(videos);

                return Ok(true);
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }
    }
}