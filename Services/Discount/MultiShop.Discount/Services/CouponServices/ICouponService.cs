using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices
{
	public interface ICouponService
	{
		Task<List<ResultCouponDto>> GetAllCouponsAsync();
		Task<GetCouponByIdDto> GetCouponByIdAsync(int id);
		Task CreateCouponAsync(CreateCouponDto createCouponDto);
		Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
		Task DeleteCouponAsync(int id);
		Task<ResultCouponDto> GetCouponByCodeAsync(string code);
	}
}
