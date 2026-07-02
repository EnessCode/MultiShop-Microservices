namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
	public class GetProductImageByIdDto
	{
		public string Id { get; set; }
		public List<string> Images { get; set; }
		public string ProductId { get; set; }
	}
}
