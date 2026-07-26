using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductDetailDescriptionViewComponent : ViewComponent
	{
		private readonly IProductDetailService _productDetailService;

		public ProductDetailDescriptionViewComponent(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var value = await _productDetailService.GetProductDetailByProductIdAsync(productId);

			if (value != null)
			{
				var model = new ResultProductDetailDto
				{
					Id = value.Id,
					ProductId = value.ProductId,
					Description = value.Description,
					Information = value.Information
				};

				return View(model);
			}

			return View(new ResultProductDetailDto());
		}
	}
}
