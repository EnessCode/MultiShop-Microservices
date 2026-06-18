using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class TopbarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
