using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.BusinessModels
{
    public class UserInformationDto
    {
        public string id { get; set; }
        public string accessToken { get; set; }
        public string email { get; set; }
        public FacebookJSON facebookJSON { get; set; }
        public GoogleJSON googleJSON { get; set; }
        public TwitterJSON twitterJSON { get; set; }
    }

    public class Like
    {
        public string about { get; set; }
        public string category { get; set; }
        public string id { get; set; }
        public string liked_date { get; set; }
        public string description { get; set; }
    }

    public class FacebookJSON
    {
        public string access_token { get; set; }
        public string facebook_id { get; set; }
        public string gender { get; set; }
        public List<Like> likes { get; set; }
        public string name { get; set; }
    }

    public class TwitterJSON
    {
        public string access_token { get; set; }
        public string email { get; set; }
    }

    public class GoogleJSON
    {

    }
}
