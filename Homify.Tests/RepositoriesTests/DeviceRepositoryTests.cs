using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class DeviceRepositoryTests
{
    [TestMethod]
    public void Get_DeviceExists_ReturnsDevice()
    {
        var testData = new List<Device>
        {
            new Device
            {
                Id = "1",
                Name = "Device1",
                Company = new Company
                {
                    Id = "1",
                    Name = "Company1",
                    Owner = new CompanyOwner { Id = "1", Name = "Owner1" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Device>>();
        mockSet.As<IQueryable<Device>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Device>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Device>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Device>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Device>()).Returns(mockSet.Object);

        var deviceRepository = new DeviceRepository(mockContext.Object);

        var result = deviceRepository.Get(d => d.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Device1", result.Name);
        Assert.AreEqual("Company1", result.Company.Name);
        Assert.AreEqual("Owner1", result.Company.Owner.Name);
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredDevices()
    {
        var testData = new List<Device>
        {
            new Device
            {
                Id = "1",
                Name = "Device1",
                Company = new Company
                {
                    Id = "1",
                    Name = "Company1",
                    Owner = new CompanyOwner { Id = "1", Name = "Owner1" }
                }
            },
            new Device
            {
                Id = "2",
                Name = "Device2",
                Company = new Company
                {
                    Id = "2",
                    Name = "Company2",
                    Owner = new CompanyOwner { Id = "2", Name = "Owner2" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Device>>();
        mockSet.As<IQueryable<Device>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Device>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Device>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Device>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Device>()).Returns(mockSet.Object);

        var deviceRepository = new DeviceRepository(mockContext.Object);

        var result = deviceRepository.GetAll(d => d.Name == "Device1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Device1", result[0].Name);
    }
}
