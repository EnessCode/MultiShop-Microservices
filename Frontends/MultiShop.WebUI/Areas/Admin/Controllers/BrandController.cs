using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
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
			var values = await _brandService.GetAllBrandsAsync();
			return View(values);
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
			await _brandService.CreateBrandAsync(createBrandDto);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBrand(string id)
		{
			SetBreadcrumb("Marka Güncelle");
			var value = await _brandService.GetBrandByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}
	}
}
