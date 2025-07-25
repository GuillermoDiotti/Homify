﻿using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.Users;

public sealed class UserService : IUserService
{
    private readonly IRepository<User> _repository;
    private readonly IRepository<UserRole> _userRolerepository;

    public UserService(IRepository<User> repository, IRepository<UserRole> userRolerepository)
    {
        _repository = repository;
        _userRolerepository = userRolerepository;
    }

    public Admin AddAdmin(CreateUserArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var user = new Admin()
        {
            Name = args.Name,
            Email = args.Email,
            Password = args.Password,
            LastName = args.LastName,
        };
        _repository.Add(user);

        LoadIntermediateTable(user.Id, Constants.ADMINISTRATORID);

        return user;
    }

    public CompanyOwner AddCompanyOwner(CreateUserArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var companyOwner = new CompanyOwner()
        {
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            IsIncomplete = true,
        };

        _repository.Add(companyOwner);

        LoadIntermediateTable(companyOwner.Id, Constants.COMPANYOWNERID);

        return companyOwner;
    }

    public HomeOwner AddHomeOwner(CreateHomeOwnerArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var homeOwner = new HomeOwner()
        {
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            ProfilePicture = args.ProfilePicUrl,
        };
        _repository.Add(homeOwner);

        LoadIntermediateTable(homeOwner.Id, Constants.HOMEOWNERID);

        return homeOwner;
    }

    public void LoadIntermediateTable(string userId, string roleId)
    {
        var userRole = new UserRole()
        {
            UserId = userId,
            RoleId = roleId,
        };
        _userRolerepository.Add(userRole);
    }

    public User? GetById(string id)
    {
        try
        {
            return _repository.Get(x => x.Id == id);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    public List<User> GetAll(string? role = null, string? name = null)
    {
        List<User> list = _repository.GetAll();

        if (!string.IsNullOrEmpty(role))
        {
            list = list.Where(u => u.Roles.Any(r => r.Role.Name.Contains(role, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        if (!string.IsNullOrEmpty(name))
        {
            list = list.Where(u => Helpers.GetUserFullName(u.Name, u.LastName)
                .Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return list;
    }

    public void Delete(string adminId)
    {
        var admin = _repository.Get(x => x.Id == adminId);
        if (admin == null)
        {
            throw new NotFoundException("Admin not found");
        }

        if (!admin.Roles.Any(r => r.Role.Name == Constants.ADMINISTRATOR))
        {
            throw new System.InvalidOperationException("Target user is not an admin");
        }

        if (admin.Roles.Count > 1)
        {
            throw new System.InvalidOperationException("Admins with more than one role cannot be deleted");
        }

        if (admin != null)
        {
            _repository.Remove(admin);
        }
    }

    public User UpdateProfilePicture(string pfp, User u)
    {
        if (u == null)
        {
            throw new NotFoundException("User not found");
        }

        if (!u.Roles.Any(x => x.Role.Name == Constants.HOMEOWNER))
        {
            throw new Exceptions.InvalidOperationException("User is not a homeowner");
        }

        u.ProfilePicture = pfp;
        _repository.Update(u);
        return u;
    }

    private void ValidateEmailIsNotRepeated(string email)
    {
        User? userWithRepeatedEmail;
        try
        {
            userWithRepeatedEmail = _repository.Get(user => user.Email == email);
        }
        catch (NotFoundException)
        {
            userWithRepeatedEmail = null;
        }

        if (userWithRepeatedEmail is not null)
        {
            throw new DuplicatedDataException("A user with this email already exists");
        }
    }
}
