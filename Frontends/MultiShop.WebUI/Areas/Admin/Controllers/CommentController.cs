using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Yorumlar", string moduleUrl = "/Admin/Comment/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Yorum Listesi");

			var client = _httpClientFactory.CreateClient("CommentApi");
			var responseMessage = await client.GetAsync("Comments");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultCommentDto>());
		}

		[HttpGet]
		public async Task<IActionResult> UpdateComment(int id)
		{
			SetBreadcrumb("Yorum Güncelle");

			var client = _httpClientFactory.CreateClient("CommentApi");
			var responseMessage = await client.GetAsync("Comments/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
		{
			var client = _httpClientFactory.CreateClient("CommentApi");
			var jsonData = JsonConvert.SerializeObject(updateCommentDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("Comments", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Comment", new { area = "Admin" });
			}
			return View(updateCommentDto);
		}

		public async Task<IActionResult> DeleteComment(int id)
		{
			var client = _httpClientFactory.CreateClient("CommentApi");
			var responseMessage = await client.DeleteAsync("Comments/" + id);

			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}
	}
}
