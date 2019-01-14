using SimpleBank.API.DomainModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, IAggregateRoot
    {
        DbContext dbContext;

        public RepositoryBase(BankDbContext bankDbContext)
        {
            this.dbContext = bankDbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        private void DetachIfExist(TEntity entity)
        {
            var entityAtachedWithSomeKey = DbSet.Local.FirstOrDefault(item => item.Id.Equals(entity.Id));

            if (entityAtachedWithSomeKey != null)
                dbContext.Entry(entityAtachedWithSomeKey).State = EntityState.Detached;
        }

        private DbSet<TEntity> DbSet;

        public DbSet<TEntity> GetDbSet()
        {
            return DbSet;
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            dbContext.SaveChanges();

        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {

            DetachIfExist(entity);

            DbSet.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;

            dbContext.SaveChanges();

            DetachIfExist(entity);
        }

        public IQueryable<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(params object[] keys)
        {
            return DbSet.Find(keys);
        }
    }
}
