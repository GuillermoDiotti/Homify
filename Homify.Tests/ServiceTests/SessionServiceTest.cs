using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Moq;
using Constants = Homify.Utility.Constants;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class SessionServiceTest
{
    private Mock<IRepository<Session>>? _sessionRepositoryMock;
    private Mock<SessionService>? _sessionServiceMock;

    private SessionService? _service;

    [TestInitialize]
    public void Setup()
    {
        _sessionRepositoryMock = new Mock<IRepository<Session>>();
        _sessionServiceMock = new Mock<SessionService>(_sessionRepositoryMock.Object);
        _service = new SessionService(_sessionRepositoryMock.Object);
    }

    [TestMethod]
    public void GetUserByToken_ValidToken_ReturnsUser()
    {
        var token = "valid_token";
        var expectedUser = new User()
        {
            Id = "123456",
            Name = "John",
            Email = "john@example.com",
            Password = "password123",
            LastName = "Doe",
            Role = new Role()
        };
        var session = new Session { AuthToken = token, User = expectedUser, Id = "123456789" };

        _sessionRepositoryMock.Setup(repo =>
            repo.Get(It.IsAny<Expression<Func<Session, bool>>>())).Returns(session);

        var result = _service?.GetUserByToken(token);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedUser, result);
    }

    [TestMethod]
    public void AddToken_ValidToken_AddsToken()
    {
        var userEmail = "john@example.com";
        var expectedUser = new User()
        {
            Id = "123456",
            Name = "John",
            Email = userEmail,
            Password = "password123",
            LastName = "Doe",
            RoleId = Constants.ADMINISTRATORID
        };
        var session = new Session() { AuthToken = "token", User = expectedUser, Id = "123456789" };

        _sessionRepositoryMock.Setup(repo =>
            repo.Get(It.IsAny<Expression<Func<Session, bool>>>())).Returns(session);
        var result = _service?.CreateSession(expectedUser);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.AuthToken);
        Assert.AreNotEqual(string.Empty, result.AuthToken);
    }
}
