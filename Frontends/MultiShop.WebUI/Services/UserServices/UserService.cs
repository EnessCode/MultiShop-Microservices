using MultiShop.WebUI.Models.UserViewModels;

namespace MultiShop.WebUI.Services.UserServices
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UserDetailViewModel> GetUserInfo()
		{
			return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("user/getuser");
		}
	}
}
