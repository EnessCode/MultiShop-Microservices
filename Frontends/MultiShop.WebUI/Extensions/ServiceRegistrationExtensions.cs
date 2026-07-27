using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.AddressServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.ClientCredentialTokenServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.IdentityServices;
using MultiShop.WebUI.Services.LoginServices;
using MultiShop.WebUI.Services.UserServices;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Extensions
{
	public static class ServiceRegistrationExtensions
	{
		public static void AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
			services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));
		}

		public static void AddCustomAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
				{
					opt.LoginPath = "/Index/Auth";
					opt.LogoutPath = "/Auth/Logout";
					opt.AccessDeniedPath = "/Pages/AccessDenied";
					opt.Cookie.HttpOnly = true;
					opt.Cookie.SameSite = SameSiteMode.Strict;
					opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
					opt.Cookie.Name = "MultiShopCookie";
				});

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
				{
					opt.LoginPath = "/Index/Auth";
					opt.LogoutPath = "/Auth/Logout";
					opt.AccessDeniedPath = "/Pages/AccessDenied";
					opt.Cookie.HttpOnly = true;
					opt.Cookie.SameSite = SameSiteMode.Strict;
					opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
					opt.Cookie.Name = "MultiShopCookie";
					opt.ExpireTimeSpan = TimeSpan.FromDays(5);
					opt.SlidingExpiration = true;
				});
		}

		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<ILoginService, LoginService>();
			services.AddScoped<IIdentityService, IdentityService>();

			services.AddTransient<ResourceOwnerPasswordTokenHandler>();
			services.AddTransient<ClientCredentialTokenHandler>();
		}

		public static void AddCustomHttpClients(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient("CatalogApi", client => client.BaseAddress = new Uri(configuration["ApiSettings:CatalogApi"]));
			services.AddHttpClient("CommentApi", client => client.BaseAddress = new Uri(configuration["ApiSettings:CommentApi"]));
			services.AddHttpClient("IdentityApi", client => client.BaseAddress = new Uri(configuration["ApiSettings:IdentityApi"]));

			services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

			var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

			var identityUri = new Uri(values.IdentityServerUrl);
			var basketUri = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
			var catalogUri = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			var commentUri = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");

			services.AddHttpClient<IUserService, UserService>(opt =>
					opt.BaseAddress = identityUri)
				.AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

			services.AddHttpClient<IBasketService, BasketService>(opt =>
					opt.BaseAddress = basketUri)
				.AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

			services.AddHttpClient<ICategoryService, CategoryService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductService, ProductServices>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IFeatureService, FeatureService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IBrandService, BrandService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IAboutService, AboutService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IAddressService, AddressService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IContactService, ContactService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductDetailService, ProductDetailService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductImageService, ProductImageService>(opt => opt.BaseAddress = catalogUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<ICommentService, CommentService>(opt => opt.BaseAddress = commentUri)
				.AddHttpMessageHandler<ClientCredentialTokenHandler>();
		}
	}
}