using System.Linq.Expressions;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomePermissionTest
{
    private Mock<IRepository<HomePermission>>? _repositoryMock;
    private HomePermissionService? _service;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<HomePermission>>();
        _service = new HomePermissionService(_repositoryMock.Object);
    }

    [TestMethod]
    public void GetByValue_ShouldReturnHomePermission_WhenValueExists()
    {
        var value = "testValue";
        var expectedPermission = new HomePermission { Value = value };
        _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomePermission, bool>>>()))
            .Returns(expectedPermission);

        var result = _service.GetByValue(value);

        Assert.IsNotNull(result);
        Assert.AreEqual(value, result.Value);
    }

    [TestMethod]
    public void GetByValue_ShouldReturnNull_WhenValueDoesNotExist()
    {
        _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomePermission, bool>>>()))
            .Returns((HomePermission)null);

        var result = _service.GetByValue("nonExistingValue");

        Assert.IsNull(result);
    }
}
