namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
	public class GetSpecialOfferByIdDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string ImageUrl { get; set; }
		public bool IsActive { get; set; }

	}
}
