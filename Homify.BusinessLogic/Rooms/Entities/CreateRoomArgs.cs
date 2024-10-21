using Homify.BusinessLogic.HomeOwners;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class CreateRoomArgs
{
    public readonly string Name;
    public readonly string HomeId;
    public readonly HomeOwner Owner;

    public CreateRoomArgs(string name, string homeId, HomeOwner? owner)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Name can not be null");
        }

        if (string.IsNullOrEmpty(homeId))
        {
            throw new NullReferenceException("HomeId can not be null");
        }

        if (owner == null)
        {
            throw new NullReferenceException("Owner can not be null");
        }

        Name = name;
        HomeId = homeId;
        Owner = owner;
    }
}
