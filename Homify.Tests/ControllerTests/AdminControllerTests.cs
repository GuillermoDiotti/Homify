namespace Homify.Tests.ControllerTests;

[TestClass]
public class AdminControllerTests
{
    #region Create
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void CreateAdmin_WhenRequestIsNull_ShouldThrowEception()
    {
        var admin = _controller.Create(null);
    }
    #endregion
}
