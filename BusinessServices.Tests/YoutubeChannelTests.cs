using System;
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
        public void InsertGetUpdateDelete()
        {
            YoutubeChannelDto dto = new YoutubeChannelDto() { Description = "Test channel", Id = 0, Name = "Test", UploadPlaylistId = "PlaylistId", YoutubeChannelId = "ChannelId" };
            int id = _youtubeChannelsService.InsertYoutubeChannel(dto);

            var addedDto = _youtubeChannelsService.GetYoutubeChannel("Test");

            Assert.AreEqual(dto.YoutubeChannelId, addedDto.YoutubeChannelId);
            Assert.AreEqual(dto.UploadPlaylistId, addedDto.UploadPlaylistId);
            Assert.AreEqual(dto.Description, addedDto.Description);

            addedDto.UploadPlaylistId = "PlaylistId124";
            addedDto.YoutubeChannelId = "ChannelId123";

            var success = _youtubeChannelsService.EdditYoutubeChannel(addedDto.Id, addedDto);

            Assert.IsTrue(success);

            addedDto = _youtubeChannelsService.GetYoutubeChannel("Test");
            Assert.AreEqual("PlaylistId124", addedDto.UploadPlaylistId);
            Assert.AreEqual("ChannelId123", addedDto.YoutubeChannelId);

            success = _youtubeChannelsService.DeleteYoutubeChannel(addedDto.Id);

            Assert.IsTrue(success);

            addedDto = _youtubeChannelsService.GetYoutubeChannel("Test");

            Assert.IsNull(addedDto);


        }
    }
}
