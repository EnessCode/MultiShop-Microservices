using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AddressController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AddressController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Adres Bilgisi", string moduleUrl = "/Admin/Address/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Adres Bilgisi Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Addresses");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultAddressDto>());
		}

		[HttpGet]
		public IActionResult CreateAddress()
		{
			SetBreadcrumb("Yeni Adres Bilgisi Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(createAddressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Addresses", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Address", new { area = "Admin" });
			}

			return View(createAddressDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateAddress(string id)
		{
			SetBreadcrumb("Adres Bilgisi Güncelle");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Addresses/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAddressDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index", "Address", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(updateAddressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("Addresses", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Address", new { area = "Admin" });
			}
			return View(updateAddressDto);
		}

		public async Task<IActionResult> DeleteAddress(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("Addresses/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Address", new { area = "Admin" });
			}
			return RedirectToAction("Index", "Address", new { area = "Admin" });
		}
	}
}
