using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
		Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string id);
		Task ChangeSpecialOfferStatusAsync(string id, bool isActive);
	}
}
