namespace MultiShop.Message.Services.StatisticServices
{
	public interface IStatisticService
	{
		Task<int> GetTotalMessageCountAsync();
		Task<int> GetUnreadMessageCountAsync();
		Task<int> GetReadMessageCountAsync();
	}
}
