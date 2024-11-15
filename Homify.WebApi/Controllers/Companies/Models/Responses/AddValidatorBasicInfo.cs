namespace Homify.WebApi.Controllers.Companies.Models.Responses;

public sealed record class AddValidatorBasicInfo
{
    public string Model { get; set; }

    public AddValidatorBasicInfo(string str)
    {
        Model = str;
    }
}
