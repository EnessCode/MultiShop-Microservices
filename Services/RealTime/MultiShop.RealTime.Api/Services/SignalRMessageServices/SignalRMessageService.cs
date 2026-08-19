using System.Net.Http;

namespace MultiShop.RealTime.Api.Services.SignalRMessageServices
{
	public class SignalRMessageService : ISignalRMessageService
	{
		private readonly HttpClient _httpClient;

		public SignalRMessageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			//var responseMessage = await _httpClient.GetAsync("api/statistics/total-message-count-by-receiver/" + id);
			var responseMessage = await _httpClient.GetAsync("api/statistics/total-message-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
