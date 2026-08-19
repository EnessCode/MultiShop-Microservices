using Microsoft.AspNetCore.SignalR;
using MultiShop.RealTime.Api.Services.SignalRCatalogServices;
using MultiShop.RealTime.Api.Services.SignalRCommentServices;
using MultiShop.RealTime.Api.Services.SignalRDiscountServices;
using MultiShop.RealTime.Api.Services.SignalRMessageServices;
using MultiShop.RealTime.Api.Services.SignalRUserServices;

namespace MultiShop.RealTime.Api.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ISignalRCommentService _signalRCommentService;
		private readonly ISignalRMessageService _signalRMessageService;
		private readonly ISignalRCatalogService _signalRCatalogService;
		private readonly ISignalRDiscountService _signalRDiscountService;
		private readonly ISignalRUserService _signalRUserService;

		public SignalRHub(
			ISignalRCommentService signalRCommentService,
			ISignalRMessageService signalRMessageService,
			ISignalRCatalogService signalRCatalogService,
			ISignalRDiscountService signalRDiscountService,
			ISignalRUserService signalRUserService)
		{
			_signalRCommentService = signalRCommentService;
			_signalRMessageService = signalRMessageService;
			_signalRCatalogService = signalRCatalogService;
			_signalRDiscountService = signalRDiscountService;
			_signalRUserService = signalRUserService;
		}

		// Yorum Bildirimi
		public async Task SendCommentNotification(string userId)
		{
			var commentCount = await _signalRCommentService.GetPassiveCommentCountAsync();
			await Clients.All.SendAsync("ReceiveCommentNotification", commentCount);
		}

		// Mesaj Bildirimi
		public async Task SendMessageNotification(string receiverId)
		{
			var messageCount = await _signalRMessageService.GetTotalMessageCountByReceiverIdAsync(receiverId);
			await Clients.All.SendAsync("ReceiveMessageNotification", messageCount);
		}

		// Katalog İstatistikleri
		public async Task SendCatalogStatistics()
		{
			var categoryCount = await _signalRCatalogService.GetCategoryCountAsync();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var productCount = await _signalRCatalogService.GetProductCountAsync();
			await Clients.All.SendAsync("ReceiveProductCount", productCount);

			var brandCount = await _signalRCatalogService.GetBrandCountAsync();
			await Clients.All.SendAsync("ReceiveBrandCount", brandCount);

			var avgPrice = await _signalRCatalogService.GetProductAveragePriceAsync();
			await Clients.All.SendAsync("ReceiveProductAvgPrice", avgPrice);
		}

		// İndirim/Kupon İstatistikleri
		public async Task SendDiscountStatistics()
		{
			var totalCoupon = await _signalRDiscountService.GetTotalCouponCountAsync();
			await Clients.All.SendAsync("ReceiveTotalCouponCount", totalCoupon);

			var activeCoupon = await _signalRDiscountService.GetActiveCouponCountAsync();
			await Clients.All.SendAsync("ReceiveActiveCouponCount", activeCoupon);

			var passiveCoupon = await _signalRDiscountService.GetPassiveCouponCountAsync();
			await Clients.All.SendAsync("ReceivePassiveCouponCount", passiveCoupon);
		}

		// Kullanıcı İstatistikleri
		public async Task SendUserStatistics()
		{
			var userCount = await _signalRUserService.GetUserCountAsync();
			await Clients.All.SendAsync("ReceiveUserCount", userCount);
		}
	}
}