namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
	public class DiscountStatisticService : IDiscountStatisticService
	{
		private readonly HttpClient _httpClient;

		public DiscountStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetTotalCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/total-coupon-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetActiveCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/active-coupon-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetPassiveCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/passive-coupon-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}
	}
}
