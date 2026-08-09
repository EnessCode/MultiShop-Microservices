namespace MultiShop.Discount.Services.StatisticServices
{
	public interface IStatisticService
	{
		Task<int> GetTotalCouponCountAsync();
		Task<int> GetActiveCouponCountAsync();
		Task<int> GetPassiveCouponCountAsync();
	}
}
