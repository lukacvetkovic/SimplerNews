using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BusinessEntities.Maps;

namespace BusinessServices.Helpers
{
    public static class ReverseGeoLookup
    {
        private static string DECODERURL = "http://maps.google.com/maps/api/geocode/json?latlng=";
        public static GeocodeResult ReverseGeoLoc(double latitude, double longitude)
        {
            try
            {

                var lat = latitude.ToString().Replace(",", ".");
                var lng = longitude.ToString().Replace(",", ".");
                string url = DECODERURL + lat + "," + lng;
                String response = GetHelper(url);

                GeocodeResult c = JSONHelper.Deserialize<GeocodeResult>(response);

                if (c.status == "OK")
                {
                    return c;
                }

            }
            catch (Exception e)
            {
                throw e;
            }


            return null;

        }


        static string GetHelper(string uri)
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
