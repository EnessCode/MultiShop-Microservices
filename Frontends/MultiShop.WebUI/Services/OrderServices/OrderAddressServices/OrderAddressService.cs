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

		public async Task CreateOrderAddressAsync(CreateUserMessageDtos createAddressDto)
		{
			await _httpClient.PostAsJsonAsync("orderaddresses", createAddressDto);
		}

		public async Task DeleteOrderAddressAsync(string id)
		{
			await _httpClient.DeleteAsync("orderaddresses/" + id);
		}

		public async Task<UpdateUserMessageDto> GetOrderAddressByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("orderaddresses/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateUserMessageDto>();
			return value;
		}

		public async Task<List<ResultUserMessageDto>> GetAllOrderAddressesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("orderaddresses");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserMessageDto>>();
			return values;
		}

		public async Task UpdateOrderAddressAsync(UpdateUserMessageDto updateAddressDto)
		{
			await _httpClient.PutAsJsonAsync("orderaddresses", updateAddressDto);
		}
	}
}
