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
    public class TestController : ApiController
    {
        readonly ITestServices _testServices;

        public TestController()
        {
            this._testServices = ServicesFactory.GetTestServices();
        }

        [HttpGet]
        public List<TestEntity> GetallTestEntities()
        {
            return _testServices.GetaAllTestEntities();
        }

        [HttpPost]
        public bool InsertRantomTest()
        {
            _testServices.TestService();
            return true;
        }
    }
}
