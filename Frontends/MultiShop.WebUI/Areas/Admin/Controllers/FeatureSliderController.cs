using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureSliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureSliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Öne Çıkan Görseller", string moduleUrl = "/Admin/FeatureSlider/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Öne Çıkan Görsel Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("FeatureSliders");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultFeatureSliderDto>());
		}

		[HttpGet]
		public IActionResult CreateFeatureSlider()
		{
			SetBreadcrumb("Yeni Öne Çıkan Görsel Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("FeatureSliders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}

			return View(createFeatureSliderDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{
			SetBreadcrumb("Öne Çıkan Görsel Güncelle");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("FeatureSliders/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("FeatureSliders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}
			return View(updateFeatureSliderDto);
		}

		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("FeatureSliders/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}
	}
}