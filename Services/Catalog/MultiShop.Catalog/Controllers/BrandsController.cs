using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _brandService.GetAllBrandsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrandById(string id)
		{
			var value = await _brandService.GetBrandByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
			await _brandService.CreateBrandAsync(createBrandDto);
			return Ok("Marka başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return Ok("Marka başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);
			return Ok("Marka başarıyla silindi.");
		}

		[HttpPut("ChangeBrandStatus")]
		public async Task<IActionResult> ChangeBrandStatus(string id, bool isActive)
		{
			await _brandService.ChangeBrandStatusAsync(id, isActive);
			return Ok("Marka durumu başarıyla güncellendi.");
		}
	}
}
