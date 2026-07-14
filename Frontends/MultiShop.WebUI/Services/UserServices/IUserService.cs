using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.UserServices
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfo();
	}
}
