using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OfferDiscountController : Controller
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Geniş Kampanya Blokları", string moduleUrl = "/Admin/OfferDiscount/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Kampanya Blokları Listesi");
			var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateOfferDiscount()
		{
			SetBreadcrumb("Yeni Kampanya Bloğu Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateOfferDiscount(string id)
		{
			SetBreadcrumb("Kampanya Bloğu Güncelle");
			var value = await _offerDiscountService.GetOfferDiscountByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			await _offerDiscountService.DeleteOfferDiscountAsync(id);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}
	}
}
