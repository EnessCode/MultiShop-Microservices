namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
	public class MessageStatisticService : IMessageStatisticService
	{
		private readonly HttpClient _httpClient;

		public MessageStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetTotalMessageCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/total-message-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetUnreadMessageCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/unread-message-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetReadMessageCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/read-message-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("statistics/total-message-count-by-receiver/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
