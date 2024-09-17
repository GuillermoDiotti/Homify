namespace Homify.BusinessLogic.Companies;

public class Company
{
    public string Id { get; init; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string Rut { get; set; } = null!;

    public Company(string name, string logourl, string rut)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        LogoUrl = logourl;
        Rut = rut;
    }

    public Company()
    {
        Id = Guid.NewGuid().ToString();
    }
}
