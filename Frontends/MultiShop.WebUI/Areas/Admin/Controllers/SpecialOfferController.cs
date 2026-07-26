using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SpecialOfferController : Controller
	{
		private readonly ISpecialOfferService _specialOfferService;

		public SpecialOfferController(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Mini Vitrin Teklifleri", string moduleUrl = "/Admin/SpecialOffer/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Mini Vitrin Teklif Listesi");
			var values = await _specialOfferService.GetAllSpecialOffersAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSpecialOffer()
		{
			SetBreadcrumb("Yeni Mini Teklif Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
		{
			SetBreadcrumb("Mini Teklif Güncelle");
			var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			await _specialOfferService.DeleteSpecialOfferAsync(id);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}
	}
}
