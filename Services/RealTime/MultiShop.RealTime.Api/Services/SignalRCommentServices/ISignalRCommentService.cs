namespace MultiShop.RealTime.Api.Services.SignalRCommentServices
{
	public interface ISignalRCommentService
	{
		Task<int> GetPassiveCommentCountAsync();
	}
}
