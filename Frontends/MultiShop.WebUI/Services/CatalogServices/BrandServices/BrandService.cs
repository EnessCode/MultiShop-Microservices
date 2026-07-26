using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
	public class BrandService : IBrandService
	{
		private readonly HttpClient _httpClient;

		public BrandService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeBrandStatusAsync(string id, bool isActive)
		{
			await _httpClient.PutAsync("brands/ChangeBrandStatus?id=" + id + "&isActive=" + isActive, null);
		}

		public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
		{
			await _httpClient.PostAsJsonAsync("brands", createBrandDto);
		}

		public async Task DeleteBrandAsync(string id)
		{
			await _httpClient.DeleteAsync("brands/" + id);
		}

		public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("brands");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
			return values;
		}

		public async Task<UpdateBrandDto> GetBrandByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("brands/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
			return value;
		}

		public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
		{
			await _httpClient.PutAsJsonAsync("brands", updateBrandDto);
		}
	}
}
