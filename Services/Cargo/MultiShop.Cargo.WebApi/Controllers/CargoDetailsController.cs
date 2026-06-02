using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Domain.Entities;
using System.Threading.Tasks;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailsController : ControllerBase
	{
		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailsController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}

		[HttpGet]
		public async Task<IActionResult> CargoDetailList()
		{
			var values = await _cargoDetailService.TGetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCargoDetailById(int id)
		{
			var value = await _cargoDetailService.TGetByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{
			var cargoDetail = new CargoDetail
			{
				SenderCustomer = createCargoDetailDto.SenderCustomer,
				ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
				Barcode = createCargoDetailDto.Barcode,
				CargoCompanyId = createCargoDetailDto.CargoCompanyId
			};

			await _cargoDetailService.TInsertAsync(cargoDetail);
			return Ok("Kargo detayı başarıyla oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCargoDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo detayı başarıyla silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			var cargoDetail = new CargoDetail
			{
				Id = updateCargoDetailDto.Id,
				SenderCustomer = updateCargoDetailDto.SenderCustomer,
				ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
				Barcode = updateCargoDetailDto.Barcode,
				CargoCompanyId = updateCargoDetailDto.CargoCompanyId
			};

			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo detayı başarıyla güncellendi");
		}
	}
}