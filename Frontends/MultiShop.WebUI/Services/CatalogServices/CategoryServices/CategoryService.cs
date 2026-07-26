using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;

		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
			await _httpClient.PostAsJsonAsync("categories", createCategoryDto);
		}

		public async Task DeleteCategoryAsync(string id)
		{
			await _httpClient.DeleteAsync("categories/" + id);
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("categories");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
			return values;
		}

		public async Task<UpdateCategoryDto> GetCategoryByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("categories/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
			return value;
		}

		public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
		{
			await _httpClient.PutAsJsonAsync("categories", updateCategoryDto);
		}
	}
}
