using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly HttpClient _httpClient;

		public SpecialOfferService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ChangeSpecialOfferStatusAsync(string id, bool isActive)
		{
			await _httpClient.PutAsync("specialoffers/ChangeSpecialOfferStatus?id=" + id + "&isActive=" + isActive, null);
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _httpClient.PostAsJsonAsync("specialoffers", createSpecialOfferDto);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _httpClient.DeleteAsync("specialoffers/" + id);
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
		{
			var responseMessage = await _httpClient.GetAsync("specialoffers");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
			return values;
		}

		public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
			return value;
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _httpClient.PutAsJsonAsync("specialoffers", updateSpecialOfferDto);
		}
	}
}
