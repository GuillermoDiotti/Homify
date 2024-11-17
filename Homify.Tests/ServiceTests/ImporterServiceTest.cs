using System.Reflection;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Importers;
using Homify.BusinessLogic.Importers.Entities;
using Homify.BusinessLogic.Users.Entities;
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

    public ImporterServiceTest()
    {
        _importerServiceMock = new Mock<IImporterService>();
        _deviceServiceMock = new Mock<IDeviceService>();
        _companyOwnerServiceMock = new Mock<ICompanyOwnerService>();
        _importerService = new ImporterService(_deviceServiceMock.Object, _companyOwnerServiceMock.Object);
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

        var list = new List<IImporter> { importerMock.Object };

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
                Photos =
                [
                    new ReturnPhotos { Path = "photo1.jpg", IsPrincipal = true },
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
    public void GetAllValidators_ShouldReturnValidators_WhenDllExists()
    {
        var mockValidator1 = new Mock<IModeloValidador>().Object;
        var mockValidator2 = new Mock<IModeloValidador>().Object;

        var mockAssembly = new Mock<Assembly>();
        mockAssembly
            .Setup(a => a.GetTypes())
            .Returns([mockValidator1.GetType(), mockValidator2.GetType()]);

        var rutaDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib", "ModeloValidador.dll");
        File.Create(rutaDll).Dispose();

        var mockFile = new Mock<FileInfo>(rutaDll);
        var mockPath = new Mock<string>();
        var mockAssemblyLoadFrom = new Mock<Func<string, Assembly>>();
        mockAssemblyLoadFrom.Setup(f => f(It.IsAny<string>())).Returns(mockAssembly.Object);

        var assembly = Assembly.LoadFrom(rutaDll);

        var result = assembly.GetTypes()
            .Where(t => typeof(IModeloValidador).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(tipo => (IModeloValidador)Activator.CreateInstance(tipo)!)
            .ToList();

        File.Delete(rutaDll);
    }
}
