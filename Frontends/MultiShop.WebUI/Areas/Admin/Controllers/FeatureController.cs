using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Öne Çıkan Özellikler", string moduleUrl = "/Admin/Feature/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Öne Çıkan Özellik Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Features");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultFeatureDto>());
		}

		[HttpGet]
		public IActionResult CreateFeature()
		{
			SetBreadcrumb("Yeni Öne Çıkan Özellik Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Features", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}

			return View(createFeatureDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			SetBreadcrumb("Öne Çıkan Özellik Güncelle");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Features/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "Feature", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("Features", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View(updateFeatureDto);
		}

		public async Task<IActionResult> DeleteFeature(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("Features/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return RedirectToAction("Index", "Feature", new { area = "Admin" });
		}
	}
}