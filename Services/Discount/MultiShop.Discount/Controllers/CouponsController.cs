using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.CouponDtos;
using MultiShop.Discount.Services.CouponServices;
using System.Threading.Tasks;

namespace MultiShop.Discount.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CouponsController : ControllerBase
	{
		private readonly ICouponService _couponService;

		public CouponsController(ICouponService couponService)
		{
			_couponService = couponService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCoupons()
		{
			var values = await _couponService.GetAllCouponsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCouponById(int id)
		{
			var value = await _couponService.GetCouponByIdAsync(id);
			return Ok(value);
		}

		[HttpGet("code/{code}")]
		public async Task<IActionResult> GetCouponByCode(string code)
		{
			var value = await _couponService.GetCouponByCodeAsync(code);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
		{
			await _couponService.CreateCouponAsync(createCouponDto);
			return Ok("İndirim kuponu başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
		{
			await _couponService.UpdateCouponAsync(updateCouponDto);
			return Ok("İndirim kuponu başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCoupon(int id)
		{
			await _couponService.DeleteCouponAsync(id);
			return Ok("İndirim kuponu başarıyla silindi.");
		}
	}
}
