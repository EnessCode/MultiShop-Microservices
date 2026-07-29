using MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
	public class OrderAddressService : IOrderAddressService
	{
		private readonly HttpClient _httpClient;

		public OrderAddressService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateOrderAddressAsync(CreateOrderAddressDto createAddressDto)
		{
			await _httpClient.PostAsJsonAsync("orderaddresses", createAddressDto);
		}

		public async Task DeleteOrderAddressAsync(string id)
		{
			await _httpClient.DeleteAsync("orderaddresses/" + id);
		}

		public async Task<UpdateOrderAddressDto> GetOrderAddressByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("orderaddresses/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateOrderAddressDto>();
			return value;
		}

		public async Task<List<ResultOrderAddressDto>> GetAllOrderAddressesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("orderaddresses");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderAddressDto>>();
			return values;
		}

		public async Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateAddressDto)
		{
			await _httpClient.PutAsJsonAsync("orderaddresses", updateAddressDto);
		}
	}
}
