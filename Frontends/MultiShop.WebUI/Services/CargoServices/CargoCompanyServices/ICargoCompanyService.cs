using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
	public interface ICargoCompanyService
	{
		Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();
		Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(string id);
		Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
		Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
		Task DeleteCargoCompanyAsync(string id);
	}
}
