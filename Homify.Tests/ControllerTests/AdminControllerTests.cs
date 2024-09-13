using FluentAssertions;
using Homify.BusinessLogic.Admins;
using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins;
using Homify.WebApi.Controllers.Admins.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class AdminControllerTests
{
    private AdminController _controller;
    private Mock<IUserService> _adminServiceMock;

    public AdminControllerTests()
    {
        _adminServiceMock = new Mock<IUserService>(MockBehavior.Strict);
        _controller = new AdminController(_adminServiceMock.Object);
    }

    #region Create

    #region Error

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

    #region Success

    [TestMethod]
    public void CreateAdmin_WhenDataIsOk_ShouldCreateAdmin()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "12345",
            LastName = "lastName"
        };

        var expectedAdmin = new Admin()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName
        };
        _adminServiceMock.Setup(admin => admin.Add(It.IsAny<CreateAdminArgs>())).Returns(expectedAdmin);

        var response = _controller.Create(request);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(expectedAdmin.Id);
    }
    #endregion

    #endregion

    #region Delete

    #region Error

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void DeleteAdmin_WhenAdminIdIsNull_ShouldThrowException()
    {
        _adminServiceMock.Setup(admin => admin.GetById(It.IsAny<string>())).Throws(new NotFoundException("Admin not found"));
        _controller.Delete("1234");
    }

    #endregion

    #region Success

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void DeleteAdmin_WhenAdminIdIsOk_ShouldDeleteAdmin()
    {
        var testAdmin = new Admin();
        _adminServiceMock.Setup(admin => admin.GetById(testAdmin.Id)).Throws(new NotFoundException("Admin not found"));
        _controller.Delete(testAdmin.Id);
    }

    #endregion

    #endregion

    #region Get

    [TestMethod]
    public void GetAdmin_WhenAdminIdIsOk_ShouldReturnAdmin()
    {
        var testAdmin = new Admin();
        _adminServiceMock.Setup(admin => admin.GetById(testAdmin.Id)).Returns(testAdmin);

        var response = _controller.GetById(testAdmin.Id);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(testAdmin.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void GetAdmin_WhenAdminIdIsNull_ShouldThrowException()
    {
        var response = _controller.GetById(null);
    }

    #endregion
}
