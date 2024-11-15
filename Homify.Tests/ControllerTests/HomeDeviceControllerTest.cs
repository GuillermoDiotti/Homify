using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Controllers.HomeDevices;
using Homify.WebApi.Controllers.HomeDevices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeDeviceControllerTest
{
    private readonly HomeDeviceController _controller;
    private readonly Mock<IHomeDeviceService> _homeDeviceMock;

    public HomeDeviceControllerTest()
    {
        _homeDeviceMock = new Mock<IHomeDeviceService>();
        _controller = new HomeDeviceController(_homeDeviceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevice_WhenRequestIsNull_ThrowsException()
    {
        _controller.UpdateHomeDevice(null, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UpdateHomeDevice_WhenRequestNameIsNull_ThrowsException()
    {
        var req = new UpdateHomeDeviceRequest() { CustomName = null };

        _controller.UpdateHomeDevice(req, null);
    }

    [TestMethod]
    public void UpdateHomeDevice_WhenRequestIsValid_UpdatesDevice()
    {
        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles =
            [
                new UserRole
                {
                    UserId = "Owner123",
                    RoleId = Constants.HOMEOWNERID,
                    Role = RolesGenerator.HomeOwner()
                }

            ]
        };
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = owner;

        var updatedDevice = new HomeDevice
        {
            DeviceId = "device123",
            HomeId = "home1",
            Home = new Home
            {
                Id = "home1"
            },
            Device = new Device
            {
                Id = "device123",
                Name = "Device1"
            },
            Connected = true,
            HardwareId = "1001",
            CustomName = "NewName",
        };

        var req = new UpdateHomeDeviceRequest() { CustomName = "NewName" };

        _homeDeviceMock.Setup(x => x.UpdateHomeDevice(req.CustomName, updatedDevice.Id, owner)).Returns(updatedDevice);
        var response = _controller.UpdateHomeDevice(req, updatedDevice.Id);

        response.Should().NotBeNull();
    }

    [TestMethod]
    public void TurnOnHomeDevice_WithValidHardwareId_ShouldReturnActivatedDevice()
    {
        var hardwareId = "Device123";
        var logged = new User { Id = "123" };
        var activatedDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = logged.Id,
                Members = [new HomeUser { UserId = logged.Id }]
            }
        };

        _homeDeviceMock.Setup(service => service.Activate(It.IsAny<string>(), It.IsAny<User>())).Returns(activatedDevice);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = logged;

        var result = _controller.TurnOnHomeDevice(hardwareId);

        result.Should().NotBeNull();
        result.Id.Should().Be("Device123");
        result.IsActive.Should().BeTrue();
        _homeDeviceMock.Verify(service => service.Activate(hardwareId, logged), Times.Once);
    }

    [TestMethod]
    public void TurnOffHomeDevice_WithValidHardwareId_ShouldReturnDeactivatedDevice()
    {
        var hardwareId = "Device123";
        var logged = new User { Id = "123" };
        var activatedDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = logged.Id,
                Members = [new HomeUser { UserId = logged.Id }]
            }
        };

        _homeDeviceMock.Setup(service => service.Deactivate(It.IsAny<string>(), It.IsAny<User>())).Returns(activatedDevice);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = logged;

        var result = _controller.TurnOffHomeDevice(hardwareId);

        result.Should().NotBeNull();
        result.Id.Should().Be("Device123");
        result.IsActive.Should().BeFalse();
        _homeDeviceMock.Verify(service => service.Deactivate(hardwareId, logged), Times.Once);
    }
}
