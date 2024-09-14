using Homify.BusinessLogic.Admins.Entities;

namespace Homify.WebApi.Controllers.Admins.Models;

public class CreateAdminResponse
{
    public string Id { get; init; }

    public CreateAdminResponse(Admin admin)
    {
        Id = admin.Id;
    }
}
