using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
	public class AboutService : IAboutService
	{
		private readonly HttpClient _httpClient;

		public AboutService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
		{
			await _httpClient.PostAsJsonAsync("abouts", createAboutDto);
		}

		public async Task DeleteAboutAsync(string id)
		{
			await _httpClient.DeleteAsync("abouts/" + id);
		}

		public async Task<UpdateAboutDto> GetAboutByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("abouts/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
			return value;
		}

		public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("abouts");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
			return values;
		}

		public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
		{
			await _httpClient.PutAsJsonAsync("abouts", updateAboutDto);
		}
	}
}
