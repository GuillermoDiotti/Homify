namespace Homify.WebApi.Controllers.Importers.Models.Requests;

public class ImportRequest
{
    public string ImporterSelected { get; init; } = null!;

    public string FilePath { get; init; } = null!;
}
