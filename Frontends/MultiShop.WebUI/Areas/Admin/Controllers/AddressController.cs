using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;
using MultiShop.WebUI.Services.CatalogServices.AddressServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;

		public AddressController(IAddressService addressService)
		{
			_addressService = addressService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Adres Bilgisi", string moduleUrl = "/Admin/Address/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Adres Bilgisi Listesi");
			var values = await _addressService.GetAllAddressesAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateAddress()
		{
			SetBreadcrumb("Yeni Adres Bilgisi Ekle");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
		{
			await _addressService.CreateAddressAsync(createAddressDto);
			return RedirectToAction("Index", "Address", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateAddress(string id)
		{
			SetBreadcrumb("Adres Bilgisi Güncelle");
			var value = await _addressService.GetAddressByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
		{
			await _addressService.UpdateAddressAsync(updateAddressDto);
			return RedirectToAction("Index", "Address", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteAddress(string id)
		{
			await _addressService.DeleteAddressAsync(id);
			return RedirectToAction("Index", "Address", new { area = "Admin" });
		}
	}
}
