namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
	public class CommentStatisticService : ICommentStatisticService
	{
		private readonly HttpClient _httpClient;

		public CommentStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetTotalCommentCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/total-comment-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetActiveCommentCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/active-comment-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetPassiveCommentCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/passive-comment-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
