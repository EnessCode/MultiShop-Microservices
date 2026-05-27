using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices
{
	public class CouponService : ICouponService
	{
		private readonly DapperContext _context;

		public CouponService(DapperContext context)
		{
			_context = context;
		}

		public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
		{
			string query = "Insert into Coupons (Code, DiscountRate, IsActive, ExpiryDate) values " +
				"(@code, @discountRate, @isActive, @expiryDate)";
			var parameters = new DynamicParameters();
			parameters.Add("@code", createCouponDto.Code);
			parameters.Add("@discountRate", createCouponDto.DiscountRate);
			parameters.Add("@isActive", createCouponDto.IsActive);
			parameters.Add("@expiryDate", createCouponDto.ExpiryDate);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteCouponAsync(int id)
		{
			string query = "Delete from Coupons where Id=@id";
			var parameters = new DynamicParameters();
			parameters.Add("id", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultCouponDto>> GetAllCouponAsync()
		{
			string query = "Select * from Coupons";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCouponDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetCouponByIdDto> GetCouponByIdAsync(int id)
		{
			string query = "Select * from Coupons where Id=@id";
			var parameters = new DynamicParameters();
			parameters.Add("id", id);
			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<GetCouponByIdDto>(query, parameters);
				return value;
			}
		}

		public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
		{
			string query = "Update Coupons set Code=@code, DiscountRate=@discountRate, IsActive=@isActive, ExpiryDate=@expiryDate where Id=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@code", updateCouponDto.Code);
			parameters.Add("@discountRate", updateCouponDto.DiscountRate);
			parameters.Add("@isActive", updateCouponDto.IsActive);
			parameters.Add("@expiryDate", updateCouponDto.ExpiryDate);
			parameters.Add("@id", updateCouponDto.Id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
