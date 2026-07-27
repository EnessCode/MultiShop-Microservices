using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using System.Threading.Tasks;

namespace MultiShop.Basket.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly ILoginService _loginService;

		public BasketsController(IBasketService basketService, ILoginService loginService)
		{
			_basketService = basketService;
			_loginService = loginService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMyBasketDetail()
		{
			var user = User.Claims;
			var userId = _loginService.GetUserId;
			var values = await _basketService.GetBasket(userId);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
		{
			basketTotalDto.UserId = _loginService.GetUserId;
			await _basketService.SaveBasket(basketTotalDto);
			return Ok("Sepetteki değişiklikler başarıyla kaydedildi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBasket(string id)
		{
			await _basketService.DeleteBasket(id);
			return Ok("Sepet başarıyla silindi.");
		}
	}
}
