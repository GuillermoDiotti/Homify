namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeDeviceControllerTest
{

    [TestMethod]
    public void UpdateHomeDevice_WhenRequestIsNull_ThrowsException()
    {
        _controller.UpdateHomeDevice(null);
    }
}
