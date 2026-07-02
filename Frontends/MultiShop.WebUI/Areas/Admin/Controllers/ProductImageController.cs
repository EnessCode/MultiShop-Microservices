using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductImageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductImageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Ürün Görselleri", string moduleUrl = "/Admin/ProductImage/ProductImageDetail")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> ProductImageDetail(string productId)
		{
			SetBreadcrumb("Ürün Görselleri");
			ViewBag.ProductId = productId;

			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var responseMessage = await client.GetAsync("ProductImages/product/" + productId);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultProductImageDto>(jsonData);
				return View(values);
			}

			return View(new ResultProductImageDto());
		}

		[HttpGet]
		public async Task<IActionResult> CreateProductImage(string productId)
		{
			SetBreadcrumb("Yeni Görsel Ekle");

			var model = new CreateProductImageDto { ProductId = productId };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
		{
			createProductImageDto.Images?.RemoveAll(string.IsNullOrWhiteSpace);

			if (createProductImageDto.Images == null || !createProductImageDto.Images.Any())
			{
				SetBreadcrumb("Yeni Görsel Ekle");
				return View(createProductImageDto);
			}

			var client = _httpClientFactory.CreateClient("MultiShopApi");

			var checkResponse = await client.GetAsync("ProductImages/product/" + createProductImageDto.ProductId);

			if (checkResponse.IsSuccessStatusCode)
			{
				var jsonCheckData = await checkResponse.Content.ReadAsStringAsync();
				var existingGallery = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonCheckData);

				if (existingGallery != null && !string.IsNullOrEmpty(existingGallery.Id))
				{
					if (existingGallery.Images == null)
						existingGallery.Images = new List<string>();

					existingGallery.Images.AddRange(createProductImageDto.Images);

					var updateJson = JsonConvert.SerializeObject(existingGallery);
					StringContent updateContent = new StringContent(updateJson, Encoding.UTF8, "application/json");

					var putResponse = await client.PutAsync("ProductImages", updateContent);
					if (putResponse.IsSuccessStatusCode)
					{
						return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = createProductImageDto.ProductId });
					}
				}
			}

			var jsonData = JsonConvert.SerializeObject(createProductImageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("ProductImages", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = createProductImageDto.ProductId });
			}

			SetBreadcrumb("Yeni Görsel Ekle");
			return View(createProductImageDto);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProductImage(string id)
		{
			SetBreadcrumb("Görsel Galeri Güncelle");

			var client = _httpClientFactory.CreateClient("MultiShopApi");

			var responseMessage = await client.GetAsync("ProductImages/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");
			var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("ProductImages", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = updateProductImageDto.ProductId });
			}
			return View(updateProductImageDto);
		}

		public async Task<IActionResult> DeleteProductImage(string id, string imageUrl)
		{
			var client = _httpClientFactory.CreateClient("MultiShopApi");

			var responseMessage = await client.GetAsync("ProductImages/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);

				if (values != null && values.Images != null)
				{
					values.Images.Remove(imageUrl);

					var updateJson = JsonConvert.SerializeObject(values);
					StringContent stringContent = new StringContent(updateJson, Encoding.UTF8, "application/json");
					await client.PutAsync("ProductImages", stringContent);

					return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = values.ProductId });
				}
			}

			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}
	}
}
