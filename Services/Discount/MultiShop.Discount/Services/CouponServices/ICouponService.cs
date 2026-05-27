using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices
{
	public interface ICouponService
	{
		Task<List<ResultCouponDto>> GetAllCouponAsync();
		Task<GetCouponByIdDto> GetCouponByIdAsync(int id);
		Task CreateCouponAsync(CreateCouponDto createCouponDto);
		Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
		Task DeleteCouponAsync(int id);
	}
}
