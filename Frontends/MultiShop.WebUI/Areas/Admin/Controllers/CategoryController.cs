using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Kategoriler", string moduleUrl = "/Admin/Category/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Kategori Listesi");
			var values = await _categoryService.GetAllCategoriesAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			SetBreadcrumb("Yeni Kategori Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			await _categoryService.CreateCategoryAsync(createCategoryDto);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCategory(string id)
		{
			SetBreadcrumb("Kategori Güncelle");
			var value = await _categoryService.GetCategoryByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDto);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}
	}
}