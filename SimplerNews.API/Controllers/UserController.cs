using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.BusinessModels;
using BusinessServices;
using BusinessServices.Implementation;
using BusinessServices.Interface;

namespace SimplerNews.API.Controllers
{
    public class UserController : ApiController
    {

        private readonly IUserServices _userServices;

        public UserController()
        {
            _userServices = ServicesFactory.GetUserServices();
        }

        [HttpPost]
        [Route("api/User/Login")]
        public bool Login(UserDto user)
        {
            return _userServices.InsertOrUpdateUser(user);
        }

        [HttpPost]
        [Route("api/User/UpdateInfo")]
        public bool UpdateInfo(UserInformationDto userInfo)
        {
            return _userServices.UpdateUserPreferences(userInfo);
        }
    }
}
