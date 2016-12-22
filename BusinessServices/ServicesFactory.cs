using BusinessServices.Implementation;
using BusinessServices.Interface;

namespace BusinessServices
{
    public class ServicesFactory
    {
        public static IVideosService GetVideoServices()
        {
            return new VideosService();
        }

        public static IYoutubeChannelsService GetYoutubeChannelsServices()
        {
            return new YoutubeChannelsService();
        }

        public static IUserServices GetUserServices()
        {
            return new UserServices();
        }


    }
}
