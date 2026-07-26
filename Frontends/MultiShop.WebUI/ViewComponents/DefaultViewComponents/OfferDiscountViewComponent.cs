using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class OfferDiscountViewComponent : ViewComponent
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountViewComponent(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
			return View(values);
		}
	}
}
