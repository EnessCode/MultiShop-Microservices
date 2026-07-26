using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly HttpClient _httpClient;

		public OfferDiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeOfferDiscountStatusAsync(string id, bool isActive)
		{
			await _httpClient.PutAsync("offerdiscounts/ChangeOfferDiscountStatus?id=" + id + "&isActive=" + isActive, null);
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _httpClient.PostAsJsonAsync("offerdiscounts", createOfferDiscountDto);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _httpClient.DeleteAsync("offerdiscounts/" + id);
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("offerdiscounts");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();
			return values;
		}

		public async Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
			return value;
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _httpClient.PutAsJsonAsync("offerdiscounts", updateOfferDiscountDto);
		}
	}
}
