using MultiShop.DtoLayer.Dtos.IdentityDtos.AuthDtos;

namespace MultiShop.WebUI.Services.IdentityServices.AuthServices
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signInDto);
		Task<bool> GetRefreshToken();
	}
}
