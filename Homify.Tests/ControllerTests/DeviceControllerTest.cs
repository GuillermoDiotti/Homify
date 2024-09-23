using FluentAssertions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.WebApi.Controllers.Devices;
using Homify.WebApi.Controllers.Devices.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class DeviceControllerTest
{
    private readonly DeviceController _controller;
    private readonly Mock<IDeviceService> _deviceServiceMock;

    public DeviceControllerTest()
    {
        _deviceServiceMock = new Mock<IDeviceService>(MockBehavior.Strict);
        _controller = new DeviceController(_deviceServiceMock.Object);
    }

    [TestMethod]
    public void RegisterCamera_WhenDataIsOk_ShouldRegisterCamera()
    {
        var request = new CreateCameraRequest()
        {
            Name = "Test",
            Description = "Test",
            Model = "Test",
            Photos = ["1", "2", "3"],
            IsExterior = false,
            IsInterior = true,
            MovementDetection = true,
            PeopleDetection = false,
            PpalPicture = "Test"
        };
        var expected = new Camera()
        {
            Name = request.Name,
            PpalPicture = request.PpalPicture,
            Company = new Company(),
            Description = request.Description,
            Model = request.Model,
            Photos = request.Photos,
            IsExterior = request.IsExterior,
            IsInterior = request.IsInterior,
            MovementDetection = request.MovementDetection,
            PeopleDetection = request.PeopleDetection,
        };

        var args = new CreateDeviceArgs(request.Name, request.Model, request.Description, request.Photos, request.PpalPicture);

        _deviceServiceMock.Setup(d => d.AddCamera(It.IsAny<CreateDeviceArgs>())).Returns(expected);

        var response = _controller.RegisterCamera(request);

        response.Should().NotBeNull();
        response.Id.Should().Be(expected.Id);
        expected.Name.Should().Be(args.Name);
        expected.Model.Should().Be(args.Model);
        expected.Description.Should().Be(args.Description);
        expected.Photos.Should().BeEquivalentTo(args.Photos);
        expected.PpalPicture.Should().Be(args.PpalPicture);
        expected.IsExterior.Should().Be(request.IsExterior);
        expected.IsInterior.Should().Be(request.IsInterior);
        expected.MovementDetection.Should().Be(request.MovementDetection);
        expected.PeopleDetection.Should().Be(request.PeopleDetection);
        expected.Company.Should().NotBeNull();
    }
}
