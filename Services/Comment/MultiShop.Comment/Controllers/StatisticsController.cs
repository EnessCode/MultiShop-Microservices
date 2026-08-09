using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Services.StatisticServices;

namespace MultiShop.Comment.Controllers
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

		[HttpGet("total-comment-count")]
		public async Task<IActionResult> GetTotalCommentCount()
		{
			var value = await _statisticService.GetTotalCommentCountAsync();
			return Ok(value);
		}

		[HttpGet("active-comment-count")]
		public async Task<IActionResult> GetActiveCommentCount()
		{
			var value = await _statisticService.GetActiveCommentCountAsync();
			return Ok(value);
		}

		[HttpGet("passive-comment-count")]
		public async Task<IActionResult> GetPassiveCommentCount()
		{
			var value = await _statisticService.GetPassiveCommentCountAsync();
			return Ok(value);
		}
	}
}
