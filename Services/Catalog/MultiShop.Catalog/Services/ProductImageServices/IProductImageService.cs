using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
		Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
		Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteProductImageAsync(string id);
		Task<GetProductImageByIdDto> GetProductImageByProductIdAsync(string productId);
	}
}
