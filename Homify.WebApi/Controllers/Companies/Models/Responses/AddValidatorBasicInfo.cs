namespace Homify.WebApi.Controllers.Companies.Models.Responses;

public sealed record class AddValidatorBasicInfo
{
    public string Model { get; set; } = null!;

    public AddValidatorBasicInfo(string str)
    {
        Model = str;
    }
}
