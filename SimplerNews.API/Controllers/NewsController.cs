using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessEntities.BusinessModels;
using BusinessServices;
using BusinessServices.Interface;

namespace SimplerNews.API.Controllers
{
    public class NewsController : ApiController
    {
        private readonly INewsServices _newsServices;

        public NewsController()
        {
            _newsServices = ServicesFactory.GetNewsServices();
        }

        [HttpPost]
        public async Task<bool> InsertNews(NewsEntity news)
        {
            return await _newsServices.InsertNews(news);

        }

        [HttpPost]
        public async Task<bool> InsertNewsList(NewsEntity[] newsList)
        {
            return await _newsServices.InsertNewsList(newsList);

        }


        [HttpGet]
        public async Task<List<NewsEntity>> GetAllNews()
        {
            return await _newsServices.GetAllNews();
        }
    }
}
