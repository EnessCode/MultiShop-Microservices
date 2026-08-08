using MultiShop.DtoLayer.Dtos.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models.UserViewModels;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.IdentityServices.UserServices
{
	public class UserService : IUserService
	{

		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UserDetailViewModel> GetUserInfoAsync()
		{
			return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("api/users/me");
		}

		public async Task<List<ResultUserDto>> GetAllUserListAsync()
		{
			var responseMessage = await _httpClient.GetAsync("api/users");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDto>>();
			return values;
		}
	}
}
