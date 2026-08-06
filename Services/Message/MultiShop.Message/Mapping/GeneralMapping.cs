using AutoMapper;
using MultiShop.Message.DataAccess.Entities;
using MultiShop.Message.Dtos.UserMessageDtos;

namespace MultiShop.Message.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<UserMessage, ResultUserMessageDto>().ReverseMap();
			CreateMap<UserMessage, ResultInboxUserMessageDto>().ReverseMap();
			CreateMap<UserMessage, ResultSendboxUserMessageDto>().ReverseMap();
			CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
			CreateMap<UserMessage, UpdateUserMessageDto>().ReverseMap();
			CreateMap<UserMessage, GetUserMessageByIdDto>().ReverseMap();
		}
	}
}