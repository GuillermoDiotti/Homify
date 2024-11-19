using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class UserServiceTest
{
    private Mock<IRepository<User>>? _userRepositoryMock;
    private Mock<IRepository<UserRole>>? _userRoleRepositoryMock;

    private UserService? _service;

    [TestInitialize]
    public void Setup()
    {
        _userRoleRepositoryMock = new Mock<IRepository<UserRole>>();
        _userRepositoryMock = new Mock<IRepository<User>>();
        _service = new UserService(_userRepositoryMock.Object, _userRoleRepositoryMock.Object);
    }

    [TestMethod]
    public void CreatePermission()
    {
        var per = new SystemPermission()
        {
            Id = "123",
            Value = "test",
            Roles = [new Role()]
        };

        Assert.IsNotNull(per);
        Assert.AreEqual("123", per.Id);
        Assert.AreEqual("test", per.Value);
        Assert.IsNotNull(per.Roles);
    }

    [TestMethod]
    public void AddUser_WhenInfoIsOk_ShouldAddUserToRepository()
    {
        var createUserArgs = new CreateUserArgs(
              "John",
              "john@example.com",
              "password123!",
              "Doe",
              RolesGenerator.Admin());

        var result = _service.AddAdmin(createUserArgs);

        _userRepositoryMock.Verify(r => r.Add(It.Is<User>(u =>
            u.Name == createUserArgs.Name &&
            u.Email == createUserArgs.Email &&
            u.Password == createUserArgs.Password &&
            u.LastName == createUserArgs.LastName)));

        Assert.IsNotNull(result);
        Assert.AreEqual(createUserArgs.Name, result.Name);
        Assert.AreEqual(createUserArgs.Email, result.Email);
        Assert.AreEqual(createUserArgs.Password, result.Password);
        Assert.AreEqual(createUserArgs.LastName, result.LastName);
    }

    [TestMethod]
    [ExpectedException(typeof(DuplicatedDataException))]
    public void AddUser_WhenEmailIsDuplicated_ShouldThrowDuplicatedDataException()
    {
        var existingUser = new Admin
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Existing",
            Email = "duplicate@example.com",
            Password = "password123",
            LastName = "User",
        };

        _userRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(existingUser);

        var createUserArgs = new CreateUserArgs(
            "New",
            "duplicate@example.com",
            "password123!",
            "User",
            new Role());

        _service.AddAdmin(createUserArgs);
    }

    [TestMethod]
    public void AddCompanyOwner_WhenInfoIsOk_ShouldAddCompanyOwnerToRepository()
    {
        var createUserArgs = new CreateUserArgs(
            "John",
            "john@example.com",
            "password123!",
            "Doe",
            new Role());

        _userRepositoryMock.Setup(r => r.Add(It.IsAny<CompanyOwner>())).Verifiable();

        var result = _service.AddCompanyOwner(createUserArgs);

        _userRepositoryMock.Verify(r => r.Add(It.Is<CompanyOwner>(u =>
            u.Name == createUserArgs.Name &&
            u.Email == createUserArgs.Email &&
            u.Password == createUserArgs.Password &&
            u.LastName == createUserArgs.LastName &&
            u.IsIncomplete == true)), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(createUserArgs.Name, result.Name);
        Assert.AreEqual(createUserArgs.Email, result.Email);
        Assert.AreEqual(createUserArgs.Password, result.Password);
        Assert.AreEqual(createUserArgs.LastName, result.LastName);
        Assert.IsTrue(result.IsIncomplete);
    }

    [TestMethod]
    public void AddHomeOwner_ShouldAddHomeOwnerToRepository()
    {
        var createHomeOwnerArgs = new CreateHomeOwnerArgs(
              "John",
             "john@example.com",
              "password123!",
             "Doe",
             "https://example.com/profile.jpg",
              RolesGenerator.HomeOwner());

        _userRepositoryMock.Setup(r => r.Add(It.IsAny<HomeOwner>())).Verifiable();

        var result = _service.AddHomeOwner(createHomeOwnerArgs);

        _userRepositoryMock.Verify(r => r.Add(It.Is<HomeOwner>(u =>
            u.Name == createHomeOwnerArgs.Name &&
            u.Email == createHomeOwnerArgs.Email &&
            u.Password == createHomeOwnerArgs.Password &&
            u.LastName == createHomeOwnerArgs.LastName &&
            u.ProfilePicture == createHomeOwnerArgs.ProfilePicUrl)), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(createHomeOwnerArgs.Name, result.Name);
        Assert.AreEqual(createHomeOwnerArgs.Email, result.Email);
        Assert.AreEqual(createHomeOwnerArgs.Password, result.Password);
        Assert.AreEqual(createHomeOwnerArgs.LastName, result.LastName);
        Assert.AreEqual(createHomeOwnerArgs.ProfilePicUrl, result.ProfilePicture);
    }

    [TestMethod]
    public void GetById_WhenUserExists_ShouldReturnUser()
    {
        var userId = Guid.NewGuid().ToString();
        var expectedUser = new User
        {
            Id = userId,
            Name = "John",
            Email = "john@example.com",
            Password = "password123",
            LastName = "Doe",
        };

        _userRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(expectedUser);

        var result = _service.GetById(userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedUser.Id, result.Id);
        Assert.AreEqual(expectedUser.Name, result.Name);
        Assert.AreEqual(expectedUser.Email, result.Email);
        Assert.AreEqual(expectedUser.Password, result.Password);
        Assert.AreEqual(expectedUser.LastName, result.LastName);
        Assert.AreEqual(expectedUser.Roles, result.Roles);
    }

    [TestMethod]
    public void GetAll_WhenAreUsers_ShouldReturnAllUsers()
    {
        var users = new List<User>
        {
            new User
            {
                Id = "1",
                Name = "John",
                Email = "john@example.com",
                Password = "password123",
                LastName = "Doe",
            },
            new User
            {
                Id = "2",
                Name = "Jane",
                Email = "jane@example.com",
                Password = "password456",
                LastName = "Smith",
            }
        };

        _userRepositoryMock
            .Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns(users);

        var result = _service.GetAll();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("John", result[0].Name);
        Assert.AreEqual("Jane", result[1].Name);
    }

    [TestMethod]
    public void Delete_WhenUserExists_ShouldRemoveUser()
    {
        var userId = Guid.NewGuid().ToString();
        var user = new Admin
        {
            Id = userId,
            Name = "John",
            Email = "john@example.com",
            Password = "password123",
            LastName = "Doe",
            Roles = [
                new UserRole()
                {
                    Role = new Role() { Name = Constants.ADMINISTRATOR }
                }

            ]
        };

        var user2 = new User(
            "John",
            "john@example.com",
            "password123",
            "Doe",
            new Role());

        _userRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
        _userRepositoryMock.Setup(r => r.Remove(It.IsAny<User>())).Verifiable();

        _service.Delete(userId);

        _userRepositoryMock.Verify(r => r.Remove(It.Is<User>(u => u.Id == userId)), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Delete_WhenAdminNotFound_ThrowsNotFoundException()
    {
        var adminId = "nonexistentAdminId";

        _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns((User)null);

        _service.Delete(adminId);
    }

    [TestMethod]
    [ExpectedException(typeof(System.InvalidOperationException))]
    public void Delete_WhenUserIsNotAdmin_ThrowsInvalidOperationException()
    {
        var adminId = "testAdminId";
        var admin = new User
        {
            Id = adminId,
            Roles =
            [
                new UserRole { Role = new Role { Name = "NonAdminRole" } }
            ]
        };

        _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(admin);

        _service.Delete(adminId);
    }

    [TestMethod]
    [ExpectedException(typeof(System.InvalidOperationException))]
    public void Delete_WhenAdminHasMoreThanOneRole_ThrowsInvalidOperationException()
    {
        var adminId = "testAdminId";
        var admin = new User
        {
            Id = adminId,
            Roles =
            [
                new UserRole { Role = new Role { Name = Constants.ADMINISTRATOR } },
                new UserRole { Role = new Role { Name = "AnotherRole" } }
            ]
        };

        _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(admin);

        _service.Delete(adminId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateProfilePicture_UserIsNull_ThrowsNotFoundException()
    {
        _service.UpdateProfilePicture("newProfilePic.jpg", null);
    }

    [TestMethod]
    public void UpdateProfilePicture_ValidUser_UpdatesProfilePicture()
    {
        var user = new User
        {
            Id = "1",
            ProfilePicture = "oldProfilePic.jpg",
            Roles = [new UserRole()
            {
                Role = new Role(){ Name = "HOMEOWNER" }
            }

            ]
        };

        var newProfilePicture = "newProfilePic.jpg";

        _userRepositoryMock.Setup(r => r.Update(It.IsAny<User>())).Verifiable();

        var updatedUser = _service.UpdateProfilePicture(newProfilePicture, user);

        _userRepositoryMock.Verify(r => r.Update(It.Is<User>(u => u.ProfilePicture == newProfilePicture)), Times.Once);
        Assert.IsNotNull(updatedUser);
        Assert.AreEqual(newProfilePicture, updatedUser.ProfilePicture);
    }

    [TestMethod]
    public void UpdateProfilePicture_ValidUser_ReturnsUpdatedUser()
    {
        var user = new User
        {
            Id = "1",
            ProfilePicture = "oldProfilePic.jpg",
            Roles = [new UserRole()
            {
                Role = new Role(){ Name = "HOMEOWNER" }
            }

            ]
        };

        var newProfilePicture = "newProfilePic.jpg";

        _userRepositoryMock.Setup(r => r.Update(It.IsAny<User>())).Verifiable();

        var updatedUser = _service.UpdateProfilePicture(newProfilePicture, user);

        Assert.AreEqual(user, updatedUser);
        Assert.AreEqual(newProfilePicture, updatedUser.ProfilePicture);
        _userRepositoryMock.Verify(r => r.Update(user), Times.Once);
    }
}
