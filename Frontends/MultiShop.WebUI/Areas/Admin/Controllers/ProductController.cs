using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Models.ProductViewModels;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IProductDetailService _productDetailService;
		private readonly IProductImageService _productImageService;

		public ProductController(
			IProductService productService,
			ICategoryService categoryService,
			IProductDetailService productDetailService,
			IProductImageService productImageService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_productDetailService = productDetailService;
			_productImageService = productImageService;
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
			var values = await _productService.GetAllProductsAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> ProductListWithCategory()
		{
			SetBreadcrumb("Ürün Listesi");
			var values = await _productService.GetProductsWithCategoryAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			SetBreadcrumb("Yeni Ürün Ekle");
			var values = await _categoryService.GetAllCategoriesAsync();
			List<SelectListItem> categoryValues = (from x in values
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id
												   }).ToList();

			ViewBag.CategoryValues = categoryValues;
			return View(new CreateProductCompositeViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCompositeViewModel model)
		{
			await _productService.CreateProductAsync(new CreateProductDto
			{
				Name = model.Name,
				Price = model.Price,
				ImageUrl = model.ImageUrl,
				CategoryId = model.CategoryId,
				Description = model.Description
			});

			var allProducts = await _productService.GetAllProductsAsync();
			var createdProduct = allProducts
				.Where(x => x.Name == model.Name && x.CategoryId == model.CategoryId)
				.OrderByDescending(x => x.Id)
				.FirstOrDefault();

			if (createdProduct != null)
			{
				await _productDetailService.CreateProductDetailAsync(new CreateProductDetailDto
				{
					ProductId = createdProduct.Id,
					Description = model.Description,
					Information = model.Information
				});

				if (model.GalleryImages != null && model.GalleryImages.Any())
				{
					model.GalleryImages.RemoveAll(string.IsNullOrWhiteSpace);

					if (model.GalleryImages.Any())
					{
						await _productImageService.CreateProductImageAsync(new CreateProductImageDto
						{
							ProductId = createdProduct.Id,
							Images = model.GalleryImages
						});
					}
				}
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			SetBreadcrumb("Ürün Güncelle");
			var value = await _categoryService.GetAllCategoriesAsync();
			List<SelectListItem> categoryValues = (from x in value
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id
												   }).ToList();

			ViewBag.CategoryValues = categoryValues;
			var productValues = await _productService.GetProductByIdAsync(id);
			return View(productValues);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _productService.UpdateProductAsync(updateProductDto);
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProductAsync(id);
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}
	}
}
