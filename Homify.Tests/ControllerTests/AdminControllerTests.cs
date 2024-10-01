using FluentAssertions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins;
using Homify.WebApi.Controllers.Admins.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class UserControllerTests
{
    private readonly AdminController _controller;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly Mock<IRoleService> _roleServicemock;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>(MockBehavior.Strict);
        _roleServicemock = new Mock<IRoleService>(MockBehavior.Strict);
        _controller = new AdminController(_userServiceMock.Object, _roleServicemock.Object);
    }

    #region Create

    #region Error

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateUser_WhenRequestIsNull_ShouldThrowEception()
    {
        _controller.Create(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateUser_WhenNameIsNull_ShouldThrowExceptionn()
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
    public void CreateUser_WhenEmailIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = null,
            Password = "password!",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenEmailFormatInInvalid1_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@example",
            Password = "password/",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenEmailFormatInInvalid2_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example.com",
            Password = "password!",
            LastName = "Doe"
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateUser_WhenPasswordIsNull_ShouldThrowExceptionn()
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
    public void CreateUser_WhenPasswordFormatIsInvalid1_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "123456",
            LastName = "Doe"
        };
        var expected = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName,
        };
        _userServiceMock.Setup(u => u.AddUser(It.IsAny<CreateUserArgs>())).Returns(expected);
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenPasswordFormatIsInvalid2_ShouldThrowException()
    {
        var password = string.Empty;
        for (var i = 0; i < 4; i++)
        {
            password += "a";
        }

        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = password + "!",
            LastName = "Doe"
        };
        var expected = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName,
        };
        _userServiceMock.Setup(u => u.AddUser(It.IsAny<CreateUserArgs>())).Returns(expected);
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateUser_WhenLastNameIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "123456!",
            LastName = null
        };
        _controller.Create(request);
    }

    #endregion

    #region Success

    [TestMethod]
    public void CreateUser_WhenDataIsOk_ShouldCreateUser()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "123456!",
            LastName = "lastName"
        };

        var expectedUser = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName
        };
        _userServiceMock.Setup(user => user.AddUser(It.IsAny<CreateUserArgs>())).Returns(expectedUser);

        var response = _controller.Create(request);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(expectedUser.Id);
        expectedUser.Name.Should().Be(request.Name);
        expectedUser.Email.Should().Be(request.Email);
        expectedUser.Password.Should().Be(request.Password);
        expectedUser.LastName.Should().Be(request.LastName);
    }
    #endregion

    #endregion

    #region Delete

    #region Error

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void DeleteUser_WhenUserIdIsNull_ShouldThrowException()
    {
        _userServiceMock.Setup(user => user.GetById(It.IsAny<string>())).Throws(new NotFoundException("User not found"));
        _controller.Delete("1234");
    }

    #endregion

    #region Success

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void DeleteUser_WhenUserIdIsOk_ShouldDeleteUser()
    {
        var testUser = new User();
        _userServiceMock.Setup(user => user.GetById(testUser.Id)).Throws(new NotFoundException("User not found"));
        _controller.Delete(testUser.Id);
    }

    #endregion

    #endregion

    #region Get

    [TestMethod]
    public void GetUser_WhenUserIdIsOk_ShouldReturnUser()
    {
        var testUser = new User();
        _userServiceMock.Setup(user => user.GetById(testUser.Id)).Returns(testUser);

        var response = _controller.GetById(testUser.Id);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(testUser.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void GetUser_WhenUserIdIsNull_ShouldThrowException()
    {
        _controller.GetById(null!);
    }

    #endregion

    [TestMethod]
    public void AllAccounts_WhenLimitAndOffsetAreValid_ShouldReturnCorrectUsers()
    {
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe"
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith"
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson"
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("2", "1");

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Jane", result[0].Name);
        Assert.AreEqual("Smith", result[0].LastName);
    }

    [TestMethod]
    public void AllAccounts_WhenLimitIsInvalid_ShouldReturnDefaultPageSize()
    {
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe"
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith"
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson"
            },
            new User
            {
                Name = "Lucy",
                LastName = "Williams"
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("invalid", "0");

        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Count);
    }

    [TestMethod]
    public void AllAccounts_WhenOffsetIsInvalid_ShouldReturnFirstUsers()
    {
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe"
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith"
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson"
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("2", "invalid");

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("John", result[0].Name);
    }

    [TestMethod]
    public void AllAccounts_WhenNoParameters_ShouldReturnDefaultValues()
    {
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe"
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith"
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson"
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts(null, null);

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void AllAccounts_ShouldMapUserToUserBasicInfoCorrectly()
    {
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe",
                CreatedAt = DateTime.Now
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("10", "0");

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("John", result[0].Name);
        Assert.AreEqual("Doe", result[0].LastName);
    }
}
