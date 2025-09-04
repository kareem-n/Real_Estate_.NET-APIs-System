using System.Linq.Expressions;
using Pro.Domain.Models;

namespace Pro.Domain.Interfaces.Specifications
{
    public interface IProjectionSpecification<T, TResult> : IBaseSpecification<T>
        where T : BaseEntity
        where TResult : class
    {
        Expression<Func<T, TResult>> Projection { get; set; }

    }
}
