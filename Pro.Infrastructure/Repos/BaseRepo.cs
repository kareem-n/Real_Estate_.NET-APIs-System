using Microsoft.EntityFrameworkCore;
using Pro.Domain.Interfaces.Repos;
using Pro.Domain.Interfaces.Specifications;
using Pro.Domain.Models;
using Pro.Infrastructure.Data;
using Pro.Infrastructure.Extenstions;

namespace Pro.Infrastructure.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;


        public BaseRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllAsync(IBaseSpecification<T> baseSpecification = default!)
        {
            var q = _dbSet.AsQueryable().AsNoTracking();

            if (baseSpecification != null)
                q = q.EvaluateQuery<T>(baseSpecification);

            return await q.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(IProjectionSpecification<T, TResult> projectionSpecification) where TResult : class
        {
            if (projectionSpecification == null)
            {
                throw new ArgumentNullException(nameof(projectionSpecification), "Projection specification cannot be null");
            }
            return await _dbSet.AsNoTracking().AsQueryable()
                .EvaluateQuery(projectionSpecification)
                .ToListAsync();
        }
    }
}
