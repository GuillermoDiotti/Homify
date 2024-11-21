using FluentAssertions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Controllers.Companies;
using Homify.WebApi.Controllers.Companies.Models;
using Homify.WebApi.Controllers.Companies.Models.Requests;
using Homify.WebApi.Controllers.Companies.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloValidador.Abstracciones;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class CompanyControllerTest
{
    private readonly CompanyController _controller;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public CompanyControllerTest()
    {
        _companyServiceMock = new Mock<ICompanyService>(MockBehavior.Strict);
        _controller = new CompanyController(_companyServiceMock.Object);
        var httpContext = new DefaultHttpContext();
        httpContext.Items["UserLogged"] = new User { };
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };
    }

    [TestInitialize]
    public void TestSetup()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Validators");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.WriteAllText(Path.Combine(path, "FakeValidator.dll"), "Fake content");
    }

    [TestMethod]
    public void Create_WhenRequstIsOk_ShouldReturnCreateCompanyResponse()
    {
        // Arrange
        var request = new CreateCompanyRequest
        {
            Name = "NewCompany",
            LogoUrl = "logo.png",
            Rut = "123456789"
        };
        var companyOwner = new CompanyOwner
        {
            Id = "1",
            IsIncomplete = true
        };
        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = companyOwner;

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        _companyServiceMock.Setup(x => x.GetByOwner(companyOwner.Id)).Returns((Company)null);
        _companyServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([]);

        var company = new Company
        {
            Name = "NewCompany"
        };
        _companyServiceMock.Setup(x => x.Add(It.IsAny<CreateCompanyArgs>(), companyOwner))
            .Returns(company);

        var result = _controller.Create(request);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Create_WhenRequestIsNull_ShouldThrowArgumentNullException()
    {
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(), It.IsAny<User>())).Throws<NullRequestException>();

        var response = () => _controller.Create(null);
        response.Should().Throw<NullRequestException>().WithMessage("Request cannot be null");
    }

    [TestMethod]
    public void Create_WhenNameIsNull_ShouldThrowArgumentNullException()
    {
        var request = new CreateCompanyRequest()
        {
            Name = null,
            Rut = "TestRut",
            LogoUrl = "TestLogoUrl",
        };

        var companyOwner = new CompanyOwner
        {
            Id = "ownerId",
            IsIncomplete = true
        };

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = companyOwner;

        var mockController = new TestableCompanyController(_companyServiceMock.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        _companyServiceMock.Setup(c => c.GetByOwner(companyOwner.Id)).Returns((Company)null);

        _companyServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([]);

        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(), It.IsAny<User>()))
            .Throws(new ArgsNullException("name cannot be null or empty"));

        var action = () => mockController.Create(request);

        action.Should().Throw<ArgsNullException>()
            .WithMessage("name cannot be null or empty");
    }

    [TestMethod]
    public void AllCompanies_ShouldReturnPaginatedCompanyBasicInfo()
    {
        var validatorMock = new Mock<IModeloValidador>();
        validatorMock
            .Setup(v => v.EsValido(It.IsAny<Modelo>()))
            .Returns(true);

        var expectedRole = new Role
        {
            Name = "COMPANYOWNER",
            Permissions = [new SystemPermission { Value = "companies-Create" }]
        };

        var owner = new CompanyOwner
        {
            Name = "name",
            LastName = "lastName",
            Email = "mail@gmail.com",
            Password = "password",
            Id = Guid.NewGuid().ToString(),
            ProfilePicture = "foto",
            Roles = [new UserRole { UserId = "123", Role = expectedRole }],
            IsIncomplete = true,
            CreatedAt = HomifyDateTime.GetActualDate()
        };

        var companies = new List<Company>
        {
            new Company { Id = "1", Name = "Company A", Owner = owner, ValidatorType = validatorMock.Object.ToString() },
            new Company { Id = "2", Name = "Company B", Owner = owner, ValidatorType = validatorMock.Object.ToString() },
            new Company { Id = "3", Name = "Company C", Owner = owner, ValidatorType = validatorMock.Object.ToString() }
        };

        _companyServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(companies);

        var limit = "2";
        var offset = "1";
        var expectedResult = new List<CompanyBasicInfo>
        {
            new CompanyBasicInfo(companies[1], companies[1].Owner),
            new CompanyBasicInfo(companies[2], companies[2].Owner)
        };

        var req = new CompanyFiltersRequest
        {
            Limit = limit,
            Offset = offset
        };

        var result = _controller.AllCompanies(req);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [ExpectedException(typeof(DuplicatedDataException))]
    public void Create_WhenCompanyNameExists_ShouldThrowDuplicatedDataException()
    {
        var request = new CreateCompanyRequest
        {
            Name = "ExistingCompany",
            LogoUrl = "http://example.com/logo.png",
            Rut = "12345678-9"
        };

        var owner = new CompanyOwner
        {
            Name = "Valid Owner",
            LastName = "Owner Last Name",
            Email = "owner@example.com"
        };

        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = owner;

        _companyServiceMock.Setup(x => x.Add(It.IsAny<CreateCompanyArgs>(), owner)).Throws(new DuplicatedDataException("The name is already taken."));

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Create_WhenCompanyOwnerAccountIsNotIncomplete_ShouldThrowInvalidOperationException()
    {
        var companyOwner = new CompanyOwner
        {
            Id = "owner123",
            IsIncomplete = false
        };
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = companyOwner;

        var request = new CreateCompanyRequest
        {
            Name = "ExistingCompany",
            LogoUrl = "http://example.com/logo.png",
            Rut = "12345678-9",
        };

        _controller.Create(request);
    }

    [TestMethod]
    public void AllCompanies_WhenOwnerFullNameAndCompanyAreProvided_ShouldFilterAndReturnPaginatedList()
    {
        var limit = "5";
        var offset = "0";
        var ownerFullName = "John Doe";
        var company = "TechCorp";
        var companies = new List<Company>
        {
            new Company
            {
                Name = "TechCorp",
                Owner = new CompanyOwner { Name = "John", LastName = "Doe" }
            },
            new Company
            {
                Name = "OtherCorp",
                Owner = new CompanyOwner { Name = "Jane", LastName = "Smith" }
            }
        };

        _companyServiceMock
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([new Company
            {
                Name = "TechCorp",
                Owner = new CompanyOwner { Name = "John", LastName = "Doe" }
            }

            ]);

        var req = new CompanyFiltersRequest()
        {
            Limit = limit,
            Offset = offset,
            OwnerFullName = ownerFullName,
            Company = company
        };

        var result = _controller.AllCompanies(req);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("TechCorp", result[0].CompanyName);
    }

    [TestMethod]
    public void UpdateCompanyValidator_ShouldReturnUpdatedModel_WhenRequestIsValid()
    {
        var user = new CompanyOwner { Id = "1", Company = new Company() { ValidatorType = "TestModel" } };
        var updatedModel = "UpdatedModel";
        var request = new AddValidatorBasicInfo() { Model = updatedModel };

        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;
        _companyServiceMock.Setup(s => s.AddValidatorModel(It.IsAny<string>(), It.IsAny<User>())).Returns(updatedModel);

        var result = _controller.UpdateCompanyValidator(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(updatedModel, result.Model);
    }
}

public class TestableCompanyController(ICompanyService companyService) : CompanyController(companyService)
{
    public virtual User GetUserLogged()
    {
        return base.GetUserLogged();
    }
}
