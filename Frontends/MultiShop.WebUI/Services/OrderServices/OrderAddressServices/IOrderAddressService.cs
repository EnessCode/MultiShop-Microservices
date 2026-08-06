using MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
	public interface IOrderAddressService
	{
		Task<List<ResultUserMessageDto>> GetAllOrderAddressesAsync();
		Task<UpdateUserMessageDto> GetOrderAddressByIdAsync(string id);
		Task CreateOrderAddressAsync(CreateUserMessageDtos createAddressDto);
		Task UpdateOrderAddressAsync(UpdateUserMessageDto updateAddressDto);
		Task DeleteOrderAddressAsync(string id);
	}
}