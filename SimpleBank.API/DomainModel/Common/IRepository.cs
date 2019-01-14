using System;
using System.Linq;
using System.Linq.Expressions;


namespace SimpleBank.API.DomainModel.Common
{
    public interface IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        TEntity GetById(params object[] keys);
    }
}
