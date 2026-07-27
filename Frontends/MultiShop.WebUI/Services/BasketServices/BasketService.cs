using MultiShop.DtoLayer.Dtos.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
	public class BasketService : IBasketService
	{
		private readonly HttpClient _httpClient;

		public BasketService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task AddBasketItem(BasketItemDto basketItemDto)
		{
			var values = await GetBasket();

			if (values == null)
			{
				values = new BasketTotalDto
				{
					BasketItems = new List<BasketItemDto>()
				};
			}

			var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
			if (existingItem != null)
			{
				existingItem.Quantity += basketItemDto.Quantity;
			}
			else
			{
				values.BasketItems.Add(basketItemDto);
			}
			await SaveBasket(values);
		}

		public async Task DeleteBasket(string userId)
		{
			await _httpClient.DeleteAsync("baskets/" + userId);
		}

		public async Task<BasketTotalDto> GetBasket()
		{
			var responseMessage = await _httpClient.GetAsync("baskets");
			var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
			return values;
		}

		public async Task<bool> RemoveBasketItem(string productId)
		{
			var values = await GetBasket();
			var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
			if (deletedItem != null)
			{
				var result = values.BasketItems.Remove(deletedItem);

				if (result)
				{
					await SaveBasket(values);
					return true;
				}
			}
			return false;
		}

		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
		}
	}
}
