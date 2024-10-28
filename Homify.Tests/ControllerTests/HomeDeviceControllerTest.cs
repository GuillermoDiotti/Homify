using Homify.Exceptions;
using Homify.WebApi.Controllers.HomeDevices;

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
        HomeDeviceController _controller = new HomeDeviceController();
        _controller.UpdateHomeDevice(null, null);
    }
}
