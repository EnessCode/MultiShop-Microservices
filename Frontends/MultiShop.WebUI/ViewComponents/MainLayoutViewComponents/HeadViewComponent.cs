using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class HeadViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
