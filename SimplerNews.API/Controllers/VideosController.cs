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
    public class VideosController : ApiController
    {

        private readonly IVideosService _videosService;

        public VideosController()
        {
            _videosService = new VideosService();
        }

        // GET: Videos
        [HttpGet]
        [Route("api/Videos")]
        public List<VideoDto> Index()
        {
            return _videosService.Get();
        }

        // GET: Videos
        [HttpGet]
        [Route("api/Videos/new")]
        public IHttpActionResult NewVideos()
        {
            var success = _videosService.GetNewVideos();

            return Ok();
        }
    }
}