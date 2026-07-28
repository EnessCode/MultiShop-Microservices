using MultiShop.DtoLayer.Dtos.DiscountDtos.CouponDtos;

namespace MultiShop.WebUI.Services.DiscountServices.CouponServices
{
	public interface ICouponService
	{
		Task<ResultCouponDto> GetCouponByCodeAsync(string code);
	}
}
