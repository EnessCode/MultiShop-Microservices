using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureSliderController : Controller
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSliderController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Öne Çıkan Görseller", string moduleUrl = "/Admin/FeatureSlider/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Öne Çıkan Görsel Listesi");
			var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateFeatureSlider()
		{
			SetBreadcrumb("Yeni Öne Çıkan Görsel Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{
			SetBreadcrumb("Öne Çıkan Görsel Güncelle");
			var value = await _featureSliderService.GetFeatureSliderByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			await _featureSliderService.DeleteFeatureSliderAsync(id);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}
	}
}