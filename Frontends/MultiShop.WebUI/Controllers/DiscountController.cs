using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices.CouponServices;

namespace MultiShop.WebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly ICouponService _couponService;
		private readonly IBasketService _basketService;

		public DiscountController(ICouponService couponService, IBasketService basketService)
		{
			_couponService = couponService;
			_basketService = basketService; 
		}

		[HttpPost]
		public async Task<IActionResult> ConfirmCoupon(string code)
		{
			var coupon = await _couponService.GetCouponByCodeAsync(code);

			if (coupon == null || !coupon.IsActive)
			{
				TempData["CouponError"] = "Geçersiz kupon girdiniz.";
				return RedirectToAction("Index", "Basket");
			}

			if (coupon.ExpiryDate < DateTime.Now)
			{
				TempData["CouponError"] = "Tarihi geçmiş kupon girdiniz.";
				return RedirectToAction("Index", "Basket");
			}

			var basket = await _basketService.GetBasketAsync();
			if (basket != null)
			{
				basket.DiscountRate = coupon.DiscountRate;
				basket.DiscountCode = coupon.Code;
				await _basketService.SaveBasketAsync(basket);
			}

			return RedirectToAction("Index", "Basket");
		}

		[HttpGet]
		public async Task<IActionResult> CancelCoupon()
		{
			var basket = await _basketService.GetBasketAsync();

			if (basket != null)
			{
				basket.DiscountCode = "";
				basket.DiscountRate = 0;
				await _basketService.SaveBasketAsync(basket);
			}

			return RedirectToAction("Index", "Basket");
		}
	}
}