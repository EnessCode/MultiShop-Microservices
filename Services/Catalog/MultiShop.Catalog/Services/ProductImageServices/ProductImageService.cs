using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _productImageCollection;
		private readonly IMapper _mapper;

		public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			var value = _mapper.Map<ProductImage>(createProductImageDto);
			await _productImageCollection.InsertOneAsync(value);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _productImageCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
		{
			var values = await _productImageCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id)
		{
			var value = await _productImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<GetProductImageByIdDto>(value);
		}

		public async Task<GetProductImageByIdDto> GetProductImageByProductIdAsync(string productId)
		{
			var value = await _productImageCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
			return _mapper.Map<GetProductImageByIdDto>(value);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			var value = _mapper.Map<ProductImage>(updateProductImageDto);
			await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageDto.Id, value);
		}
	}
}
