namespace MultiShop.RealTime.Api.Services.SignalRUserServices
{
	public interface ISignalRUserService
	{
		Task<int> GetUserCountAsync();
	}
}
