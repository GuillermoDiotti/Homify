namespace Homify.WebApi.Controllers.Importers.Models.Requests;

public sealed record class ImportRequest
{
    public string ImporterSelected { get; init; } = null!;

    public string FilePath { get; init; } = null!;

    public string DllPath { get; init; } = null!;
}
