using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class VendorViewComponent : ViewComponent
	{
		private readonly IBrandService _brandService;

		public VendorViewComponent(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _brandService.GetAllBrandsAsync();
			return View(values);
		}
	}
}
