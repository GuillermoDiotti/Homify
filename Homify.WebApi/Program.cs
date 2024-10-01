using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Contexts;
using Homify.DataAccess.Repositories;
using Homify.WebApi.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options => { options.Filters.Add<ExceptionFilter>(); });

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

services.AddScoped<IRepository<Session>, SessionRepository>();
services.AddScoped<ISessionService, SessionService>();

services.AddScoped<IRepository<Role>, RoleRepository>();
services.AddScoped<IRoleService, RoleService>();

services.AddScoped<AuthenticationFilterAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
