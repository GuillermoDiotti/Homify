using FluentAssertions;
using Homify.BusinessLogic.HouseOwner;
using Homify.BusinessLogic.HouseOwner.Entities;
using Homify.BusinessLogic.Users;
using Homify.WebApi.Controllers.HomeOwners;
using Homify.WebApi.Controllers.HomeOwners.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class HomeOwnerControllerTest
{
    private readonly Mock<IUserService> _userService;
    private readonly HomeOwnerController _controller;

    public HomeOwnerControllerTest()
    {
        _userService = new Mock<IUserService>(MockBehavior.Strict);
        _controller = new HomeOwnerController(_userService.Object);
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
            CreatedAt = DateTime.Now,
        };

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
}
