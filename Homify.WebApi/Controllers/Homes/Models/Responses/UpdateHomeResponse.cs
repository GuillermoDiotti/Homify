using Homify.BusinessLogic.Homes.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public sealed record class UpdateHomeResponse
{
    public string Id { get; set; }
    public string Alias { get; set; }

    public UpdateHomeResponse(Home h)
    {
        Id = h.Id;
        Alias = h.Alias;
    }
}
