using MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
	public interface IOrderAddressService
	{
		Task<List<ResultOrderAddressDto>> GetAllOrderAddressesAsync();
		Task<UpdateOrderAddressDto> GetOrderAddressByIdAsync(string id);
		Task CreateOrderAddressAsync(CreateOrderAddressDto createAddressDto);
		Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateAddressDto);
		Task DeleteOrderAddressAsync(string id);
	}
}