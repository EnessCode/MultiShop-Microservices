using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
		private readonly IMapper _mapper;

		public OfferDiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_offerDiscountCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
			_mapper = mapper;
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
			await _offerDiscountCollection.InsertOneAsync(value);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _offerDiscountCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
		{
			var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task<GetOfferDiscountByIdDto> GetOfferDiscountByIdAsync(string id)
		{
			var value = await _offerDiscountCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetOfferDiscountByIdDto>(value);
		}

		public async Task ChangeOfferDiscountStatusAsync(string id, bool isActive)
		{
			var value = await _offerDiscountCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			value.IsActive = isActive;
			await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
			await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.Id == updateOfferDiscountDto.Id, value);
		}
	}
}
