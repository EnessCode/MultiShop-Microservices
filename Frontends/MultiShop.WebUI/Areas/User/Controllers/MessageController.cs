using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.MessageServices.UserMessageServices;
using MultiShop.WebUI.Services.IdentityServices.UserServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.User.Controllers
{
	[Area("User")]
	public class MessageController : Controller
	{
		private readonly IUserMessageService _userMessageService;
		private readonly IUserService _userService;

		public MessageController(IUserMessageService userMessageService, IUserService userService)
		{
			_userMessageService = userMessageService;
			_userService = userService;
		}

		public async Task<IActionResult> Inbox()
		{
			var user = await _userService.GetUserInfoAsync();
			var values = await _userMessageService.GetInboxMessagesAsync(user.Id);
			return View(values);
		}

		public async Task<IActionResult> Sendbox()
		{
			var user = await _userService.GetUserInfoAsync();
			var values = await _userMessageService.GetSendboxMessagesAsync(user.Id);
			return View(values);
		}
	}
}
