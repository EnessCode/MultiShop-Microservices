using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureSlidersController : ControllerBase
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSlidersController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureSliderList()
		{
			var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureSliderById(string id)
		{
			var value = await _featureSliderService.GetFeatureSliderByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
			return Ok("Öne çıkan görsel başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
			return Ok("Öne çıkan görsel başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			await _featureSliderService.DeleteFeatureSliderAsync(id);
			return Ok("Öne çıkan görsel başarıyla silindi.");
		}

		[HttpPut("ChangeFeatureSliderStatus")]
		public async Task<IActionResult> ChangeFeatureSliderStatus(string id, bool isActive)
		{
			await _featureSliderService.ChangeFeatureSliderStatusAsync(id, isActive);
			return Ok("Öne çıkan görsel durumu başarıyla güncellendi.");
		}
	}
}
