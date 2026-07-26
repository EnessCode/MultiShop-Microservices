
using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AddressServices
{
	public class AddressService : IAddressService
	{
		private readonly HttpClient _httpClient;

		public AddressService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
		{
			await _httpClient.PostAsJsonAsync("addresses", createAddressDto);
		}

		public async Task DeleteAddressAsync(string id)
		{
			await _httpClient.DeleteAsync("addresses/" + id);
		}

		public async Task<UpdateAddressDto> GetAddressByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("addresses/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateAddressDto>();
			return value;
		}

		public async Task<List<ResultAddressDto>> GetAllAddressesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("addresses");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAddressDto>>();
			return values;
		}

		public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
		{
			await _httpClient.PutAsJsonAsync("addresses", updateAddressDto);
		}
	}
}
