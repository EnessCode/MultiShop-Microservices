using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
		Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id);
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string id);
		Task ChangeSpecialOfferStatusAsync(string id, bool isActive);
	}
}
