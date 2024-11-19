using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices.Entities;
using ModeloValidador.Abstracciones;

namespace Homify.BusinessLogic.Companies.Entities;

public class Company
{
    [NotMapped]
    private IModeloValidador _validator = null!;
    public string ValidatorType { get; set; } = string.Empty;
    public string Id { get; init; }
    public CompanyOwner Owner { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string Rut { get; set; } = null!;

    public List<Device> Devices { get; set; } = [];

    public string OwnerId { get; set; } = null!;

    public Company()
    {
        Id = Guid.NewGuid().ToString();
        LoadValidator();
    }

    private void LoadValidator()
    {
        var rutaDll = "./Validators";
        var filePaths = Directory.GetFiles(rutaDll, $"{ValidatorType}.dll");

        foreach (var file in filePaths)
        {
            if (File.Exists(file))
            {
                var dllFile = new FileInfo(file);
                var myAssembly = Assembly.LoadFile(dllFile.FullName);

                foreach (Type type in myAssembly.GetTypes())
                {
                    if (ImplementsRequiredInterface<IModeloValidador>(type))
                    {
                        var instance = (IModeloValidador)Activator.CreateInstance(type);
                        if (instance != null)
                        {
                            _validator = instance;
                            return;
                        }
                    }
                }
            }
        }
    }

    public void ValidateModel(string model)
    {
        LoadValidator();

        if (_validator == null)
        {
            throw new InvalidDataException($"Validator {ValidatorType} not found.");
        }

        if (!_validator.EsValido(new Modelo(model)))
        {
            throw new InvalidDataException($"Model does not match {ValidatorType} validation.");
        }
    }

    private bool ImplementsRequiredInterface<T>(Type type)
    {
        return typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;
    }
}
