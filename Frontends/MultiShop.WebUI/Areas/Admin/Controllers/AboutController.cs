using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Hakkımda", string moduleUrl = "/Admin/About/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Hakkımda Listesi");
			var values = await _aboutService.GetAllAboutsAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateAbout()
		{
			SetBreadcrumb("Yeni Hakkımda Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			await _aboutService.CreateAboutAsync(createAboutDto);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateAbout(string id)
		{
			SetBreadcrumb("Hakkımda Güncelle");
			var value = await _aboutService.GetAboutByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			await _aboutService.UpdateAboutAsync(updateAboutDto);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteAbout(string id)
		{
			await _aboutService.DeleteAboutAsync(id);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}
	}
}