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
        ITestServices testServices;

        public TestController()
        {
            this.testServices = ServicesFactory.GetTestService();
        }

        [HttpGet]
        public List<TestEntity> GetallTestEntities()
        {
            return testServices.GetaAllTestEntities();
        }

        [HttpPost]
        public bool InsertRantomTest()
        {
            testServices.TestService();
            return true;
        }
    }
}
