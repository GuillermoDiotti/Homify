using Homify.BusinessLogic.Admins;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins;
using Homify.WebApi.Controllers.Admins.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class AdminControllerTests
{
    private AdminController _controller;
    private Mock<IAdminService> _adminServiceMock;

    public AdminControllerTests()
    {
        _adminServiceMock = new Mock<IAdminService>(MockBehavior.Strict);
        _controller = new AdminController(_adminServiceMock.Object);
    }

    #region Create
    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateAdmin_WhenRequestIsNull_ShouldThrowEception()
    {
        var admin = _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateAdmin_WhenNameIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = null,
            Email = "example@gmail.com",
            Password = "password",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateAdmin_WhenEmailIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = null,
            Password = "password",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateAdmin_WhenEmailFormatInInvalid1_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@example",
            Password = "password",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateAdmin_WhenEmailFormatInInvalid2_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example.com",
            Password = "password",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateAdmin_WhenPasswordIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = null,
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateAdmin_WhenPasswordIsFormatIsInvalid1_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "123",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateAdmin_WhenPasswordIsFormatIsInvalid2_ShouldThrowExceptionn()
    {
        var password = string.Empty;
        for (var i = 0; i < 60; i++)
        {
            password += "a";
        }

        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = password,
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateAdmin_WhenLastNameIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "12345",
            LastName = null
        };
        _controller.Create(request);
    }
    #endregion
}
