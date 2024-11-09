using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers.Entities;

namespace Homify.DataAccess.Repositories.Importers;

public interface IImporterService
{
    public List<string> GetImporters(string path);
    public void AddImportedDevices(ImporterArgs args, User user);
}
