using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();
		Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id);
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
		Task DeleteOfferDiscountAsync(string id);
		Task ChangeOfferDiscountStatusAsync(string id, bool isActive);
	}
}
