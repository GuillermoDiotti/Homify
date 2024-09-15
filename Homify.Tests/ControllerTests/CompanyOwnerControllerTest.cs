using FluentAssertions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins;
using Homify.WebApi.Controllers.CompanyOwners;
using Homify.WebApi.Controllers.CompanyOwners.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class CompanyOwnerControllerTest
{
    private readonly CompanyOwnerController _controller;
    private readonly Mock<IUserService> _ownerServiceMock;

    public CompanyOwnerControllerTest()
    {
        _ownerServiceMock = new Mock<IUserService>(MockBehavior.Strict);
        _controller = new CompanyOwnerController(_ownerServiceMock.Object);
    }

    #region Create

    #region Success

    [TestMethod]
    public void CreateOwner_WhenDataIsOk_ShouldCreateOwner()
    {
        var request = new CreateCompanyOwnerRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "12345",
            LastName = "lastName"
        };

        var expectedOwner = new CompanyOwner()
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            LastName = request.LastName
        };
        _ownerServiceMock.Setup(ow => ow.AddCompanyOwner(It.IsAny<CreateUserArgs>())).Returns(expectedOwner);

        var response = _controller.Create(request);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(expectedOwner.Id);
        expectedOwner.Name.Should().Be(request.Name);
        expectedOwner.Email.Should().Be(request.Email);
        expectedOwner.Password.Should().Be(request.Password);
        expectedOwner.LastName.Should().Be(request.LastName);
    }

    #endregion

    #region Error
    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateOwner_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void CreateOwner_WhenUserServiceFails_ShouldThrowException()
    {
        var request = new CreateCompanyOwnerRequest()
        {
            Name = "John",
            Email = "example@gmail.com",
            Password = "12345",
            LastName = "lastName"
        };

        _ownerServiceMock.Setup(ow => ow.AddCompanyOwner(It.IsAny<CreateUserArgs>())).Throws(new Exception("Internal Error"));

        _controller.Create(request);
    }

    #endregion

    #endregion
}
