using MultiShop.WebUI.Models.UserViewModels;

namespace MultiShop.WebUI.Services.UserServices
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfoAsync();
	}
}
