using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;
using FluentAssertions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers;
using Homify.DataAccess.Repositories.Importers.Entities;
using Homify.WebApi.Controllers.Importers;
using InterfaceImporter;
using InterfaceImporter.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class ImporterServiceTest
{
    private ImporterService? _importerService;
    private Mock<IImporterService>? _importerServiceMock;
    private Mock<IDeviceService>? _deviceServiceMock;
    private Mock<ICompanyOwnerService>? _companyOwnerServiceMock;

    public ImporterServiceTest()
    {
        _importerServiceMock = new Mock<IImporterService>();
        _deviceServiceMock = new Mock<IDeviceService>();
        _companyOwnerServiceMock = new Mock<ICompanyOwnerService>();
        _importerService = new ImporterService(_deviceServiceMock.Object, _companyOwnerServiceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(BadImageFormatException))]
    public void AddImportedDevices_WithValidImporterName_ShouldReturn()
    {
        // Arrange
        var importerMock = new Mock<ImporterInterface>();
        importerMock.Setup(i => i.GetName()).Returns("ValidImporter");
        importerMock.Setup(i => i.ImportDevices(It.IsAny<string>())).Returns(new List<ReturnImportDevices>());

        var list = new List<ImporterInterface> { importerMock.Object };

        var user = new User();
        var args = new ImporterArgs("ValidImporter", "somePath", user);

        _importerServiceMock.Setup(i => i.GetAllImporters()).Returns(list);

        // Act
        _importerService.AddImportedDevices(args, user);

        // Assert
        importerMock.Verify(i => i.ImportDevices(args.Path), Times.Once);
    }
}
