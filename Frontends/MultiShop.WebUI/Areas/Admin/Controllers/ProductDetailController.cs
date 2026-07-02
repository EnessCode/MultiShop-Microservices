using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductDetailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductDetailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		private void SetBreadcrumb(string activePage, string moduleName = "Ürün Detayı", string moduleUrl = "/Admin/ProductDetail/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProductDetail(string id)
		{
			SetBreadcrumb("Ürün Detayı Güncelle");

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("ProductDetails/product/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("ProductDetails", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return View(updateProductDetailDto);
		}
	}
}
