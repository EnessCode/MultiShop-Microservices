using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductImageSliderViewComponent : ViewComponent
	{
		private readonly IProductImageService _productImageService;
		private readonly IProductService _productService;

		public ProductImageSliderViewComponent(IProductImageService productImageService, IProductService productService)
		{
			_productImageService = productImageService;
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var model = new ResultProductImageDto
			{
				ProductId = productId,
				Images = new List<string>()
			};

			var product = await _productService.GetProductByIdAsync(productId);

			if (product != null && !string.IsNullOrWhiteSpace(product.ImageUrl))
			{
				model.Images.Add(product.ImageUrl);
			}

			var gallery = await _productImageService.GetProductImageByProductIdAsync(productId);

			if (gallery != null && gallery.Images != null && gallery.Images.Any())
			{
				model.Images.AddRange(gallery.Images);
			}

			return View(model);
		}
	}
}
