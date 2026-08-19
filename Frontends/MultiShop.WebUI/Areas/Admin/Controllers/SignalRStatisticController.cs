using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SignalRStatisticController : Controller
	{
		private void SetBreadcrumb(string activePage, string moduleName = "Canlı İstatistikler", string moduleUrl = "/Admin/SignalRStatistic/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public IActionResult Index()
		{
			SetBreadcrumb("Anlık Sistem Verileri");
			return View();
		}
	}
}
