using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
	public class CargoCompanyService : ICargoCompanyService
	{
		private readonly HttpClient _httpClient;

		public CargoCompanyService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
		{
			await _httpClient.PostAsJsonAsync("cargocompanies", createCargoCompanyDto);
		}

		public async Task DeleteCargoCompanyAsync(string id)
		{
			await _httpClient.DeleteAsync("cargocompanies/" + id);
		}

		public async Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("cargocompanies/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
			return value;
		}

		public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("cargocompanies");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
			return values;
		}

		public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			await _httpClient.PutAsJsonAsync("cargocompanies", updateCargoCompanyDto);
		}
	}
}
