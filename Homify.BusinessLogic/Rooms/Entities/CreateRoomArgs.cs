using Homify.BusinessLogic.HomeOwners;
using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class CreateRoomArgs
{
    public readonly string HomeId;
    public readonly string Name;

    public CreateRoomArgs(string homeId, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Name can not be null");
        }

        if (string.IsNullOrEmpty(homeId))
        {
            throw new NullReferenceException("HomeId can not be null");
        }

        HomeId = homeId;
        Name = name;
    }
}
