namespace MultiShop.RealTime.Api.Services.SignalRMessageServices
{
	public interface ISignalRMessageService
	{
		Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
	}
}
