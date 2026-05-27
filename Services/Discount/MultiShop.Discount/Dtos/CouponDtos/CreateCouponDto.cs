namespace MultiShop.Discount.Dtos.CouponDtos
{
	public class CreateCouponDto
	{
		public string Code { get; set; }
		public int DiscountRate { get; set; }
		public bool IsActive { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
