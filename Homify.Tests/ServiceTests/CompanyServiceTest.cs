using System.Linq.Expressions;
using System.Reflection;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using ModeloValidador.Abstracciones;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class CompanyServiceTest
{
    private Mock<IRepository<Company>>? _companyRepositoryMock;
    private CompanyService? _service;

    private Mock<IDirectoryWrapper>? _mockDirectory;
    private Mock<IAssemblyLoader>? _mockAssemblyLoader;
    private Mock<IModeloValidador>? _mockValidator;
    private Company? _company;

    [TestInitialize]
    public void Setup()
    {
        _companyRepositoryMock = new Mock<IRepository<Company>>();
        _service = new CompanyService(_companyRepositoryMock.Object);

        _mockDirectory = new Mock<IDirectoryWrapper>();
        _mockAssemblyLoader = new Mock<IAssemblyLoader>();
        _mockValidator = new Mock<IModeloValidador>();
        _company = new Company();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void Constructor_ShouldThrowArgsNullException_WhenNameIsNullOrEmpty()
    {
        string name = null;
        var logoUrl = "validLogoUrl";
        var rut = "validRut";
        var validator = "validValidator";
        var owner = new CompanyOwner { IsIncomplete = true };

        new CreateCompanyArgs(name, logoUrl, rut, validator, owner);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void Constructor_ShouldThrowArgsNullException_WhenLogoUrlIsNullOrEmpty()
    {
        var name = "validName";
        string logoUrl = null;
        var rut = "validRut";
        var validator = "validValidator";
        var owner = new CompanyOwner { IsIncomplete = true };

        new CreateCompanyArgs(name, logoUrl, rut, validator, owner);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void Constructor_ShouldThrowArgsNullException_WhenRutIsNullOrEmpty()
    {
        var name = "validName";
        var logoUrl = "validLogoUrl";
        string rut = null;
        var validator = "validValidator";
        var owner = new CompanyOwner { IsIncomplete = true };

        new CreateCompanyArgs(name, logoUrl, rut, validator, owner);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Constructor_ShouldThrowInvalidOperationException_WhenOwnerIsNull()
    {
        var name = "validName";
        var logoUrl = "validLogoUrl";
        var rut = "validRut";
        var validator = "validValidator";
        CompanyOwner owner = null;

        new CreateCompanyArgs(name, logoUrl, rut, validator, owner);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Constructor_ShouldThrowInvalidOperationException_WhenOwnerIsNotIncomplete()
    {
        var name = "validName";
        var logoUrl = "validLogoUrl";
        var rut = "validRut";
        var validator = "validValidator";
        var owner = new CompanyOwner { IsIncomplete = false };

        new CreateCompanyArgs(name, logoUrl, rut, validator, owner);
    }

    [TestMethod]
    public void ValidateModel_ShouldThrowInvalidDataException_WhenValidatorNotFound()
    {
        var model = "ValidModel";
        var mockFilePaths = new string[] { };

        _mockDirectory.Setup(d => d.GetFiles(It.IsAny<string>(), It.IsAny<string>())).Returns(mockFilePaths);

        Assert.ThrowsException<InvalidDataException>(() => _company.ValidateModel(model));
    }

    [TestMethod]
    public void ValidateModel_ShouldThrowInvalidDataException_WhenModelIsInvalid()
    {
        var model = "InvalidModel";
        var mockFilePaths = new[] { "validator.dll" };
        var mockTypes = new[] { typeof(MockValidator) };

        _mockDirectory.Setup(d => d.GetFiles(It.IsAny<string>(), It.IsAny<string>())).Returns(mockFilePaths);
        _mockAssemblyLoader.Setup(a => a.LoadFile(It.IsAny<string>())).Returns(Assembly.GetExecutingAssembly());
        _mockValidator.Setup(v => v.EsValido(It.IsAny<Modelo>())).Returns(false);

        Assert.ThrowsException<InvalidDataException>(() => _company.ValidateModel(model));
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
            string.Empty,
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
            string.Empty,
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
        var result = _service.GetByOwner(userId);
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCompany, result);
    }

    [TestMethod]
    public void GetByUserId_ShouldReturnNull_WhenNotFoundExceptionThrown()
    {
        var userId = "test-user-id";
        _companyRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Company, bool>>>()))
            .Throws(new NotFoundException("Test Company"));
        var result = _service.GetByOwner(userId);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void AddValidatorModel_ShouldReturnModel_WhenCompanyExists()
    {
        var user = new User { Id = "1" };
        var company = new Company { OwnerId = "1" };
        var model = "ValidatorModel";

        _companyRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<Company, bool>>>())).Returns(company);

        var result = _service.AddValidatorModel(model, user);

        Assert.AreEqual(model, result);
        _companyRepositoryMock.Verify(r => r.Update(It.Is<Company>(c => c.ValidatorType == model)), Times.Once);
    }

    [TestMethod]
    public void AddValidatorModel_ShouldThrowNotFoundException_WhenCompanyDoesNotExist()
    {
        var user = new User { Id = "1" };
        var model = "ValidatorModel";

        _companyRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<Company, bool>>>())).Returns((Company)null);

        Assert.ThrowsException<NotFoundException>(() => _service.AddValidatorModel(model, user));
    }

    [TestMethod]
    public void GetAll_ShouldFilterByOwner()
    {
        var companies = new List<Company>
        {
            new Company { Owner = new CompanyOwner { Name = "John", LastName = "Doe" }, Name = "CompanyA" },
            new Company { Owner = new CompanyOwner { Name = "Jane", LastName = "Smith" }, Name = "CompanyB" }
        };
        _companyRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns(companies);

        var result = _service.GetAll(owner: "John Doe");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("CompanyA", result[0].Name);
    }

    [TestMethod]
    public void GetAll_ShouldFilterByCompany()
    {
        var companies = new List<Company>
        {
            new Company { Owner = new CompanyOwner { Name = "John", LastName = "Doe" }, Name = "CompanyA" },
            new Company { Owner = new CompanyOwner { Name = "Jane", LastName = "Smith" }, Name = "CompanyB" }
        };
        _companyRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns(companies);
        var result = _service.GetAll(company: "CompanyB");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("CompanyB", result[0].Name);
    }

    [TestMethod]
    public void GetAll_ShouldFilterByOwnerAndCompany()
    {
        var companies = new List<Company>
        {
            new Company { Owner = new CompanyOwner { Name = "John", LastName = "Doe" }, Name = "CompanyA" },
            new Company { Owner = new CompanyOwner { Name = "Jane", LastName = "Smith" }, Name = "CompanyB" }
        };
        _companyRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Company, bool>>>()))
            .Returns(companies);
        var result = _service.GetAll(owner: "Jane Smith", company: "CompanyB");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("CompanyB", result[0].Name);
    }

    public interface IDirectoryWrapper
    {
        string[] GetFiles(string path, string searchPattern);
    }

    public interface IAssemblyLoader
    {
        Assembly LoadFile(string path);
    }

    public class MockValidator : IModeloValidador
    {
        public bool EsValido(Modelo modelo) => true;
    }
}
