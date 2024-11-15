using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
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
        if (string.IsNullOrEmpty(ValidatorType))
        {
            throw new InvalidOperationException("Validator type is not defined.");
        }

        var rutaDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib", "ModeloValidador.dll");

        if (!File.Exists(rutaDll))
        {
            throw new FileNotFoundException("Validator's dll file not found.");
        }

        var assembly = Assembly.LoadFrom(rutaDll);

        Type tipoValidador = assembly.GetType(ValidatorType);

        if (tipoValidador == null)
        {
            throw new InvalidOperationException("Could not find a IModeloValidador implementation.");
        }

        if (!typeof(IModeloValidador).IsAssignableFrom(tipoValidador))
        {
            throw new InvalidOperationException($"Type {ValidatorType} does not implement IModeloValidador.");
        }

        _validator = (IModeloValidador)Activator.CreateInstance(tipoValidador)!;
    }

    public void ValidateModel(string model)
    {
        if (!_validator.EsValido(new Modelo(model)))
        {
            throw new InvalidDataException($"Model does not match {ValidatorType} validation.");
        }
    }
}
