using MultiShop.RealTime.Api.Hubs;
using MultiShop.RealTime.Api.Services.SignalRCatalogServices;
using MultiShop.RealTime.Api.Services.SignalRCommentServices;
using MultiShop.RealTime.Api.Services.SignalRDiscountServices;
using MultiShop.RealTime.Api.Services.SignalRMessageServices;
using MultiShop.RealTime.Api.Services.SignalRUserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed(host => true)
				.AllowCredentials();
	});
});

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<ISignalRCommentService, SignalRCommentService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7075/");
});

builder.Services.AddHttpClient<ISignalRMessageService, SignalRMessageService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7076/");
});

builder.Services.AddHttpClient<ISignalRCatalogService, SignalRCatalogService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7070/");
});

builder.Services.AddHttpClient<ISignalRDiscountService, SignalRDiscountService>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7071/");
});

builder.Services.AddHttpClient<ISignalRUserService, SignalRUserService>(client =>
{
	client.BaseAddress = new Uri("http://localhost:5001/");
});

builder.Services.AddControllers();

builder.Services.AddSignalR(options =>
{
	options.EnableDetailedErrors = true; 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalr");

app.Run();
