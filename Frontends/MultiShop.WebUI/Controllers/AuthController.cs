using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.IdentityDtos.AuthDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.LoginServices;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
	public class AuthController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;

		public AuthController(IHttpClientFactory httpClientFactory, ILoginService loginService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.ActiveTab = "login";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient("IdentityApi");
			var content = new StringContent(JsonConvert.SerializeObject(createLoginDto), Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Auth/login", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var tokenModel = JsonConvert.DeserializeObject<JwtResponeModel>(jsonData, new JsonSerializerSettings
				{
					ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
				});

				if (tokenModel != null && tokenModel.Token != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();

					claims.Add(new Claim("multishoptoken", tokenModel.Token));
					var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
					var authProperties = new AuthenticationProperties
					{
						IsPersistent = true,
						ExpiresUtc = tokenModel.ExpireDate
					};

					await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
					var id = _loginService.GetUserId;
					return RedirectToAction("Index", "Home");
				}
			}

			ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
			ViewBag.ActiveTab = "login";
			return View("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Register(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.ConfirmPassword != createRegisterDto.Password)
			{
				ModelState.AddModelError("", "Şifreler birbiriyle eşleşmiyor.");
				ViewBag.ActiveTab = "register";
				return View("Index");
			}

			var client = _httpClientFactory.CreateClient("IdentityApi");
			var jsonData = JsonConvert.SerializeObject(createRegisterDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("Auth/register", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				TempData["SuccessMessage"] = "Hesabınız başarıyla oluşturuldu. Lütfen giriş yapın.";
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", "Kayıt işlemi başarısız oldu. Lütfen bilgilerinizi kontrol edin.");
			ViewBag.ActiveTab = "register";
			return View("Index");
		}
	}
}
