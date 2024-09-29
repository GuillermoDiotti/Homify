using FluentAssertions;
using Homify.BusinessLogic.Companies;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Companies;
using Homify.WebApi.Controllers.Companies.Models;
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
    }

    [TestMethod]
    public void Create_WhenDataIsOk_ShouldCreateCompany()
    {
        var request = new CreateCompanyRequest()
        {
            Name = "TestCompany",
            Rut = "TestRut",
            LogoUrl = "TestLogoUrl",
        };
        var expected = new Company()
        {
            Name = request.Name,
            LogoUrl = request.LogoUrl,
            Rut = request.Rut,
        };
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Returns(expected);

        var response = _controller.Create(request);

        response.Should().NotBeNull();
        response.Id.Should().Be(expected.Id);
        expected.Name.Should().Be(request.Name);
        expected.LogoUrl.Should().Be(request.LogoUrl);
        expected.Rut.Should().Be(request.Rut);
    }

    [TestMethod]
    public void Create_WhenRequestIsNull_ShouldThrowArgumentNullException()
    {
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Throws<NullRequestException>();

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
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Throws(new ArgsNullException("name cannot be null or empty"));

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
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Throws(new ArgsNullException("logo image cannot be null or empty"));

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
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Throws(new ArgsNullException("rut cannot be null or empty"));

        var response = () => _controller.Create(request);
        response.Should().Throw<ArgsNullException>().WithMessage("rut cannot be null or empty");
    }
}
