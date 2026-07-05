using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductDetailReviewViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductDetailReviewViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var client = _httpClientFactory.CreateClient("CommentApi");
			var responseMessage = await client.GetAsync("Comments/product/" + productId);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultCommentDto>());
		}
	}
}
