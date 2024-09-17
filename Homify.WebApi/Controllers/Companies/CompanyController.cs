using Homify.BusinessLogic.Companies;
using Homify.WebApi.Controllers.Companies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Companies;

[ApiController]
[Route("companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost]
    public CreateCompanyResponse Create(CreateCompanyRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        var args = new CreateCompanyArgs(request.Name ?? string.Empty, request.LogoUrl ?? string.Empty,
            request.Rut ?? string.Empty);

        var company = _companyService.Add(args);
        return new CreateCompanyResponse(company);
    }
}
