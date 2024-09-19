using Homify.BusinessLogic.Homes.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
}
