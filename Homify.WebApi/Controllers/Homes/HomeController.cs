using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Homes.Entities;
using Homify.WebApi.Controllers.Homes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Homes;

[ApiController]
[Route("homes")]
public sealed class HomeController : ControllerBase
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    [HttpPost]
    public CreateHomeResponse Create(CreateHomeRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var arguments = new CreateHomeArgs(
           request.Street ?? string.Empty, request.Number ?? string.Empty, request.Latitude ?? string.Empty,
           request.Longitud ?? string.Empty, request.MaxMembers ?? string.Empty);

        // string.Empty, request.Number ?? string.Empty, request.Latitude ?? string.Empty,
        //    request.Longitud ?? string.Empty, request.MaxMembers ?? string.Empty);

        var home = new Home
        {
            Street = arguments.Street,
            Number = arguments.Number,
            Latitude = arguments.Latitude,
            Longitude = arguments.Longitude,
            MaxMembers = arguments.MaxMembers
        };

        // _homes.Add(home);
        return new CreateHomeResponse(home);
    }

}
