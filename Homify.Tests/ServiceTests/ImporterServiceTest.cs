using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;
using FluentAssertions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Users.Entities;
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
        var importerMock = new Mock<ImporterInterface>();
        importerMock.Setup(i => i.GetName()).Returns("ValidImporter");
        importerMock.Setup(i => i.ImportDevices(It.IsAny<string>())).Returns(new List<ReturnImportDevices>());

        var list = new List<ImporterInterface> { importerMock.Object };

        var user = new User();
        var args = new ImporterArgs("ValidImporter", "somePath", user);

        _importerServiceMock.Setup(i => i.GetAllImporters()).Returns(list);

        _importerService.AddImportedDevices(args, user);

        importerMock.Verify(i => i.ImportDevices(args.Path), Times.Once);
    }

    [TestMethod]
    public void Transformation_WithValidDevices_ShouldTransformAndAddDevices()
    {
        var user = new User { Id = "userId" };
        var companyOwner = new CompanyOwner { Id = "companyId" };

        var devices = new List<ReturnImportDevices>
        {
            new ReturnImportDevices
            {
                Name = "Device1",
                Model = "Model1",
                Id = "DeviceId1",
                Type = "camera",
                PersonDetection = true,
                MovementDetection = true,
                Photos = new List<ReturnPhotos>
                {
                    new ReturnPhotos { Path = "photo1.jpg", IsPrincipal = true },
                    new ReturnPhotos { Path = "photo2.jpg", IsPrincipal = false }
                }
            }
        };

        _companyOwnerServiceMock.Setup(s => s.GetById(user.Id)).Returns(companyOwner);

        _importerService.Transformation(devices, user);

        _deviceServiceMock.Verify(s => s.AddCamera(It.Is<CreateDeviceArgs>(d =>
            d.Name == "Device1" &&
            d.Model == "Model1" &&
            d.Id == "DeviceId1" &&
            d.Type == "camera" &&
            d.PeopleDetection == true &&
            d.MovementDetection == true &&
            d.Description == "importado" &&
            d.PpalPicture == "photo1.jpg" &&
            d.Photos.Contains("photo1.jpg") &&
            d.Photos.Contains("photo2.jpg")
        ), companyOwner), Times.Once);
    }
}
