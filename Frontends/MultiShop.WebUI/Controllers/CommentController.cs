using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
		{
			var client = _httpClientFactory.CreateClient("CommentApi");
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Comments", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductId });
			}

			return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductId });
		}
	}
}