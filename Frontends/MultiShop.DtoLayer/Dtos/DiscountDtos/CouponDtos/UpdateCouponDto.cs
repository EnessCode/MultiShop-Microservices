using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.DiscountDtos.CouponDtos
{
	public class UpdateCouponDto
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public int DiscountRate { get; set; }
		public bool IsActive { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
