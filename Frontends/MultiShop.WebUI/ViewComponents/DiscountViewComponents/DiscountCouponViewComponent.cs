using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DiscountViewComponents
{
	public class DiscountCouponViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
