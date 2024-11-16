using Homify.BusinessLogic.Importers.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Importer.Abstractions;
using ModeloValidador.Abstracciones;

namespace Homify.BusinessLogic.Importers;

public interface IImporterService
{
    public List<IImporter> GetAllImporters();
    public void AddImportedDevices(ImporterArgs args, User user);
    public List<IModeloValidador> GetAllValidators();
}
