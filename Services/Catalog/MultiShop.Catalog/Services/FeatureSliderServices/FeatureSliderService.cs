using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
		private readonly IMapper _mapper;

		public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
			await _featureSliderCollection.InsertOneAsync(value);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _featureSliderCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task ChangeFeatureSliderStatusAsync(string id, bool isActive)
		{
			var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync(); 
			value.IsActive = isActive;
			await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
		{
			var values = await _featureSliderCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureSliderDto>>(values);
		}

		public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
		{
			var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetFeatureSliderByIdDto>(value);
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
			await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderDto.Id, value);
		}
	}
}
