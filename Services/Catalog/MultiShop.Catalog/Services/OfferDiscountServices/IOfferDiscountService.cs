using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();
		Task<GetOfferDiscountByIdDto> GetOfferDiscountByIdAsync(string id);
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
		Task DeleteOfferDiscountAsync(string id);
		Task ChangeOfferDiscountStatusAsync(string id, bool isActive);
	}
}
