using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace digitalwedding.Infrastructure.Data.Repositories
{
    public class Repository<TContext, T> : IRepository<T> where T : Base where TContext : DbContext
    {
        protected readonly TContext _dbContext;

        public Repository(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual IQueryable<T> Entity => _dbContext.Set<T>();

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Update(entity);

            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            var dbEntities = entities.ToList();

            dbEntities.ForEach(c =>
            {
                c.CreatedAt = DateTime.UtcNow;
                c.UpdatedAt = DateTime.UtcNow;
            });

            _dbContext.Set<T>().AddRange(dbEntities);
        }
    }
}

