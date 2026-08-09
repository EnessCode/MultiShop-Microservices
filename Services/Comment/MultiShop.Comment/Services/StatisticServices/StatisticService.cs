using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly CommentContext _context;

		public StatisticService(CommentContext context)
		{
			_context = context;
		}

		public async Task<int> GetActiveCommentCountAsync()
		{
			return await _context.UserComments.CountAsync(x => x.Status == true);
		}

		public async Task<int> GetPassiveCommentCountAsync()
		{
			return await _context.UserComments.CountAsync(x => x.Status == false);
		}

		public async Task<int> GetTotalCommentCountAsync()
		{
			return await _context.UserComments.CountAsync();
		}
	}
}
