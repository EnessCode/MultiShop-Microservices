using Dapper;
using MultiShop.Discount.Context;

namespace MultiShop.Discount.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly DapperContext _context;

		public StatisticService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetActiveCouponCountAsync()
		{
			string query = "SELECT COUNT(*) FROM Coupons WHERE IsActive = 1"; 
			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<int>(query);
				return value;
			}
		}

		public async Task<int> GetPassiveCouponCountAsync()
		{
			string query = "SELECT COUNT(*) FROM Coupons WHERE IsActive = 0"; 
			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<int>(query);
				return value;
			}
		}

		public async Task<int> GetTotalCouponCountAsync()
		{
			string query = "SELECT COUNT(*) FROM Coupons";
			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<int>(query);
				return value;
			}
		}
	}
}
