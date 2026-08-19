using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.IdentityServices.UserServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class AdminHeaderViewComponent : ViewComponent
	{
		private readonly IMessageStatisticService _messageStatisticService;
		private readonly IUserService _userService;
		private readonly ICommentStatisticService _commentStatisticService;

		public AdminHeaderViewComponent(IMessageStatisticService messageStatisticService, IUserService userService, ICommentStatisticService commentStatisticService)
		{
			_messageStatisticService = messageStatisticService;
			_userService = userService;
			_commentStatisticService = commentStatisticService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _userService.GetUserInfoAsync();
			var messageCount = await _messageStatisticService.GetTotalMessageCountByReceiverIdAsync(user.Id);
			var commentCount = await _commentStatisticService.GetPassiveCommentCountAsync();

			ViewBag.MessageCount = messageCount;
			ViewBag.CommentCount = commentCount;

			return View();
		}
	}
}
