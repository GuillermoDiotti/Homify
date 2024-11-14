using System.Text.Json;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Lamps.Entities;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Rooms;
using Homify.BusinessLogic.Rooms.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
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

services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var homifyConnectionString = configuration.GetConnectionString("Homify");
if (string.IsNullOrEmpty(homifyConnectionString))
{
    throw new Exception("Missing Homify connection string");
}

services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

services.AddDbContext<DbContext, HomifyDbContext>(options => options.UseSqlServer(homifyConnectionString));

services.AddScoped<IRepository<UserRole>, UserRoleRepository>();

services.AddScoped<IRepository<User>, UserRepository>();
services.AddScoped<IUserService, UserService>();

services.AddScoped<IRepository<Room>, RoomRepository>();
services.AddScoped<IRoomService, RoomService>();

services.AddScoped<IRepository<Company>, CompanyRepository>();
services.AddScoped<ICompanyService, CompanyService>();

services.AddScoped<IRepository<Device>, DeviceRepository>();

services.AddScoped<IRepository<Camera>, Repository<Camera>>();
services.AddScoped<IRepository<MovementSensor>, Repository<MovementSensor>>();
services.AddScoped<IRepository<Lamp>, Repository<Lamp>>();

services.AddScoped<IRepository<Sensor>, Repository<Sensor>>();
services.AddScoped<IDeviceService, DeviceService>();

services.AddScoped<IRepository<Session>, SessionRepository>();
services.AddScoped<ISessionService, SessionService>();

services.AddScoped<IRepository<Role>, RoleRepository>();
services.AddScoped<IRoleService, RoleService>();

services.AddScoped<IRepository<Home>, HomeRepository>();
services.AddScoped<IHomeService, HomeService>();

services.AddScoped<IRepository<HomeUser>, HomeUserRepository>();
services.AddScoped<IHomeUserService, HomeUserService>();

services.AddScoped<IRepository<HomePermission>, HomePermissionRepository>();
services.AddScoped<IHomePermissionService, HomePermissionService>();

services.AddScoped<IRepository<HomeDevice>, HomeDeviceRepository>();
services.AddScoped<IHomeDeviceService, HomeDeviceService>();

services.AddScoped<IRepository<CompanyOwner>, CompanyOwnerRepository>();
services.AddScoped<ICompanyOwnerService, CompanyOwnerService>();

services.AddScoped<IRepository<Notification>, NotificationRepository>();
services.AddScoped<INotificationService, NotificationService>();

services.AddScoped<IImporterService, ImporterService>();

services.AddScoped<AuthenticationFilterAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("AllowAngularDev");

app.UseAuthorization();

app.MapControllers();

app.Run();
