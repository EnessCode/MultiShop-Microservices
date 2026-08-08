using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CargoController : Controller
	{
		private readonly ICargoCompanyService _cargoCompanyService;
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoController(ICargoCompanyService cargoCompanyService, ICargoCustomerService cargoCustomerService)
		{
			_cargoCompanyService = cargoCompanyService;
			_cargoCustomerService = cargoCustomerService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _cargoCompanyService.GetAllCargoCompaniesAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateCargoCompany()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{
			await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
			return RedirectToAction("Index", "Cargo", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCargoCompany(string id)
		{
			var value = await _cargoCompanyService.GetCargoCompanyByIdAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
			return RedirectToAction("Index", "Cargo", new { area = "Admin" });
		}

		public async Task<IActionResult> DeleteCargoCompany(string id)
		{
			await _cargoCompanyService.DeleteCargoCompanyAsync(id);
			return RedirectToAction("Index", "Cargo", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> AddressInfo(string id)
		{
			var value = await _cargoCustomerService.GetCargoCustomerByIdAsync(id);
			return View(value);
		}
	}
}
