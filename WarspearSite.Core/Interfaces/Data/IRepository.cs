using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Core.Interfaces.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task Update(T enties);
        Task Remove(T entity);
        Task<T> GetById(Guid id);
        IQueryable<T> Get();
        Task<T> GetByIdWithIncludes(Guid Id,
            params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate,
           params Expression<Func<T, object>>[] includes);
    }
}
