using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
		Task<UpdateCategoryDto> GetCategoryByIdAsync(string id);
		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
		Task DeleteCategoryAsync(string id);
	}
}
