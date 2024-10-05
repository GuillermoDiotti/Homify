using FluentAssertions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Companies;
using Homify.WebApi.Controllers.Companies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

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

        _companyServiceMock.Setup(x => x.GetByUserId(companyOwner.Id)).Returns((Company)null);
        _companyServiceMock.Setup(x => x.GetAll()).Returns(new List<Company>() { });
        var company = new Company
        {
            Name = "NewCompany"
        };
        _companyServiceMock.Setup(x => x.Add(It.IsAny<CreateCompanyArgs>(), companyOwner))
            .Returns(company);

        // Act
        var result = _controller.Create(request); // Llama al método del controlador en lugar de la clase de servicio

        // Assert
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

        _companyServiceMock.Setup(c => c.GetByUserId(companyOwner.Id)).Returns((Company)null);

        // Setup the GetAll method to return an empty list
        _companyServiceMock.Setup(c => c.GetAll()).Returns(new List<Company>());

        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(), It.IsAny<User>()))
            .Throws(new ArgsNullException("name cannot be null or empty"));

        var action = () => mockController.Create(request);

        action.Should().Throw<ArgsNullException>()
            .WithMessage("name cannot be null or empty");
    }

    [TestMethod]
    public void AllCompanies_ShouldReturnPaginatedCompanyBasicInfo()
    {
        var companies = new List<Company>
        {
            new Company
            {
                Id = "1",
                Name = "Company A",
                Owner = new CompanyOwner()
            },
            new Company
            {
                Id = "2",
                Name = "Company B",
                Owner = new CompanyOwner()
            },
            new Company
            {
                Id = "3",
                Name = "Company C",
                Owner = new CompanyOwner()
            },
        };

        _companyServiceMock.Setup(s => s.GetAll()).Returns(companies);

        var limit = "2";
        var offset = "1";
        var expectedResult = new List<CompanyBasicInfo>
        {
            new CompanyBasicInfo(companies[1], companies[1].Owner),
            new CompanyBasicInfo(companies[2], companies[2].Owner)
        };

        var result = _controller.AllCompanies(limit, offset, string.Empty, string.Empty);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEqual(expectedResult, result);
    }
}

public class TestableCompanyController : CompanyController
{
    public TestableCompanyController(ICompanyService companyService)
        : base(companyService) { }

    public virtual User GetUserLogged()
    {
        return base.GetUserLogged();
    }
}

