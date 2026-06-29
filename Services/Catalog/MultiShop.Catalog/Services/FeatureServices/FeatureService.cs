using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
	public class FeatureService : IFeatureService
	{
		private readonly IMongoCollection<Feature> _featureCollection;
		private readonly IMapper _mapper;

		public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
		{
			var value = _mapper.Map<Feature>(createFeatureDto);
			await _featureCollection.InsertOneAsync(value);
		}

		public async Task DeleteFeatureAsync(string id)
		{
			await _featureCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
		{
			var values = await _featureCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureDto>>(values);
		}

		public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
		{
			var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetFeatureByIdDto>(value);
		}

		public async Task ChangeFeatureStatusAsync(string id, bool isActive)
		{
			var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			value.IsActive = isActive;
			await _featureCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
		}

		public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
		{
			var value = _mapper.Map<Feature>(updateFeatureDto);
			await _featureCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureDto.Id, value);
		}
	}
}
