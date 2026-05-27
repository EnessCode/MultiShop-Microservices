namespace MultiShop.Discount.Dtos.CouponDtos
{
	public class GetCouponByIdDto
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public int DiscountRate { get; set; }
		public bool IsActive { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
