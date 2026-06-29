using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
	public class ResultProductWithCategoryDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal? OldPrice { get; set; }
		public int DiscountPercentage
		{
			get
			{
				if (OldPrice.HasValue && OldPrice.Value > Price)
				{
					return (int)Math.Round(((OldPrice.Value - Price) / OldPrice.Value) * 100);
				}
				return 0;
			}
		}
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public string CategoryId { get; set; }
		public ResultCategoryDto Category { get; set; }
	}
}
