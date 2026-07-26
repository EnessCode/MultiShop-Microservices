using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
	public interface IContactService
	{
		Task<List<ResultContactDto>> GetAllContactsAsync();
		Task<UpdateContactDto> GetContactByIdAsync(string id);
		Task CreateContactAsync(CreateContactDto createContactDto);
		Task UpdateContactAsync(UpdateContactDto updateContactDto);
		Task DeleteContactAsync(string id);
		Task ChangeIsReadStatusAsync(string id, bool isRead);
	}
}
