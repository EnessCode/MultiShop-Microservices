using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Services.LoginServices;

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

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();

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
