using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Importers.Entities;

public class ImporterArgs
{
    public string Importer { get; set; }
    public string Path { get; set; }
    public User User { get; set; }

    public ImporterArgs(string importer, string path, User user)
    {
        if (string.IsNullOrEmpty(importer))
        {
            throw new ArgsNullException("The importer can not be null.");
        }

        Importer = importer;

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgsNullException("The path can not be null.");
        }

        Path = path;

        User = user;

        // if (string.IsNullOrEmpty(dllPath))
        // {
        //     throw new ArgsNullException("The path can not be null.");
        // }

        // DllPath = dllPath;
    }
}
