using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Contexts;
using Homify.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;
var configuration = builder.Configuration;

var homifyConnectionString = configuration.GetConnectionString("Homify");
if (string.IsNullOrEmpty(homifyConnectionString))
{
    throw new Exception("Missing Homify connection string");
}

services.AddDbContext<DbContext, HomifyDbContext>(options => options.UseSqlServer(homifyConnectionString));

services.AddScoped<IRepository<User>, UserRepository>();
services.AddScoped<IUserService, UserService>();

services.AddScoped<IRepository<Company>, CompanyRepository>();
services.AddScoped<ICompanyService, CompanyService>();

services.AddScoped<IRepository<Device>, Repository<Device>>();
services.AddScoped<IRepository<Camera>, Repository<Camera>>();
services.AddScoped<IRepository<Sensor>, Repository<Sensor>>();
services.AddScoped<IDeviceService, DeviceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
