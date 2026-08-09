namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
	public class UserStatisticService : IUserStatisticService
	{
		private readonly HttpClient _httpClient;

		public UserStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetUserCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/user-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
