
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
	public class CatalogStatisticService : ICatalogStatisticService
	{
		private readonly HttpClient _httpClient;

		public CatalogStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<long> GetBrandCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/brand-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}

		public async Task<long> GetCategoryCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/category-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}

		public async Task<long> GetProductCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/product-count");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}

		public async Task<decimal> GetProductAveragePriceAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/product-average-price");
			var value = await responseMessage.Content.ReadFromJsonAsync<decimal>();
			return value;
		}

		public async Task<string> GetMaxPriceProductNameAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/max-price-product-name");
			var value = await responseMessage.Content.ReadAsStringAsync();
			return value;
		}

		public async Task<string> GetMinPriceProductNameAsync()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/min-price-product-name");
			var value = await responseMessage.Content.ReadAsStringAsync();
			return value;
		}
	}
}
