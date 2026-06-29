using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class BrandController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BrandController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Marka İşlemleri", string moduleUrl = "/Admin/Brand/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Marka Listesi");

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("Brands");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultBrandDto>());
		}

		[HttpGet]
		public IActionResult CreateBrand()
		{
			SetBreadcrumb("Yeni Marka Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(createBrandDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Brands", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}

			return View(createBrandDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBrand(string id)
		{
			SetBreadcrumb("Marka Güncelle");

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("Brands/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(updateBrandDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("Brands", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}
			return View(updateBrandDto);
		}

		public async Task<IActionResult> DeleteBrand(string id)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.DeleteAsync("Brands/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}
	}
}
