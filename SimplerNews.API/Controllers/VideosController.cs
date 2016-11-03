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
    public class VideosController : ApiController
    {

        private readonly VideosService _videosService;

        public VideosController()
        {
            _videosService = new VideosService();
        }

        // GET: Videos
        [HttpGet]
        [Route("api/Videos")]
        public async Task<IHttpActionResult> Index()
        {
            return Ok(await _videosService.get());
        }

        // GET: Videos
        [HttpGet]
        [Route("api/Videos/new")]
        public async Task<IHttpActionResult> NewVideos()
        {
            var success = await _videosService.getNewVideos();

            return Ok();
        }
    }
}