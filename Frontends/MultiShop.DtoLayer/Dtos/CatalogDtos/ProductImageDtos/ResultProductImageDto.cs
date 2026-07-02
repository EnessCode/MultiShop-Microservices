using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos
{
	public class ResultProductImageDto
	{
		public string Id { get; set; }
		public List<string> Images { get; set; }
		public string ProductId { get; set; }
	}
}
