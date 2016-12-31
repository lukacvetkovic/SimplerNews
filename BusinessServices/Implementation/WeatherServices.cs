using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Weather;
using BusinessServices.Helpers;
using BusinessServices.Interface;

namespace BusinessServices.Implementation
{
    public class WeatherServices : IWeatherServices
    {
        public OpenWeatherMapResult GetCityWeather(double latitude, double longitude)
        {
            return OpenWeatherMapHelper.GetWeatherInformationForLocation(latitude, longitude);
        }
    }
}
