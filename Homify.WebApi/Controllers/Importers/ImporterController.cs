using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Permissions;
using Homify.Utility;
using Homify.WebApi.Controllers.Importers.Models.Requests;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Importers;

[ApiController]
[Route("importers")]
public sealed class ImporterController : HomifyControllerBase
{
    private readonly IImporterService _importerService;

    public ImporterController(IImporterService importerService)
    {
        _importerService = importerService;
    }

    [HttpPost]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateCompany)]
    public void AddImportedDevices(ImportRequest request)
    {
        Helpers.ValidateRequest(request);

        var user = GetUserLogged();
        var args = new BusinessLogic.Importers.Entities.ImporterArgs(
            request.ImporterSelected,
            request.FilePath,
            user);

        _importerService.AddImportedDevices(args, user);
    }

    [HttpGet]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateCompany)]
    public List<string> ObtainImporters()
    {
        return _importerService
            .GetAll()
            .Select(x => x.GetName())
            .ToList();
    }

    [HttpGet("validators")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateCompany)]
    public List<string> GetAllValidators()
    {
        return _importerService
            .GetAllValidators()
            .Select(v => v.GetType().Name)
            .ToList();
    }
}
