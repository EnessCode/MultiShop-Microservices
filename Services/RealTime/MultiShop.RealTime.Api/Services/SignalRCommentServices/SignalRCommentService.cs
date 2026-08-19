namespace MultiShop.RealTime.Api.Services.SignalRCommentServices
{
	public class SignalRCommentService : ISignalRCommentService
	{
		private readonly HttpClient _httpClient;

		public SignalRCommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetPassiveCommentCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/passive-comment-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
