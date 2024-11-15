using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class CompanyServiceTest
{
    private Mock<IRepository<Company>>? _companyRepositoryMock;

    private CompanyService? _service;

    [TestInitialize]
    public void Setup()
    {
        _companyRepositoryMock = new Mock<IRepository<Company>>();
        _service = new CompanyService(_companyRepositoryMock.Object);
    }

    [TestMethod]
    public void Add_WhenInfoIsOk_ShouldAddCompanyToRepository()
    {
        var user = new CompanyOwner
        {
            Id = "1",
            Name = "John",
            Email = "john@example.com",
            Password = "password123",
            LastName = "Doe",
            Roles =
            [
                new UserRole() { UserId = "1", Role = RolesGenerator.CompanyOwner() }

            ]
        };

        var createCompanyArgs = new CreateCompanyArgs(
            "Test Company",
            "https://example.com/logo.png",
            "123456789",
            user);

        _companyRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns([new Company()]);
        _companyRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns((Company)null);
        _companyRepositoryMock.Setup(r => r.Add(It.IsAny<Company>())).Verifiable();

        var result = _service.Add(createCompanyArgs, user);

        _companyRepositoryMock.Verify(r => r.Add(It.Is<Company>(c =>
            c.Name == createCompanyArgs.Name &&
            c.LogoUrl == createCompanyArgs.LogoUrl &&
            c.Rut == createCompanyArgs.Rut &&
            c.Owner == user)), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(createCompanyArgs.Name, result.Name);
        Assert.AreEqual(createCompanyArgs.LogoUrl, result.LogoUrl);
        Assert.AreEqual(createCompanyArgs.Rut, result.Rut);
        Assert.AreEqual(user, result.Owner);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Create_WhenUserAlreadyOwnsACompany_ShouldThrowInvalidOperationException()
    {
        var companyOwner = new CompanyOwner { Id = "owner123", IsIncomplete = true };

        var createCompanyArgs = new CreateCompanyArgs(
            "Test Company",
            "https://example.com/logo.png",
            "123456789",
            companyOwner);

        _companyRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns([new Company()]);
        _companyRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns(new Company());

        _service.Add(createCompanyArgs, companyOwner);
    }

    [TestMethod]
    public void GetByUserId_ShouldReturnCompany_WhenCompanyExists()
    {
        var userId = "test-user-id";
        var expectedCompany = new Company { Id = Guid.NewGuid().ToString(), Name = "Test Company", OwnerId = userId };
        _companyRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns(expectedCompany);
        var result = _service.GetByUserId(userId);
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCompany, result);
    }

    [TestMethod]
    public void GetByUserId_ShouldReturnNull_WhenNotFoundExceptionThrown()
    {
        var userId = "test-user-id";
        _companyRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Company, bool>>>()))
            .Throws(new NotFoundException("Test Company"));
        var result = _service.GetByUserId(userId);
        Assert.IsNull(result);
    }
}
