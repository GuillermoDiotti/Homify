using FluentAssertions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.WebApi.Controllers.Devices;
using Homify.WebApi.Controllers.Devices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class DeviceControllerTest
{
    private readonly DeviceController _controller;
    private readonly Mock<IDeviceService> _deviceServiceMock;
    private readonly Mock<ICompanyOwnerService> _companyOwnerServiceMock;
    private readonly Mock<IHomeDeviceService> _homeDeviceServiceMock;

    public DeviceControllerTest()
    {
        _companyOwnerServiceMock = new Mock<ICompanyOwnerService>(MockBehavior.Strict);
        _deviceServiceMock = new Mock<IDeviceService>(MockBehavior.Strict);
        _homeDeviceServiceMock = new Mock<IHomeDeviceService>(MockBehavior.Strict);
        _controller = new DeviceController(_deviceServiceMock.Object, _companyOwnerServiceMock.Object, _homeDeviceServiceMock.Object);
        var httpContext = new DefaultHttpContext();
        httpContext.Items["UserLogged"] = new User { };
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };
    }

    [TestMethod]
    public void RegisterCamera_WhenDataIsOk_ShouldRegisterCamera()
    {
        var request = new CreateCameraRequest()
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            IsExterior = false,
            IsInterior = true,
            PpalPicture = "Test"
        };
        var comoany = new Company();
        var expected = new Camera()
        {
            Name = request.Name,
            PpalPicture = request.PpalPicture,
            Company = comoany,
            Description = request.Description,
            Model = request.Model,
            Photos = request.Photos,
            IsExterior = request.IsExterior,
            IsInterior = request.IsInterior,
            CompanyId = comoany.Id
        };

        var args = new CreateDeviceArgs(request.Name, request.Model, request.Description, request.Photos, request.PpalPicture,false,false);

        _deviceServiceMock.Setup(d => d.AddCamera(It.IsAny<CreateDeviceArgs>(), It.IsAny<CompanyOwner>())).Returns(expected);

        var response = _controller.RegisterCamera(request);

        response.Should().NotBeNull();
        response.Id.Should().Be(expected.Id);
        expected.Name.Should().Be(args.Name);
        expected.Model.Should().Be(args.Model);
        expected.Description.Should().Be(args.Description);
        expected.Photos.Should().BeEquivalentTo(args.Photos);
        expected.PpalPicture.Should().Be(args.PpalPicture);
        expected.IsExterior.Should().Be(request.IsExterior);
        expected.IsInterior.Should().Be(request.IsInterior);
        expected.Company.Should().NotBeNull();
    }

    [TestMethod]
    public void RegisterSensor_WhenDataIsOk_ShouldRegisterCamera()
    {
        var request = new CreateSensorRequest()
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            PpalPicture = "Test"
        };
        var expected = new Sensor()
        {
            Name = request.Name,
            PpalPicture = request.PpalPicture,
            Company = new Company(),
            Description = request.Description,
            Model = request.Model,
            Photos = request.Photos,
        };

        var args = new CreateDeviceArgs(request.Name, request.Model, request.Description, request.Photos, request.PpalPicture,false,false);

        _deviceServiceMock.Setup(d => d.AddSensor(It.IsAny<CreateDeviceArgs>(),It.IsAny<CompanyOwner>())).Returns(expected);

        var response = _controller.RegisterSensor(request);

        response.Should().NotBeNull();
        response.Id.Should().Be(expected.Id);
        expected.Name.Should().Be(args.Name);
        expected.Model.Should().Be(args.Model);
        expected.Description.Should().Be(args.Description);
        expected.Photos.Should().BeEquivalentTo(args.Photos);
        expected.PpalPicture.Should().Be(args.PpalPicture);
        expected.Company.Should().NotBeNull();
    }

    [TestMethod]
    public void ObtainDevices_ReturnsListOfDevices_WhenValidParamsProvided()
    {
        var deviceList = new List<Device>
        {
            new Device { Id = "1", Name = "Camera 1", Model = "Model A", PpalPicture = "photo1.jpg", Company = new Company { Name = "Company A" }},
            new Device { Id = "2", Name = "Sensor 1", Model = "Model B", PpalPicture = "photo2.jpg", Company = new Company { Name = "Company B" }},
            new Device { Id = "3", Name = "Camera 2", Model = "Model C", PpalPicture = null, Company = new Company { Name = "Company A" }}
        };

        _deviceServiceMock
            .Setup(service => service.SearchDevices(It.IsAny<SearchDevicesArgs>()))
            .Returns(deviceList);

        var result = _controller.ObtainDevices("Camera", null, null, null, null, null);

        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("Camera 1", result[0].Name);
        Assert.AreEqual("Model A", result[0].Model);
        Assert.AreEqual("photo1.jpg", result[0].Photo);
        Assert.AreEqual("Company A", result[0].CompanyName);
        Assert.AreEqual("Camera 2", result[2].Name);
        Assert.AreEqual(string.Empty, result[2].Photo);
        _deviceServiceMock.Verify(service => service.SearchDevices(It.IsAny<SearchDevicesArgs>()), Times.Once);
    }

    [TestMethod]
    public void ObtainSupportedDevices_ShouldReturnCorrectSupportedDevicesResponse()
    {
        var devices = new List<string> { "DeviceTypeA", "DeviceTypeB", "DeviceTypeC" };
        _deviceServiceMock.Setup(service => service.SearchSupportedDevices()).Returns(devices);

        var result = _controller.ObtainSupportedDevices();

        result.Count.Should().Be(3);
        result.Should().ContainSingle(r => r.Type == "DeviceTypeA");
        result.Should().ContainSingle(r => r.Type == "DeviceTypeB");
        result.Should().ContainSingle(r => r.Type == "DeviceTypeC");
    }

    [TestMethod]
    public void ObtainSupportedDevices_ShouldReturnEmptyListWhenNoDevicesFound()
    {
        _deviceServiceMock.Setup(service => service.SearchSupportedDevices()).Returns(new List<string>());

        var result = _controller.ObtainSupportedDevices();

        result.Should().BeEmpty();
    }
}
