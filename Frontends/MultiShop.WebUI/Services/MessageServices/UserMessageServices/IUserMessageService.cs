using MultiShop.DtoLayer.Dtos.MessageDtos.UserMessageDtos;

namespace MultiShop.WebUI.Services.MessageServices.UserMessageServices
{
	public interface IUserMessageService
	{
		Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id);
		Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id);
	}
}
