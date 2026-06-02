using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Domain.Entities;
using System.Threading.Tasks;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomersController : ControllerBase
	{
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}

		[HttpGet]
		public async Task<IActionResult> CargoCustomerList()
		{
			var values = await _cargoCustomerService.TGetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCargoCustomerById(int id)
		{
			var value = await _cargoCustomerService.TGetByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			var cargoCustomer = new CargoCustomer
			{
				Name = createCargoCustomerDto.Name,
				Surname = createCargoCustomerDto.Surname,
				Email = createCargoCustomerDto.Email,
				Phone = createCargoCustomerDto.Phone,
				Address = createCargoCustomerDto.Address,
				City = createCargoCustomerDto.City,
				District = createCargoCustomerDto.District
			};

			await _cargoCustomerService.TInsertAsync(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo müşterisi başarıyla silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
		{
			var cargoCustomer = new CargoCustomer
			{
				Id = updateCargoCustomerDto.Id,
				Name = updateCargoCustomerDto.Name,
				Surname = updateCargoCustomerDto.Surname,
				Email = updateCargoCustomerDto.Email,
				Phone = updateCargoCustomerDto.Phone,
				Address = updateCargoCustomerDto.Address,
				City = updateCargoCustomerDto.City,
				District = updateCargoCustomerDto.District
			};

			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla güncellendi");
		}
	}
}