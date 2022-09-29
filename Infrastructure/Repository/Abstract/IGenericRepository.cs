using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        bool Exists(Expression<Func<TEntity, bool>> selector = null);
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query { get; }
    }
}
