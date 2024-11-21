using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.HomeOwners;
using Homify.WebApi.Controllers.HomeOwners.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeOwnerControllerTest
{
    private readonly Mock<IUserService> _userService;
    private readonly HomeOwnerController _controller;
    private readonly Mock<IRoleService> _roleService;

    public HomeOwnerControllerTest()
    {
        _userService = new Mock<IUserService>(MockBehavior.Strict);
        _roleService = new Mock<IRoleService>(MockBehavior.Strict);
        _controller = new HomeOwnerController(_userService.Object, _roleService.Object);
    }

    [TestMethod]
    public void CreateHomeOwner_WhenDataIsOk_CreatesHomeOwner()
    {
        CreateHomeOwnerRequest req = new()
        {
            Email = "test@test.com",
            LastName = "test",
            Name = "test",
            Password = "test123@",
            ProfilePicUrl = "pic",
        };

        HomeOwner ho = new()
        {
            Email = req.Email,
            Password = req.Password,
            LastName = req.LastName,
            Name = req.Name,
        };

        var role = new Role { Name = "HOMEOWNER" };

        _roleService.Setup(r => r.Get("HOMEOWNER")).Returns(role);
        _userService.Setup(u => u.AddHomeOwner(It.IsAny<CreateHomeOwnerArgs>())).Returns(ho);

        var response = _controller.Create(req);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(ho.Id);
        ho.Name.Should().Be(req.Name);
        ho.Email.Should().Be(req.Email);
        ho.Password.Should().Be(req.Password);
        ho.LastName.Should().Be(req.LastName);
    }

    [TestMethod]
    public void CreateHomeOwner_WhenRequestIsNull_ThrowsArgumentNullException()
    {
        _userService.Setup(u => u.AddHomeOwner(It.IsAny<CreateHomeOwnerArgs>())).Throws<NullRequestException>();

        var response = () => _controller.Create(null);
        response.Should().Throw<NullRequestException>().WithMessage("Request cannot be null");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHomeOwner_WhenEmailIsNull_ThrowsArgumentNullException()
    {
        new CreateHomeOwnerArgs(null, "example@domain.com", ".Qwhnd123", "test123@", "pic", RolesGenerator.HomeOwner());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHomeOwner_WhenPasswordIsNull_ThrowsArgumentNullException()
    {
        new CreateHomeOwnerArgs("test", "example@domain.com", null, "test123@", "pic", RolesGenerator.HomeOwner());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHomeOwner_WhenLastNameIsNull_ThrowsArgumentNullException()
    {
        new CreateHomeOwnerArgs("test", "example@domain.com", ".Qwhnd123", null, "pic", RolesGenerator.HomeOwner());
    }

    [TestMethod]
    public void UpdateProfileResponse_ValidRequest_UpdatesProfilePicture()
    {
        var validRequest = new UpdateProfileRequest { ProfilePicture = "newProfilePic.jpg" };
        var user = new User { Id = "1", ProfilePicture = "oldProfilePic.jpg" };
        var updatedUser = new User { Id = "1", ProfilePicture = "newProfilePic.jpg" };

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = null;
        var mockController = new HomeOwnerController(_userService.Object, _roleService.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        _userService.Setup(s => s.UpdateProfilePicture(It.IsAny<string>(), It.IsAny<User>())).Returns(updatedUser);

        var response = mockController.UpdateProfileResponse(validRequest);

        Assert.IsNotNull(response);
        Assert.AreEqual(updatedUser.ProfilePicture, response.ProfilePicture);
    }
}
