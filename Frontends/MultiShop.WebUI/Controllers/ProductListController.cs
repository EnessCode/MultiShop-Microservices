using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index(string id)
		{
			ViewBag.categoryId = id;
			return View();
		}

		public IActionResult ProductDetail(string id)
		{
			ViewBag.productId = id;
			return View();
		}
	}
}
