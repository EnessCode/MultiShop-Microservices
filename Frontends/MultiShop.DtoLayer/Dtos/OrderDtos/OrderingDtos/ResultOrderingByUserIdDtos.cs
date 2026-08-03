using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.OrderDtos.OrderingDtos
{
	public class ResultOrderingByUserIdDtos
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
