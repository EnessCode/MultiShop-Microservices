using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "İletişim Mesajı", string moduleUrl = "/Admin/Contact/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("İletişim Mesajı Listesi");
			var values = await _contactService.GetAllContactsAsync();
			return View(values);
		}

		[HttpGet] 
		public async Task<IActionResult> ChangeReadStatus(string id, bool isRead)
		{
			await _contactService.ChangeIsReadStatusAsync(id, isRead);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteContact(string id)
		{
			await _contactService.DeleteContactAsync(id);
			return RedirectToAction("Index", "Contact", new { area = "Admin" });
		}
	}
}
