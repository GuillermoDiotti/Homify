using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

public class NotificationServiceTest
{
    private Mock<IRepository<Notification>>? _mockRepository;
    private NotificationService? _homeUserService;
    private Mock<IHomeDeviceService>? _mockHomeDeviceService;
    private Mock<IHomeUserService>? _mockHomeUserService;

    [TestInitialize]
    public void Setup()
    {
        _mockHomeDeviceService = new Mock<IHomeDeviceService>();
        _mockRepository = new Mock<IRepository<Notification>>();
        _mockHomeUserService = new Mock<IHomeUserService>();
        _homeUserService = new NotificationService(_mockRepository.Object, _mockHomeDeviceService.Object, _mockHomeUserService.Object);
    }
}
