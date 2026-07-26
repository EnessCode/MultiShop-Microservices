using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly HttpClient _httpClient;

		public ProductImageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			await _httpClient.PostAsJsonAsync("productimages", createProductImageDto);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _httpClient.DeleteAsync("productimages/" + id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("productimages");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
			return values;
		}

		public async Task<UpdateProductImageDto> GetProductImageByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("productimages/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
			return value;
		}

		public async Task<UpdateProductImageDto> GetProductImageByProductIdAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync("productimages/product/" + productId);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
			return value;
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			await _httpClient.PutAsJsonAsync("productimages", updateProductImageDto);
		}
	}
}