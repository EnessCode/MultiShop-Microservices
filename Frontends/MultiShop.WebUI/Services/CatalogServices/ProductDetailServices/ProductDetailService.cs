using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly HttpClient _httpClient;

		public ProductDetailService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
		{
			await _httpClient.PostAsJsonAsync("productdetails", createProductDetailDto);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _httpClient.DeleteAsync("productdetails/" + id);
		}

		public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("productdetails");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
			return values;
		}

		public async Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
			return value;
		}

		public async Task<UpdateProductDetailDto> GetProductDetailByProductIdAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync("productdetails/product/" + productId);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
			return value;
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			await _httpClient.PutAsJsonAsync("productdetails", updateProductDetailDto);
		}
	}
}