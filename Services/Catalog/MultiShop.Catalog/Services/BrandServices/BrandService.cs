using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
	public class BrandService : IBrandService
	{
		private readonly IMongoCollection<Brand> _brandCollection;
		private readonly IMapper _mapper;

		public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
			_mapper = mapper;
		}

		public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
		{
			var value = _mapper.Map<Brand>(createBrandDto);
			await _brandCollection.InsertOneAsync(value);
		}

		public async Task DeleteBrandAsync(string id)
		{
			await _brandCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
		{
			var values = await _brandCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultBrandDto>>(values);
		}

		public async Task<GetBrandByIdDto> GetBrandByIdAsync(string id)
		{
			var value = await _brandCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetBrandByIdDto>(value);
		}

		public async Task ChangeBrandStatusAsync(string id, bool isActive)
		{
			var value = await _brandCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			value.IsActive = isActive;
			await _brandCollection.FindOneAndReplaceAsync(x => x.Id == id, value);
		}

		public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
		{
			var value = _mapper.Map<Brand>(updateBrandDto);
			await _brandCollection.FindOneAndReplaceAsync(x => x.Id == updateBrandDto.Id, value);
		}
	}
}
