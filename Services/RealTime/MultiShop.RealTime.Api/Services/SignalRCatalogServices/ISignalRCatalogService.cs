namespace MultiShop.RealTime.Api.Services.SignalRCatalogServices
{
	public interface ISignalRCatalogService
	{
		Task<int> GetCategoryCountAsync();
		Task<int> GetProductCountAsync();
		Task<int> GetBrandCountAsync();
		Task<decimal> GetProductAveragePriceAsync();
	}
}
