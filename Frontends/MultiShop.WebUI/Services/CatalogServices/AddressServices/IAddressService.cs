using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AddressServices
{
	public interface IAddressService
	{
		Task<List<ResultAddressDto>> GetAllAddressesAsync();
		Task<UpdateAddressDto> GetAddressByIdAsync(string id);
		Task CreateAddressAsync(CreateAddressDto createAddressDto);
		Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
		Task DeleteAddressAsync(string id);
	}
}
