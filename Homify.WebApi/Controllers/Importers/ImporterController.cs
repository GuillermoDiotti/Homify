using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Permissions;
using Homify.Exceptions;
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
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateCompany)]
    public void AddImportedDevices(ImportRequest request)
    {
        if(request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var user = GetUserLogged();
        var args = new BusinessLogic.Importers.Entities.ImporterArgs(
            request.ImporterSelected,
            request.FilePath,
            user);

        _importerService.AddImportedDevices(args, user);
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateCompany)]
    public List<string> ObtainImporters()
    {
        return _importerService
            .GetAllImporters()
            .Select(x => x.GetName())
            .ToList();
    }

    [HttpGet("validators")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateCompany)]
    public List<string> GetAllValidators()
    {
        return _importerService
            .GetAllValidators()
            .Select(v => v.GetType().Name)
            .ToList();
    }
}
