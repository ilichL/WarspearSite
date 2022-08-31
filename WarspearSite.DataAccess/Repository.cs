using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WarspearSite.Core.Interfaces.Data;
using WarspesrSite.Data;
using WarspesrSite.Data.Entity;

namespace WarspearSite.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Context context;
        private readonly DbSet<T> _entities;

        public Repository(Context context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public async Task Update(T enties)
        {
            _entities.Update(enties);
        }

        public async Task Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<T> GetById(Guid id)
        {
             return await _entities.FirstOrDefaultAsync( entity
                => entity.Id == id);
        }

        public virtual IQueryable<T> Get()
        {
            return _entities;
        }

        public async Task<T> GetByIdWithIncludes(Guid Id,
            params Expression<Func<T, object>>[] includes)
        {
            if (includes.Any())
            {
                return await includes.Aggregate(_entities.Where(entity => entity.Id.Equals(Id)),
                    (current, include) => current.Include(include)).FirstOrDefaultAsync();
            }
            return await GetById(Id);
        }

        public virtual async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate,
           params Expression<Func<T, object>>[] includes)
        {
            var result = _entities.Where(predicate);

            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }
            return result;
        }
    }
}
