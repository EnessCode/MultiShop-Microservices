using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationsController : ControllerBase
	{
		private readonly ICargoOperationService _cargoOperationService;

		public CargoOperationsController(ICargoOperationService cargoOperationService)
		{
			_cargoOperationService = cargoOperationService;
		}

		[HttpGet]
		public async Task<IActionResult> CargoOperationList()
		{
			var values = await _cargoOperationService.TGetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCargoOperationById(int id)
		{
			var value = await _cargoOperationService.TGetByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			var cargoOperation = new CargoOperation
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = DateTime.Now 
			};

			await _cargoOperationService.TInsertAsync(cargoOperation);
			return Ok("Kargo işlemi/hareketi başarıyla oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCargoOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo işlemi/hareketi başarıyla silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			var cargoOperation = new CargoOperation
			{
				Id = updateCargoOperationDto.Id,
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate
			};

			_cargoOperationService.TUpdate(cargoOperation);
			return Ok("Kargo işlemi/hareketi başarıyla güncellendi");
		}
	}
}