using System.Linq.Expressions;

namespace Homify.BusinessLogic;

public interface IRepository<TEntity>
    where TEntity : class
{
    bool Exist(Expression<Func<TEntity, bool>> expression);

    void Add(TEntity entity);

    List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null);

    TEntity Get(Expression<Func<TEntity, bool>> predicate);

    void Remove(TEntity entity);

    void Update(TEntity entity);
}
