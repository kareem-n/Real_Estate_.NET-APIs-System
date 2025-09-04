using Pro.Domain.Interfaces.Specifications;
using Pro.Domain.Models;

namespace Pro.Domain.Interfaces.Repos
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(IBaseSpecification<T> baseSpecification = default!);

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(IProjectionSpecification<T, TResult> projectionSpecification) where TResult : class;

        Task AddAsync(T entity);


    }
}
