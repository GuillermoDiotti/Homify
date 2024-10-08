using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.HomeOwners.Models;

public sealed record class CreateHomeOwnerResponse
{
    public string Id { get; init; }

    public CreateHomeOwnerResponse(User u)
    {
        Id = u.Id;
    }
}
