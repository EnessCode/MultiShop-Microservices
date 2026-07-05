using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductDetailFeatureViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductDetailFeatureViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Products/" + productId);
			var product = JsonConvert.DeserializeObject<UpdateProductDto>(await responseMessage.Content.ReadAsStringAsync());

			var commentClient = _httpClientFactory.CreateClient("CommentApi");
			var commentResponse = await commentClient.GetAsync("Comments/product/" + productId);
			var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(await commentResponse.Content.ReadAsStringAsync());

			ViewBag.ReviewCount = comments?.Count ?? 0;
			ViewBag.AverageRating = comments != null && comments.Count > 0 ? comments.Average(x => x.Rating) : 0;

			return View(product);
		}
	}
}
