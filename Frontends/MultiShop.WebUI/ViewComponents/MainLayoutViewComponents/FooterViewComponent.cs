using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		private readonly IAboutService _aboutService;

		public FooterViewComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _aboutService.GetAllAboutsAsync();
			return View(values);
		}
	}
}
