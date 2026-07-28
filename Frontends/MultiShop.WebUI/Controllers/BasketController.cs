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
			var item = new BasketItemDto
			{
				ProductId = product.Id,
				ProductName = product.Name,
				ProductImageUrl = product.ImageUrl,
				Price = product.Price,
				Quantity = 1
			};
			await _basketService.AddBasketItemAsync(item);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> RemoveBasketItem(string id)
		{
			await _basketService.RemoveBasketItemAsync(id);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> UpdateQuantity(string id, int change)
		{
			var basket = await _basketService.GetBasketAsync();
			if (basket == null) return Json(new { success = false });

			var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == id);
			if (item != null)
			{
				item.Quantity += change;

				if (item.Quantity <= 0)
				{
					basket.BasketItems.Remove(item); 
				}

				await _basketService.SaveBasketAsync(basket);
			}
			else
			{
				return Json(new { success = false });
			}

			decimal subTotal = basket.TotalPrice;
			decimal discountRate = !string.IsNullOrEmpty(basket.DiscountCode) ? basket.DiscountRate : 0;

			decimal discountAmount = subTotal * discountRate / 100;
			decimal totalAfterDiscount = subTotal - discountAmount;

			decimal freeShippingLimit = 500;
			decimal shippingFee = 49.90m;

			decimal shipping = (totalAfterDiscount > 0 && totalAfterDiscount < freeShippingLimit) ? shippingFee : 0;
			decimal grandTotal = totalAfterDiscount + shipping;
			decimal amountLeft = freeShippingLimit - totalAfterDiscount;

			decimal itemTotal = (item != null && item.Quantity > 0) ? (item.Price * item.Quantity) : 0;
			int newQuantity = item != null ? item.Quantity : 0;

			return Json(new
			{
				success = true,
				isRemoved = newQuantity <= 0,
				newQuantity = newQuantity,
				itemTotal = itemTotal.ToString("N2"),
				subTotal = subTotal.ToString("N2"),
				discountAmount = discountAmount.ToString("N2"),
				shippingText = shipping == 0 ? "Bedava" : "+ " + shipping.ToString("N2") + " TL",
				grandTotal = grandTotal.ToString("N2"),
				totalAfterDiscount = totalAfterDiscount,
				amountLeft = amountLeft.ToString("N2"),
				freeShippingLimit = freeShippingLimit,
				hasDiscount = discountAmount > 0
			});
		}
	}
}
