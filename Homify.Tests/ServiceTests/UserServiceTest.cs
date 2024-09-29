using System.Linq.Expressions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.DataAccess.Repositories.Roles;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class UserServiceTest
{
    private Mock<IRepository<User>>? _userRepositoryMock;
    private Mock<UserService>? _userServiceMock;

    private UserService? _service;

    [TestInitialize]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IRepository<User>>();
        _userServiceMock = new Mock<UserService>(_userRepositoryMock.Object);
        _service = new UserService(_userRepositoryMock.Object);
    }

    [TestMethod]
    public void AddUser_WhenInfoIsOk_ShouldAddUserToRepository()
    {
        var mockRepository = new Mock<IRepository<User>>();
        var userService = new UserService(mockRepository.Object);
        Role rol = new Role();
        var createUserArgs = new CreateUserArgs(
              "John",
              "john@example.com",
              "password123!",
              "Doe",
              rol
        );

        var result = _service.AddUser(createUserArgs);

        _userRepositoryMock.Verify(r => r.Add(It.Is<User>(u =>
            u.Name == createUserArgs.Name &&
            u.Email == createUserArgs.Email &&
            u.Password == createUserArgs.Password &&
            u.LastName == createUserArgs.LastName &&
            u.Role == createUserArgs.Role
        )), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(createUserArgs.Name, result.Name);
        Assert.AreEqual(createUserArgs.Email, result.Email);
        Assert.AreEqual(createUserArgs.Password, result.Password);
        Assert.AreEqual(createUserArgs.LastName, result.LastName);
        Assert.AreEqual(createUserArgs.Role, result.Role);
    }

    [TestMethod]
    [ExpectedException(typeof(DuplicatedDataException))]
    public void AddUser_WhenEmailIsDuplicated_ShouldThrowDuplicatedDataException()
    {
        var existingUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Existing",
            Email = "duplicate@example.com",
            Password = "password123",
            LastName = "User",
            Role = new Role()
        };

        _userRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(existingUser);

        var createUserArgs = new CreateUserArgs(
            "New",
            "duplicate@example.com",
            "password123!",
            "User",
            new Role()
        );

        _service.AddUser(createUserArgs);
    }

    [TestMethod]
    public void AddCompanyOwner_ShouldAddCompanyOwnerToRepository()
    {
        var createUserArgs = new CreateUserArgs(
            "John",
            "john@example.com",
            "password123!",
            "Doe",
            new Role()
        );

        _userRepositoryMock.Setup(r => r.Add(It.IsAny<CompanyOwner>())).Verifiable();

        // Act
        var result = _service.AddCompanyOwner(createUserArgs);

        // Assert
        _userRepositoryMock.Verify(r => r.Add(It.Is<CompanyOwner>(u =>
            u.Name == createUserArgs.Name &&
            u.Email == createUserArgs.Email &&
            u.Password == createUserArgs.Password &&
            u.LastName == createUserArgs.LastName &&
            u.IsIncomplete == true
        )), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(createUserArgs.Name, result.Name);
        Assert.AreEqual(createUserArgs.Email, result.Email);
        Assert.AreEqual(createUserArgs.Password, result.Password);
        Assert.AreEqual(createUserArgs.LastName, result.LastName);
        Assert.IsTrue(result.IsIncomplete);
    }
}
