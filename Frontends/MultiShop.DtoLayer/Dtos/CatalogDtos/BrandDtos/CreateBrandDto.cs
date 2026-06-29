using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos
{
	public class CreateBrandDto
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public bool IsActive { get; set; }
	}
}
