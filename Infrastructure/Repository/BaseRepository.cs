using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    abstract public class BaseRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id, cancellationToken);
            if (entity is null)
                throw new NotFoundException($"{typeof(T).Name} {id} not found");
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T existingEntity,T entity, CancellationToken cancellationToken) //TODO: ID через URL должен быть
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            return entity;
        }

        public virtual async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            var trackedEntity = _dbContext.Set<T>().Local.FirstOrDefault(e => e == entity);
            if (trackedEntity == null)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Set<T>().Remove(entity);
            return entity;
        }
    }
}
