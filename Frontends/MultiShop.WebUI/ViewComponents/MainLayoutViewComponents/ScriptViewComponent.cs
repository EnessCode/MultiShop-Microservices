using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class ScriptViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
