using Homify.BusinessLogic.Rooms.Entities;
using Homify.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class RoomRepositoryTests
{
    [TestMethod]
    public void Get_RoomExists_ReturnsRoom()
    {
        var testData = new List<Room>
        {
            new Room
            {
                Id = "1",
                Name = "Room1",
                HomeId = "1"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Room>>();
        mockSet.As<IQueryable<Room>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Room>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Room>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Room>()).Returns(mockSet.Object);

        var roomRepository = new RoomRepository(mockContext.Object);

        var result = roomRepository.Get(r => r.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Room1", result.Name);
        Assert.AreEqual("1", result.HomeId);
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredRooms()
    {
        var testData = new List<Room>
        {
            new Room
            {
                Id = "1",
                Name = "Room1",
                HomeId = "1"
            },
            new Room
            {
                Id = "2",
                Name = "Room2",
                HomeId = "2"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Room>>();
        mockSet.As<IQueryable<Room>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Room>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Room>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Room>()).Returns(mockSet.Object);

        var roomRepository = new RoomRepository(mockContext.Object);

        var result = roomRepository.GetAll(r => r.Name == "Room1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Room1", result[0].Name);
    }
}
