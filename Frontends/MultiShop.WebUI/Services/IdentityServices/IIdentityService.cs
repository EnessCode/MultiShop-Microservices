using MultiShop.DtoLayer.Dtos.IdentityDtos.AuthDtos;

namespace MultiShop.WebUI.Services.IdentityServices
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signInDto);
	}
}
