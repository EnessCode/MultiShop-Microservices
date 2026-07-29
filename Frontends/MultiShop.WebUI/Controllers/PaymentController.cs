using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
	public class PaymentController : Controller
	{
		public IActionResult Index(string cardNumber, string cardName, string cardExpiry, string cardCvv)
		{
			return View();
		}
	}
}
