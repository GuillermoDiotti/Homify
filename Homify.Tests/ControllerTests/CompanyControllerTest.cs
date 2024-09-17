using FluentAssertions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Companies;
using Homify.WebApi.Controllers.Companies.Models;
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
    }

    [TestMethod]
    public void Create_WhenRequestIsNull_ShouldThrowArgumentNullException()
    {
        _companyServiceMock.Setup(c => c.Add(It.IsAny<CreateCompanyArgs>())).Throws<NullRequestException>();

        var response = () => _controller.Create(null);
        response.Should().Throw<NullRequestException>().WithMessage("Request cannot be null");
    }
}
