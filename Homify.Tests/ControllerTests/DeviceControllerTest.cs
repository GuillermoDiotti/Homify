using FluentAssertions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Devices;
using Homify.WebApi.Controllers.Devices.Models;
using Homify.WebApi.Controllers.Devices.Models.Requests;
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
        var request = new CreateCameraRequest
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            IsExterior = false,
            IsInterior = true,
            PpalPicture = "Test"
        };
        var user = new User { Id = "testUserId" };
        var companyOwner = new CompanyOwner { Id = "companyOwnerId", IsIncomplete = false };
        var expectedCamera = new Camera
        {
            Name = request.Name,
            PpalPicture = request.PpalPicture,
            Company = new Company { Id = companyOwner.Id },
            Description = request.Description,
            Model = request.Model,
            Photos = request.Photos,
            IsExterior = request.IsExterior,
            IsInterior = request.IsInterior,
            CompanyId = companyOwner.Id
        };

        _deviceServiceMock.Setup(d => d.AddCamera(It.IsAny<CreateDeviceArgs>(), companyOwner)).Returns(expectedCamera);
        _companyOwnerServiceMock.Setup(c => c.GetById(user.Id)).Returns(companyOwner);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var response = _controller.RegisterCamera(request);

        response.Should().NotBeNull();
    }

    [TestMethod]
    public void RegisterSensor_WhenDataIsOk_ShouldRegisterSensor()
    {
        var request = new CreateSensorRequest
        {
            Name = "TestSensor",
            Description = "TestDescription",
            Model = "TestModel",
            Photos = ["1", "2", "3"],
            PpalPicture = "TestPicture"
        };
        var user = new User { Id = "testUserId" };
        var companyOwner = new CompanyOwner { Id = "companyOwnerId", IsIncomplete = false };
        var expectedSensor = new Sensor
        {
            Name = request.Name,
            PpalPicture = request.PpalPicture,
            Company = new Company { Id = companyOwner.Id },
            Description = request.Description,
            Model = request.Model,
            Photos = request.Photos,
            CompanyId = companyOwner.Id
        };

        _deviceServiceMock.Setup(d => d.AddSensor(It.IsAny<CreateDeviceArgs>(), companyOwner)).Returns(expectedSensor);
        _companyOwnerServiceMock.Setup(c => c.GetById(user.Id)).Returns(companyOwner);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var response = _controller.RegisterSensor(request);

        response.Should().NotBeNull();
    }

    [TestMethod]
    public void ObtainDevices_ReturnsListOfDevices_WhenValidParamsProvided()
    {
        var deviceList = new List<Device>
        {
            new Device
            {
                Id = "1",
                Name = "Camera 1",
                Model = "Model A",
                PpalPicture = "photo1.jpg",
                Company = new Company
                {
                    Name = "Company A"
                }
            },
            new Device
            {
                Id = "2",
                Name = "Sensor 1",
                Model = "Model B",
                PpalPicture = "photo2.jpg",
                Company = new Company
                {
                    Name = "Company B"
                }
            },
            new Device
            {
                Id = "3",
                Name = "Camera 2",
                Model = "Model C",
                PpalPicture = null,
                Company = new Company
                {
                    Name = "Company A"
                }
            }
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
        var devices = new List<string>
        {
            "DeviceTypeA",
            "DeviceTypeB",
            "DeviceTypeC"
        };
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
        _deviceServiceMock.Setup(service => service.SearchSupportedDevices()).Returns([]);

        var result = _controller.ObtainSupportedDevices();

        result.Should().BeEmpty();
    }

    [TestMethod]
    public void TurnOnDevice_WithValidHardwareId_ShouldReturnActivatedDevice()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = user.Id,
                Members = [new HomeUser { UserId = user.Id }]
            }
        };

        var activatedDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = homeDevice.Home
        };

        _homeDeviceServiceMock.Setup(service => service.GetHomeDeviceByHardwareId(hardwareId)).Returns(homeDevice);
        _homeDeviceServiceMock.Setup(service => service.Activate(homeDevice)).Returns(activatedDevice);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var result = _controller.TurnOnDevice(hardwareId);

        result.Should().NotBeNull();
        result.IsActive.Should().BeTrue();
        _homeDeviceServiceMock.Verify(service => service.GetHomeDeviceByHardwareId(hardwareId), Times.Once);
        _homeDeviceServiceMock.Verify(service => service.Activate(homeDevice), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void RegisterSensor_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        CreateSensorRequest request = null;

        _controller.RegisterSensor(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void RegisterCamera_WhenCompanyOwnerNotFound_ShouldThrowNotFoundException()
    {
        var request = new CreateCameraRequest
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            IsExterior = false,
            IsInterior = true,
            PpalPicture = "Test"
        };

        var user = new User { Id = "testUserId" };

        _companyOwnerServiceMock.Setup(c => c.GetById(user.Id)).Returns<CompanyOwner>(null);
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.RegisterCamera(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void RegisterCamera_WhenCompanyOwnerIsIncomplete_ShouldThrowInvalidOperationException()
    {
        var request = new CreateCameraRequest
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            IsExterior = false,
            IsInterior = true,
            PpalPicture = "Test"
        };

        var user = new User { Id = "testUserId" };
        var companyOwner = new CompanyOwner { Id = "companyOwnerId", IsIncomplete = true };

        _companyOwnerServiceMock.Setup(c => c.GetById(user.Id)).Returns(companyOwner);
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.RegisterCamera(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void TurnOnDevice_WhenHomeDeviceNotFound_ShouldThrowNotFoundException()
    {
        var hardwareId = "Device123";

        _homeDeviceServiceMock.Setup(service => service.GetHomeDeviceByHardwareId(hardwareId)).Returns<HomeDevice>(null);

        _controller.TurnOnDevice(hardwareId);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TurnOnDevice_WhenUserIsNotMemberOrOwner_ShouldThrowInvalidOperationException()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = "otherUserId",
                Members = []
            }
        };

        _homeDeviceServiceMock.Setup(service => service.GetHomeDeviceByHardwareId(hardwareId)).Returns(homeDevice);
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.TurnOnDevice(hardwareId);
    }
}
