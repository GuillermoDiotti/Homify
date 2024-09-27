using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.HouseOwner;
using Homify.BusinessLogic.HouseOwner.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Users;

public class UserService : IUserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }

    public User AddUser(CreateUserArgs args)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = args.Name,
            Email = args.Email,
            CreatedAt = DateTime.Now,
            Password = args.Password,
            LastName = args.LastName,
        };

        _repository.Add(user);
        return user;
    }

    public CompanyOwner AddCompanyOwner(CreateUserArgs args)
    {
        var companyOwner = new CompanyOwner
        {
            Id = Guid.NewGuid().ToString(),
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            CreatedAt = DateTime.Now,
            IsIncomplete = true,
        };

        _repository.Add(companyOwner);
        return companyOwner;
    }

    public HomeOwner AddHomeOwner(CreateHomeOwnerArgs args)
    {
        var homeOwner = new HomeOwner
        {
            Id = Guid.NewGuid().ToString(),
            Email = args.Email,
            Name = args.Name,
            Password = args.Password,
            LastName = args.LastName,
            CreatedAt = DateTime.Now,
            ProfilePicture = args.ProfilePicUrl,
        };

        _repository.Add(homeOwner);
        return homeOwner;
    }

    public User GetById(string id)
    {
        return _repository.Get(x  => x.Id == id);
    }

    public List<User> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public void Delete(string userId)
    {
        var user = _repository.Get(x  => x.Id == userId);
        if (user != null)
        {
            _repository.Remove(user);
        }
    }
}
