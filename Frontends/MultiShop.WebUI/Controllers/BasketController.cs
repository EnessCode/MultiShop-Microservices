using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
	public class BasketController : Controller
	{
		private readonly IProductService _productService;
		private readonly IBasketService _basketService;

		public BasketController(IProductService productService, IBasketService basketService)
		{
			_productService = productService;
			_basketService = basketService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> AddBasketItem(string id)
		{
			var product = await _productService.GetProductByIdAsync(id);
			var items = new BasketItemDto
			{
				ProductId = product.Id,
				ProductName = product.Name,
				ProductImageUrl = product.ImageUrl,
				Price = product.Price,
				Quantity = 1
			};
			await _basketService.AddBasketItem(items);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> RemoveBasketItem(string id)
		{
			await _basketService.RemoveBasketItem(id);
			return RedirectToAction("Index");
		}
	}
}
