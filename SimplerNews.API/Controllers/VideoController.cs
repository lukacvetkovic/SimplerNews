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
            _videosService = ServicesFactory.GetVideoServices();
        }


        [HttpGet]
        [Route("api/Video/HotVideos")]
        public List<VideoDto> GetHotVideos(int numberOfVideos, string token)
        {
            return _videosService.GetHotVideos(numberOfVideos,token);
        }


        [HttpGet]
        [Route("api/Video/PersonalizedVideos")]
        public List<VideoDto> GetPersonalizedVideos(int numberOfVideos, string token)
        {
            return _videosService.GetPersonalizedVideos(token, numberOfVideos);
        }

        //[HttpGet]
        //[Route("api/Video/GetVidesByCategory")]
        //public List<VideoDto> GetVidesByCategory(int categoryId, int numberOfVideos)
        //{
        //    return _videosService.GetVidesByCategory(categoryId, numberOfVideos);
        //}

        //[HttpGet]
        //[Route("api/Video/VideosForChannel")]
        //public List<VideoDto> Videos(int youtubeChannelId, DateTime from, DateTime to, string search, int numberOfVideos)
        //{
        //    return _videosService.GetVideosForChannel(youtubeChannelId, from, to, search, numberOfVideos);
        //}

        [HttpPut]
        [Route("api/Video/Insert")]
        public IHttpActionResult InsertVideo(VideoFromService video)
        {
            var result = _videosService.AddVideo(video);

            if (result != 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/Video/InsertBulk")]
        public IHttpActionResult InsertVideo(List<VideoFromService> videos)
        {
            if (videos == null)
            {
                throw new ArgumentException("VIDEOS ARE NULL");
            }
            try
            {
                _videosService.AddBulkVideos(videos);

                return Ok(true);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}