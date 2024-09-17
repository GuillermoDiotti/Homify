using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var arguments = new CreateUserArgs(
            request.Name ?? string.Empty,
            request.Email ?? string.Empty,
            request.Password ?? string.Empty,
            request.LastName ?? string.Empty);

        var administratorSaved = _userService.AddUser(arguments);

        return new CreateAdminResponse(administratorSaved);
    }

    [HttpDelete("{adminId}")]
    public void Delete(string adminId)
    {
        var admin = _userService.GetById(adminId);
        if (admin == null)
        {
            throw new NotFoundException("Admin not found");
        }
        else
        {
            _userService.Delete(adminId);
        }
    }

    [HttpGet]
    public List<UserBasicInfo> AllAccounts([FromQuery] string limit, [FromQuery] string offset)
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

        List<User> list = _userService.GetAll();
        List<User> paginatedList = list.Skip(pageOffset).Take(pageSize).ToList();

        List<UserBasicInfo> result = new ();
        foreach (User u in paginatedList)
        {
            result.Add(new UserBasicInfo(u));
        }

        return result;
    }

    public User GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new NotFoundException("Admin not found");
        }

        return _userService.GetById(id);
    }
}
