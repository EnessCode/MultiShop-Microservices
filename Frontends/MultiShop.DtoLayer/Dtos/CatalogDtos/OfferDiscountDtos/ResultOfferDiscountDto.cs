using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos
{
	public class ResultOfferDiscountDto
	{
		public string Id { get; set; }
		public string Label { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool IsActive { get; set; }
	}
}
