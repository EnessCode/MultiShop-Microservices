using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Ürünler", string moduleUrl = "/Admin/Product/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Ürün Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Products");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultProductWithCategoryDto>());
		}

		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			SetBreadcrumb("Yeni Ürün Ekle");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Categories");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

				List<SelectListItem> categoryValues = (from x in values
													   select new SelectListItem
													   {
														   Text = x.Name,
														   Value = x.Id
													   }).ToList();

				ViewBag.CategoryValues = categoryValues;
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}

			var categoryResponse = await client.GetAsync("Categories");
			if (categoryResponse.IsSuccessStatusCode)
			{
				var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
				var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);
				ViewBag.CategoryValues = (from x in categoryValues
										  select new SelectListItem
										  {
											  Text = x.Name,
											  Value = x.Id
										  }).ToList();
			}

			return View(createProductDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			SetBreadcrumb("Ürün Güncelle");

			var client = _httpClientFactory.CreateClient("CatalogApi");

			var categoryResponse = await client.GetAsync("Categories");
			if (categoryResponse.IsSuccessStatusCode)
			{
				var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
				var categoryData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);
				ViewBag.CategoryValues = (from x in categoryData
										  select new SelectListItem
										  {
											  Text = x.Name,
											  Value = x.Id
										  }).ToList();
			}

			var responseMessage = await client.GetAsync("Products/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return View(updateProductDto);
		}

		public async Task<IActionResult> DeleteProduct(string id)
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.DeleteAsync("Products/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> ProductListWithCategory()
		{
			SetBreadcrumb("Ürün Listesi");

			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Products/with-category");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultProductWithCategoryDto>());
		}
	}
}