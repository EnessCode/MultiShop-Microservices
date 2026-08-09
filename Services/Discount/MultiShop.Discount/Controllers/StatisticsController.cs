using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Services.StatisticServices;

namespace MultiShop.Discount.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticService _statisticService;

		public StatisticsController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		[HttpGet("total-coupon-count")]
		public async Task<IActionResult> GetTotalCouponCount()
		{
			var value = await _statisticService.GetTotalCouponCountAsync();
			return Ok(value);
		}

		[HttpGet("active-coupon-count")]
		public async Task<IActionResult> GetActiveCouponCount()
		{
			var value = await _statisticService.GetActiveCouponCountAsync();
			return Ok(value);
		}

		[HttpGet("passive-coupon-count")]
		public async Task<IActionResult> GetPassiveCouponCount()
		{
			var value = await _statisticService.GetPassiveCouponCountAsync();
			return Ok(value);
		}
	}
}
