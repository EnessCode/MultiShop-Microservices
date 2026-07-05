using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OfferDiscountController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OfferDiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Geniş Kampanya Blokları", string moduleUrl = "/Admin/OfferDiscount/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Kampanya Blokları Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("OfferDiscounts");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultOfferDiscountDto>());
		}

		[HttpGet]
		public IActionResult CreateOfferDiscount()
		{
			SetBreadcrumb("Yeni Kampanya Bloğu Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("OfferDiscounts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}

			return View(createOfferDiscountDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateOfferDiscount(string id)
		{
			SetBreadcrumb("Kampanya Bloğu Güncelle");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("OfferDiscounts/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("OfferDiscounts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}
			return View(updateOfferDiscountDto);
		}

		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("OfferDiscounts/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}
	}
}
