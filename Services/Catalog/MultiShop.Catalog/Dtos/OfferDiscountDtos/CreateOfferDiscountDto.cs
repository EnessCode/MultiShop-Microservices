namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
	public class CreateOfferDiscountDto
	{
		public string Label { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool IsActive { get; set; }
	}
}
