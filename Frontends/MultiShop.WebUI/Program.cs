using MultiShop.WebUI.Extensions; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomSettings(builder.Configuration);

builder.Services.AddCustomServices();

builder.Services.AddCustomHttpClients(builder.Configuration);

builder.Services.AddCustomAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
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