using Homify.Exceptions;
using Homify.WebApi.Controllers.HomeDevices;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeDeviceControllerTest
{
    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevice_WhenRequestIsNull_ThrowsException()
    {
        HomeDeviceController _controller = new HomeDeviceController();
        _controller.UpdateHomeDevice(null, null);
    }
}
