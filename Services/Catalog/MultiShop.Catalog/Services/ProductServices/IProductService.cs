using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductsAsync();
		Task<GetProductByIdDto> GetProductByIdAsync(string id);
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAsync(string id);
		Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string categoryId);
	}
}
