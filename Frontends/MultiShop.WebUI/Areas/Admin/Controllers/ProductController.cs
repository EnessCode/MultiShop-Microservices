using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
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
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productService.CreateProductAsync(createProductDto);
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