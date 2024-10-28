using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.HomeDevices;
using Homify.WebApi.Controllers.HomeDevices.Models;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeDeviceControllerTest
{
    private readonly HomeDeviceController _controller;

    public HomeDeviceControllerTest()
    {
        _controller = new HomeDeviceController();
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
        var req = new UpdateHomeDeviceRequest() { CustomName = "NewName" };
        _HomeDeviceMock.Setup(x => x.UpdateHomeDevice(req, "idDevice")).Returns(new HomeDevice() { CustomName = "NewName" } );
        _controller.UpdateHomeDevice(req, "idDevice");
    }
}
