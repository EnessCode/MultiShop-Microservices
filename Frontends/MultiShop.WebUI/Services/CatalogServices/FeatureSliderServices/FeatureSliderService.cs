using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		private readonly HttpClient _httpClient;

		public FeatureSliderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeFeatureSliderStatusAsync(string id, bool isActive)
		{
			await _httpClient.PutAsync("featuresliders/FeatureSliderStatus?id=" + id + "&isActive=" + isActive, null);
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _httpClient.PostAsJsonAsync("featuresliders", createFeatureSliderDto);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _httpClient.DeleteAsync("featuresliders/" + id);
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
		{
			var responseMessage = await _httpClient.GetAsync("featuresliders");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();
			return values;
		}

		public async Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
			return value;
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDto);
		}
	}
}
