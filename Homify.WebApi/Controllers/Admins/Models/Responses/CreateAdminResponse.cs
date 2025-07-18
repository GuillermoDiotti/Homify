using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Admins.Models.Responses;

public class CreateAdminResponse
{
    public string Id { get; init; }

    public CreateAdminResponse(User admin)
    {
        Id = admin.Id;
    }
}
