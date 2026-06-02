using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Domain.Entities;
using System.Threading.Tasks;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompaniesController : ControllerBase
	{
		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public async Task<IActionResult> CargoCompanyList()
		{
			var values = await _cargoCompanyService.TGetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCargoCompanyById(int id)
		{
			var value = await _cargoCompanyService.TGetByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{
			var cargoCompany = new CargoCompany
			{
				Name = createCargoCompanyDto.Name 
			};

			await _cargoCompanyService.TInsertAsync(cargoCompany);
			return Ok("Kargo firması başarıyla oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCargoCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo firması başarıyla silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			var cargoCompany = new CargoCompany
			{
				Id = updateCargoCompanyDto.Id,
				Name = updateCargoCompanyDto.Name // Entity'deki Name alanıyla eşledik
			};

			_cargoCompanyService.TUpdate(cargoCompany);
			return Ok("Kargo firması başarıyla güncellendi");
		}
	}
}