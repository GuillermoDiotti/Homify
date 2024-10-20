using Homify.BusinessLogic.HomeOwners;
using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class CreateRoomArgs
{
    public readonly string HomeId;

    public CreateRoomArgs(string homeId)
    {
        if (string.IsNullOrEmpty(homeId))
        {
            throw new NullReferenceException("HomeId can not be null");
        }

        HomeId = homeId;
    }
}
