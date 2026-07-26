using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandsAsync();
		Task<UpdateBrandDto> GetBrandByIdAsync(string id);
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAsync(string id);
		Task ChangeBrandStatusAsync(string id, bool isActive);
	}
}
