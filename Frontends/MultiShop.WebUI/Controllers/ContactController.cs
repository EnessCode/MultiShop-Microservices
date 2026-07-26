using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using System;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContactDto)
		{
			createContactDto.IsRead = false;
			createContactDto.CreatedDate = DateTime.Now;
			await _contactService.CreateContactAsync(createContactDto);
			return RedirectToAction("Index", "Home");
		}
	}
}