using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.Exceptions;
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
        if (request == null)
        {
            throw new NullRequestException();
        }

        var userLogged = GetUserLogged();

        var companyOwner = userLogged as CompanyOwner;

        var args = new CreateCompanyArgs(
            request.Name ?? string.Empty,
            request.LogoUrl ?? string.Empty,
            request.Rut ?? string.Empty,
            companyOwner);

        var company = _companyService.Add(args, companyOwner!);

        return new CreateCompanyResponse(company);
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetCompanies)]
    public List<CompanyBasicInfo> AllCompanies([FromQuery] CompanyFiltersRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var pageSize = 10;
        var pageOffset = 0;

        if (!string.IsNullOrEmpty(req.Limit) && int.TryParse(req.Limit, out var parsedLimit))
        {
            pageSize = parsedLimit > 0 ? parsedLimit : pageSize;
        }

        if (!string.IsNullOrEmpty(req.Offset) && int.TryParse(req.Offset, out var parsedOffset))
        {
            pageOffset = parsedOffset >= 0 ? parsedOffset : pageOffset;
        }

        var list = _companyService.GetAll();

        if (!string.IsNullOrEmpty(req.OwnerFullName))
        {
            list = list.Where(c => Helpers.GetUserFullName(c.Owner.Name, c.Owner.LastName)
                .Contains(req.OwnerFullName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(req.Company))
        {
            list = list.Where(c => c.Name.Contains(req.Company, StringComparison.OrdinalIgnoreCase)).ToList();
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
