using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureService _featureService;

		public FeaturesController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await _featureService.GetAllFeaturesAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureById(string id)
		{
			var value = await _featureService.GetFeatureByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return Ok("Öne çıkan özellik başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);
			return Ok("Öne çıkan özellik başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteFeatureAsync(id);
			return Ok("Öne çıkan özellik başarıyla silindi.");
		}

		[HttpPut("ChangeFeatureStatus")]
		public async Task<IActionResult> ChangeFeatureStatus(string id, bool isActive)
		{
			await _featureService.ChangeFeatureStatusAsync(id, isActive);
			return Ok("Öne çıkan özellik durumu başarıyla güncellendi.");
		}
	}
}
