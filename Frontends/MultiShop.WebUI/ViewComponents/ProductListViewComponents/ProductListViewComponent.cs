using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class ProductListViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductListViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string categoryId)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Products/category/" + categoryId);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultProductWithCategoryDto>());
		}
	}
}
