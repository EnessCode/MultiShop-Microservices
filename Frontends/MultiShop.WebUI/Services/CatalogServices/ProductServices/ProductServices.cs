using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
	public class ProductServices : IProductService
	{
		private readonly HttpClient _httpClient;

		public ProductServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductAsync(CreateProductDto createProductDto)
		{
			await _httpClient.PostAsJsonAsync("products", createProductDto);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _httpClient.DeleteAsync("products/" + id);
		}

		public async Task<List<ResultProductDto>> GetAllProductsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("products");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
			return values;
		}

		public async Task<UpdateProductDto> GetProductByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("products/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
			return value;
		}

		public async Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string categoryId)
		{
			var responseMessage = await _httpClient.GetAsync("products/category/" + categoryId);
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
			return values;
		}

		public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
		{
			var responseMessage = await _httpClient.GetAsync("products/with-category"); 
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
			return values;
		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
		{
			await _httpClient.PutAsJsonAsync("products", updateProductDto);
		}
	}
}
