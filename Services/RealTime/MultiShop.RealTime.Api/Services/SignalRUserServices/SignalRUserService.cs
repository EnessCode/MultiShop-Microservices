using System.Net.Http;
using System.Net.Http.Json;

namespace MultiShop.RealTime.Api.Services.SignalRUserServices
{
	public class SignalRUserService : ISignalRUserService
	{
		private readonly HttpClient _httpClient;

		public SignalRUserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetUserCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/user-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}
	}
}