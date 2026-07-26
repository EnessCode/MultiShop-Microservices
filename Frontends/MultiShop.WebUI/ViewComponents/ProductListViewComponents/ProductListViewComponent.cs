using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class ProductListViewComponent : ViewComponent
	{
		private readonly IProductService _productService;

		public ProductListViewComponent(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string categoryId)
		{
			var values = await _productService.GetProductsByCategoryIdAsync(categoryId);
			return View(values);
		}
	}
}
