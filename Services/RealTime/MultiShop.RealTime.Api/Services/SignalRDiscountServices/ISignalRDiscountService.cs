namespace MultiShop.RealTime.Api.Services.SignalRDiscountServices
{
	public interface ISignalRDiscountService
	{
		Task<int> GetTotalCouponCountAsync();
		Task<int> GetActiveCouponCountAsync();
		Task<int> GetPassiveCouponCountAsync();
	}
}
