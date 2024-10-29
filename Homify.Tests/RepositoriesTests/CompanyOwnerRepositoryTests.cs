using System.Linq.Expressions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class CompanyOwnerRepositoryTests
{
    [TestMethod]
    public void Get_CompanyOwnerExists_ReturnsCompanyOwner()
    {
        var testData = new List<CompanyOwner>
        {
            new CompanyOwner
            {
                Id = "1",
                Name = "CompanyOwner1",
                Company = new Company
                {
                    Id = "1",
                    Name = "Company1",
                    Devices = [new Device { Id = "1", Name = "Device1" }]
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<CompanyOwner>>();
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<CompanyOwner>()).Returns(mockSet.Object);

        var companyOwnerRepository = new CompanyOwnerRepository(mockContext.Object);

        var result = companyOwnerRepository.Get(co => co.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("CompanyOwner1", result.Name);
        Assert.AreEqual("Company1", result.Company.Name);
        Assert.AreEqual(1, result.Company.Devices.Count);
        Assert.AreEqual("Device1", result.Company.Devices.First().Name);
    }

    [TestMethod]
    public void Get_WhenCompanyOwnerDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<CompanyOwner>>();
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.Provider).Returns(new List<CompanyOwner>().AsQueryable().Provider);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.Expression).Returns(new List<CompanyOwner>().AsQueryable().Expression);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.ElementType).Returns(new List<CompanyOwner>().AsQueryable().ElementType);
        mockSet.As<IQueryable<CompanyOwner>>().Setup(m => m.GetEnumerator()).Returns(new List<CompanyOwner>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<CompanyOwner>()).Returns(mockSet.Object);

        var companyOwnerRepository = new CompanyOwnerRepository(mockContext.Object);
        Expression<Func<CompanyOwner, bool>> predicate = co => false;

        Assert.ThrowsException<NotFoundException>(() => companyOwnerRepository.Get(predicate));
    }
}
