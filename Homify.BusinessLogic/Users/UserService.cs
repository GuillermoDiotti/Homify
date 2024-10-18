using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.BusinessLogic.Utility;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Users;

public class UserService : IUserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }

    public Admin AddAdmin(CreateUserArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var user = new Admin()
        {
            Id = Guid.NewGuid().ToString(),
            Name = args.Name,
            Email = args.Email,
            CreatedAt = HomifyDateTime.GetActualDate(),
            Password = args.Password,
            LastName = args.LastName,
            Role = args.Role,
        };

        _repository.Add(user);
        return user;
    }

    public CompanyOwner AddCompanyOwner(CreateUserArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var companyOwner = new CompanyOwner()
        {
            Id = Guid.NewGuid().ToString(),
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            CreatedAt = HomifyDateTime.GetActualDate(),
            IsIncomplete = true,
            Role = args.Role,
        };

        _repository.Add(companyOwner);
        return companyOwner;
    }

    public HomeOwner AddHomeOwner(CreateHomeOwnerArgs args)
    {
        ValidateEmailIsNotRepeated(args.Email);
        var homeOwner = new HomeOwner()
        {
            Id = Guid.NewGuid().ToString(),
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            CreatedAt = HomifyDateTime.GetActualDate(),
            ProfilePicture = args.ProfilePicUrl,
            Role = args.Role,
        };

        _repository.Add(homeOwner);
        return homeOwner;
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

    public List<User> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public void Delete(string userId)
    {
        User user;
        try
        {
            user = _repository.Get(x => x.Id == userId);
        }
        catch (NotFoundException)
        {
            user = null;
        }

        if (user != null)
        {
            _repository.Remove(user);
        }
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
