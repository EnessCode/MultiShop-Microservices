using System.Net.Http;
using System.Net.Http.Json;

namespace MultiShop.RealTime.Api.Services.SignalRDiscountServices
{
	public class SignalRDiscountService : ISignalRDiscountService
	{
		private readonly HttpClient _httpClient;

		public SignalRDiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetTotalCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/total-coupon-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task<int> GetActiveCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/active-coupon-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task<int> GetPassiveCouponCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/passive-coupon-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}
	}
}