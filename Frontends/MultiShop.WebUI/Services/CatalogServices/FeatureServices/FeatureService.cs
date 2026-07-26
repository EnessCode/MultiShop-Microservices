
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
	public class FeatureService : IFeatureService
	{
		private readonly HttpClient _httpClient;

		public FeatureService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeFeatureStatusAsync(string id, bool isActive)
		{
			await _httpClient.PutAsync("features/ChangeFeatureStatus?id=" + id + "&isActive=" + isActive, null);
		}

		public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
		{
			await _httpClient.PostAsJsonAsync("features", createFeatureDto);
		}

		public async Task DeleteFeatureAsync(string id)
		{
			await _httpClient.DeleteAsync("features/" + id);
		}

		public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("features");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
			return values;
		}

		public async Task<UpdateFeatureDto> GetFeatureByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("features/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
			return value;
		}

		public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
		{
			await _httpClient.PutAsJsonAsync("features", updateFeatureDto);
		}
	}
}
