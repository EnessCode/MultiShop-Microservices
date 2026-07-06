using MultiShop.Catalog.Dtos.AddressDtos;

namespace MultiShop.Catalog.Services.AddressServices
{
	public interface IAddressService
	{
		Task<List<ResultAddressDto>> GetAllAddressesAsync();
		Task<GetAddressByIdDto> GetAddressByIdAsync(string id);
		Task CreateAddressAsync(CreateAddressDto createAddressDto);
		Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
		Task DeleteAddressAsync(string id);
	}
}
