using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services.StatisticServices;

namespace MultiShop.Message.Controllers
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

		[HttpGet("total-message-count")]
		public async Task<IActionResult> GetTotalMessageCount()
		{
			var value = await _statisticService.GetTotalMessageCountAsync();
			return Ok(value);
		}

		[HttpGet("unread-message-count")]
		public async Task<IActionResult> GetUnreadMessageCount()
		{
			var value = await _statisticService.GetUnreadMessageCountAsync();
			return Ok(value);
		}

		[HttpGet("read-message-count")]
		public async Task<IActionResult> GetReadMessageCount()
		{
			var value = await _statisticService.GetReadMessageCountAsync();
			return Ok(value);
		}

		[HttpGet("total-message-count-by-receiver/{id}")]
		public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
		{
			var value = await _statisticService.GetTotalMessageCountByReceiverIdAsync(id);
			return Ok(value);
		}
	}
}
