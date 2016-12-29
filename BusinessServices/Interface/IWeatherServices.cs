using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Weather;

namespace BusinessServices.Interface
{
    public interface IWeatherServices
    {
        WeatherInformation GetCityWeather(double latitude, double longitude);
    }
}
