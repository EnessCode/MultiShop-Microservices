using MultiShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
	public class OrderingService : IOrderingService
	{
		private readonly HttpClient _httpClient;

		public OrderingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultOrderingByUserIdDtos>> GetOrderingByUserIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("orderings/user/" + id);
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDtos>>();
			return values;
		}
	}
}
