using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.WebUI.Services.IdentityServices;
using MultiShop.WebUI.Services.LoginServices;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
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

builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddHttpClient("CatalogApi", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogApi"]);
});

builder.Services.AddHttpClient("CommentApi", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["ApiSettings:CommentApi"]);
});

builder.Services.AddHttpClient("IdentityApi", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["ApiSettings:IdentityApi"]);
});

builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Index}/{id?}"
);

app.Run();
