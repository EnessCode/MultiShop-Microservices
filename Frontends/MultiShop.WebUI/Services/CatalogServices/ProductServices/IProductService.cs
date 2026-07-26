using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductsAsync();
		Task<UpdateProductDto> GetProductByIdAsync(string id);
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAsync(string id);
		Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetProductsByCategoryIdAsync(string categoryId);
	}
}
