using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Importers.Entities;

public class ImporterArgs
{
    public string Importer { get; set; }
    public string Path { get; set; }
    public string DllPath { get; set; }

    public ImporterArgs(string importer, string path, string dllPath)
    {
        if (string.IsNullOrEmpty(importer))
        {
            throw new ArgsNullException("The index can not be null.");
        }

        Importer = importer;

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgsNullException("The path can not be null.");
        }

        Path = path;

        if (string.IsNullOrEmpty(dllPath))
        {
            throw new ArgsNullException("The path can not be null.");
        }

        DllPath = dllPath;
    }
}
