using Homify.BusinessLogic.Homes.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public sealed record class CreateHomeResponse
{
    public string Id { get; set; }
    public CreateHomeResponse(Home home)
    {
        Id = home.Id;
    }
}
