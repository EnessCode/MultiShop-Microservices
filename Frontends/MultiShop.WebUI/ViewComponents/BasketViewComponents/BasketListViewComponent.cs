using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.BasketViewComponents
{
	public class BasketListViewComponent : ViewComponent
	{
		private readonly IBasketService _basketService;

		public BasketListViewComponent(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var basketTotal = await _basketService.GetBasket();
			var basketItems = basketTotal.BasketItems;
			return View(basketItems);
		}
	}
}
