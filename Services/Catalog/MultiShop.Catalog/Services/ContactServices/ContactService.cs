using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
	public class ContactService : IContactService
	{
		private readonly IMongoCollection<Contact> _contactCollection;
		private readonly IMapper _mapper;

		public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
			_mapper = mapper;
		}

		public async Task ChangeIsReadStatusAsync(string id, bool isRead)
		{
			var value = Builders<Contact>.Update.Set(x => x.IsRead, isRead);
			await _contactCollection.UpdateOneAsync(x => x.Id == id, value);
		}

		public async Task CreateContactAsync(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			await _contactCollection.InsertOneAsync(value);
		}

		public async Task DeleteContactAsync(string id)
		{
			await _contactCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultContactDto>> GetAllContactsAsync()
		{
			var values = await _contactCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultContactDto>>(values);
		}

		public async Task<GetContactByIdDto> GetContactByIdAsync(string id)
		{
			var value = await _contactCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetContactByIdDto>(value);
		}

		public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
		{
			var value = _mapper.Map<Contact>(updateContactDto);
			await _contactCollection.FindOneAndReplaceAsync(x => x.Id == updateContactDto.Id, value);
		}
	}
}
