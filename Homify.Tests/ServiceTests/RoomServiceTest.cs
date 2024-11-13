using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories.Rooms;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class RoomServiceTest
{
    private Mock<IHomeService>? _mockHomeService;
    private Mock<IHomeDeviceService>? _mockHomeDeviceService;
    private Mock<IRepository<Room>>? _mockRoomRepository;
    private RoomService? _roomService;

    [TestInitialize]
    public void Setup()
    {
        _mockHomeService = new Mock<IHomeService>();
        _mockHomeDeviceService = new Mock<IHomeDeviceService>();
        _mockRoomRepository = new Mock<IRepository<Room>>();
        _roomService = new RoomService(_mockRoomRepository.Object, _mockHomeService.Object, _mockHomeDeviceService.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AddHomeRoom_HomeNotFound_ThrowsNotFoundException()
    {
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns((Home)null);

        _roomService.AddHomeRoom(args);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddHomeRoom_RoomNameAlreadyExists_ThrowsInvalidOperationException()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner123" } };
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns(home);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>()))
            .Returns(new Room { Name = "Living Room", HomeId = "home123" });

        _roomService.AddHomeRoom(args);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddHomeRoom_UserIsNotOwner_ThrowsInvalidOperationException()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner456" } };
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns(home);

        _roomService.AddHomeRoom(args);
    }

    [TestMethod]
    public void AddHomeRoom_ValidRequest_AddsRoomSuccessfully()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner123" } };
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns(home);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns((Room)null);

        var result = _roomService.AddHomeRoom(args);

        _mockRoomRepository.Verify(r => r.Add(It.IsAny<Room>()), Times.Once);
        Assert.AreEqual("Living Room", result.Name);
        Assert.AreEqual(home.Id, result.HomeId);
    }

    [TestMethod]
    public void AddHomeRoom_ValidRequest_ReturnsRoomWithCorrectValues()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner123" } };
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns(home);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns((Room)null);

        var result = _roomService.AddHomeRoom(args);

        Assert.AreEqual("Living Room", result.Name);
        Assert.AreEqual(home.Id, result.HomeId);
        Assert.IsNotNull(result.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AssignHomeDeviceToRoom_HomeDeviceDoesNotBelongToRoomHome_ThrowsInvalidOperationException()
    {
        var homeDevice = new HomeDevice { Id = "device123", Home = new Home { Id = "home456" } };
        var room = new Room { Id = "room123", Home = new Home { Id = "home123" } };

        var args = new UpdateRoomArgs("room123", "device123", new HomeOwner { Id = "owner123" });

        _mockHomeDeviceService.Setup(s => s.GetHomeDeviceById(args.HomeDeviceId)).Returns(homeDevice);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns(room);

        _roomService.AssignHomeDeviceToRoom(args);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AssignHomeDeviceToRoom_UserIsNotOwner_ThrowsInvalidOperationException()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner456" } };
        var room = new Room { Id = "room123", Home = home };
        var homeDevice = new HomeDevice { Id = "device123", Home = home };

        var args = new UpdateRoomArgs("room123", "device123", new HomeOwner { Id = "owner123" });

        _mockHomeDeviceService.Setup(s => s.GetHomeDeviceById(args.HomeDeviceId)).Returns(homeDevice);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns(room);

        _roomService.AssignHomeDeviceToRoom(args);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AssignHomeDeviceToRoom_DeviceAlreadyAssignedToAnotherRoom_ThrowsInvalidOperationException()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner123" } };
        var homeDevice = new HomeDevice { Id = "device123", Home = home };

        var room1 = new Room { Id = "room123", Home = home, Devices = [homeDevice] };
        var room2 = new Room { Id = "room456", Home = home, Devices = [] };

        var args = new UpdateRoomArgs("room456", "device123", new HomeOwner { Id = "owner123" });

        _mockHomeDeviceService.Setup(s => s.GetHomeDeviceById(args.HomeDeviceId)).Returns(homeDevice);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns(room2);
        _mockRoomRepository.Setup(r => r.GetAll(It.IsAny<Expression<Func<Room, bool>>>())).Returns([room1, room2]);

        _roomService.AssignHomeDeviceToRoom(args);
    }

    [TestMethod]
    public void AssignHomeDeviceToRoom_ValidRequest_AssignsDeviceToRoomSuccessfully()
    {
        var home = new Home { Id = "home123", Owner = new HomeOwner { Id = "owner123" } };
        var homeDevice = new HomeDevice { Id = "device123", Home = home };

        var room = new Room { Id = "room123", Home = home, Devices = [] };

        var args = new UpdateRoomArgs("room123", "device123", new HomeOwner { Id = "owner123" });

        _mockHomeDeviceService.Setup(s => s.GetHomeDeviceById(args.HomeDeviceId)).Returns(homeDevice);
        _mockRoomRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Room, bool>>>())).Returns(room);
        _mockRoomRepository.Setup(r => r.GetAll(It.IsAny<Expression<Func<Room, bool>>>())).Returns([room]);

        var result = _roomService.AssignHomeDeviceToRoom(args);

        Assert.IsTrue(result.Devices.Contains(homeDevice));
        _mockRoomRepository.Verify(r => r.Update(room), Times.Once);
    }
}
