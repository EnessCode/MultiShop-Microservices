using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
	public class ContactService : IContactService
	{
		private readonly HttpClient _httpClient;

		public ContactService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeIsReadStatusAsync(string id, bool isRead)
		{
			await _httpClient.GetAsync($"contacts/ChangeReadStatus/{id}/{isRead}");
		}

		public async Task CreateContactAsync(CreateContactDto createContactDto)
		{
			await _httpClient.PostAsJsonAsync("contacts", createContactDto);
		}

		public async Task DeleteContactAsync(string id)
		{
			await _httpClient.DeleteAsync("contacts/" + id);
		}

		public async Task<List<ResultContactDto>> GetAllContactsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("contacts");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
			return values;
		}

		public async Task<UpdateContactDto> GetContactByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("contacts/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateContactDto>();
			return value;
		}

		public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
		{
			await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
		}
	}
}
