using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactsController(IContactService ContactService)
		{
			_contactService = ContactService;
		}

		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			var values = await _contactService.GetAllContactsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetContactById(string id)
		{
			var value = await _contactService.GetContactByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			await _contactService.CreateContactAsync(createContactDto);
			return Ok("İletişim mesajı başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			await _contactService.UpdateContactAsync(updateContactDto);
			return Ok("İletişim mesajı başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			await _contactService.DeleteContactAsync(id);
			return Ok("İletişim mesajı başarıyla silindi.");
		}

		[HttpPatch("ChangeReadStatus/{id}")]
		public async Task<IActionResult> ChangeReadStatus(string id, [FromBody] bool isRead)
		{
			await _contactService.ChangeIsReadStatusAsync(id, isRead);
			return Ok("İletişim mesajının okundu durumu güncellendi.");
		}
	}
}
