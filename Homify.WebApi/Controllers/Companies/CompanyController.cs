using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.Utility;
using Homify.WebApi.Controllers.Companies.Models;
using Homify.WebApi.Controllers.Companies.Models.Requests;
using Homify.WebApi.Controllers.Companies.Models.Responses;
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
        Helpers.ValidateRequest(request);

        var userLogged = GetUserLogged();

        var companyOwner = userLogged as CompanyOwner;

        var args = new CreateCompanyArgs(
            request.Name ?? string.Empty,
            request.LogoUrl ?? string.Empty,
            request.Rut ?? string.Empty,
            request.Validator ?? string.Empty,
            companyOwner);

        var company = _companyService.Add(args, companyOwner!);

        return new CreateCompanyResponse(company);
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetCompanies)]
    public List<CompanyBasicInfo> AllCompanies([FromQuery] CompanyFiltersRequest? req)
    {
        var pageSize = Helpers.ValidatePaginationLimit(req.Limit);
        var pageOffset = Helpers.ValidatePaginatioOffset(req.Offset);

        return _companyService
            .GetAll(req.OwnerFullName, req.Company)
            .Skip(pageOffset)
            .Take(pageSize)
            .Select(m => new CompanyBasicInfo(m, m.Owner))
            .ToList();
    }

    [HttpPut("validators")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateCompany)]
    public AddValidatorBasicInfo UpdateCompanyValidator(AddValidatorBasicInfo req)
    {
        var user = GetUserLogged();
        var resp = _companyService.AddValidatorModel(req.Model ?? string.Empty, user);
        return new AddValidatorBasicInfo(/*resp*/);
    }
}
