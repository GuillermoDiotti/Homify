using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers.Entities;
using InterfaceImporter;

namespace Homify.BusinessLogic.Importers;

public interface IImporterService
{
    public List<ImporterInterface> GetAllImporters();
    public void AddImportedDevices(ImporterArgs args, User user);
}
