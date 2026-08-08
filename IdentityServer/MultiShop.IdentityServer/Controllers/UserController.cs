using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName)]
	[Route("api/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet("me")]
		public async Task<IActionResult> GetCurrentUser()
		{
			var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

			var user = await _userManager.FindByIdAsync(userClaim.Value);

			if (user == null)
				return NotFound(); 

			return Ok(new
			{
				Id = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Email = user.Email,
				UserName = user.UserName
			});
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _userManager.Users
				.Select(user => new
				{
					Id = user.Id,
					Name = user.Name,
					Surname = user.Surname,
					Email = user.Email,
					UserName = user.UserName
				})
				.ToListAsync(); 

			return Ok(users);
		}
	}
}
