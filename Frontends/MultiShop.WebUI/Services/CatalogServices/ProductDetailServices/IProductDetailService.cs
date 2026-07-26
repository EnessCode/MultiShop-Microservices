using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
	public interface IProductDetailService
	{
		Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
		Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id);
		Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
		Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
		Task DeleteProductDetailAsync(string id);
		Task<UpdateProductDetailDto> GetProductDetailByProductIdAsync(string productId);
	}
}
