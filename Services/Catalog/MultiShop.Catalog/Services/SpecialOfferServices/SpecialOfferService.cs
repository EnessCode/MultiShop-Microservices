using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
		private readonly IMapper _mapper;

		public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
			_mapper = mapper;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
			await _specialOfferCollection.InsertOneAsync(value);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _specialOfferCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
		{
			var values = await _specialOfferCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultSpecialOfferDto>>(values);
		}

		public async Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id)
		{
			var value = await _specialOfferCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetSpecialOfferByIdDto>(value);
		}

		public async Task ChangeSpecialOfferStatusAsync(string id, bool isActive)
		{
			var value = await _specialOfferCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			value.IsActive = isActive;
			await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
			await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id == updateSpecialOfferDto.Id, value);
		}
	}
}
