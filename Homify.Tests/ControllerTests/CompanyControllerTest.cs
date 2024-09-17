using Homify.BusinessLogic.Users;
using Homify.WebApi.Controllers.Admins;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class CompanyControllerTest
{
    [TestMethod]
    public void Create_WhenDataIsOk_ShouldCreateCompany()
    {
        var request = CreateCompanyRequest();
        var expected = new Company();

        var response = _controller.Create(request);

        response.Should().NotBeNull();
        response.Id.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();
        response.Id.Should().Be(expected.Id);
    }
}
