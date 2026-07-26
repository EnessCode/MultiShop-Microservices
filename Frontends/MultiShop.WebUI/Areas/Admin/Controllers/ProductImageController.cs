using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductImageController : Controller
	{
		private readonly IProductImageService _productImageService;

		public ProductImageController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
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

			var value = await _productImageService.GetProductImageByProductIdAsync(productId);

			if (value != null)
			{
				var model = new ResultProductImageDto
				{
					Id = value.Id,
					ProductId = value.ProductId,
					Images = value.Images
				};

				return View(model);
			}

			return View(new ResultProductImageDto());
		}

		[HttpGet]
		public IActionResult CreateProductImage(string productId)
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

			var existingGallery = await _productImageService.GetProductImageByProductIdAsync(createProductImageDto.ProductId);

			if (existingGallery != null && !string.IsNullOrEmpty(existingGallery.Id))
			{
				if (existingGallery.Images == null)
					existingGallery.Images = new List<string>();

				existingGallery.Images.AddRange(createProductImageDto.Images);

				await _productImageService.UpdateProductImageAsync(existingGallery);
			}
			else
			{
				await _productImageService.CreateProductImageAsync(createProductImageDto);
			}

			return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = createProductImageDto.ProductId });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProductImage(string id)
		{
			SetBreadcrumb("Görsel Galeri Güncelle");

			var value = await _productImageService.GetProductImageByIdAsync(id);
			if (value != null)
			{
				return View(value);
			}

			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
		{
			await _productImageService.UpdateProductImageAsync(updateProductImageDto);
			return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = updateProductImageDto.ProductId });
		}

		public async Task<IActionResult> DeleteProductImage(string id, string imageUrl)
		{
			var values = await _productImageService.GetProductImageByIdAsync(id);

			if (values != null && values.Images != null)
			{
				values.Images.Remove(imageUrl);
				await _productImageService.UpdateProductImageAsync(values);

				return RedirectToAction("ProductImageDetail", "ProductImage", new { area = "Admin", productId = values.ProductId });
			}

			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}
	}
}
