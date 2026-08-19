namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
	public interface IMessageStatisticService
	{
		Task<int> GetTotalMessageCountAsync();
		Task<int> GetUnreadMessageCountAsync();
		Task<int> GetReadMessageCountAsync();
		Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
	}
}
