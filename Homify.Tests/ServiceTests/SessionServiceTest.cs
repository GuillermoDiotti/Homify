using System.Linq.Expressions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Session.Models.Requests;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class SessionServiceTest
{
    private Mock<IRepository<Session>>? _sessionRepositoryMock;
    private Mock<IUserService>? _userServiceMock;
    private SessionService? _service;

    [TestInitialize]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _sessionRepositoryMock = new Mock<IRepository<Session>>();
        _service = new SessionService(_sessionRepositoryMock.Object, _userServiceMock.Object);
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
        };
        var session = new Session
        {
            AuthToken = token,
            User = expectedUser,
            Id = "123456789"
        };

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
        };
        var session = new Session()
        {
            AuthToken = "token",
            User = expectedUser,
            Id = "123456789"
        };

        _sessionRepositoryMock.Setup(repo =>
            repo.Get(It.IsAny<Expression<Func<Session, bool>>>())).Returns(session);
        var result = _service?.CreateSession(expectedUser);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.AuthToken);
        Assert.AreNotEqual(string.Empty, result.AuthToken);
    }

    [TestMethod]
    public void CreateSession_WhenSessionNotFound_ShouldEnterCatchBlockAndCreateNewSession()
    {
        var user = new User { Email = "test@example.com" };
        _sessionRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Session, bool>>>()))
            .Throws(new NotFoundException("not found"));

        var result = _service.CreateSession(user);

        Assert.IsNotNull(result);
        Assert.AreEqual(user.Email, result.User.Email);
        Assert.IsNotNull(result.AuthToken);
        _sessionRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<Session, bool>>>()), Times.Once);
        _sessionRepositoryMock.Verify(repo => repo.Add(It.IsAny<Session>()), Times.Once);
    }

    /*[TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void Create_WhenEmailFormatIsInvalid_ShouldThrowInvalidFormatException()
    {
        var request = new CreateSessionRequest
        {
            Email = "invalid-email",
            Password = "testPassword"
        };

        _service.CheckSessionConstraints(request.Email, request.Password);
    }*/

    /*[TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void Create_WhenEmailIsNull_ShouldThrowArgsNullException()
    {
        var request = new CreateSessionRequest
        {
            Email = null,
            Password = "testPassword"
        };

        _service.CheckSessionConstraints(request.Email, request.Password);
    }*/

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void Create_WhenPasswordIsIncorrect_ShouldThrowArgumentException()
    {
        var request = new CreateSessionRequest
        {
            Email = "user@example.com",
            Password = "wrongPassword"
        };

        var user = new User
        {
            Email = "user@example.com",
            Password = ".Coo120dshjha"
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([user]);

        _service.CheckSessionConstraints(request.Email, request.Password);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Create_WhenUserNotFound_ShouldThrowNotFoundException()
    {
        var request = new CreateSessionRequest
        {
            Email = "nonexistent@example.com",
            Password = "testPassword"
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([]);

        _service.CheckSessionConstraints(request.Email, request.Password);
    }

    [TestMethod]
    public void CheckSessionConstraints_WhenValid_ShouldReturnUser()
    {
        var email = "example@mail.com";
        var password = "password123.";

        var user = new User()
        {
            Email = email, Password = password
        };
        _userServiceMock.Setup(u => u.GetAll(It.IsAny<string?>(), It.IsAny<string?>())).Returns([user]);

        var result = _service.CheckSessionConstraints(email, password);

        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
    }
}
