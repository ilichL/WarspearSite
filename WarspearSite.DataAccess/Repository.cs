using Microsoft.EntityFrameworkCore;
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

        public async Task FindById(Guid id)
        {
            await _entities.FirstOrDefaultAsync( entity
                => entity.Id == id);
        }

        public async 

    }
}
