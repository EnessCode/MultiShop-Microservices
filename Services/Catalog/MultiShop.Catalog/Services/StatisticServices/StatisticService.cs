using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly IMongoCollection<Product> _productCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMongoCollection<Brand> _brandCollection;

		public StatisticService(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
			_brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
		}

		public async Task<long> GetBrandCountAsync()
		{
			return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
		}

		public async Task<long> GetCategoryCountAsync()
		{
			return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
		}

		public async Task<long> GetProductCountAsync()
		{
			return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
		}

		public async Task<string> GetMaxPriceProductNameAsync()
		{
			var product = await _productCollection.Find(FilterDefinition<Product>.Empty)
															  .SortByDescending(x => x.Price)
															  .FirstOrDefaultAsync();

			return product.Name;
		}

		public async Task<string> GetMinPriceProductNameAsync()
		{
			var product = await _productCollection.Find(FilterDefinition<Product>.Empty)
															  .SortBy(x => x.Price)
															  .FirstOrDefaultAsync();
			return product.Name;
		}

		public async Task<decimal> GetProductAveragePriceAsync()
		{
			return await _productCollection.AsQueryable().AverageAsync(x => x.Price);
		}
	}
}
