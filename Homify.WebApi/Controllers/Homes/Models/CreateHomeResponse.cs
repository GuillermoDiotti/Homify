using Homify.BusinessLogic.Homes.Entities;

namespace Homify.WebApi.Controllers.Homes.Models;

public class CreateHomeResponse
{
    public string Id { get; set; }
    public CreateHomeResponse(Home home)
    {
        Id = home.Id;
    }
}
