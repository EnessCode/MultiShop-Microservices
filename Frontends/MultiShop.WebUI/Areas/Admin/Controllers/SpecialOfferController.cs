using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SpecialOfferController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SpecialOfferController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Mini Vitrin Teklifleri", string moduleUrl = "/Admin/SpecialOffer/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Mini Vitrin Teklif Listesi");

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("SpecialOffers");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultSpecialOfferDto>());
		}

		[HttpGet]
		public IActionResult CreateSpecialOffer()
		{
			SetBreadcrumb("Yeni Mini Teklif Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("SpecialOffers", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}

			return View(createSpecialOfferDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
		{
			SetBreadcrumb("Mini Teklif Güncelle");

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("SpecialOffers/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("SpecialOffers", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View(updateSpecialOfferDto);
		}

		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.DeleteAsync("SpecialOffers/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}
	}
}
