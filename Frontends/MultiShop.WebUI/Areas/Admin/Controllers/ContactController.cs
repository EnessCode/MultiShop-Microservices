using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "İletişim Mesajı", string moduleUrl = "/Admin/Contact/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("İletişim Mesajı Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Contacts");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultContactDto>());
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeReadStatus(string id, [FromBody] bool isRead)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var content = new StringContent(JsonConvert.SerializeObject(isRead), Encoding.UTF8, "application/json");
			var responseMessage = await client.PatchAsync($"Contacts/ChangeReadStatus/{id}", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return Ok();
			}
			return BadRequest();
		}

		public async Task<IActionResult> DeleteContact(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("Contacts/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Contact", new { area = "Admin" });
			}
			return RedirectToAction("Index", "Contact", new { area = "Admin" });
		}
	}
}
