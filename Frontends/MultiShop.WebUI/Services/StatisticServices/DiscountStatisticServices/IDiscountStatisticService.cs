namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
	public interface IDiscountStatisticService
	{
		Task<int> GetTotalCouponCountAsync();
		Task<int> GetActiveCouponCountAsync();
		Task<int> GetPassiveCouponCountAsync();
	}
}
