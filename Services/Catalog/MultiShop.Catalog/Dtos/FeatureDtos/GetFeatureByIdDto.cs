namespace MultiShop.Catalog.Dtos.FeatureDtos
{
	public class GetFeatureByIdDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public bool IsActive { get; set; }
	}
}
