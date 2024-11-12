using System.Linq.Expressions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class CompanyOwnerServiceTests
{
    private Mock<IRepository<CompanyOwner>>? _repositoryMock;
    private CompanyOwnerService? _companyOwnerService;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<CompanyOwner>>();
        _companyOwnerService = new CompanyOwnerService(_repositoryMock.Object);
    }

    [TestMethod]
    public void GetById_ShouldReturnCompanyOwner_WhenIdExists()
    {
        var companyOwnerId = "owner1";
        var expectedCompanyOwner = new CompanyOwner { Id = companyOwnerId };
        _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<CompanyOwner, bool>>>()))
            .Returns(expectedCompanyOwner);

        var result = _companyOwnerService.GetById(companyOwnerId);

        Assert.IsNotNull(result);
        Assert.AreEqual(companyOwnerId, result.Id);
    }

    [TestMethod]
    public void GetCompOwnerPermissions()
    {
        var perms = PermissionsGenerator.GetCompanyOwnerPermissions();
        Assert.AreEqual(6, perms.Count);
    }
}
