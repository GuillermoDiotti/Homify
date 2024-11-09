using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers;
using Homify.DataAccess.Repositories.Importers.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Importers.Models.Requests;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Importers;

[ApiController]
public sealed class ImporterController : HomifyControllerBase
{
    private readonly IImporterService _importerService;

    public ImporterController(IImporterService importerService)
    {
        _importerService = importerService;
    }

    [HttpPost]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.ImportDevices)]
    public void AddImportedDevices(ImportRequest request)
    {
        // RequestValidator.CheckRequest(request); edify hace un check de null en una clase aparte en el proyecto utilities

        if(request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var user = GetUserLogged();
        ImporterArgs args = new ImporterArgs(
            request.ImporterSelected,
            request.FilePath,
            user);

        // ImporterArgs args = new ImporterArgs(
        //     request.ImporterSelected,
        //     request.FilePath,
        //     request.DllPath);
        _importerService.AddImportedDevices(args, user);
    }
}
