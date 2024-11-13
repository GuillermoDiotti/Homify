using System.Linq.Expressions;
using Homify.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public readonly DbSet<TEntity> _entities;

    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public bool Exist(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.Any(predicate);
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);

        _context.SaveChanges();
    }

    public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return _entities.ToList();
        }

        return _entities.Where(predicate).ToList();
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _entities.FirstOrDefault(predicate);

        if (entity == null)
        {
            throw new InvalidOperationException($"Entity {typeof(TEntity).Name} not found");
        }

        return entity;
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);

        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);

        _context.SaveChanges();
    }
}
