using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AddressDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AddressServices
{
	public class AddressService : IAddressService
	{
		private readonly IMongoCollection<Address> _addressCollection;
		private readonly IMapper _mapper;

		public AddressService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_addressCollection = database.GetCollection<Address>(databaseSettings.AddressCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
		{
			var value = _mapper.Map<Address>(createAddressDto);
			await _addressCollection.InsertOneAsync(value);
		}

		public async Task DeleteAddressAsync(string id)
		{
			await _addressCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultAddressDto>> GetAllAddressesAsync()
		{
			var values = await _addressCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultAddressDto>>(values);
		}

		public async Task<GetAddressByIdDto> GetAddressByIdAsync(string id)
		{
			var value = await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetAddressByIdDto>(value);
		}

		public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
		{
			var value = _mapper.Map<Address>(updateAddressDto);
			await _addressCollection.FindOneAndReplaceAsync(x => x.Id == updateAddressDto.Id, value);
		}
	}
}
