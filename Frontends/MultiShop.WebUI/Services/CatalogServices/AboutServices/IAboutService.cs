using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
	public interface IAboutService
	{
		Task<List<ResultAboutDto>> GetAllAboutsAsync();
		Task<UpdateAboutDto> GetAboutByIdAsync(string id);
		Task CreateAboutAsync(CreateAboutDto createAboutDto);
		Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
		Task DeleteAboutAsync(string id);
	}
}
