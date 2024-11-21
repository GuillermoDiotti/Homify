using System.Linq.Expressions;
using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class CompanyRepositoryTests
{
    [TestMethod]
    public void Get_CompanyExists_ReturnsCompany()
    {
        var testData = new List<Company>
        {
            new Company
            {
                Id = "1",
                Name = "Company1",
                Owner = new CompanyOwner { Id = "1", Name = "Owner1" },
                Devices = [new Device { Id = "1", Name = "Device1" }]
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Company>>();
        mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Company>()).Returns(mockSet.Object);

        var companyRepository = new CompanyRepository(mockContext.Object);

        var result = companyRepository.Get(c => c.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Company1", result.Name);
        Assert.AreEqual("Owner1", result.Owner.Name);
        Assert.AreEqual(1, result.Devices.Count);
        Assert.AreEqual("Device1", result.Devices.First().Name);
    }

    [TestMethod]
    public void Get_WhenCompanyDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<Company>>();
        mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(new List<Company>().AsQueryable().Provider);
        mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(new List<Company>().AsQueryable().Expression);
        mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(new List<Company>().AsQueryable().ElementType);
        mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(new List<Company>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Company>()).Returns(mockSet.Object);

        var companyRepository = new CompanyRepository(mockContext.Object);
        Expression<Func<Company, bool>> predicate = company => false;

        Assert.ThrowsException<NotFoundException>(() => companyRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredCompanies()
    {
        var testData = new List<Company>
        {
            new Company
            {
                Id = "1",
                Name = "Company1",
                Owner = new CompanyOwner { Id = "1", Name = "Owner1" }
            },
            new Company
            {
                Id = "2",
                Name = "Company2",
                Owner = new CompanyOwner { Id = "2", Name = "Owner2" }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Company>>();
        mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Company>()).Returns(mockSet.Object);

        var companyRepository = new CompanyRepository(mockContext.Object);

        var result = companyRepository.GetAll(c => c.Name == "Company1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Company1", result[0].Name);
    }
}
