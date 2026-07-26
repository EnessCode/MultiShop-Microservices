using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
		Task<UpdateProductImageDto> GetProductImageByIdAsync(string id);
		Task<UpdateProductImageDto> GetProductImageByProductIdAsync(string productId);
		Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteProductImageAsync(string id);
	}
}
