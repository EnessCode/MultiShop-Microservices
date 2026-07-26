using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductImageSliderViewComponent : ViewComponent
	{
		private readonly IProductImageService _productImageService;

		public ProductImageSliderViewComponent(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var value = await _productImageService.GetProductImageByProductIdAsync(productId);

			if (value != null)
			{
				var model = new ResultProductImageDto
				{
					Id = value.Id,
					ProductId = value.ProductId,
					Images = value.Images
				};

				return View(model);
			}

			return View(new ResultProductImageDto());
		}
	}
}