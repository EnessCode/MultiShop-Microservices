using MultiShop.Message.Dtos.UserMessageDtos;

namespace MultiShop.Message.MessageServices
{
	public interface IUserMessageService
	{
		Task<List<ResultUserMessageDto>> GetAllUserMessagesAsync();
		Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id);
		Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id);
		Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto);
		Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto);
		Task DeleteUserMessageAsync(int id);
		Task<GetUserMessageByIdDto> GetUserMessageByIdAsync(int id);
	}
}
