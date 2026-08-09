using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices; 
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StatisticController : Controller
	{
		private readonly ICatalogStatisticService _catalogStatisticService;
		private readonly IUserStatisticService _userStatisticService;
		private readonly ICommentStatisticService _commentStatisticService;
		private readonly IDiscountStatisticService _discountStatisticService; 

		public StatisticController(
			ICatalogStatisticService catalogStatisticService,
			IUserStatisticService userStatisticService,
			ICommentStatisticService commentStatisticService,
			IDiscountStatisticService discountStatisticService)
		{
			_catalogStatisticService = catalogStatisticService;
			_userStatisticService = userStatisticService;
			_commentStatisticService = commentStatisticService;
			_discountStatisticService = discountStatisticService;
		}
		private void SetBreadcrumb(string activePage, string moduleName = "İstatistikler", string moduleUrl = "/Admin/Statistic/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Genel Bakış");

			// Katalog İstatistikleri
			ViewBag.BrandCount = await _catalogStatisticService.GetBrandCountAsync();
			ViewBag.CategoryCount = await _catalogStatisticService.GetCategoryCountAsync();
			ViewBag.ProductCount = await _catalogStatisticService.GetProductCountAsync();
			ViewBag.ProductAveragePrice = await _catalogStatisticService.GetProductAveragePriceAsync();
			ViewBag.MaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
			ViewBag.MinPriceProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();

			// Kullanıcı İstatistikleri
			ViewBag.UserCount = await _userStatisticService.GetUserCountAsync();

			// Yorum İstatistikleri
			ViewBag.TotalCommentCount = await _commentStatisticService.GetTotalCommentCountAsync();
			ViewBag.ActiveCommentCount = await _commentStatisticService.GetActiveCommentCountAsync();
			ViewBag.PassiveCommentCount = await _commentStatisticService.GetPassiveCommentCountAsync();

			// İndirim/Kupon İstatistikleri
			ViewBag.TotalCouponCount = await _discountStatisticService.GetTotalCouponCountAsync();
			ViewBag.ActiveCouponCount = await _discountStatisticService.GetActiveCouponCountAsync();
			ViewBag.PassiveCouponCount = await _discountStatisticService.GetPassiveCouponCountAsync();

			return View();
		}
	}
}