using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.HomeDevices;
using Homify.WebApi.Controllers.HomeDevices.Models;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeDeviceControllerTest
{
    private readonly HomeDeviceController _controller;
    private readonly Mock<IHomeDeviceService> _HomeDeviceMock;

    public HomeDeviceControllerTest()
    {
        _HomeDeviceMock = new Mock<IHomeDeviceService>();
        _controller = new HomeDeviceController(_HomeDeviceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevice_WhenRequestIsNull_ThrowsException()
    {
        _controller.UpdateHomeDevice(null, null);
    }

    [TestMethod]
    public void UpdateHomeDevice_WhenRequestIsValid_UpdatesDevice()
    {
        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Role = RolesGenerator.HomeOwner()
        };

        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
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
        _HomeDeviceMock.Setup(x => x.UpdateHomeDevice(req.CustomName, updatedDevice.Id)).Returns(updatedDevice);
        var response = _controller.UpdateHomeDevice(req, updatedDevice.Id);

        response.Should().NotBeNull();
    }
}
