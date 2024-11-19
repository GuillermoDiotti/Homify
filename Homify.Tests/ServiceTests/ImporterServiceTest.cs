using System.Reflection;
using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Importers.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Importer.Abstractions;
using InterfaceImporter.Models;
using ModeloValidador.Abstracciones;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class ImporterServiceTest
{
    private ImporterService? _importerService;
    private Mock<IImporterService>? _importerServiceMock;
    private Mock<IDeviceService>? _deviceServiceMock;
    private Mock<ICompanyOwnerService>? _companyOwnerServiceMock;
    private string validatorpath;
    public ImporterServiceTest()
    {
        _importerServiceMock = new Mock<IImporterService>();
        _deviceServiceMock = new Mock<IDeviceService>();
        _companyOwnerServiceMock = new Mock<ICompanyOwnerService>();
        _importerService = new ImporterService(_deviceServiceMock.Object, _companyOwnerServiceMock.Object);
        validatorpath = "path";
    }

    [TestInitialize]
    public void TestSetup()
    {
        validatorpath = Path.Combine(AppContext.BaseDirectory, "Validators");
        if (!Directory.Exists(validatorpath))
        {
            Directory.CreateDirectory(validatorpath);
        }

        File.WriteAllText(Path.Combine(validatorpath, "FakeValidator.dll"), "Fake content");

        var importersPath = Path.Combine(AppContext.BaseDirectory, "Importers");
        if (!Directory.Exists(importersPath))
        {
            Directory.CreateDirectory(importersPath);
        }

        var fakeDllPath = Path.Combine(importersPath, "FakeImporter.dll");
        if (!File.Exists(fakeDllPath))
        {
            File.WriteAllText(fakeDllPath, "Fake content");
        }
    }

    public ImporterService? ImporterService { get => _importerService; set => _importerService = value; }
    public Mock<IImporterService>? ImporterServiceMock { get => _importerServiceMock; set => _importerServiceMock = value; }
    public Mock<IDeviceService>? DeviceServiceMock { get => _deviceServiceMock; set => _deviceServiceMock = value; }
    public Mock<ICompanyOwnerService>? CompanyOwnerServiceMock { get => _companyOwnerServiceMock; set => _companyOwnerServiceMock = value; }

    [TestMethod]
    [ExpectedException(typeof(BadImageFormatException))]
    public void AddImportedDevices_WithValidImporterName_ShouldReturn()
    {
        var importerMock = new Mock<IImporter>();
        importerMock.Setup(i => i.GetName()).Returns("ValidImporter");
        importerMock.Setup(i => i.ImportDevices(It.IsAny<string>())).Returns([]);

        var validatorMock = new Mock<IModeloValidador>();
        validatorMock
            .Setup(v => v.EsValido(It.IsAny<Modelo>()))
            .Returns(true);
        var list = new List<IImporter> { importerMock.Object };

        var ImportationContainer = new List<ImportationContainer>{ new ImportationContainer{ Devices = new List<ImportedDevices>()} };
        var importedDevices = new ImportedDevices
        {
            Id = "id", Model = "model", Name = "name",
            Photos = new List<ImportPhotos>(), Type = "type", PersonDetection = true, MovementDetection = true
        };

        var user = new User();
        var args = new ImporterArgs("ValidImporter", validatorpath, user);
        var company = new Company{ValidatorType = validatorMock.Object.ToString()};
        var owner = new CompanyOwner{ Company = company };
        _companyOwnerServiceMock.Setup(i => i.GetById(user.Id)).Returns(owner);
        _importerServiceMock.Setup(i => i.GetAllImporters()).Returns(list);

        _importerService.AddImportedDevices(args, user);
    }

    [TestMethod]
    public void Transformation_WithValidDevices_ShouldTransformAndAddDevices()
    {
        var user = new User { Id = "userId" };
        var companyOwner = new CompanyOwner { Id = "companyId" };
        var importationDevice = new List<ImportedDevices>()
        {
            new ImportedDevices()
            {
                Id = "DeviceId1",
                Model = "Model1",
                Name = "Device1",
                Type = "camera",
                PersonDetection = true,
                MovementDetection = true,
                Photos = new List<ImportPhotos>
                {
                    new ImportPhotos { Path = "photo1.jpg", IsPrincipal = true },
                    new ImportPhotos { Path = "photo2.jpg", IsPrincipal = false }
                }
            }
        };
        var importationContainer = new ImportationContainer { Devices = importationDevice };
        var importedPhotos = new ImportPhotos{ Path = "photo1.jpg", IsPrincipal = true };
        var devices = new List<ReturnImportDevices>
        {
            new ReturnImportDevices
            {
                Name = importationDevice[0].Name,
                Model = importationDevice[0].Model,
                Id = importationDevice[0].Id,
                Type = importationDevice[0].Type,
                PersonDetection = importationDevice[0].PersonDetection,
                MovementDetection = importationDevice[0].MovementDetection,
                Photos =
                [
                    new ReturnPhotos { Path = importedPhotos.Path, IsPrincipal = importedPhotos.IsPrincipal},
                    new ReturnPhotos { Path = "photo2.jpg", IsPrincipal = false }
                ]
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
            d.Photos.Contains("photo2.jpg")), companyOwner), Times.Once);
    }

    [TestMethod]
    public void AddImportedDeviceByType_WhenDeviceTypeIsSensorMovement_CallsAddMovementSensor()
    {
        var device = new CreateDeviceArgs { Type = "sensor-movement" };
        var user = new CompanyOwner();

        _importerService.AddImportedDeviceByType(device, user);

        _deviceServiceMock.Verify(ds => ds.AddMovementSensor(device, user), Times.Once);
    }

    [TestMethod]
    public void AddImportedDeviceByType_WhenDeviceTypeIsSensorOpenClose_CallsAddWindowSensor()
    {
        var device = new CreateDeviceArgs { Type = "sensor-open-close" };
        var user = new CompanyOwner();

        _importerService.AddImportedDeviceByType(device, user);

        _deviceServiceMock.Verify(ds => ds.AddWindowSensor(device, user), Times.Once);
    }

    [ExpectedException(typeof(ArgsNullException))]
    [TestMethod]
    public void ImporterArgs_WhenImporterNull_ThrowsException()
    {
        var args = new ImporterArgs(null, "path", new User());
    }
}

