using System.Net;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Companies.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Companies;

[ApiController]
[Route("companies")]
public class CompanyController : HomifyControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateCompany)]
    public CreateCompanyResponse Create(CreateCompanyRequest request)
    {
        // TODO: verificar que no tenga una empresa ya creada

        if (request == null)
        {
            throw new NullRequestException();
        }

        var userLogged = GetUserLogged();

        var companyOwner = userLogged as CompanyOwner;

        if (companyOwner == null)
        {
            throw new InvalidOperationException("Only a CompanyOwner can create a company.");
        }

        if (!companyOwner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be incomplete to execute this action.");
        }

        var args = new CreateCompanyArgs(
            request.Name ?? string.Empty,
            request.LogoUrl ?? string.Empty,
            request.Rut ?? string.Empty
        );

        var company = _companyService.Add(args, companyOwner);

        return new CreateCompanyResponse(company);
    }
}
