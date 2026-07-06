using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents
{
	public class ContactAddressViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactAddressViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient("CatalogApi");
			var responseMessage = await client.GetAsync("Addresses");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData);
				return View(values.FirstOrDefault());
			}

			return View(new ResultAddressDto());
		}
	}
}