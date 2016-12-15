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
            var channels = _unitOfWork.YoutubeChannelRepository.GetAll().ToList();
            if (channels.Any())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<YoutubeChannel, YoutubeChannelDto>());

                List<YoutubeChannelDto> dtoList = Mapper.Map<List<YoutubeChannelDto>>(channels);

                return dtoList;
            }
            return null;
        }

        public int InsertOrUpdateYoutubeChannel(YoutubeChannelDto channelDto)
        {
            using (var scope = new TransactionScope())
            {

                var channel = _unitOfWork.YoutubeChannelRepository.GetSingle(p=>p.YoutubeChannelId==channelDto.YoutubeChannelId);
                if (channel != null)
                {
                    channel.Description = channelDto.Description;
                    channel.Name = channelDto.Name;
                    channel.UploadPlaylistId = channelDto.UploadPlaylistId;
                    _unitOfWork.YoutubeChannelRepository.Update(channel);

                }
                else
                {
                    var newchannel = new YoutubeChannel()
                    {
                        Description = channelDto.Description,
                        Name = channelDto.Name,
                        UploadPlaylistId = channelDto.UploadPlaylistId,
                        YoutubeChannelId = channelDto.YoutubeChannelId
                    };
                    _unitOfWork.YoutubeChannelRepository.Insert(newchannel);
                    channel = newchannel;

                }
                _unitOfWork.Save();
                scope.Complete();
                return channel.Id;
            }
        }

        public bool DeleteYoutubeChannel(int youtubeChannelId)
        {
            var success = false;
            if (youtubeChannelId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var youtubeChannel = _unitOfWork.YoutubeChannelRepository.GetByID(youtubeChannelId);
                    if (youtubeChannel != null)
                    {

                        _unitOfWork.YoutubeChannelRepository.Delete(youtubeChannel);
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
