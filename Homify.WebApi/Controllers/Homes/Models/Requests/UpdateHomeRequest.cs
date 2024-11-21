namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public sealed record class UpdateHomeRequest
{
    public string Alias { get; set; } = null!;
}
