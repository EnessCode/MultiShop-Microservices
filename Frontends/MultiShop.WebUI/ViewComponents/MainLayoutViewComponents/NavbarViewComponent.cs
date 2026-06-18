using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class NavbarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
