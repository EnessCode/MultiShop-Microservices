namespace MultiShop.Comment.Services.StatisticServices
{
	public interface IStatisticService
	{
		Task<int> GetTotalCommentCountAsync();
		Task<int> GetActiveCommentCountAsync();
		Task<int> GetPassiveCommentCountAsync();
	}
}
