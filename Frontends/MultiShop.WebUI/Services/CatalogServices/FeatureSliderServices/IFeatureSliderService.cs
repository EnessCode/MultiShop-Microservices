using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
		Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id);
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string id);
		Task ChangeFeatureSliderStatusAsync(string id, bool isActive);
	}
}
