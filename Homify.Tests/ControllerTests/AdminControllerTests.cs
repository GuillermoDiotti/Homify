using FluentAssertions;
using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Admins;
using Homify.WebApi.Controllers.Admins.Models.Requests;
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
        _userServiceMock = new Mock<IUserService>();
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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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

        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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
        _roleServicemock.Setup(roleService => roleService.Get("ADMINISTRATOR")).Returns(new Role { Name = "ADMINISTRATOR" });

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
    [TestMethod]
    public void Delete_WhenCalled_InvokesUserServiceDelete()
    {
        var adminId = "testAdminId";

        _controller.Delete(adminId);

        _userServiceMock.Verify(service => service.Delete(adminId), Times.Once);
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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "userid",
                Name = "Jane",
                LastName = "Smith",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "userid",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "user",
                Name = "Adam",
                LastName = "Johnson",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "user",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(users);

        var req = new UserFiltersRequest()
        {
            Limit = "2",
            Offset = "1"
        };

        var result = _controller.AllAccounts(req);

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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "userid",
                Name = "Jane",
                LastName = "Smith",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "userid",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "user",
                Name = "Adam",
                LastName = "Johnson",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "user",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(users);

        var req = new UserFiltersRequest()
        {
            Limit = "invalid",
            Offset = "0"
        };

        var result = _controller.AllAccounts(req);

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count);
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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "userid",
                Name = "Jane",
                LastName = "Smith",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "userid",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "user",
                Name = "Adam",
                LastName = "Johnson",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "user",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(users);

        var req = new UserFiltersRequest()
        {
            Limit = "2",
            Offset = "invalid"
        };

        var result = _controller.AllAccounts(req);

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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "userid",
                Name = "Jane",
                LastName = "Smith",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "userid",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "user",
                Name = "Adam",
                LastName = "Johnson",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "user",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(users);

        var req = new UserFiltersRequest()
        {
            Limit = string.Empty,
            Offset = string.Empty
        };

        var result = _controller.AllAccounts(req);

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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(users);

        var req = new UserFiltersRequest()
        {
            Limit = "10",
            Offset = "0"
        };

        var result = _controller.AllAccounts(req);

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
                Id = "adminId",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "adminId",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            },
            new User
            {
                Id = "userid",
                Name = "Jane",
                LastName = "Smith",
                Roles =
                [
                    new UserRole
                    {
                        UserId = "userid",
                        RoleId = Constants.ADMINISTRATORID,
                        Role = new Role { Id = Constants.ADMINISTRATORID, Name = "ADMINISTRATOR" }
                    }

                ]
            }
        };

        _userServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns((string? role, string? name) =>
                users.Where(u =>
                    (string.IsNullOrEmpty(role) || u.Roles.Any(r => r.Role.Name.Contains(role, StringComparison.OrdinalIgnoreCase))) &&
                    (string.IsNullOrEmpty(name) || Helpers.GetUserFullName(u.Name, u.LastName).Contains(name, StringComparison.OrdinalIgnoreCase))).ToList());

        var req = new UserFiltersRequest()
        {
            Limit = limit,
            Offset = offset,
            Role = role,
            FullName = fullName
        };

        var result = _controller.AllAccounts(req);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("John Doe", Helpers.GetUserFullName(result[0].Name, result[0].LastName));
    }
}
