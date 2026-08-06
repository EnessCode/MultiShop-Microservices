using System.Net.Http.Json;
using MultiShop.DtoLayer.Dtos.MessageDtos.UserMessageDtos;

namespace MultiShop.WebUI.Services.MessageServices.UserMessageServices
{
	public class UserMessageService : IUserMessageService
	{
		private readonly HttpClient _httpClient;

		public UserMessageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("usermessage/GetInboxMessages/" + id);
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxUserMessageDto>>();
			return values;
		}

		public async Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("usermessage/GetSendboxMessages/" + id);
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxUserMessageDto>>();
			return values;
		}
	}
}