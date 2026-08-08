using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.IdentityServices.UserServices;

namespace MultiShop.WebUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderAddressService _addressService;
		private readonly IUserService _userService;

		public OrderController(IOrderAddressService addressService, IUserService userService)
		{
			_addressService = addressService;
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateUserMessageDtos createOrderAddressDto)
		{
			var values = await _userService.GetUserInfoAsync();
			createOrderAddressDto.UserId = values.Id;

			await _addressService.CreateOrderAddressAsync(createOrderAddressDto);
			return RedirectToAction("Index", "Payment");
		}
	}
}
