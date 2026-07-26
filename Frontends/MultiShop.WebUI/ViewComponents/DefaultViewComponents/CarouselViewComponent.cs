using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class CarouselViewComponent : ViewComponent
	{
		private readonly IFeatureSliderService _featureSliderService;

		public CarouselViewComponent(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);
		}
	}
}
