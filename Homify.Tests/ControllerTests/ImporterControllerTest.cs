using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers;
using Homify.DataAccess.Repositories.Importers.Entities;
using Homify.WebApi;
using Homify.WebApi.Controllers.Importers;
using Homify.WebApi.Controllers.Importers.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class ImporterControllerTest
{
    private Mock<IImporterService>? _importerService;
    private ImporterController? _importerController;

    [TestInitialize]
    public void TestInitialize()
    {
        _importerService = new Mock<IImporterService>();
        _importerController = new ImporterController(_importerService.Object);
    }

    [TestMethod]
    public void AddImportedDevices_ValidRequest_ShouldImport()
    {
        var request = new ImportRequest
        {
            ImporterSelected = "importer",
            FilePath = "path",
        };
        var user = new User { Id = "userId" };
        _importerController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _importerController.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _importerController.AddImportedDevices(request);
    }
}
