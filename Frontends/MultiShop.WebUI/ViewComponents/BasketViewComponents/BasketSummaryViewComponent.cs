using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.BasketViewComponents
{
	public class BasketSummaryViewComponent : ViewComponent
	{
		private readonly IBasketService _basketService;

		public BasketSummaryViewComponent(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var basketTotal = await _basketService.GetBasketAsync();
			return View(basketTotal);
		}
	}
}
