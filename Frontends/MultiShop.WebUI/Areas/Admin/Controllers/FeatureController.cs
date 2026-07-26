using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Öne Çıkan Özellikler", string moduleUrl = "/Admin/Feature/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Öne Çıkan Özellik Listesi");
			var values = await _featureService.GetAllFeaturesAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateFeature()
		{
			SetBreadcrumb("Yeni Öne Çıkan Özellik Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return RedirectToAction("Index", "Feature", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			SetBreadcrumb("Öne Çıkan Özellik Güncelle");
			var value = await _featureService.GetFeatureByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);
			return RedirectToAction("Index", "Feature", new { area = "Admin" });

		}

		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteFeatureAsync(id);
			return RedirectToAction("Index", "Feature", new { area = "Admin" });
		}
	}
}
