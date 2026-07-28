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

		public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
		{
			var values = await GetBasketAsync();

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
			await SaveBasketAsync(values);
		}

		public async Task DeleteBasketAsync(string userId)
		{
			await _httpClient.DeleteAsync("baskets/" + userId);
		}

		public async Task<BasketTotalDto> GetBasketAsync()
		{
			var responseMessage = await _httpClient.GetAsync("baskets");
			var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
			return values;
		}

		public async Task<bool> RemoveBasketItemAsync(string productId)
		{
			var values = await GetBasketAsync();
			var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
			if (deletedItem != null)
			{
				var result = values.BasketItems.Remove(deletedItem);

				if (result)
				{
					await SaveBasketAsync(values);
					return true;
				}
			}
			return false;
		}

		public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
		{
			await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
		}
	}
}
