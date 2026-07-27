namespace MultiShop.WebUI.Models.ProductViewModels
{
	public class CreateProductCompositeViewModel
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal? OldPrice { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public string CategoryId { get; set; }
		public string Information { get; set; }
		public List<string> GalleryImages { get; set; }
	}
}
