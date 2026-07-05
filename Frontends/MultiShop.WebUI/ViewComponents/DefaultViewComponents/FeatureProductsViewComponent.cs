using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class FeatureProductsViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureProductsViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Products");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

				var commentClient = _httpClientFactory.CreateClient("CommentApi");
				var ratings = new Dictionary<string, double>();

				foreach (var product in values)
				{
					var commentResponse = await commentClient.GetAsync("Comments/product/" + product.Id);
					if (commentResponse.IsSuccessStatusCode)
					{
						var commentJson = await commentResponse.Content.ReadAsStringAsync();
						var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(commentJson);
						ratings[product.Id] = comments != null && comments.Count > 0 ? comments.Average(x => x.Rating) : 0;
					}
					else
					{
						ratings[product.Id] = 0;
					}
				}
				ViewBag.Ratings = ratings;
			
				return View(values);
			}

			return View(new List<ResultProductDto>());
		}
	}
}
