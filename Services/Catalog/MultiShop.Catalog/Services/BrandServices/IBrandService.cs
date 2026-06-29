using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandsAsync();
		Task<GetBrandByIdDto> GetBrandByIdAsync(string id);
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAsync(string id);
		Task ChangeBrandStatusAsync(string id, bool isActive);
	}
}
