using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos
{
	public class ResultFeatureDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public bool IsActive { get; set; }
	}
}
