using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Users.Entities;
using Homify.Importer.Abstractions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Importers;
using Homify.WebApi.Controllers.Importers.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloValidador.Abstracciones;
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

    [TestMethod]
    public void ObtainImporters_ReturnsListOfImporters()
    {
        var importers = new List<IImporter>
        {
            new Mock<IImporter>().Object,
            new Mock<IImporter>().Object
        };
        _importerService.Setup(service => service.GetAllImporters()).Returns(importers);

        var result = _importerController.ObtainImporters();

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void GetAllValidators_ShouldReturnValidatorNames()
    {
        var mockValidators = new List<IModeloValidador>
        {
            new Mock<IModeloValidador>().Object,
            new Mock<IModeloValidador>().Object
        };

        _importerService
            .Setup(service => service.GetAllValidators())
            .Returns(mockValidators);

        var result = _importerController.GetAllValidators();

        Assert.IsNotNull(result);
        Assert.AreEqual(mockValidators.Count, result.Count);
        CollectionAssert.AreEqual(mockValidators.Select(v => v.GetType().Name).ToList(), result);
    }
}
