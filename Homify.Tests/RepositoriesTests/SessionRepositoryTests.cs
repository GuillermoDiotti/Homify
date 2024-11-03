using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

/*[TestClass]
public class SessionRepositoryTests
{
    [TestMethod]
    public void Get_UserExists_ReturnsSession()
    {
        var testData = new List<Session>
        {
            new Session
            {
                Id = "1",
                User = new User
                {
                    Id = "1",
                    Email = "user1@example.com",
                    Name = "User1",
                    LastName = "LastName1",
                    Password = "Password1",
                    Roles = RolesGenerator.Admin()
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Session>>();
        mockSet.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Session>()).Returns(mockSet.Object);

        var sessionRepository = new SessionRepository(mockContext.Object);

        var result = sessionRepository.Get(s => s.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Id);
        Assert.AreEqual("User1", result.User.Name);
        Assert.AreEqual("LastName1", result.User.LastName);
        Assert.AreEqual("user1@example.com", result.User.Email);
        Assert.AreEqual("ADMINISTRATOR", result.User.Roles.Name);
    }

    [TestMethod]
    public void Get_WhenSessionDoesNotExist_ThrowsNotFoundException()
    {
        var mockSet = new Mock<DbSet<Session>>();
        mockSet.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(new List<Session>().AsQueryable().Provider);
        mockSet.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(new List<Session>().AsQueryable().Expression);
        mockSet.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(new List<Session>().AsQueryable().ElementType);
        mockSet.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(new List<Session>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Session>()).Returns(mockSet.Object);

        var sessionRepository = new SessionRepository(mockContext.Object);
        Expression<Func<Session, bool>> predicate = session => session.Id == "non-existent-id";

        Assert.ThrowsException<NotFoundException>(() => sessionRepository.Get(predicate));
    }
}*/
