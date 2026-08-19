using System.Net.Http;
using System.Net.Http.Json;

namespace MultiShop.RealTime.Api.Services.SignalRCatalogServices
{
	public class SignalRCatalogService : ISignalRCatalogService
	{
		private readonly HttpClient _httpClient;

		public SignalRCatalogService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetCategoryCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/category-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task<int> GetProductCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/product-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task<int> GetBrandCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/brand-count");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task<decimal> GetProductAveragePriceAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/statistics/product-average-price");
			return await responseMessage.Content.ReadFromJsonAsync<decimal>();
		}
	}
}