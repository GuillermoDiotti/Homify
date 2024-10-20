using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class RoomServiceTest
{
    private Mock<IHomeService> _mockHomeService;
    private Mock<IRepository<Room>> _mockRoomRepository;
    private RoomService _roomService;

    [TestInitialize]
    public void Setup()
    {
        _mockHomeService = new Mock<IHomeService>();
        _mockRoomRepository = new Mock<IRepository<Room>>();
        _roomService = new RoomService(_mockHomeService.Object, _mockRoomRepository.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AddHomeRoom_HomeNotFound_ThrowsNotFoundException()
    {
        var args = new CreateRoomArgs("Living Room", "home123", new HomeOwner { Id = "owner123" });

        _mockHomeService.Setup(s => s.GetHomeById(args.HomeId)).Returns((Home)null);

        _roomService.AddHomeRoom(args);
    }
}
