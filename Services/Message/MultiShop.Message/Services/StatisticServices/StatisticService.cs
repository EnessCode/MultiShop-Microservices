using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Context;

namespace MultiShop.Message.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly MessageContext _context;

		public StatisticService(MessageContext context)
		{
			_context = context;
		}

		public async Task<int> GetTotalMessageCountAsync()
		{
			return await _context.UserMessages.CountAsync();
		}

		public async Task<int> GetUnreadMessageCountAsync()
		{
			return await _context.UserMessages.CountAsync(x => x.IsRead == false);
		}

		public async Task<int> GetReadMessageCountAsync()
		{
			return await _context.UserMessages.CountAsync(x => x.IsRead == true);
		}

		public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			return await _context.UserMessages.CountAsync(x => x.ReceiverId == id);
		}
	}
}
