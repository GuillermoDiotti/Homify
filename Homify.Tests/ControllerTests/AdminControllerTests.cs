using FluentAssertions;
using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
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
    public void CreateUser_WhenNameIsNull_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = null,
            Email = "example@gmail.com",
            Password = "password",
            LastName = "Doe"
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateUser_WhenEmailIsNull_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = null,
            Password = "password!",
            LastName = "Doe"
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenEmailFormatIsInvalid_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@example",
            Password = "password/",
            LastName = "Doe"
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenEmailFormatIsInvalid2_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example.com",
            Password = "password!",
            LastName = "Doe"
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CreateUser_WhenPasswordFormatIsInvalid2_ShouldThrowException()
    {
        var password = new string('a', 4);

        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = password + "!",
            LastName = "Doe"
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateUser_WhenLastNameIsNull_ShouldThrowException()
    {
        var request = new CreateAdminRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "123456!",
            LastName = null
        };

        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        var expectedUser = new Admin()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName,
            Id = Guid.NewGuid().ToString()
        };

        _userServiceMock.Setup(user => user.AddAdmin(It.IsAny<CreateUserArgs>())).Returns(expectedUser);
        _roleServicemock.Setup(roleService => roleService.GetRole("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Delete_WhenAdminNotFound_ShouldThrowNotFoundException()
    {
        var adminId = "nonexistentAdminId";
        _userServiceMock.Setup(service => service.GetById(adminId)).Returns((User)null);

        _controller.Delete(adminId);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Delete_WhenTargetUserIsNotAdmin_ShouldThrowInvalidOperationException()
    {
        var adminId = "userId";
        var user = new User { Id = adminId, Role = new Role { Name = "User" } };
        _userServiceMock.Setup(service => service.GetById(adminId)).Returns(user);

        _controller.Delete(adminId);
    }

    [TestMethod]
    public void Delete_WhenAdminExistsAndIsAdmin_ShouldDeleteAdmin()
    {
        // Arrange
        var adminId = "adminId";
        var admin = new User { Id = adminId, Role = new Role { Name = Constants.ADMINISTRATOR } };
        _userServiceMock.Setup(service => service.GetById(adminId)).Returns(admin);
        _userServiceMock.Setup(service => service.Delete(adminId));

        // Act
        _controller.Delete(adminId);

        // Assert
        _userServiceMock.Verify(service => service.GetById(adminId), Times.Once);
        _userServiceMock.Verify(service => service.Delete(adminId), Times.Once);
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
                LastName = "Doe",
                Role = new Role
                {
                    Name = "Admin"
                }
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson",
                Role = new Role
                {
                    Name = "Guest"
                }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("2", "1", string.Empty, string.Empty);

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
                LastName = "Doe",
                Role = new Role
                {
                    Name = "Admin"
                }
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson",
                Role = new Role
                {
                    Name = "Guest"
                }
            },
            new User
            {
                Name = "Lucy",
                LastName = "Williams",
                Role = new Role
                {
                    Name = "Admin"
                }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("invalid", "0", string.Empty, string.Empty);

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
                LastName = "Doe",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson",
                Role = new Role
                {
                    Name = "Admin"
                }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("2", "invalid", string.Empty, string.Empty);

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
                LastName = "Doe",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith",
                Role = new Role
                {
                    Name = "User"
                }
            },
            new User
            {
                Name = "Adam",
                LastName = "Johnson",
                Role = new Role
                {
                    Name = "Admin"
                }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts(null, null, string.Empty, string.Empty);

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
                Role = new Role
                {
                    Name = "Admin"
                }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts("10", "0", string.Empty, string.Empty);

        Assert.IsNotNull(result, "El resultado no debe ser nulo");
        Assert.AreEqual(1, result.Count, "Debe haber exactamente un usuario en la lista");
        Assert.AreEqual("John", result[0].Name, "El nombre del usuario debe ser 'John'");
        Assert.AreEqual("Doe", result[0].LastName, "El apellido del usuario debe ser 'Doe'");
    }

    [TestMethod]
    public void AllAccounts_WhenRoleAndFullNameAreProvided_ShouldFilterAndReturnPaginatedList()
    {
        var limit = "5";
        var offset = "0";
        var role = "Admin";
        var fullName = "John Doe";
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                LastName = "Doe",
                Role = new Role { Name = "Admin" }
            },
            new User
            {
                Name = "Jane",
                LastName = "Smith",
                Role = new Role { Name = "User" }
            }
        };

        _userServiceMock.Setup(service => service.GetAll()).Returns(users);

        var result = _controller.AllAccounts(limit, offset, role, fullName);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("John Doe", Helpers.GetUserFullName(result[0].Name, result[0].LastName));
        _userServiceMock.Verify(service => service.GetAll(), Times.Once);
    }
}
