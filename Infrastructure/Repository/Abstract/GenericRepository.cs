using DomainModel.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Abstract
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected BusinessModelContext Context { get; private set; }

        protected readonly DbSet<TEntity> dbSet;
        public GenericRepository(BusinessModelContext BusinessDBContext)
        {
            Context = BusinessDBContext;
            dbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query => dbSet;

        public bool Exists(Expression<Func<TEntity, bool>> selector = null)
        {
            if (selector == null)
            {
                return dbSet.Any();
            }
            else
            {
                return dbSet.Any(selector);
            }
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }
    }
}
