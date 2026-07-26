using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
		Task<UpdateFeatureDto> GetFeatureByIdAsync(string id);
		Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
		Task DeleteFeatureAsync(string id);
		Task ChangeFeatureStatusAsync(string id, bool isActive);
	}
}
