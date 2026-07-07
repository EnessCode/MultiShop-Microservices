using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class SpecialOffersController : ControllerBase
	{
		private readonly ISpecialOfferService _specialOfferService;

		public SpecialOffersController(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		[HttpGet]
		public async Task<IActionResult> SpecialOfferList()
		{
			var values = await _specialOfferService.GetAllSpecialOffersAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSpecialOfferById(string id)
		{
			var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
			return Ok("Mini vitrin teklifi başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
			return Ok("Mini vitrin teklifi başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			await _specialOfferService.DeleteSpecialOfferAsync(id);
			return Ok("Mini vitrin teklifi başarıyla silindi.");
		}

		[HttpPut("ChangeSpecialOfferStatus")]
		public async Task<IActionResult> ChangeSpecialOfferStatus(string id, bool isActive)
		{
			await _specialOfferService.ChangeSpecialOfferStatusAsync(id, isActive);
			return Ok("Mini vitrin teklifi durumu başarıyla güncellendi.");
		}
	}
}
