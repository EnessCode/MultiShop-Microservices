using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllProductImageAsync();
		Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
		Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteProductImageAsync(string id);
	}
}
