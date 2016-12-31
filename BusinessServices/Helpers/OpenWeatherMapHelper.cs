using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Weather;

namespace BusinessServices.Helpers
{
    public static class OpenWeatherMapHelper
    {
        private static string DECODERURLStart = "http://api.openweathermap.org/data/2.5/forecast?q=";
         private static string DECODERURLEnd = "London&mode=xml%20&units=imperial&APPID=001a504dd76363d1cd6c69c26a28fb84";
        public static OpenWeatherMapResult GetWeatherInformationForLocation(double latitude, double longitude)
        {

            var geolocation = ReverseGeoLookup.ReverseGeoLoc(latitude, longitude);
            System.Threading.Thread.Sleep(3000);
            String response = GetHelper(DECODERURLStart + geolocation.results[0].formatted_address + DECODERURLEnd);

            OpenWeatherMapResult result = JSONHelper.Deserialize<OpenWeatherMapResult>(response);

            return result;
        }

        private static string GetHelper(string uri)
        {
            using (WebResponse wr = WebRequest.Create(uri).GetResponse())
            {
                using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
