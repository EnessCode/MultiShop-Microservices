using MultiShop.DtoLayer.Dtos.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models.UserViewModels;

namespace MultiShop.WebUI.Services.IdentityServices.UserServices
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfoAsync();
		Task<List<ResultUserDto>> GetAllUserListAsync();
	}
}
