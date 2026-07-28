using MultiShop.DtoLayer.Dtos.DiscountDtos.CouponDtos;
using System.Net;

namespace MultiShop.WebUI.Services.DiscountServices.CouponServices
{
	public class CouponService : ICouponService
	{
		private readonly HttpClient _httpClient;

		public CouponService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ResultCouponDto> GetCouponByCodeAsync(string code)
		{
			var responseMessage = await _httpClient.GetAsync("coupons/code/" + code);

			if (responseMessage.IsSuccessStatusCode)
			{
				if (responseMessage.StatusCode == HttpStatusCode.NoContent)
				{
					return null;
				}

				var values = await responseMessage.Content.ReadFromJsonAsync<ResultCouponDto>();
				return values;
			}
			return null;
		}
	}
}
