using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public bool InsertNews(NewsEntity news)
        {
            _newsServices.InsertNews(news);
            return true;
        }
    }
}
