using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class SpecialOfferViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SpecialOfferViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("SpecialOffers");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultSpecialOfferDto>());
		}
	}
}
