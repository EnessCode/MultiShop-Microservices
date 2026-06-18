using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
