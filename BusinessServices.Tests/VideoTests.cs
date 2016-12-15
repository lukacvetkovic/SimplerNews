using System;
using System.Collections;
using System.Collections.Generic;
using BusinessEntities.APIModels;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessServices.Tests
{
    [TestClass]
    public class VideoTests
    {

        private readonly IVideosService _videosServiceService;
        private readonly IYoutubeChannelsService _youtubeChannelsService;

        public VideoTests()
        {
            _videosServiceService = ServicesFactory.GetVideoServices();
            _youtubeChannelsService = ServicesFactory.GetYoutubeChannelsServices();
        }
        [TestMethod]
        public void InsertGetUpdateDeleteVideo()
        {
            string videoName = "Video" + Guid.NewGuid();

            var model = new VideoAPIModel()
            {
                Description = "Test video",
                PublishedAt = DateTime.Now,
                Title = "Test",
                VideoCategoryId = "29",
                VideoTagList = new List<string>() { "Test","Testni"},
                YoutubeChannelId = "Test124",
                YoutubeId = "gtdaghs513",
                YoutubeLink = "www.youtube.com?v=gansdgda",
                Id = -1
            };

            _videosServiceService.AddVideo(model);

            
        }
    }
}
