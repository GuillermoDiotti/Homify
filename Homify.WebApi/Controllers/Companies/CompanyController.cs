using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
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
        if (request == null)
        {
            throw new NullRequestException();
        }

        var nameExists = _companyService.GetAll().Any(x => x.Name == request.Name);

        if (nameExists)
        {
            throw new DuplicatedDataException("The name is already taken.");
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

        var alreadyHasACompany = _companyService.GetByUserId(userLogged.Id);

        if (alreadyHasACompany != null)
        {
            throw new InvalidOperationException("User already owns a company");
        }

        var args = new CreateCompanyArgs(
            request.Name ?? string.Empty,
            request.LogoUrl ?? string.Empty,
            request.Rut ?? string.Empty
        );

        var company = _companyService.Add(args, companyOwner);

        return new CreateCompanyResponse(company);
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetCompanies)]
    public List<CompanyBasicInfo> AllCompanies([FromQuery] string? limit, [FromQuery] string? offset,
        [FromQuery] string? ownerFullName, [FromQuery] string? company)
    {
        var pageSize = 10;
        var pageOffset = 0;

        if (!string.IsNullOrEmpty(limit) && int.TryParse(limit, out var parsedLimit))
        {
            pageSize = parsedLimit > 0 ? parsedLimit : pageSize;
        }

        if (!string.IsNullOrEmpty(offset) && int.TryParse(offset, out var parsedOffset))
        {
            pageOffset = parsedOffset >= 0 ? parsedOffset : pageOffset;
        }

        var list = _companyService.GetAll();

        if (!string.IsNullOrEmpty(ownerFullName))
        {
            list = list.Where(c => Helpers.GetUserFullName(c.Owner.Name, c.Owner.LastName)
                .Contains(ownerFullName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(company))
        {
            list = list.Where(c => c.Name.Contains(company, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var paginatedList = list.Skip(pageOffset).Take(pageSize).ToList();

        List<CompanyBasicInfo> result = [];
        foreach (Company c in paginatedList)
        {
            result.Add(new CompanyBasicInfo(c, c.Owner));
        }

        return result;
    }
}
