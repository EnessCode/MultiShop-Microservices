using MultiShop.DtoLayer.Dtos.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
	public interface IOrderingService
	{
		Task<List<ResultOrderingByUserIdDtos>> GetOrderingByUserIdAsync(string id);
	}
}
