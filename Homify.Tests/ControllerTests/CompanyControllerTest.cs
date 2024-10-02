using FluentAssertions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
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
    public void Create_WhenDataIsOk_ShouldCreateCompany()
    {
        // Arrange
        var request = new CreateCompanyRequest()
        {
            Name = "TestCompany",
            Rut = "TestRut",
            LogoUrl = "TestLogoUrl",
        };
        var expected = new Company()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            LogoUrl = request.LogoUrl,
            Rut = request.Rut,
            Owner = new CompanyOwner(),
            Devices = new List<Device>()
        };
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(), It.IsAny<User>())).Returns(expected);

        // Act
        var response = _controller.Create(request);

        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be(expected.Id);
    }

    [TestMethod]
    public void Create_WhenRequestIsNull_ShouldThrowArgumentNullException()
    {
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(),It.IsAny<User>())).Throws<NullRequestException>();

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
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(),It.IsAny<User>())).Throws(new ArgsNullException("name cannot be null or empty"));

        var response = () => _controller.Create(request);
        response.Should().Throw<ArgsNullException>().WithMessage("name cannot be null or empty");
    }

    [TestMethod]
    public void Create_WhenLogoUrlIsNull_ShouldThrowArgumentNullException()
    {
        var request = new CreateCompanyRequest()
        {
            Name = "TestCompany",
            Rut = "TestRut",
            LogoUrl = null,
        };
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(),It.IsAny<User>())).Throws(new ArgsNullException("logo image cannot be null or empty"));

        var response = () => _controller.Create(request);
        response.Should().Throw<ArgsNullException>().WithMessage("logo image cannot be null or empty");
    }

    [TestMethod]
    public void Create_WhenRutIsNull_ShouldThrowArgumentNullException()
    {
        var request = new CreateCompanyRequest()
        {
            Name = "TestCompany",
            Rut = null,
            LogoUrl = "TestLogoUrl",
        };
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>(),It.IsAny<User>())).Throws(new ArgsNullException("rut cannot be null or empty"));

        var response = () => _controller.Create(request);
        response.Should().Throw<ArgsNullException>().WithMessage("rut cannot be null or empty");
    }

    [TestMethod]
    public void AllCompanies_ShouldReturnPaginatedCompanyBasicInfo()
    {
        var companies = new List<Company>
        {
            new Company { Id = "1", Name = "Company A", Owner = new CompanyOwner() },
            new Company { Id = "2", Name = "Company B", Owner = new CompanyOwner() },
            new Company { Id = "3", Name = "Company C", Owner = new CompanyOwner() },
        };

        _companyServiceMock.Setup(s => s.GetAll()).Returns(companies);

        var limit = "2";
        var offset = "1";
        var expectedResult = new List<CompanyBasicInfo>
        {
            new CompanyBasicInfo(companies[1], companies[1].Owner),
            new CompanyBasicInfo(companies[2], companies[2].Owner)
        };

        var result = _controller.AllCompanies(limit, offset);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEqual(expectedResult, result);
    }
}
