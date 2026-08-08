using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.IdentityServices.UserServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _userService.GetAllUserListAsync();
			return View(values);
		}
	}
}
