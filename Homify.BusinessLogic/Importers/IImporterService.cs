using Homify.BusinessLogic.Importers.Entities;
using Homify.BusinessLogic.Users.Entities;
using InterfaceImporter;

namespace Homify.BusinessLogic.Importers;

public interface IImporterService
{
    public List<IImporter> GetAllImporters();
    public void AddImportedDevices(ImporterArgs args, User user);
}
