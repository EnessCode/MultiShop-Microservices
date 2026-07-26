using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class FeatureViewComponent : ViewComponent
	{
		private readonly IFeatureService _featureService;

		public FeatureViewComponent(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _featureService.GetAllFeaturesAsync();
			return View(values);
		}
	}
}
