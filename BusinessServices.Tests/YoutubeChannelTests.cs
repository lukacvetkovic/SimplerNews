using System;
using System.Linq;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessServices.Tests
{
    [TestClass]
    public class YoutubeChannelTests
    {
        private readonly IYoutubeChannelsService _youtubeChannelsService;

        public YoutubeChannelTests()
        {
            _youtubeChannelsService = ServicesFactory.GetYoutubeChannelsServices();
        }

        [TestMethod]
        public void InsertGetUpdateDeleteChannel()
        {
            string testName = "Test";
            YoutubeChannelDto dto = new YoutubeChannelDto() { Description = "Test channel", Id = 0, Name = testName, UploadPlaylistId = "PlaylistId", YoutubeChannelId = "ChannelId" };
            int id = _youtubeChannelsService.InsertOrUpdateYoutubeChannel(dto);

            var addedDto = _youtubeChannelsService.GetYoutubeChannels().SingleOrDefault(p => p.YoutubeChannelId == dto.YoutubeChannelId);

            Assert.AreEqual(dto.YoutubeChannelId, addedDto.YoutubeChannelId);
            Assert.AreEqual(dto.UploadPlaylistId, addedDto.UploadPlaylistId);
            Assert.AreEqual(dto.Description, addedDto.Description);

            addedDto.UploadPlaylistId = "PlaylistId124";

            _youtubeChannelsService.InsertOrUpdateYoutubeChannel(addedDto);

            addedDto = _youtubeChannelsService.GetYoutubeChannels().SingleOrDefault(p => p.YoutubeChannelId == dto.YoutubeChannelId);
            Assert.AreEqual("PlaylistId124", addedDto.UploadPlaylistId);

            var success = _youtubeChannelsService.DeleteYoutubeChannel(addedDto.Id);

            Assert.IsTrue(success);

            addedDto = _youtubeChannelsService.GetYoutubeChannels().SingleOrDefault(p => p.YoutubeChannelId == dto.YoutubeChannelId);

            Assert.IsNull(addedDto);


        }
    }
}
