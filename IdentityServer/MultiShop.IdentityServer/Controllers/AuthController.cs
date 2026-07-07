using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var values = new ApplicationUser()
			{
				UserName = userRegisterDto.Username,
				Email = userRegisterDto.Email,
				Name = userRegisterDto.Name,
				Surname = userRegisterDto.Surname
			};

			var result = await _userManager.CreateAsync(values, userRegisterDto.Password);

			if (result.Succeeded)
			{
				return Ok("Kullanıcı başarıyla eklendi.");
			}
			else
			{
				var errors = result.Errors.Select(x => x.Description).ToList();
				return BadRequest(errors);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);

			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(userLoginDto.Username);

				GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
				model.Id = user.Id;
				model.UserName = user.UserName;
				var userRoles = await _userManager.GetRolesAsync(user);
				model.Role = userRoles.FirstOrDefault();

				var token = JwtTokenGenerator.GenerateToken(model);
				return Ok(token);
			}
			else
			{
				return Unauthorized("Kullanıcı adı veya şifre hatalı.");
			}
		}
	}
}