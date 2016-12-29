using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Weather;
using BusinessServices;
using BusinessServices.Interface;

namespace SimplerNews.API.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherServices _weatherServices;

        public WeatherController()
        {
            _weatherServices = ServicesFactory.GetWeatherServices();
        }

        public WeatherInformation Get(double latitude, double longitude)
        {
            return _weatherServices.GetCityWeather(latitude, longitude);
        }
    }
}
