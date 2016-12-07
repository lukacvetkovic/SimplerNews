using System;
using System.Collections;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessServices.Tests
{
    [TestClass]
    public class VideoTests
    {

        private readonly IVideosService _videosServiceService;

        public VideoTests()
        {
            _videosServiceService = ServicesFactory.GetVideoServices();
        }
        [TestMethod]
        public void InsertGetUpdateDeleteVideo()
        {
            string videoName = "Video" + Guid.NewGuid();
            VideoDto dto = new VideoDto() { YoutubeChannelId = "TestChannel",Id = 0,Description = "Video about testing",PublishedAt = DateTime.Now,YoutubeId = "YoutubeId",YoutubeChannelTitle = "Test channel",Title = "Test video" };
            _videosServiceService.AddVideo(dto);

            
        }
    }
}
