using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using DataModel.SQLDatabase;
using DataModel.UnitOfWork;



namespace BusinessServices.Implementation
{
    public class YoutubeChannelsService : IYoutubeChannelsService
    {

        private readonly UnitOfWork _unitOfWork;

        public YoutubeChannelsService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<YoutubeChannelDto> GetYoutubeChannels()
        {
            var channels = _unitOfWork.YoutubeChannelRepository.GetAll();

            if (channels.Any())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<YoutubeChannel, YoutubeChannelDto>());

                List<YoutubeChannelDto> dtoList = Mapper.Map<List<YoutubeChannelDto>>(channels);

                return dtoList;
            }
            return null;
        }

        public YoutubeChannelDto GetYoutubeChannel(string name)
        {
            var channel = _unitOfWork.YoutubeChannelRepository.GetFirst(p => p.Name == name);

            if (channel != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<YoutubeChannel, YoutubeChannelDto>());

                YoutubeChannelDto dto = Mapper.Map<YoutubeChannelDto>(channel);

                return dto;
            }

            return null;
        }

        public int InsertYoutubeChannel(YoutubeChannelDto channelDto)
        {
            using (var scope = new TransactionScope())
            {
                if (channelDto.UploadPlaylistId == null && channelDto.YoutubeChannelId == null)
                {
                    var details = GetChannelDetails(channelDto.Name);

                    channelDto.YoutubeChannelId = details.YoutubeChannelId;
                    channelDto.UploadPlaylistId = details.UploadPlaylistId;
                }

                var channel = new YoutubeChannel()
                {
                    YoutubeChannelId = channelDto.YoutubeChannelId,
                    Description = channelDto.Description,
                    Name = channelDto.Name,
                    Id = channelDto.Id,
                    UploadPlaylistId = channelDto.UploadPlaylistId
                };

                _unitOfWork.YoutubeChannelRepository.Insert(channel);
                _unitOfWork.Save();

                scope.Complete();

                return channel.Id;
            }
        }

        public YoutubeChannelDetails GetChannelDetails(string channelName)
        {
            var requestURL = "https://www.googleapis.com/youtube/v3/channels?" +
                   "part=contentDetails&key=AIzaSyBSsdJSTQ3uvLOH1MgN6joX_cxfs4Tmflw" +
                   "&forUsername=" + channelName;

            var request = WebRequest.Create(requestURL);
            var responseStream = request.GetResponse().GetResponseStream();

            using (StreamReader reader = new StreamReader(responseStream))
            {
                var jsonString = reader.ReadToEnd();

                return YoutubeChannelDetails.FromJson(jsonString);
            }
        }

        public bool EdditYoutubeChannel(int id, YoutubeChannelDto channelDto)
        {
            var success = false;
            if (channelDto != null)
            {
                using (var scope = new TransactionScope())
                {
                    var channel = _unitOfWork.YoutubeChannelRepository.GetByID(id);
                    if (channel != null)
                    {
                        channel.Name = channelDto.Name;
                        channel.Description = channelDto.Description;
                        channel.UploadPlaylistId = channelDto.UploadPlaylistId;
                        channel.YoutubeChannelId = channelDto.YoutubeChannelId;
                        _unitOfWork.YoutubeChannelRepository.Update(channel);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteYoutubeChannel(int channelId)
        {
            var success = false;
            if (channelId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var quote = _unitOfWork.YoutubeChannelRepository.GetByID(channelId);
                    if (quote != null)
                    {

                        _unitOfWork.YoutubeChannelRepository.Delete(quote);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

    }
}
