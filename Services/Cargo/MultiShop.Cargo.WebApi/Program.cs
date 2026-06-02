using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Application.Interfaces.Repositories;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Application.Services.Concrete;
using MultiShop.Cargo.Persistence.Context;
using MultiShop.Cargo.Persistence.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.Authority = builder.Configuration["IdentityServerUrl"];
	options.Audience = "ResourceCargo";
	options.RequireHttpsMetadata = false;
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
builder.Services.AddScoped<ICargoCustomerRepository, CargoCustomerRepository>();
builder.Services.AddScoped<ICargoDetailRepository, CargoDetailRepository>();
builder.Services.AddScoped<ICargoOperationRepository, CargoOperationRepository>();

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CargoContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
